using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.DAL.Gateway
{
    public class PaymentGateway : BaseGateway
    {
        double TotalAmount = 0;
        public double GetInfo(int billId)
        {
            string qSearch = "SELECT testReqTotal FROM TestRequestEntry JOIN PaymentInfo " +
                             "ON TestRequestEntry.testReqPaymentId = PaymentInfo.paymentId " +
                             "WHERE TestRequestEntry.testReqPaymentId = @BillID;";
            Command = new SqlCommand(qSearch, Connection);
            Command.Parameters.Add("BillID", SqlDbType.Int).Value = billId;

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                TotalAmount = Convert.ToDouble(Reader["testReqTotal"]);
            }
            Reader.Close();
            Connection.Close();

            return TotalAmount;
        }

        public double GetInfo(string mobileNo)
        {
            string qSearch = "SELECT testReqTotal FROM TestRequestEntry JOIN PatientInfo " +
                             "ON TestRequestEntry.testReqPatientId = PatientInfo.patientId " +
                             "WHERE TestRequestEntry.testReqPatientId = (SELECT PatientInfo.patientId FROM PatientInfo " +
                             "WHERE PatientInfo.patientMobileNo = @MobileNo);";
            Command = new SqlCommand(qSearch, Connection);
            Command.Parameters.Add("MobileNo", SqlDbType.VarChar).Value = mobileNo;

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                TotalAmount = Convert.ToDouble(Reader["testReqTotal"]);
            }
            Reader.Close();
            Connection.Close();

            return TotalAmount;
        }

        public int SetPayment(DateTime dueDate, string paymentStatus, int billId)
        {
            string setQuery = "UPDATE PaymentInfo SET paymentdate = @DueDate, paymentStatus = @PaidStatus " +
                              "WHERE paymentId = @BillID;";
            Command = new SqlCommand(setQuery, Connection);
            Command.Parameters.Add("DueDate", SqlDbType.Date).Value = dueDate;
            Command.Parameters.Add("PaidStatus", SqlDbType.VarChar).Value = paymentStatus;
            Command.Parameters.Add("BillID", SqlDbType.Int).Value = billId;

            Connection.Open();
            int status = Command.ExecuteNonQuery();
            Connection.Close();

            return status;
        }

        public int SetPayment(DateTime dueDate, string paymentStatus, string mobileNo)
        {
            string setQuery = "UPDATE PaymentInfo SET paymentdate = @DueDate, paymentStatus = @PaidStatus " +
                              "WHERE paymentId = (SELECT TestRequestEntry.testReqPaymentId FROM TestRequestEntry " +
                              "JOIN PatientInfo ON TestRequestEntry.testReqPatientId = PatientInfo.patientId " +
                              "WHERE TestRequestEntry.testReqPatientId = (SELECT PatientInfo.patientId FROM PatientInfo " +
                              "WHERE PatientInfo.patientMobileNo = @MobileNo));";
            Command = new SqlCommand(setQuery, Connection);
            Command.Parameters.Add("DueDate", SqlDbType.Date).Value = dueDate;
            Command.Parameters.Add("PaidStatus", SqlDbType.VarChar).Value = paymentStatus;
            Command.Parameters.Add("MobileNo", SqlDbType.VarChar).Value = mobileNo;

            Connection.Open();
            int status = Command.ExecuteNonQuery();
            Connection.Close();

            return status;
        }
    }
}