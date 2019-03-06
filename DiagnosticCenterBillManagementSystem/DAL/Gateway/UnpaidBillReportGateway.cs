using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DiagnosticCenterBillManagementSystem.DAL.Model;

namespace DiagnosticCenterBillManagementSystem.DAL.Gateway
{
    public class UnpaidBillReportGateway : BaseGateway
    {
        public List<UnpaidBillReportModel> GetAllInformation(DateTime fromDate, DateTime toDate)
        {
            string getSql = "SELECT PaymentInfo.paymentId, PatientInfo.patientName, PatientInfo.patientMobileNo, " +
                            "TestRequestEntry.testReqTotal, PaymentInfo.paymentStatus FROM TestRequestEntry " +
                            "JOIN PatientInfo ON TestRequestEntry.testReqPatientId = PatientInfo.patientId " +
                            "JOIN PaymentInfo ON TestRequestEntry.testReqPaymentId = PaymentInfo.paymentId " +
                            "WHERE PaymentInfo.paymentStatus = 'Due' AND PaymentInfo.paymentdate BETWEEN @FROM AND @TO";
            
            Command = new SqlCommand(getSql, Connection);
            Command.Parameters.Add("FROM", SqlDbType.Date).Value = fromDate;
            Command.Parameters.Add("TO", SqlDbType.Date).Value = toDate;

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<UnpaidBillReportModel> ubrModels = new List<UnpaidBillReportModel>();
            int k = 0;
            while (Reader.Read())
            {
                UnpaidBillReportModel model = new UnpaidBillReportModel();
                model.SerialNo = k + 1;
                model.TreId = Convert.ToInt32(Reader["paymentId"]);
                model.TrePatientName = Reader["patientName"].ToString();
                model.TreMobile = Reader["patientMobileNo"].ToString();
                model.TreTotal = Convert.ToDouble(Reader["testReqTotal"]);
                model.PaymentStatus = Reader["paymentStatus"].ToString();

                ubrModels.Add(model);
                k++;
            }
            Reader.Close();
            Connection.Close();
            return ubrModels;
        }
    }
}