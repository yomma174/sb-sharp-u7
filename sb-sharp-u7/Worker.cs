using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sb_sharp_u7
{
    struct Worker
    {
        public int Id {  get; set; }
        public DateTime CreateDate {  get; set; }
        public string FIO {  get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }


        public Worker(int Id, DateTime CreateDate, string FIO, int Age, int Height, DateTime BirthDate, string BirthPlace)
        {  
            this.Id = Id;
            this.CreateDate = CreateDate;
            this.FIO = FIO;
            this.Age = Age;
            this.Height = Height;
            this.BirthDate = BirthDate;
            this.BirthPlace = BirthPlace;
        }

        public string Print()
        {
            return $"ID:{Id,-3}\t" +
                $"Время записи: {CreateDate:g}\n" +
                $"ФИО: {FIO}\n" +
                $"Возраст: {Age,-2}; " +
                $"Рост: {Height,-3}; " +
                $"Дата рождения: {BirthDate:d}; " +
                $"Место рождения: {BirthPlace}\n";
        }
    }
}
