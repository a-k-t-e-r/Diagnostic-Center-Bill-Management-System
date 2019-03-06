using System;
using System.Collections.Generic;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.DAL.Model;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class TestSetupWebForm : System.Web.UI.Page
    {
        TestSetupModel tsModel = new TestSetupModel();
        TestSetupManager tsManager = new TestSetupManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RetriveData4DropDown();
            }
            RetriveAll();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            tsModel.TsName = testNameTextBox.Text;
            tsModel.TsFee = Convert.ToDouble(feeTextBox.Text);
            tsModel.TtsName = testTypeDropDownList.SelectedValue;

            statusLabel.Text = tsManager.SetTestSetupInfo(tsModel.TsName, tsModel.TsFee, tsModel.TtsName);
            testNameTextBox.Text = feeTextBox.Text = "";

            RetriveData4DropDown();
            RetriveAll();
        }

        private void RetriveData4DropDown()
        {
            List<TestTypeSetupModel> lModel = tsManager.GetAllNames();
            testTypeDropDownList.DataSource = lModel;
            testTypeDropDownList.DataTextField = "TtsName";
            testTypeDropDownList.DataValueField = "TtsName";
            testTypeDropDownList.DataBind();
        }

        private void RetriveAll()
        {
            List<TestSetupModel> lModel = tsManager.GetAllInfo();
            testSetupGridView.DataSource = lModel;
            testSetupGridView.DataBind();
        }
    }
}