using System;
using System.Data.Entity;
using System.Data.SqlClient;
using HelloWorld.Data.DTO;

namespace HelloWorld.Data
{
    public class EFContext : DbContext, IEFContext
    {
        private readonly string _connStr;

        public EFContext(string connStr)
            : base(new SqlConnection(connStr), true)
        {
            _connStr = connStr;
        }

        public virtual DbSet<Greetings> HelloWorlds { get; set; }

    }
}