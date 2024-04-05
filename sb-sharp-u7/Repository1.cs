using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sb_sharp_u7
{
    struct Repository1
    {
        public Worker[] Workers;

        public Repository1(params Worker[] Args)
        {
            Workers = Args;
        }
    }
}
