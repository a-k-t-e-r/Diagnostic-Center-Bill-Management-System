using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DiagnosticCenterBillManagementSystem.DAL.Model;

namespace DiagnosticCenterBillManagementSystem.DAL.Gateway
{
    public class TestTypeSetupGateway : BaseGateway
    {
        public bool CheckDuplicate(string ttsName)
        {
            string checkQuery = "SELECT * FROM TestTypeSetup WHERE testTypeName = '"+ttsName+"'";
            Command = new SqlCommand(checkQuery, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            bool b = Reader.HasRows;
            Reader.Close();
            Connection.Close();

            return b;
        }

        public int SetNames(string ttsName)
        {
            string setQuery = "INSERT INTO TestTypeSetup(testTypeName) VALUES('"+ttsName+"')";
            Command = new SqlCommand(setQuery, Connection);

            Connection.Open();
            int i = Command.ExecuteNonQuery();
            Connection.Close();

            return i;
        }

        public List<TestTypeSetupModel> GetAllNames()
        {
            string getQuery = "SELECT * FROM TestTypeSetup";
            Command = new SqlCommand(getQuery, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            int a = 0;
            List<TestTypeSetupModel> lModel = new List<TestTypeSetupModel>();
            while (Reader.Read())
            {
                TestTypeSetupModel aModel = new TestTypeSetupModel();
                aModel.TtsId = Convert.ToInt32(Reader["testTypeId"]);
                aModel.TtsName = Reader["testTypeName"].ToString();
                aModel.SerialNo = a + 1;

                lModel.Add(aModel);
                a++;
            }
            Reader.Close();
            Connection.Close();

            return lModel;
        }
    }
}