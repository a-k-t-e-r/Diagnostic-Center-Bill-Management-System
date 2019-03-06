using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DiagnosticCenterBillManagementSystem.DAL.Model;

namespace DiagnosticCenterBillManagementSystem.DAL.Gateway
{
    public class TestWiseReportGateway : BaseGateway
    {
        public List<TestWiseReportModel> GetAllInformation(DateTime fromDate, DateTime toDate)
        {
            string getSql = "SELECT PaymentInfo.paymentdate, TestRequestEntry.testReqAllNames, " +
                            "TestRequestEntry.testReqTotal, PaymentInfo.paymentStatus FROM TestRequestEntry JOIN " +
                            "PaymentInfo ON TestRequestEntry.testReqPaymentId = PaymentInfo.paymentId " +
                            "WHERE PaymentInfo.paymentdate BETWEEN @FROM AND @TO";
            Command = new SqlCommand(getSql, Connection);
            Command.Parameters.Add("FROM", SqlDbType.Date).Value = fromDate;
            Command.Parameters.Add("TO", SqlDbType.Date).Value = toDate;

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<TestWiseReportModel> twrModels = new List<TestWiseReportModel>();
            int k = 0;
            while (Reader.Read())
            {
                TestWiseReportModel model = new TestWiseReportModel();
                model.AllDates = Convert.ToDateTime(Reader["paymentdate"]);
                model.TsName = Reader["testReqAllNames"].ToString();
                model.TreTotal = Convert.ToDouble(Reader["testReqTotal"]);
                model.PaymentStatus = Reader["paymentStatus"].ToString();
                model.SerialNo = k + 1;

                twrModels.Add(model);
                k++;
            }
            Reader.Close();
            Connection.Close();
            return twrModels;
        }
    }
}