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
    public partial class TypeWiseReportWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        TypeWiseReportModel twrModel = new TypeWiseReportModel();
        TypeWiseReportManager twrManager = new TypeWiseReportManager();
 
        protected void showButton_Click(object sender, EventArgs e)
        {
            double total = 0;
            twrModel.FromDate = Convert.ToDateTime(fromDateTextBox.Text);
            twrModel.ToDate = Convert.ToDateTime(toDateTextBox.Text);

            List<TypeWiseReportModel> twrModels = twrManager.GetAllTestNames(twrModel.FromDate, twrModel.ToDate);
            typeWiseReportGridView.DataSource = twrModels;
            typeWiseReportGridView.DataBind();

            foreach (TypeWiseReportModel twrM in twrModels)
            {
                total += twrM.Amount;
            }
            totalTextBox.Text = total.ToString();
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {

        }
    }
}