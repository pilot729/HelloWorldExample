using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HelloWorld.Data;
using StructureMap;
using HelloWorld.Business.Domain;

namespace HelloWorld.Business
{
    [Serializable]
    public class HelloWorldRepository : IHelloWorldRepository
    {
        private IDataLayer _dal;

        public HelloWorldRepository(IDataLayer dal)
        {
            _dal = dal;
        }

        public string Get(int id)
        {
            return _dal.Get(id);
        }

        public List<Domain.Greetings> GetAll(int? id)
        {
            try
            {
                var items = _dal.GetDT(id).AsEnumerable()
                    .Select(x => new Greetings()
                    {
                        Id = x.Field<int>("Id"),
                        Greeting = x.Field<string>("Greeting"),
                        CreatedBy = x.Field<int?>("CreatedBy"),
                        CreatedDateTime = x.Field<DateTime?>("CreatedDateTime"),
                        UpdatedBy = x.Field<int?>("UpdatedBy"),
                        UpdatedDateTime = x.Field<DateTime?>("UpdatedDateTime"),
                    }).ToList();

                return items;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving data", ex);
            }
        }

        public void Insert(Greetings greet)
        {
            try
            {
                _dal.Upsert(null, greet.Greeting, (int)greet.CreatedBy);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting data", ex);
            }
        }

        public void Update(Greetings greet)
        {
            try
            {
                _dal.Upsert(greet.Id, greet.Greeting, (int)greet.UpdatedBy);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating data", ex);
            }
        }
    }
}
