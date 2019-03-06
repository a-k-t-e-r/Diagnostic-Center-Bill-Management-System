using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.DAL.Model;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class UnpaidBillReportWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        UnpaidBillReportModel ubrModel = new UnpaidBillReportModel();
        UnpaidBillReportManager ubrManager = new UnpaidBillReportManager();

        protected void showButton_Click(object sender, EventArgs e)
        {
            ubrModel.FromDate = Convert.ToDateTime(fromDateTextBox.Text);
            ubrModel.ToDate = Convert.ToDateTime(toDateTextBox.Text);

            List<UnpaidBillReportModel> ubrModels = ubrManager.GetAllInformation(ubrModel.FromDate, ubrModel.ToDate);
            typeWiseReportGridView.DataSource = ubrModels;
            typeWiseReportGridView.DataBind();

            double total = 0;
            foreach (UnpaidBillReportModel ubrM in ubrModels)
            {
                total += ubrM.TreTotal;
            }
            totalTextBox.Text = total.ToString();

            fromDateTextBox.Text = toDateTextBox.Text = "";
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {

        }
    }
}