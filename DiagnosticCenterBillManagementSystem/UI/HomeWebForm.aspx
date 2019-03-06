<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeWebForm.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.HomeWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
    <link href="CSS/StyleSheet4Home.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="Header">
                <h1>Diagonostic Center Bill Management System</h1>
            </div>

            <div id="Navigation">
                <a id="HomeLink" href="HomeWebForm.aspx">H O M E</a>
                <dl>
                    <dt>Setup</dt>
                    <dd><a href="TestTypeSetupWebForm.aspx">Test Type Setup</a></dd>
                    <dd><a href="TestSetupWebForm.aspx">Test Setup</a></dd>
                </dl>

                <dl>
                    <dt>Request</dt>
                    <dd><a href="TestRequestEntryWebForm.aspx">Test Request Entry</a></dd>
                    <dd><a href="PaymentWebForm.aspx">PaymentModel</a></dd>
                </dl>

                <dl>
                    <dt>Report</dt>
                    <dd><a href="TestWiseReportWebForm.aspx">Test Wise Report</a></dd>
                    <dd><a href="TypeWiseReportWebForm.aspx">Type Wise Report</a></dd>
                    <dd><a href="UnpaidBillReportWebForm.aspx">Unpaid Bill Report</a></dd>
                </dl>
            </div>

            <div id="HomeBar">
                <h3>Welcome Here</h3>
            </div>
            <br />
            <br />
            <div id="aboutCoder">
                <p>Md. Akter Hossain</p>
            </div>
        </div>
    </form>
</body>
</html>
