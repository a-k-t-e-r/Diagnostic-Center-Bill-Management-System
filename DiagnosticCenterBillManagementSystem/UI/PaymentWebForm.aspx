<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentWebForm.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.PaymentWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Model</title>
    <link href="CSS/StyleSheet4Home.css" rel="stylesheet" />
    <link href="CSS/StyleSheet4Request.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-datepicker.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/bootstrap-datepicker.min.js"></script>
    <script type="text/javascript">
        $(Document).ready(function() {
            $('#dueDateTextBox').datepicker({
                format: "dd/MM/yyyy",
                orientation: "bottom right",
                daysOfWeekHighlighted: "5",
                autoclose: true,
                todayHighlight: true
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
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
                    <dd><a href="PaymentWebForm.aspx">Payment</a></dd>
                </dl>

                <dl>
                    <dt>Report</dt>
                    <dd><a href="TestWiseReportWebForm.aspx">Test Wise Report</a></dd>
                    <dd><a href="TypeWiseReportWebForm.aspx">Type Wise Report</a></dd>
                    <dd><a href="UnpaidBillReportWebForm.aspx">Unpaid Bill Report</a></dd>
                </dl>
            </div>
            <div id="PayBar">
                <h3 id="PayName">Payment Model</h3>
                <table>
                    <tr>
                        <th>
                            <asp:Label ID="Label1" runat="server" Text="Bill No.:"></asp:Label></th>
                        <td>
                            <asp:TextBox ID="billNoTextBox" runat="server" Width="200px" Font-Size="20px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <asp:Label ID="Label2" runat="server" Text="OR,"></asp:Label></td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="Label3" runat="server" Text="Mobile No.:"></asp:Label></th>
                        <td>
                            <asp:TextBox ID="mobileNoTextBox" runat="server" Width="200px" Font-Size="20px"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <th></th>
                        <td style="text-align: right;">
                            <asp:Button ID="searchButton" runat="server" Text="SEARCH" Font-Bold="True" Font-Size="20px" OnClick="searchButton_Click" /></td>
                    </tr>
                </table>
                <br />
                <table>
                    <tr>
                        <th>
                            <asp:Label ID="Label4" runat="server" Text="Amount:"></asp:Label></th>
                        <td>
                            <asp:TextBox ID="amountTextBox" runat="server" Width="200px" Font-Size="20px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th><asp:Label ID="Label5" runat="server" Text="Due Date:"></asp:Label></th>
                        <td><asp:TextBox ID="dueDateTextBox" runat="server" Width="200px" Font-Size="20px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th></th>
                        <td style="text-align: right;">
                            <asp:Button ID="payButton" runat="server" Text="PAY" Font-Bold="True" Font-Size="20px" OnClick="payButton_Click" /></td>
                    </tr>
                </table>
                <br />
                <asp:Label runat="server" ID="statusLabel" Text="[status]" ForeColor="red" Font-Bold="True" Font-Size="20px"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
