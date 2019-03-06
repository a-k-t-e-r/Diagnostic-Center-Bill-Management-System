using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.DAL.Model
{
    public class TestSetupModel : TestTypeSetupModel
    {
        public int TsId { get; set; }
        public string TsName { get; set; }
        public double TsFee { get; set; }
    }
}