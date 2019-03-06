using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DiagnosticCenterBillManagementSystem.DAL.Model;

namespace DiagnosticCenterBillManagementSystem.DAL.Gateway
{
    public class TestRequestEntryGateway : BaseGateway
    {
        public List<TestSetupModel> GetAllTestNames()
        {
            string testNamesQuery = "SELECT DISTINCT testName, testFee FROM TestSetup";
            Command = new SqlCommand(testNamesQuery, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<TestSetupModel> tsModel = new List<TestSetupModel>();
            while (Reader.Read())
            {
                TestSetupModel tsM = new TestSetupModel();
                tsM.TsName = Reader["testName"].ToString();
                tsM.TsFee = Convert.ToDouble(Reader["testFee"]);

                tsModel.Add(tsM);
            }
            Reader.Close();
            Connection.Close();

            return tsModel;
        }

        public int SetPatientInfo(string patientName, DateTime patientBirthDate, string patientMobileNo)
        {
            string setPatientQuery = "INSERT INTO PatientInfo(patientName, patientBirthDate, patientMobileNo)" +
                              " VALUES(@NAME, @BIRTH_DATE, @MOBILE)";
            Command = new SqlCommand(setPatientQuery, Connection);
            Command.Parameters.Add("NAME", SqlDbType.VarChar).Value = patientName;
            Command.Parameters.Add("BIRTH_DATE", SqlDbType.Date).Value = patientBirthDate;
            Command.Parameters.Add("MOBILE", SqlDbType.VarChar).Value = patientMobileNo;

            Connection.Open();
            int rowAffact = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffact;
        }

        public int SetPaymentInfo(DateTime today, string paymentStatus)
        {
            string setPayQuery = "INSERT INTO PaymentInfo(paymentdate, paymentStatus) VALUES(@DATE, @PayStatus)";
            Command = new SqlCommand(setPayQuery, Connection);
            Command.Parameters.Add("DATE", SqlDbType.VarChar).Value = today;
            Command.Parameters.Add("PayStatus", SqlDbType.VarChar).Value = paymentStatus;

            Connection.Open();
            int rowAffact = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffact;
        }

        public int SetRequestInfo(double totalFees, string allTestNames, string patientName)
        {
            int patientId = 0, paymentId = 0;

            /* Query For Get Patient ID */
            string searchPatientIdQuery = "SELECT patientId FROM PatientInfo WHERE patientName = @PatientName";
            Command = new SqlCommand(searchPatientIdQuery, Connection);
            Command.Parameters.Add("PatientName", SqlDbType.VarChar).Value = patientName;

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                patientId = Convert.ToInt32(Reader["patientId"]);
            }
            Reader.Close();
            Connection.Close();

            /* Query For Get PaymentModel ID */
            string searchPaymentIdQuery = "SELECT paymentId FROM PaymentInfo WHERE paymentdate = @PaymentDate";
            Command = new SqlCommand(searchPaymentIdQuery, Connection);
            Command.Parameters.Add("PaymentDate", SqlDbType.VarChar).Value = DateTime.Today;

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                paymentId = Convert.ToInt32(Reader["paymentId"]);
            }
            Reader.Close();
            Connection.Close();

            /* Insert Request Information */
            string setReqQuery = "INSERT INTO TestRequestEntry(testReqTotal, testReqAllNames, testReqPatientId, testReqPaymentId)" +
                                 " VALUES(@TotalFees, @AllNames, @PatientID, @PaymentID)";
            Command = new SqlCommand(setReqQuery, Connection);
            Command.Parameters.Add("TotalFees", SqlDbType.VarChar).Value = totalFees;
            Command.Parameters.Add("AllNames", SqlDbType.VarChar).Value = allTestNames;
            Command.Parameters.Add("PatientID", SqlDbType.Int).Value = patientId;
            Command.Parameters.Add("PaymentID", SqlDbType.Int).Value = paymentId;

            Connection.Open();
            int rowAffact = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffact;
        }

        public string GetType(string testName)
        {
            string typeName = "";

            string getForTypeWise = "SELECT TestTypeSetup.testTypeName FROM TestTypeSetup JOIN TestSetup " +
                                    "ON TestSetup.testTypeSetupId = TestTypeSetup.testTypeId WHERE " +
                                    "TestSetup.testName = @TEST;";

            Command = new SqlCommand(getForTypeWise, Connection);
            Command.Parameters.Add("TEST", SqlDbType.VarChar).Value = testName;

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                typeName = Reader["testTypeName"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return typeName;
        }
    }
}