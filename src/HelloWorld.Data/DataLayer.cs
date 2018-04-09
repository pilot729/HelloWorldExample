using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HelloWorld.Data.DTO;

namespace HelloWorld.Data
{
    public class DataLayer : IDataLayer
    {
        private readonly string _cnn;

        public DataLayer(string connectionString)
        {
            _cnn = connectionString;
        }

        public string Get(int id)
        {
            var context = StructureMap.ObjectFactory.GetInstance<Data.IEFContext>();

            return context.HelloWorlds.SingleOrDefault(x => x.Id == id).Greeting;
        }

        public DataTable GetDT(int? id)
        {
            using (SqlConnection cnn = new SqlConnection(_cnn))
            {
                SqlCommand cmd = new SqlCommand("usp_GetHelloWorld", cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                cnn.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public void Upsert(int? id, string greeting, int userId)
        {
            var context = StructureMap.ObjectFactory.GetInstance<Data.IEFContext>();

            var row = context.HelloWorlds.SingleOrDefault(x => x.Id == id);

            if (row == null)
            {
                row = new Greetings();
                context.HelloWorlds.Add(row);
                row.Greeting = greeting;
                row.CreatedBy = userId;
                row.CreatedDateTime = DateTime.Now;
            }

            row.Greeting = greeting;
            row.UpdatedBy = userId;
            row.UpdatedDateTime = DateTime.Now;

            context.SaveChanges();
        }
    }
}
