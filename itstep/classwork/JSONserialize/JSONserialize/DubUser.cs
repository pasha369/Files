using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONserialize
{
    class DubUser
    {
        public string _name { get; set; }
        public string _password { get; set; }
        public int _age { get; set; }
        public List<string> _subjects { get; set; }
    }
}
