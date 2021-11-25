using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2
{
    public static class Names
    {
        public static string GetStr(int i)
        {
            string[] str = new string[3] { "up", "down", "none" };
            return str[i];
        }
    }
}
