using System;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.DAL.Model;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class PaymentWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        PaymentModel payModel = new PaymentModel();
        PaymentManager payManager = new PaymentManager();

        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (mobileNoTextBox.Text == "")
            {
                payModel.BillId = Convert.ToInt32(billNoTextBox.Text);
                amountTextBox.Text = payManager.GetInfo(payModel.BillId);
            }
            else if (billNoTextBox.Text == "")
            {
                payModel.TreMobile = mobileNoTextBox.Text;
                amountTextBox.Text = payManager.GetInfo(payModel.TreMobile);
            }
            else
            {
                statusLabel.Text = "**fault** in search techniqe";
            }
        }

        protected void payButton_Click(object sender, EventArgs e)
        {
            DateTime dueDate = Convert.ToDateTime(dueDateTextBox.Text);
            string paymentStatus = "Paid";

            if (mobileNoTextBox.Text == "")
            {
                payModel.BillId = Convert.ToInt32(billNoTextBox.Text);
                statusLabel.Text = payManager.SetPayment(dueDate, paymentStatus, payModel.BillId);
            }
            else if (billNoTextBox.Text == "")
            {
                payModel.TreMobile = mobileNoTextBox.Text;
                statusLabel.Text = payManager.SetPayment(dueDate, paymentStatus, payModel.TreMobile);
            }
            billNoTextBox.Text = mobileNoTextBox.Text = amountTextBox.Text = dueDateTextBox.Text = "";
        }
    }
}