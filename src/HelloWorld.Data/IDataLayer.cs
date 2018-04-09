using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.Security;

namespace HelloWorld.Data
{
    public interface IDataLayer
    {
        string Get(int id);
        void Upsert(int? id, string greeting, int userId);
        DataTable GetDT(int? id);
    }
}
