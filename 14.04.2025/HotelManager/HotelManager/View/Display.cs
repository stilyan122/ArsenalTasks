using HotelManager.Controllers;

namespace HotelManager.View
{
    public class Display
    {
        private HotelController controller;

        public Display(HotelController controller)
        {
            this.controller = controller;
        }

        public async Task Menu()
        {
            Console.WriteLine("1. Показване на всички гости");
            Console.WriteLine("2. Добавяне на нов гост");
            Console.WriteLine("3. Стаи с цена между 80 и 100 лв (в низходящ ред)");
            Console.WriteLine("4. Изтриване на резервация по ID");
            Console.WriteLine("5. Брой свободни стаи");
            Console.WriteLine("6. Минимална цена по статус");
            Console.WriteLine("7. ID-та на активни резервации");
            Console.WriteLine("0. Изход");

            while (true)
            {
                Console.Write("Моля, въведете избора си: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var names = await controller.GetAllGuestNames();
                        names.ForEach(Console.WriteLine);
                        break;
                    case "2":
                        Console.Write("Име: ");
                        var fName = Console.ReadLine();
                        Console.Write("Фамилия: ");
                        var lName = Console.ReadLine();
                        Console.Write("ЕГН: ");
                        var ucn = Console.ReadLine();
                        Console.Write("Телефон: ");
                        var phone = Console.ReadLine();

                        await controller.AddGuest(fName, lName, ucn, phone);

                        Console.WriteLine("Гостът е успешно добавен.");
                        break;
                    case "3":
                        var roomsByPriceRange = await controller.GetRoomsByPriceRange();
                        roomsByPriceRange.ForEach(Console.WriteLine);
                        break;
                    case "4":
                        Console.Write("Въведете ID на резервацията: ");
                        var resId = int.Parse(Console.ReadLine());

                        if (await controller.DeleteReservation(resId))
                            Console.WriteLine($"Резервацията с ID {resId} е изтрита успешно.");
                        else
                            Console.WriteLine("Няма такава резервация.");
                        break;
                    case "5":
                        var count = await controller.GetFreeRoomCount();

                        Console.WriteLine($"Свободни стаи: {count}");
                        break;
                    case "6":
                        Console.Write("Въведете статус на стаята: ");

                        var status = Console.ReadLine();
                        var price = await controller.GetMinPriceByStatus(status);

                        Console.WriteLine($"Минимална цена: {price:f2} лв");
                        break;
                    case "7":
                        Console.WriteLine("Резервации, които още не са приключили:");
                        var ids = await controller.GetActiveReservationIds();
                        ids.ForEach(Console.WriteLine);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невалидна команда.");
                        break;
                }
            }
        }
    }
}
