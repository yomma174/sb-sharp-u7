using System.Security.Cryptography.X509Certificates;

namespace sb_sharp_u7
{

    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            Repository db = new Repository("WorkersList.txt");


            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine(
                    "Выберите действие:" +
                    "\n1. Вывести данные одного сотрудника через ID" +
                    "\n2. Вывести данные всех рабочих" +
                    "\n3. Вывести данные в диапазоне" +
                    "\n4. Добавить запись" +
                    "\n5. Редактировать запись" +
                    "\n6. Удалить запись" +
                    "\nДля выхода из программы нажмите любую иную клавишу"
                    );

                char userChoise = Console.ReadKey(true).KeyChar;
                Console.Clear();

                switch (userChoise)
                {
                    case '1':
                        db.PrintWorkerById();
                        break;
                    case '2':
                        db.PrintAllWorkers();
                        break;
                    case '3':
                        db.PrintWorkersByDateRange();
                        break;
                    case '4':
                        db.AddRecord();
                        break;
                    case '5':
                        db.EditWorker();
                        break;
                    case '6':
                        db.DeleteWorker();
                        break;
                    default:
                        Console.WriteLine("Работа завершена.");
                        isWorking = false;
                        Thread.Sleep(2000);
                        break;
                }

                if (isWorking)
                {
                    Sorted(db.GetAllWorkers());
                    Console.WriteLine("Для возвращения в главное меню нажмите любую клавишу.");
                    Console.ReadKey(true);
                }

            }

            void Sorted(Worker[] workers)
            {

                Console.Write("Введите поле по которому нужно произвести сортировку: ");
                string field = Console.ReadLine();
                Console.Clear();
                var sortedWorkers = workers.OrderBy(w => w.Id);
                Console.WriteLine($"Сортировка по: {field}\n");

                switch (field)
                {
                    case "ID":
                        sortedWorkers = workers.OrderBy(w=>w.Id);
                        break;
                    case "Время записи":
                        sortedWorkers = workers.OrderBy(w => w.CreateDate);
                        break;
                    case "ФИО":
                        sortedWorkers = workers.OrderBy(w => w.FIO);
                        break;
                    case "Возраст":
                        sortedWorkers = workers.OrderBy(w => w.Age);
                        break;
                    case "Рост":
                        sortedWorkers = workers.OrderBy(w => w.Height);
                        break;
                    case "Дата рождения":
                        sortedWorkers = workers.OrderBy(w => w.BirthDate);
                        break;
                    case "Место рождения":
                        sortedWorkers = workers.OrderBy(w => w.BirthPlace);
                        break;
                    default:
                        break;
                }

                foreach (Worker worker in sortedWorkers)
                {
                    Console.WriteLine(worker.Print());
                }
            }
        }


    }
}
