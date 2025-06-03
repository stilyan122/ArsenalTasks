using TVShow.Core.Services;
using TVShow.Data.Models;

namespace TVShow.ConsoleApp
{
    public class View
    {
        private readonly ShowService _showService;
        private readonly ContestantService _contestantService;
        private readonly QuizService _quizService;
        private readonly QuestionService _questionService;
        public View(
            ShowService showService,
            ContestantService contestantService,
            QuizService quizService,
            QuestionService questionService)
        {
            _showService = showService;
            _contestantService = contestantService;
            _quizService = quizService;
            _questionService = questionService;
        }

        public async Task RunAsync()
        {
            bool exitRequested = false;

            while (!exitRequested)
            {
                Console.Clear();
                Console.WriteLine("==== TV Quiz Management ====");
                Console.WriteLine("1) Създаване на ново телевизионно предаване");
                Console.WriteLine("2) Добавяне на участник");
                Console.WriteLine("3) Добавяне на викторина към предаване");
                Console.WriteLine("4) Добавяне на въпрос към викторина");
                Console.WriteLine("5) Преглед на съществуващи предавания");
                Console.WriteLine("6) Преглед на съществуващи участници");
                Console.WriteLine("7) Преглед на викторини");
                Console.WriteLine("8) Преглед на въпроси");
                Console.WriteLine("9) Присвояване на участник към предаване");
                Console.WriteLine("10) Премахване на участник от предаване");
                Console.WriteLine("0) Изход");
                Console.Write("Вашият избор: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        await CreateShowAsync();
                        break;
                    case "2":
                        await CreateContestantAsync();
                        break;
                    case "3":
                        await CreateQuizAsync();
                        break;
                    case "4":
                        await CreateQuestionAsync();
                        break;
                    case "5":
                        await ListShowsAsync();
                        break;
                    case "6":
                        await ListContestantsAsync();
                        break;
                    case "7":
                        await ListQuizzesAsync();
                        break;
                    case "8":
                        await ListQuestionsAsync();
                        break;
                    case "9":
                        await AssignContestantToShowAsync();
                        break;
                    case "10":
                        await RemoveContestantFromShowAsync();
                        break;
                    case "0":
                        exitRequested = true;
                        break;
                    default:
                        Console.WriteLine("Невалиден избор. Натиснете Enter, за да опитате отново.");
                        Console.ReadLine();
                        break;
                }
            }

            Console.WriteLine("Изход от приложението. Довиждане!");
        }

        private async Task CreateShowAsync()
        {
            Console.Clear();
            Console.WriteLine("=== Създаване на ново телевизионно предаване ===");

            Console.Write("Име: ");
            var name = Console.ReadLine();

            Console.Write("Дата на излъчване (формат YYYY-MM-DD или празно за липсваща): ");
            var dateInput = Console.ReadLine();
            DateTime? airDate = null;
            if (!string.IsNullOrWhiteSpace(dateInput))
            {
                if (DateTime.TryParse(dateInput, out var parsedDate))
                    airDate = parsedDate;
                else
                {
                    Console.WriteLine("Невалиден формат на дата. Операцията се отказва. Натиснете Enter.");
                    Console.ReadLine();
                    return;
                }
            }

            Console.Write("Описание (по избор): ");
            var description = Console.ReadLine();

            var show = new Show
            {
                Name = name,
                AirDate = airDate,
                Description = description
            };

            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(show);
            var validationResults = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();
            bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(show, validationContext, validationResults, true);

            if (!isValid)
            {
                Console.WriteLine("Грешки при валидация:");
                foreach (var vr in validationResults)
                {
                    Console.WriteLine($" - {vr.ErrorMessage}");
                }
                Console.WriteLine("Натиснете Enter, за да се върнете в менюто.");
                Console.ReadLine();
                return;
            }

            try
            {
                await _showService.AddAsync(show);
                Console.WriteLine("Успешно създадено ново предаване! Натиснете Enter.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка при създаване: {ex.Message}");
            }

            Console.ReadLine();
        }

        private async Task CreateContestantAsync()
        {
            Console.Clear();
            Console.WriteLine("=== Добавяне на участник ===");

            Console.Write("Име и фамилия: ");
            var fullName = Console.ReadLine();

            Console.Write("Възраст (число или празно за пропуск): ");
            var ageInput = Console.ReadLine();
            int? age = null;
            if (!string.IsNullOrWhiteSpace(ageInput))
            {
                if (int.TryParse(ageInput, out var parsedAge))
                    age = parsedAge;
                else
                {
                    Console.WriteLine("Невалидна възраст. Операцията се отказва. Натиснете Enter.");
                    Console.ReadLine();
                    return;
                }
            }

            Console.Write("Имейл (по избор): ");
            var email = Console.ReadLine();

            Console.Write("Телефон (по избор): ");
            var phone = Console.ReadLine();

            var contestant = new Contestant
            {
                FullName = fullName,
                Age = age,
                ContactEmail = string.IsNullOrWhiteSpace(email) ? null : email,
                PhoneNumber = string.IsNullOrWhiteSpace(phone) ? null : phone
            };

            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(contestant);
            var validationResults = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();
            bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(contestant, validationContext, validationResults, true);

            if (!isValid)
            {
                Console.WriteLine("Грешки при валидация:");
                foreach (var vr in validationResults)
                {
                    Console.WriteLine($" - {vr.ErrorMessage}");
                }
                Console.WriteLine("Натиснете Enter, за да се върнете в менюто.");
                Console.ReadLine();
                return;
            }

            try
            {
                await _contestantService.AddAsync(contestant);
                Console.WriteLine("Успешно добавен участник! Натиснете Enter.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка при добавяне: {ex.Message}");
            }

            Console.ReadLine();
        }

