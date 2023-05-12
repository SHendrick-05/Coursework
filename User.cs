using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    internal class User
    {
        public int ID { get; set; }
        public string username { get; set; }
        public string zValue { get; set; }
        public string yShifted { get; set; }
        public string Salt { get; set; }
        public User(string UN, string ZP, string YS, string salt)
        {
            username = UN;
            zValue = ZP;
            yShifted = YS;
            Salt = salt;
        }
    }
}
