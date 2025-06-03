using TVShow.Core.Services;
using TVShow.Data;

namespace TVShow.ConsoleApp
{
    public class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            var context = new TVShowDbContext();

            var view = new View(new ShowService(context), new ContestantService(context),
               new QuizService(context), new QuestionService(context));

            await view.RunAsync();
        }
    }
}