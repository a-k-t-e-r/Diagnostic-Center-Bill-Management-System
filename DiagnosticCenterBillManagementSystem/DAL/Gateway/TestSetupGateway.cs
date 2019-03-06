using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.DAL.Model;

namespace DiagnosticCenterBillManagementSystem.DAL.Gateway
{
    public class TestSetupGateway : TestTypeSetupGateway
    {
        public int SetTestSetupInfo(string tsName, double tsFee, string ttsName)
        {
            int id = 0;
            string idQuery = "SELECT testTypeId FROM TestTypeSetup WHERE testTypeName = '" + ttsName + "'";
            Command = new SqlCommand(idQuery, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                id = Convert.ToInt32(Reader["testTypeId"]);
            }
            Reader.Close();
            Connection.Close();

            string infoQuery = "INSERT INTO TestSetup(testName, testFee, testTypeSetupId)" +
                               " VALUES(@TsName, @TsFee, @Id)";
            Command = new SqlCommand(infoQuery, Connection);
            Command.Parameters.Add("TsName", SqlDbType.VarChar).Value = tsName;
            Command.Parameters.Add("TsFee", SqlDbType.Float).Value = tsFee;
            Command.Parameters.Add("Id", SqlDbType.Int).Value = id;

            Connection.Open();
            int i = Command.ExecuteNonQuery();
            Connection.Close();

            return i;
        }

        public List<TestSetupModel> GetAllInfo()
        {
            string getQuery = "SELECT * FROM TestSetup JOIN TestTypeSetup " +
                              "ON TestSetup.testTypeSetupId = TestTypeSetup.testTypeId";
            Command = new SqlCommand(getQuery, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            int x = 0;
            List<TestSetupModel> lModel = new List<TestSetupModel>();
            while (Reader.Read())
            {
                TestSetupModel tsModel = new TestSetupModel();
                tsModel.TsId = Convert.ToInt32(Reader["testId"]);
                tsModel.SerialNo = x + 1;
                tsModel.TsName = Reader["testName"].ToString();
                tsModel.TsFee = Convert.ToDouble(Reader["testFee"]);
                tsModel.TtsName = Reader["testTypeName"].ToString();

                lModel.Add(tsModel);
                x++;
            }
            Reader.Close();
            Connection.Close();

            return lModel;
        }
    }
}