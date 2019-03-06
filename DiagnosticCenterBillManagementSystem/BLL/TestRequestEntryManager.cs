using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.DAL.Gateway;
using DiagnosticCenterBillManagementSystem.DAL.Model;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class TestRequestEntryManager
    {
        TestRequestEntryGateway treGate = new TestRequestEntryGateway();

        public List<TestSetupModel> GetAllTestNames()
        {
            List<TestSetupModel> tsModel = treGate.GetAllTestNames();
            return tsModel;
        }

        public string SetPatientInfo(string patientName, DateTime patientBirthDate, string patientMobileNo)
        {
            int rowAffact = treGate.SetPatientInfo(patientName, patientBirthDate, patientMobileNo);

            if (rowAffact > 0)
            {
                return "Patient Information Store...";
            }
            else
            {
                return "Some Problem Occurs, Check Again !!!";
            }
        }

        public string SetPaymentInfo(DateTime today, string paymentStatus)
        {
            int rowAffact = treGate.SetPaymentInfo(DateTime.Today, paymentStatus);
            if (rowAffact > 0)
            {
                return " & PaymentModel Information Store...";
            }
            else
            {
                return " & Some Problem Occurs, Check Again !!!";
            }
        }

        public string SetRequestInfo(double totalFees, string allTestNames, string patientName)
        {
            // Filtering All Test Names
            char[] c = allTestNames.ToCharArray();
            for (int i = 0; i < c.Count(); i++)
            {
                if (i == (c.Count() - 2))
                {
                    c[i] = c[i+1];
                }
            }
            allTestNames = "";
            for (int i = 0; i < c.Count()-2; i++)
            {
                allTestNames += c[i];
            }

            // Send to Gateway
            int rowAffact = treGate.SetRequestInfo(totalFees, allTestNames, patientName);
            if (rowAffact > 0)
            {
                return "Request Information Store...";
            }
            else
            {
                return "Some Problem Occurs, Check Again !!!";
            }
        }

        public string GetType(string testName)
        {
            string TypeName = treGate.GetType(testName);
            return TypeName;
        }
    }
}