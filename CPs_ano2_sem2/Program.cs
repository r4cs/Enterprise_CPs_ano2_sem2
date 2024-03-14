using System.Threading.Tasks;

namespace CPs_ano2_sem2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                Menu menu = new Menu();
                await menu.RunMenu();
            }).GetAwaiter().GetResult();
        }
    }
}