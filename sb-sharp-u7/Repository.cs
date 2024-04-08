using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sb_sharp_u7
{
    class Repository
    {
        public string Source {  get; set; }

        public Repository(string Source) 
        {
            this.Source = Source;
        }


        public void PrintWorkerById(int ID = -1)
        {
            if (ID == -1)
            {
                Console.Write("Введите ID: ");
                ID = int.Parse(Console.ReadLine());
            }
            if (File.Exists(Source))
                Console.WriteLine(GetWorkerById(ID).Print());
            else
                Console.WriteLine("Пока нет ни одной записи.");
        }
        public Worker GetWorkerById(int id) 
        {
            string[] workersData = File.ReadAllLines(Source);
            foreach (string worker in workersData)
            {
                if (worker.Split('#')[0] == id.ToString())
                {
                    string[] workerData = worker.Split('#');
                    Worker workerById = new Worker(
                                        int.Parse(workerData[0]),
                                        DateTime.Parse(workerData[1]),
                                        workerData[2],
                                        int.Parse(workerData[3]),
                                        int.Parse(workerData[4]),
                                        DateTime.Parse(workerData[5]),
                                        workerData[6]
                                        );

                    return workerById;
                }
            }
            return new Worker();
        }


        public void PrintAllWorkers()
        {
            if (File.Exists(Source))
            {
                Worker[] workersList = GetAllWorkers();
                for (int i = 0; i < workersList.Length; i++)
                {
                    Console.WriteLine(workersList[i].Print());
                }
            }
            else
                Console.WriteLine("Пока нет ни одной записи.");
        }
        public void PrintWorkersByDateRange()
        {
            if (File.Exists(Source))
            {
                Console.Write("Введите первую дату: ");
                DateTime date1 = DateTime.Parse(Console.ReadLine());

                Console.Write("Введите вторую дату: ");
                DateTime date2 = DateTime.Parse(Console.ReadLine());

                Worker[] workersList = GetAllWorkers();
                for (int i = 0; i < workersList.Length; i++)
                {
                    if (date1 <= workersList[i].CreateDate && date2 >= workersList[i].CreateDate)
                    {
                        Console.WriteLine(workersList[i].Print());
                    }
                }
            }
            else
                Console.WriteLine("Пока нет ни одной записи.");
        }
        public Worker[] GetAllWorkers()
        {
            int recordCount = File.ReadAllLines(Source).Length;
            Worker[] workers = new Worker[recordCount];

            using (StreamReader streamReader = new StreamReader(Source, UnicodeEncoding.UTF8))
            {
                int index = 0;

                while (!streamReader.EndOfStream)
                {
                    string[] workerData = streamReader.ReadLine().Split('#');

                    Worker worker = new Worker(
                        int.Parse(workerData[0]),
                        DateTime.Parse(workerData[1]),
                        workerData[2],
                        int.Parse(workerData[3]),
                        int.Parse(workerData[4]),
                        DateTime.Parse(workerData[5]),
                        workerData[6]
                        );
                    workers[index] = worker;
                    index++;
                }
            }
            return workers;
        }


        public void AddRecord()
        {
            AddWorker(userInput());
        }
        public void AddWorker(Worker worker)
        {
            worker.Id = GetNextId();
            worker.CreateDate = DateTime.Now;

            using (StreamWriter sw = new StreamWriter(Source,true))
            {
                string record =
                    $"{worker.Id}#" +
                    $"{worker.CreateDate:g}#" +
                    $"{worker.FIO}#" +
                    $"{worker.Age}#" +
                    $"{worker.Height}#" +
                    $"{worker.BirthDate:d}#" +
                    $"{worker.BirthPlace}";

                sw.WriteLine(record);
            }
        }
        public int GetNextId()
        {
            int nextId = 1;
            if (File.Exists(Source))
            {
                string workersData = File.ReadAllLines(Source).Last();
                nextId = int.Parse(workersData.Split('#')[0]) + 1;
            }
            return nextId;
        }
        public Worker userInput()
        {
            Worker worker = new Worker();

            Console.Write("Введите ФИО: ");
            worker.FIO = Console.ReadLine();

            Console.Write("Введите возраст: ");
            worker.Age = int.Parse(Console.ReadLine());

            Console.Write("Введите рост: ");
            worker.Height = int.Parse(Console.ReadLine());

            Console.Write("Введите дату рождения: ");
            worker.BirthDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Введите место рождения: ");
            worker.BirthPlace = Console.ReadLine();

            return worker;
        }


        public void DeleteWorker(int ID = -1)
        {
            if (File.Exists(Source))
            {
                if(ID == -1)
                {
                    Console.Write("Введите ID: ");
                    ID = int.Parse(Console.ReadLine());
                }

                StreamReader sr = new StreamReader(Source);
                StringBuilder tempWorkers = new StringBuilder();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line.Split('#')[0] == ID.ToString())
                    {
                        continue;
                    }
                    tempWorkers.Append(line+"\n");
                }
                sr.Close();

                File.WriteAllText(Source,tempWorkers.ToString());

                Console.WriteLine("Запись удалена");
            }
            else
                Console.WriteLine("Пока нет ни одной записи.");
        }


        public void EditWorker(int ID = -1)
        {
            if (ID == -1)
            {
                PrintAllWorkers();
                Console.Write("Введите ID: ");
                ID = int.Parse(Console.ReadLine());
                Console.Clear();
            }

            PrintWorkerById(ID);

            StreamReader sr = new StreamReader(Source);
            StringBuilder tempWorkers = new StringBuilder();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line.Split('#')[0] == ID.ToString())
                {
                    Worker worker = userInput();

                    Console.Write("Введите ID: ");
                    worker.Id = int.Parse(Console.ReadLine());

                    Console.Write("Введите новую дату и время записи: ");
                    worker.CreateDate = DateTime.Parse(Console.ReadLine());

                    line = $"{worker.Id}#" +
                           $"{worker.CreateDate:g}#" +
                           $"{worker.FIO}#" +
                           $"{worker.Age}#" +
                           $"{worker.Height}#" +
                           $"{worker.BirthDate:d}#" +
                           $"{worker.BirthPlace}";
                }
                tempWorkers.Append(line + "\n");
            }
            sr.Close();

            File.WriteAllText(Source, tempWorkers.ToString());
        }
    }
}
