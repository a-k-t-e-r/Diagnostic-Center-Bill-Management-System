using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.DAL.Model
{
    public class TypeWiseReportModel : TestWiseReportModel
    {
        public string TypeName { get; set; }
        public string TestName { get; set; }
        public int NoOfTest { get; set; }
        public double Amount { get; set; }
    }
}