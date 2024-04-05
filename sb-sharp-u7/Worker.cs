using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sb_sharp_u7
{
    struct Worker
    {
        public string Position;

        public uint Salary;

        public string FirstName;

        public string LastName;

        public DateTime DateOfBirth;

        public string Print()
        {
            return $"Должность: {Position} Зарплата: {Salary} Имя: {FirstName} Фамилия: {LastName} Дата рождения: {DateOfBirth.ToShortDateString}";
        }

        public Worker(string Position, uint Salary, string FirstName, string LastName, DateTime DateOfBirth) 
        { 
            this.Position = Position ;
            this.Salary = Salary ;
            this.FirstName = FirstName ;
            this.LastName = LastName ;
            this.DateOfBirth = DateOfBirth ;
        }

        public Worker(string Position, uint Salary, string FirstName, string LastName) :
            this(Position, Salary, FirstName, LastName,new DateTime(1900, 1, 1, 0, 0, 0))
        {

        }

        public Worker(string Position, uint Salary, string FirstName) :
            this(Position, Salary, FirstName, String.Empty, new DateTime(1900, 1, 1, 0, 0, 0))
        {

        }

        public Worker(string Position,string FirstName) :
            this(Position, 0, FirstName, String.Empty, new DateTime(1900, 1, 1, 0, 0, 0))
        {

        }

        public Worker(string FirstName) :
            this(String.Empty, 0, FirstName, String.Empty, new DateTime(1900, 1, 1, 0, 0, 0))
        {
            this.Salary = 100;
        }

    }
}
