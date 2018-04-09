using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.Data.Mocks
{
    public class MockDataLayer : IDataLayer
    {
        private readonly DataLayer _dataLayer;

        public MockDataLayer(DataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }
        public string Get(int id)
        {
            return "Hello World";
        }

        public DataTable GetDT(int? id)
        {
            throw new NotImplementedException();
        }

        public void Upsert(int? id, string greeting, int userId)
        {
            throw new NotImplementedException();
        }
    }
}