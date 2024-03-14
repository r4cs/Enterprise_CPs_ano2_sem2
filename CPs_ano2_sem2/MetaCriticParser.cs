namespace CPs_ano2_sem2
{
    public static class MetaCriticParser
    {
        public class CriticRating
        {
            private string Title { get; }
            private int MetaScore { get; }
            private float UserScore { get; }

            public CriticRating(string title, int metaScore, float userScore)
            {
                Title = title;
                MetaScore = metaScore;
                UserScore = userScore;
            }

            public override string ToString()
            {
                return $"Title: {Title}, MetaScore: {MetaScore}, UserScore: {UserScore}";
            }
        }
            public static (int, float) ParseScores(string metaScore, string userScore)
            {
                var parsedMetaScore = int.TryParse(metaScore, out var metaResult) ? metaResult : -1;

                float parsedUserScore;
                // Tenta analisar como um número de ponto flutuante (float)
                if (float.TryParse(userScore, out var floatUserScore))
                {
                    parsedUserScore = floatUserScore;
                }
                // Se a análise como float falhar, tenta analisar como um número inteiro (int)
                else if (int.TryParse(userScore, out var intUserScore))
                {
                    parsedUserScore = intUserScore;
                }
                // Se ambas as análises falharem, atribui -1
                else
                {
                    parsedUserScore = -1;
                }

                return (parsedMetaScore, parsedUserScore);
            }
    }
}