        private async Task CreateQuizAsync()
        {
            Console.Clear();
            Console.WriteLine("=== Добавяне на викторина към предаване ===");

            Console.Write("Заглавие на викторината: ");
            var title = Console.ReadLine();

            Console.Write("Идентификатор (ID) на предаването, към което да се добави: ");
            var showIdInput = Console.ReadLine();
            if (!int.TryParse(showIdInput, out var showId))
            {
                Console.WriteLine("Невалиден ID. Операцията се отказва. Натиснете Enter.");
                Console.ReadLine();
                return;
            }

            Console.Write("Описание (по избор): ");
            var description = Console.ReadLine();

            var quiz = new Quiz
            {
                Title = title,
                ShowId = showId,
                Description = description
            };

            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(quiz);
            var validationResults = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();
            bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(quiz, validationContext, validationResults, true);

            if (!isValid)
            {
                Console.WriteLine("Грешки при валидация:");
                foreach (var vr in validationResults)
                {
                    Console.WriteLine($" - {vr.ErrorMessage}");
                }
                Console.WriteLine("Натиснете Enter, за да се върнете в менюто.");
                Console.ReadLine();
                return;
            }

            try
            {
                await _quizService.AddAsync(quiz);
                Console.WriteLine("Успешно добавена викторина! Натиснете Enter.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка при добавяне: {ex.Message}");
            }

            Console.ReadLine();
        }

        private async Task CreateQuestionAsync()
        {
            Console.Clear();
            Console.WriteLine("=== Добавяне на въпрос към викторина ===");

            Console.Write("Идентификатор (ID) на викторината, към която да се добави: ");
            var quizIdInput = Console.ReadLine();
            if (!int.TryParse(quizIdInput, out var quizId))
            {
                Console.WriteLine("Невалиден ID. Операцията се отказва. Натиснете Enter.");
                Console.ReadLine();
                return;
            }

            Console.Write("Текст на въпроса: ");
            var text = Console.ReadLine();

            Console.Write("Опция A: ");
            var optA = Console.ReadLine();

            Console.Write("Опция B: ");
            var optB = Console.ReadLine();

            Console.Write("Опция C: ");
            var optC = Console.ReadLine();

            Console.Write("Опция D: ");
            var optD = Console.ReadLine();

            Console.Write("Коректен отговор (A/B/C/D): ");
            var correct = Console.ReadLine();

            var question = new Question
            {
                QuizId = quizId,
                Text = text,
                OptionA = optA,
                OptionB = optB,
                OptionC = optC,
                OptionD = optD,
                CorrectAnswer = correct?.ToUpper()
            };

            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(question);
            var validationResults = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();
            bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(question, validationContext, validationResults, true);

            if (!isValid)
            {
                Console.WriteLine("Грешки при валидация:");
                foreach (var vr in validationResults)
                {
                    Console.WriteLine($" - {vr.ErrorMessage}");
                }
                Console.WriteLine("Натиснете Enter, за да се върнете в менюто.");
                Console.ReadLine();
                return;
            }

            try
            {
                await _questionService.AddAsync(question);
                Console.WriteLine("Успешно добавен въпрос! Натиснете Enter.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка при добавяне: {ex.Message}");
            }

            Console.ReadLine();
        }

        private async Task ListShowsAsync()
        {
            Console.Clear();
            Console.WriteLine("=== Списък с предавания ===");

            var shows = (await _showService.GetAllAsync()).ToList();
            if (!shows.Any())
            {
                Console.WriteLine("Няма въведени предавания.");
            }
            else
            {
                foreach (var s in shows)
                {
                    Console.WriteLine($"ID: {s.Id} | Име: {s.Name} | Дата: {s.AirDate?.ToString("yyyy-MM-dd") ?? "-"} | Описание: {s.Description}");
                    Console.Write("   Викторини: ");
                    if (s.Quizzes.Any())
                        Console.WriteLine(string.Join(", ", s.Quizzes.Select(q => $"{q.Title}(ID:{q.Id})")));
                    else
                        Console.WriteLine("Няма.");
                    Console.Write("   Участници: ");
                    if (s.Contestants.Any())
                        Console.WriteLine(string.Join(", ", s.Contestants.Select(c => $"{c.FullName}(ID:{c.Id})")));
                    else
                        Console.WriteLine("Няма.");
                    Console.WriteLine(new string('-', 50));
                }
            }

            Console.WriteLine("Натиснете Enter, за да се върнете в менюто.");
            Console.ReadLine();
        }

