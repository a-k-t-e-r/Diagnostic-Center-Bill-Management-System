using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.DAL.Gateway;
using DiagnosticCenterBillManagementSystem.DAL.Model;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class TestWiseReportManager
    {
        TestWiseReportGateway twrGateway = new TestWiseReportGateway();
        public List<TestWiseReportModel> GetAllInformation(DateTime fromDate, DateTime toDate)
        {
            List<TestWiseReportModel> twrModels = twrGateway.GetAllInformation(fromDate, toDate);
            return twrModels;
        }
    }
}