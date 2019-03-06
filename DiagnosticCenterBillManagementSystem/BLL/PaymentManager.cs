using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.DAL.Gateway;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class PaymentManager
    {
        PaymentGateway payGateway = new PaymentGateway();
        public string GetInfo(int billId)
        {
            double totalAmount = payGateway.GetInfo(billId);
            return totalAmount.ToString();
        }

        public string GetInfo(string mobileNo)
        {
            double totalAmount = payGateway.GetInfo(mobileNo);
            return totalAmount.ToString();
        }

        public string SetPayment(DateTime dueDate, string paymentStatus, int billId)
        {
            int status = payGateway.SetPayment(dueDate, paymentStatus, billId);
            if (status > 0)
            {
                return "PaymentModel ***Clear***";
            }
            else
            {
                return "PaymentModel Not Clear !!!";
            }
        }

        public string SetPayment(DateTime dueDate, string paymentStatus, string mobileNo)
        {
            int status = payGateway.SetPayment(dueDate, paymentStatus, mobileNo);
            if (status > 0)
            {
                return "PaymentModel ***Clear***";
            }
            else
            {
                return "PaymentModel Not Clear !!!";
            }
        }
    }
}