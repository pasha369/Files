using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace AbstractFactory_Log
{
    public  class LogDBContext : DbContext
    {
        public IDbSet<Log> logs { set; get; }

        public LogDBContext(): base("DBConnectionString")
        {
            Database.SetInitializer<LogDBContext>( new DropCreateDatabaseAlways<LogDBContext>());
        }
    }

    [Table("log")]
    public class Log
    {
        [Key]
        public string Message { set; get; }

        public DateTime Time { set; get; }
    }
}