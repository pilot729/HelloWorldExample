using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorld.Business.Domain;

namespace HelloWorld.Business
{
    public interface IHelloWorldRepository
    {
        string Get(int id);
        List<Greetings> GetAll(int? id);
    }
}
