using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.DAL.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class TestWiseReportWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        TestWiseReportModel twrModel = new TestWiseReportModel();
        TestWiseReportManager twrManager = new TestWiseReportManager();

        protected void showButton_Click(object sender, EventArgs e)
        {
            twrModel.FromDate = Convert.ToDateTime(fromDateTextBox.Text);
            twrModel.ToDate = Convert.ToDateTime(toDateTextBox.Text);

            List<TestWiseReportModel> twrModels = twrManager.GetAllInformation(twrModel.FromDate, twrModel.ToDate);
            testWiseReportGridView.DataSource = twrModels;
            testWiseReportGridView.DataBind();

            double total = 0;
            foreach (TestWiseReportModel twrM in twrModels)
            {
                total += twrM.TreTotal;
            }
            totalTextBox.Text = total.ToString();

            fromDateTextBox.Text = toDateTextBox.Text = "";
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(testWiseReportGridView.HeaderRow.Cells.Count);

            foreach (TableCell headerCell in testWiseReportGridView.HeaderRow.Cells)
            {
                Font font = new Font();
                font.Color = new BaseColor(testWiseReportGridView.HeaderStyle.ForeColor);

                PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text, font));
                pdfCell.BackgroundColor = new BaseColor(testWiseReportGridView.HeaderStyle.BackColor);
                pdfTable.AddCell(pdfCell);
            }

            foreach (GridViewRow gridViewRow in testWiseReportGridView.Rows)
            {
                foreach (TableCell tableCell in gridViewRow.Cells)
                {
                    Font font = new Font();
                    font.Color = new BaseColor(testWiseReportGridView.RowStyle.ForeColor);

                    PdfPCell pdfCell = new PdfPCell(new Phrase(tableCell.Text));
                    pdfCell.BackgroundColor = new BaseColor(testWiseReportGridView.RowStyle.BackColor);
                    pdfTable.AddCell(pdfCell);
                }
            }
            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=TestWiseReport.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }
    }
}