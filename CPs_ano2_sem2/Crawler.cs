using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace CPs_ano2_sem2
{
    public class Crawler
    {
        private readonly HttpClient _client;

        public Crawler()
        {
            _client = new HttpClient();
        }

        public async Task<bool> CheckGameExistence(string url)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Erro ao acessar a URL: {url}");
                return false;
            }

            var content = await response.Content.ReadAsStringAsync();
            var doc = new HtmlDocument();
            doc.LoadHtml(content);

            var errorMessageNode = doc.DocumentNode.HasClass("c-error404");
            if (errorMessageNode)
            {
                Console.WriteLine("Jogo não encontrado. Por favor, tente novamente.");
                return false;
            }
            else
            {
                await GetGameRatingAsync(url);
                return true;
            }
        }
        
        public async Task<MetaCriticParser.CriticRating> GetGameRatingAsync(string url)
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var doc = new HtmlDocument();
            doc.LoadHtml(content);

            var titleNode = doc.DocumentNode.SelectSingleNode(
                "//*[@id=\"__layout\"]/div/div[2]/div[1]/div[1]/div/div/div[2]/div[3]/div[1]/div"
            );
            var metaScoreNode = doc.DocumentNode.SelectSingleNode(
                "//*[@id=\"__layout\"]/div/div[2]/div[1]/div[1]/div/div/div[2]/div[3]/div[4]/div[1]/div/div[1]/div[2]/div/div/span"
            );
            var userScoreNode = doc.DocumentNode.SelectSingleNode(
                "//*[@id=\"__layout\"]/div/div[2]/div[1]/div[1]/div/div/div[2]/div[3]/div[4]/div[2]/div[1]/div[2]/div/div/span"
            );

            var title = titleNode?.InnerText?.Trim();
            var metaScore = metaScoreNode?.InnerText?.Trim();
            var userScore = userScoreNode?.InnerText?.Trim();

            var parsedScores = MetaCriticParser.ParseScores(metaScore, userScore);
            var parsedMetaScore = parsedScores.Item1;
            var parsedUserScore = parsedScores.Item2;

            var criticRating = new MetaCriticParser.CriticRating(title, parsedMetaScore, parsedUserScore);

            Console.WriteLine(criticRating.ToString());

            return criticRating;
        }
    }
}