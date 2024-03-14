    using System;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    
namespace CPs_ano2_sem2
{
    public class Menu
    {
        public async Task RunMenu()
        {
            string userInput;
            var crawler = new Crawler();

            do
            {
                Console.WriteLine("Insira a url do jogo (ou 'sair' para sair):");
                userInput = Console.ReadLine();
                if (!Regex.IsMatch(userInput,  @"^(https?:\/\/)?(www\.)?metacritic\.com\/game\/[a-zA-Z0-9_-]+"))
                {
                    Console.WriteLine("Você deve inserir uma url válida do metecritic games!");
                }

                if (userInput?.ToLower() != "sair")
                {
                    string gameUrl = $"{userInput}";
                    bool gameFound = await crawler.CheckGameExistence(gameUrl);

                    if (!gameFound)
                    {
                        Console.WriteLine("Jogo não encontrado. Por favor, tente novamente.");
                    }
                    else
                    {
                        await crawler.GetGameRatingAsync(gameUrl);
                    }
                }

            } while (userInput?.ToLower() != "sair");
        }
    }
}