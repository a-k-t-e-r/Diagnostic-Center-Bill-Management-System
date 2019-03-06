using System;
using System.Collections.Generic;
using DiagnosticCenterBillManagementSystem.DAL.Gateway;
using DiagnosticCenterBillManagementSystem.DAL.Model;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class UnpaidBillReportManager
    {
        UnpaidBillReportGateway ubrGateway = new UnpaidBillReportGateway();

        public List<UnpaidBillReportModel> GetAllInformation(DateTime fromDate, DateTime toDate)
        {
            List<UnpaidBillReportModel> ubrModels = ubrGateway.GetAllInformation(fromDate, toDate);
            return ubrModels;
        }
    }
}