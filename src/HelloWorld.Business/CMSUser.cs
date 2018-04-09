using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using Pivotal.ClaimsManagement.Data;
using StructureMap;

namespace Pivotal.ClaimsManagement
{
    [Serializable]
    public class CMSUser : IIdentity, IPrincipal
    {
        //custom
        public int UserID { get; set; }
        private string _userName;
        public int RoleID { get; set; }
        private string _permissionIDs;
        public string Login { get; set; }

        //IPrinciple
        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name
        {
            get { return _userName; }
        }

        public IIdentity Identity
        {
            get { return this; }
        }

        public bool IsInRole(string role)
        {
            return false;
        }

        //Roles - select * from tblapplicationvalues where groupid = 5
        public bool IsAdministrator { get { return RoleID == 14; } }
        public bool IsSupervisor { get { return RoleID == 57; } }
        public bool IsCallCenter { get { return RoleID == 15; } }
        public bool IsClaimsProcessing { get { return RoleID == 16; } }

        public CMSUser()
        {
        }

        public CMSUser(DataRow dr)
        {
            UserID = dr.Field<int>("UserID");
            _userName = dr.Field<string>("username");
            RoleID = dr.Field<int>("Role");
            _permissionIDs = dr.Field<string>("PermissionIds");
            Login = dr.Field<string>("login");
        }

        static public CMSUser Get(int userID)
        {
            var dal = ObjectFactory.GetInstance<ICMSDataLayer>();

            DataTable dt = dal.ValidateLogin(userID);

            if (dt.Rows.Count != 1)
            {
                throw new InvalidOperationException(string.Format("UserID {0} not found", userID));
            }

            return new CMSUser(dt.Rows[0]);
        }

        //Permissions  - select * from tblapplicationvalues where groupid = 77 
        public bool HasPermission(int permissionId)
        {
            string searchPermission = "|" + permissionId.ToString() + "|";

            if (String.IsNullOrEmpty(_permissionIDs))
                return false;
            else if (_permissionIDs.IndexOf(searchPermission) == -1)
                return false;
            else
                return true;
        }
    }

    public enum PermissionValue  //tblApplicationValues.GroupID = 77
    {
        Administration_ResetUserPassword_700 = 700,
        Administration_AddandEditUser_701 = 701,
        Administration_AddServiceCenter_702 = 702,
        Administration_EditServiceCenterPriority_703 = 703,
        Administration_PendingApprovals_704 = 704,
        Administration_AccountsBilled_705 = 705,
        Invoice_Overridebutton_706 = 706,
        Invoice_Reimbursementbutton_707 = 707,
        EditServiceCenter_EditandSubmitExceptInsuranceInfo_708 = 708,
        EditServiceCenter_EditInsuranceinfo_709 = 709,
        ClaimLine_EditClaim_710 = 710,
        Administration_CoveredComponents_711 = 711,
        Administration_ImportQualityScores_712 = 712,
        Administration_ServiceCallLimit_713 = 713,
        Administration_PastDueCustomerClaim_714 = 714,
        Invoice_Referral_770 = 770,
    }   
}
