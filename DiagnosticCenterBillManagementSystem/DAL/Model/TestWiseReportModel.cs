using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.DAL.Model
{
    public class TestWiseReportModel : PaymentModel
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime AllDates { get; set; }
        public string PaymentStatus { get; set; }
    }
}