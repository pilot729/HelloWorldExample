using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorld.Data;
using HelloWorld.Data.Mocks;
using StructureMap;
using System.Configuration;

namespace HelloWorld.UnitTest
{
    public class Configuration
    {
        static IDataLayer mockDataLayer;
        static public void WireUpBusinessObjects()
        {
            StructureMap.ObjectFactory.Configure(x =>
            {
                x.For<IDataLayer>().Use(_ =>
                {
                    var dal = ObjectFactory.GetInstance<DataLayer>();

                    if (IsMockDataLayer)
                    {
                        if (mockDataLayer == null)
                        {
                            mockDataLayer = new MockDataLayer(dal);
                        }

                        return mockDataLayer;
                    }

                    return dal;
                });

                x.For<DataLayer>()
                    .Use(() =>
                    {
                        return new DataLayer(
                            ConnectionString);
                    });

                x.For<Data.IEFContext>()
                    .Use(() =>
                    {
                        return new Data.EFContext(
                            ConnectionString);
                    });

                x.For<Business.IHelloWorldRepository>().Use(_ =>
                {
                    var dal = ObjectFactory.GetInstance<DataLayer>();

                    if (IsMockDataLayer)
                    {
                        if (mockDataLayer == null)
                        {
                            mockDataLayer = new MockDataLayer(dal);
                        }

                        return new Business.HelloWorldRepository(
                            mockDataLayer);
                    }

                    return new Business.HelloWorldRepository(
                            dal);
                });

            });
        }

        public static string Environment
        {
            get { return ConfigurationManager.AppSettings["Environment"]; }
        }

        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["HelloWorld_" + Environment].ToString(); }
        }

        public static bool IsMockDataLayer
        {
            get
            {
                return bool.Parse(System.Configuration.ConfigurationManager.AppSettings["MockDataLayer"] ?? "false");
            }
        }
    }

}
