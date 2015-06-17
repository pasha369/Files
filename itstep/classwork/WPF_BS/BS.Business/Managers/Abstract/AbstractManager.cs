using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Business.Managers.Abstract
{
    class AbstractManager
    {
        private readonly string _connection_string;

        public AbstractManager(string connection_string){
            _connection_string = connection_string;
        }

        protected DbContext CreateDBContex()
        {
            return new (_connection_string);
        }
    }
}
