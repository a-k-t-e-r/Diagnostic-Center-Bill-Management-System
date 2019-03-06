using System;
using System.Collections.Generic;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.DAL.Model;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class TestRequestEntryWebForm : System.Web.UI.Page
    {
        TestRequestEntryManager treMan = new TestRequestEntryManager();
        private List<TestSetupModel> tsModel;

        protected void Page_Load(object sender, EventArgs e)
        {
            tsModel = treMan.GetAllTestNames();
            if (!IsPostBack)
            {
                SetDataForDropDown();
            }
        }

        private void SetDataForDropDown()
        {
            testReqEntryDropDownList.DataSource = tsModel;
            testReqEntryDropDownList.DataTextField = "TsName";
            testReqEntryDropDownList.DataBind();
        }

        protected void testTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (TestSetupModel tsM in tsModel)
            {
                if (testReqEntryDropDownList.SelectedValue == tsM.TsName)
                {
                    feeTextBox.Text = tsM.TsFee.ToString();
                    break;
                }
            }
        }

        List<TestRequestEntryModel> treModel = new List<TestRequestEntryModel>();
        private int setSerial = 1;

        protected void addButton_Click(object sender, EventArgs e)
        {
            if (Session["addLists"] != null)
            {
                treModel = (List<TestRequestEntryModel>)Session["addLists"];
                foreach (TestRequestEntryModel tReqModel in treModel)
                {
                    setSerial = tReqModel.SerialNo++;
                }
            }

            TestRequestEntryModel trEntryModel = new TestRequestEntryModel();
            trEntryModel.TrePatientName = patientNameTextBox.Text;
            trEntryModel.TreDoB = Convert.ToDateTime(birthTextBox.Text);
            trEntryModel.TreMobile = mobileNo.Text;
            trEntryModel.TsName = testReqEntryDropDownList.SelectedValue;
            trEntryModel.TsFee = Convert.ToDouble(feeTextBox.Text);
            trEntryModel.SerialNo = setSerial;

            treModel.Add(trEntryModel);
            Session["addLists"] = treModel;
            TestRequestEntryGridView.DataSource = treModel;
            TestRequestEntryGridView.DataBind();

            statusLabel.Text = "Information Added";
            if (treModel.Count == 1)
            {
                totalTextBox.Text = trEntryModel.TsFee.ToString();
            }
            else
            {
                double fee = 0;
                foreach (TestRequestEntryModel entryTotal in treModel)
                {
                    fee += entryTotal.TsFee;
                }
                totalTextBox.Text = fee.ToString();
            }

            patientNameTextBox.Text = String.Empty;
            birthTextBox.Text = String.Empty;
            mobileNo.Text = String.Empty;
            feeTextBox.Text = String.Empty;
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string patientName = "";
            DateTime patientBirthDate = new DateTime();
            string patientMobileNo = "";
            string allTestNames = "";
            string paymentStatus = "Due";

            treModel = (List<TestRequestEntryModel>) Session["addLists"];
            foreach (TestRequestEntryModel entry in treModel)
            {
                patientName = entry.TrePatientName;
                patientBirthDate = entry.TreDoB;
                patientMobileNo = entry.TreMobile;
                allTestNames += entry.TsName + ", ";
            }
            double totalFees = double.Parse(totalTextBox.Text);

            statusLabel.Text = treMan.SetPatientInfo(patientName, patientBirthDate, patientMobileNo);
            statusLabel.Text += treMan.SetPaymentInfo(DateTime.Today, paymentStatus);
            statusLabel.Text = treMan.SetRequestInfo(totalFees, allTestNames, patientName);

            patientNameTextBox.Text = birthTextBox.Text = mobileNo.Text = feeTextBox.Text = totalTextBox.Text = "";
            SetDataForDropDown();
            TestRequestEntryGridView.DataSource = "";
            TestRequestEntryGridView.DataBind();
            Session["addLists"] = null;
        }

    }
}