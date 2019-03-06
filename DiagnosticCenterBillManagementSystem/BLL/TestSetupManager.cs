using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.DAL.Gateway;
using DiagnosticCenterBillManagementSystem.DAL.Model;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class TestSetupManager
    {
        TestSetupGateway tsGateway = new TestSetupGateway();

        public List<TestTypeSetupModel> GetAllNames()
        {
            List<TestTypeSetupModel> lModel = tsGateway.GetAllNames();

            return lModel;
        }

        public string SetTestSetupInfo(string tsName, double tsFee, string ttsName)
        {
            int check = tsGateway.SetTestSetupInfo(tsName, tsFee, ttsName);
            if (check > 0)
            {
                return "Saved Successfully :)";
            }
            else
            {
                return "Saved Unsuccessfully :(";
            }
        }

        public List<TestSetupModel> GetAllInfo()
        {
            List<TestSetupModel> lModel = tsGateway.GetAllInfo();

            return lModel;
        }
    }
}