        private async Task ListContestantsAsync()
        {
            Console.Clear();
            Console.WriteLine("=== Списък с участници ===");

            var contestants = (await _contestantService.GetAllAsync()).ToList();
            if (!contestants.Any())
            {
                Console.WriteLine("Няма въведени участници.");
            }
            else
            {
                foreach (var c in contestants)
                {
                    Console.WriteLine($"ID: {c.Id} | Име: {c.FullName} | Възраст: {c.Age?.ToString() ?? "-"} | Имейл: {c.ContactEmail} | Телефон: {c.PhoneNumber}");
                    Console.Write("   Предавания: ");
                    if (c.Shows.Any())
                        Console.WriteLine(string.Join(", ", c.Shows.Select(s => $"{s.Name}(ID:{s.Id})")));
                    else
                        Console.WriteLine("Няма.");
                    Console.WriteLine(new string('-', 50));
                }
            }

            Console.WriteLine("Натиснете Enter, за да се върнете в менюто.");
            Console.ReadLine();
        }

        private async Task ListQuizzesAsync()
        {
            Console.Clear();
            Console.WriteLine("=== Списък с викторини ===");

            var quizzes = (await _quizService.GetAllAsync()).ToList();
            if (!quizzes.Any())
            {
                Console.WriteLine("Няма въведени викторини.");
            }
            else
            {
                foreach (var q in quizzes)
                {
                    Console.WriteLine($"ID: {q.Id} | Заглавие: {q.Title} | Show: {q.Show?.Name}(ID:{q.ShowId}) | Описание: {q.Description}");
                    Console.Write("   Въпроси: ");
                    if (q.Questions.Any())
                        Console.WriteLine(q.Questions.Count + " въпроса");
                    else
                        Console.WriteLine("Няма.");
                    Console.WriteLine(new string('-', 50));
                }
            }

            Console.WriteLine("Натиснете Enter, за да се върнете в менюто.");
            Console.ReadLine();
        }

        private async Task ListQuestionsAsync()
        {
            Console.Clear();
            Console.WriteLine("=== Списък с въпроси ===");

            var questions = (await _questionService.GetAllAsync()).ToList();
            if (!questions.Any())
            {
                Console.WriteLine("Няма въведени въпроси.");
            }
            else
            {
                foreach (var q in questions)
                {
                    Console.WriteLine($"ID: {q.Id} | Quiz: {q.Quiz?.Title}(ID:{q.QuizId}) | Текст: {q.Text}");
                    Console.WriteLine($"   A: {q.OptionA} | B: {q.OptionB} | C: {q.OptionC} | D: {q.OptionD} | Правилен: {q.CorrectAnswer}");
                    Console.WriteLine(new string('-', 50));
                }
            }

            Console.WriteLine("Натиснете Enter, за да се върнете в менюто.");
            Console.ReadLine();
        }

        private async Task AssignContestantToShowAsync()
        {
            Console.Clear();
            Console.WriteLine("=== Присвояване на участник към предаване ===");

            Console.Write("ID на участника: ");
            var contestantIdInput = Console.ReadLine();
            if (!int.TryParse(contestantIdInput, out var contestantId))
            {
                Console.WriteLine("Невалиден ID. Натиснете Enter.");
                Console.ReadLine();
                return;
            }

            Console.Write("ID на предаването: ");
            var showIdInput = Console.ReadLine();
            if (!int.TryParse(showIdInput, out var showId))
            {
                Console.WriteLine("Невалиден ID. Натиснете Enter.");
                Console.ReadLine();
                return;
            }

            try
            {
                await _contestantService.AssignToShowAsync(contestantId, showId);
                Console.WriteLine("Успешно присвоен участникът! Натиснете Enter.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка: {ex.Message}");
            }

            Console.ReadLine();
        }

        private async Task RemoveContestantFromShowAsync()
        {
            Console.Clear();
            Console.WriteLine("=== Премахване на участник от предаване ===");

            Console.Write("ID на участника: ");
            var contestantIdInput = Console.ReadLine();
            if (!int.TryParse(contestantIdInput, out var contestantId))
            {
                Console.WriteLine("Невалиден ID. Натиснете Enter.");
                Console.ReadLine();
                return;
            }

            Console.Write("ID на предаването: ");
            var showIdInput = Console.ReadLine();
            if (!int.TryParse(showIdInput, out var showId))
            {
                Console.WriteLine("Невалиден ID. Натиснете Enter.");
                Console.ReadLine();
                return;
            }

            try
            {
                await _contestantService.RemoveFromShowAsync(contestantId, showId);
                Console.WriteLine("Успешно премахнат участникът! Натиснете Enter.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}
