using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.DAL.Gateway;
using DiagnosticCenterBillManagementSystem.DAL.Model;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class TestTypeSetupManager
    {
        TestTypeSetupGateway ttsSetupGateway = new TestTypeSetupGateway();

        public string SetNames(string ttsName)
        {
            bool check = ttsSetupGateway.CheckDuplicate(ttsName);
            if (check == true)
            {
                return "This Name is already in the LIST";
            }
            else
            {
                int notificatiion = ttsSetupGateway.SetNames(ttsName);
                if (notificatiion > 0)
                {
                    return "Name Saved Successfully :)";
                }
                else
                {
                    return "Sorry!!! Invalid :(";
                }
            }
        }

        public List<TestTypeSetupModel> GetAllNames()
        {
            List<TestTypeSetupModel> lModel = ttsSetupGateway.GetAllNames();

            return lModel;
        }
    }
}