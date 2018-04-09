using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Pivotal.ClaimsManagement.Data;
using StructureMap;

namespace Pivotal.ClaimsManagement
{
    [Serializable]
    public class ServiceCenterRates
    {
        public int RateID { get; set; }
        public int ServiceCenterID { get; set; }
        public int DiagnosticID { get; set; }
        public string RateDescription { get; set; }
        public decimal? DiagnosticRate { get; set; }
        public decimal? DiagnosticRateOT { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public string Status { get; set; }

        public ServiceCenterRates()
        {
        }

        public ServiceCenterRates(DataRow dr)
        {
            RateID = dr.Field<int>("RateID");
            ServiceCenterID = dr.Field<int>("ServiceCenterID");
            DiagnosticID = dr.Field<int>("RateID");
            RateDescription = dr.Field<string>("RateDescription");
            DiagnosticRate = dr.Field<decimal?>("DiagnosticRate");
            DiagnosticRateOT = dr.Field<decimal?>("DiagnosticRateOT");
            UpdatedBy = dr.Field<int?>("UpdatedBy");
            UpdatedDateTime = dr.Field<DateTime?>("UpdatedDateTime");
            Status = dr.Field<string>("Status");
        }

        static public IEnumerable<ServiceCenterRates> GetBySCId(int serviceCenterID)
        {
            var dal = ObjectFactory.GetInstance<ICMSDataLayer>();

            var items = new List<ServiceCenterRates>();

            foreach (var dr in dal.FetchServiceCenterProfileInformation(4, serviceCenterID).AsEnumerable())
            {
                items.Add(new ServiceCenterRates(dr));
            }

            return items;
        }
    }
}
