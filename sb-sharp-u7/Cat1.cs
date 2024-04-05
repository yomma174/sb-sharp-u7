using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sb_sharp_u7
{
    struct Cat1
    {

        public Cat1(string Breed, string Nickname)
        {
            this.Breed = Breed;
            this.Nickname = Nickname;

        }

        public string Breed { get; private set;}
        public string Nickname { get; private set;}

    }
}
