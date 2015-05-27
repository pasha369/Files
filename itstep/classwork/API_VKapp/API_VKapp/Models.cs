using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_VKapp
{
    public class Item
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string nickname { get; set; }
        public int online { get; set; }
        public List<int?> lists { get; set; }
        public string deactivated { get; set; }
    }

    public class Response
    {
        public int count { get; set; }
        public List<Item> items { get; set; }
    }

    public class RootObject
    {
        public Response response { get; set; }
    }
}
