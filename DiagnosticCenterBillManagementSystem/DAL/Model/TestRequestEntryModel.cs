using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.DAL.Model
{
    public class TestRequestEntryModel : TestSetupModel
    {
        public int TreId { get; set; }
        public string TrePatientName { get; set; }
        public DateTime TreDoB { get; set; }
        public string TreMobile { get; set; }
        public double TreTotal { get; set; }
    }
}