using Microsoft.Extensions.Options;
using MoneyQuiz.Core;
using MoneyQuiz.Data;
using System.Text;

namespace MoneyQuiz.ConsoleApp
{
    public class StartUp
    {
        static async Task Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            var context = new MoneyQuizDbContext();

            var questionService = new QuestionService(context);
            var answerService = new AnswerService(context);
            var lifelineService = new LifelineService(context);
            var playerService = new PlayerService(context);

            while (true)
            {
                Console.WriteLine("\nMoney Quiz Console App Menu:");
                Console.WriteLine("1. Add Question");
                Console.WriteLine("2. Add 4 Answers to Question");
                Console.WriteLine("3. Edit Question");
                Console.WriteLine("4. Edit Answer");
                Console.WriteLine("5. Delete Lifeline");
                Console.WriteLine("6. Add Player");
                Console.WriteLine("7. Show Questions With Amount > 3000");
                Console.WriteLine("8. Show All Questions With Answers");
                Console.WriteLine("9. Show Questions And Correct Answers For Amount");
                Console.WriteLine("0. Exit");

                Console.Write("Select option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter question text: ");
                        var text = Console.ReadLine();
                        Console.Write("Enter amount: ");
                        var amount = decimal.Parse(Console.ReadLine());
                        await questionService.AddQuestionAsync(text, amount);
                        break;

                    case "2":
                        Console.Write("Enter question ID: ");
                        var qid = int.Parse(Console.ReadLine());
                        for (int i = 1; i <= 4; i++)
                        {
                            Console.Write($"Answer {i} text: ");
                            var atext = Console.ReadLine();
                            Console.Write($"Is answer {i} correct (true/false): ");
                            var correct = bool.Parse(Console.ReadLine());
                            await answerService.AddAnswerAsync(qid, atext, correct);
                        }
                        break;

                    case "3":
                        Console.Write("Enter question ID: ");
                        var qeditId = int.Parse(Console.ReadLine());
                        Console.Write("New question text: ");
                        var newQText = Console.ReadLine();
                        Console.Write("New amount: ");
                        var newAmount = decimal.Parse(Console.ReadLine());
                        await questionService.UpdateQuestionAsync(qeditId, newQText, newAmount);
                        break;

                    case "4":
                        Console.Write("Enter answer ID: ");
                        var aid = int.Parse(Console.ReadLine());
                        Console.Write("New answer text: ");
                        var newAText = Console.ReadLine();
                        Console.Write("Is correct (true/false): ");
                        var isCorrect = bool.Parse(Console.ReadLine());
                        await answerService.UpdateAnswerAsync(aid, newAText, isCorrect);
                        break;

                    case "5":
                        Console.Write("Enter lifeline ID to delete: ");
                        var lid = int.Parse(Console.ReadLine());
                        await lifelineService.DeleteLifelineAsync(lid);
                        break;

                    case "6":
                        Console.Write("Enter player name: ");
                        var pname = Console.ReadLine();
                        Console.Write("Enter player email: ");
                        var pemail = Console.ReadLine();
                        await playerService.AddPlayerAsync(pname, pemail);
                        break;

                    case "7":
                        var richQuestions = await questionService.GetQuestionsAboveAmountAsync(3000);
                        foreach (var q in richQuestions)
                            Console.WriteLine(q.QuestionText);
                        break;

                    case "8":
                        var allQ = await questionService.GetAllQuestionsAsync();
                        foreach (var q in allQ)
                        {
                            Console.WriteLine($"Question: {q.QuestionText}");
                            foreach (var a in q.Answers)
                                Console.WriteLine($" - {a.AnswerText}");
                        }
                        break;

                    case "9":
                        Console.Write("Enter amount: ");
                        var amt = decimal.Parse(Console.ReadLine());
                        var qWithCorrectAnswers = await questionService
                            .GetQuestionsByAmountWithCorrectAnswersAsync(amt);
                        foreach (var q in qWithCorrectAnswers)
                        {
                            Console.WriteLine($"Question: {q.QuestionText}");
                            foreach (var a in q.Answers.Where(a => a.IsCorrect))
                                Console.WriteLine($" -> Correct Answer: {a.AnswerText}");
                        }
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }

        }
    }
}
