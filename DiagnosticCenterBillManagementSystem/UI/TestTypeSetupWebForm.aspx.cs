using System;
using System.Collections.Generic;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.DAL.Model;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class TestTypeSetupWebForm : System.Web.UI.Page
    {
        TestTypeSetupManager ttsMan = new TestTypeSetupManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllTypesName();
        }

        private void GetAllTypesName()
        {
            List<TestTypeSetupModel> lModel = ttsMan.GetAllNames();
            testTypeSetupGridView.DataSource = lModel;
            testTypeSetupGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            statusLabel.Text = ttsMan.SetNames(typeNameTextBox.Text);

            typeNameTextBox.Text = "";
        }
    }
}