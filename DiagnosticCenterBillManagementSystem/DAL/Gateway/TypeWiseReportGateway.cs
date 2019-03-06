using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.DAL.Gateway
{
    public class TypeWiseReportGateway : BaseGateway
    {
        public List<string> GetAllTestNames(DateTime fromDate, DateTime toDate)
        {
            string sqlString = "SELECT TestRequestEntry.testReqAllNames FROM TestRequestEntry JOIN " +
                               "PaymentInfo ON TestRequestEntry.testReqPaymentId = PaymentInfo.paymentId " +
                               "WHERE paymentdate BETWEEN @FROM AND @TO;";
            Command = new SqlCommand(sqlString, Connection);
            Command.Parameters.Add("@FROM", SqlDbType.Date).Value = fromDate;
            Command.Parameters.Add("@TO", SqlDbType.Date).Value = toDate;

            Connection.Open();
            List<string> testNameList = new List<string>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                string allTestNames = Reader["testReqAllNames"].ToString();

                testNameList.Add(allTestNames);
            }
            Reader.Close();
            Connection.Close();

            return testNameList;
        }

        public string GetTypeName(string testName)
        {
            string strType = "";

            string getType = "SELECT TestTypeSetup.testTypeName FROM TestTypeSetup JOIN TestSetup ON " +
                            "TestSetup.testTypeSetupId = TestTypeSetup.testTypeId WHERE TestSetup.testName = @TestName;";
            Command = new SqlCommand(getType, Connection);
            Command.Parameters.Add("TestName", SqlDbType.VarChar).Value = testName;

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                strType = Reader["testTypeName"].ToString();
            }
            Reader.Close();
            Connection.Close();

            return strType;
        }

        public double GetFee(string testName)
        {
            double strFee = 0;

            string getFee = "SELECT TestSetup.testFee FROM TestTypeSetup JOIN TestSetup ON " +
                            "TestSetup.testTypeSetupId = TestTypeSetup.testTypeId WHERE TestSetup.testName = @TestName;";
            Command = new SqlCommand(getFee, Connection);
            Command.Parameters.Add("TestName", SqlDbType.VarChar).Value = testName;

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                strFee = Convert.ToDouble(Reader["testFee"]);
            }
            Reader.Close();
            Connection.Close();

            return strFee;
        }
    }
}