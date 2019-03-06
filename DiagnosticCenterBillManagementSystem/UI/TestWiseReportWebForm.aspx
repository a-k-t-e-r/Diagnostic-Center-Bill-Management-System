<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestWiseReportWebForm.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.TestWiseReportWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Wise Report</title>
    <link href="CSS/StyleSheet4Home.css" rel="stylesheet" />
    <link href="CSS/StyleSheet4Report.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-datepicker.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/bootstrap-datepicker.min.js"></script>
    <script type="text/javascript">
        $(Document).ready(function() {
            $('#fromDateTextBox').datepicker({
                format: "dd/MM/yyyy",
                orientation: "bottom right",
                daysOfWeekHighlighted: "5",
                autoclose: true,
                todayHighlight: true
            });

            $('#toDateTextBox').datepicker({
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

            <div class="Main">
                <h3 class="Header">Test Wise Report</h3>
                <table>
                    <tr>
                        <th>
                            <asp:Label ID="Label1" runat="server" Text="From Date:"></asp:Label></th>
                        <td>
                            <asp:TextBox ID="fromDateTextBox" runat="server" Width="200px" Font-Size="20px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="Label2" runat="server" Text="To Date:"></asp:Label></th>
                        <td>
                            <asp:TextBox ID="toDateTextBox" runat="server" Width="200px" Font-Size="20px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th></th>
                        <td id="Show">
                            <asp:Button ID="showButton" runat="server" Text="S H O W" Font-Bold="True" Font-Size="20px" OnClick="showButton_Click" /></td>
                    </tr>
                </table>
                <br />
                <div style="width: 443px; float: left;">
                    <asp:GridView ID="testWiseReportGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="451px">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />

                        <Columns>
                            <asp:TemplateField HeaderText="#Sl No.">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("SerialNo") %>'>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <Columns>
                            <asp:TemplateField HeaderText="Dates">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("AllDates") %>'>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <Columns>
                            <asp:TemplateField HeaderText="Test Names">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("TsName") %>'>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <Columns>
                            <asp:TemplateField HeaderText="Total Fees">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("TreTotal") %>'>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <Columns>
                            <asp:TemplateField HeaderText="Payment Status">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("PaymentStatus") %>'>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <br />
                <div class="Footer">
                    <asp:Label ID="Label6" runat="server" Text="TOTAL "></asp:Label>
                    <asp:TextBox ID="totalTextBox" runat="server" Height="40px" Width="90px" Font-Size="30px" Enabled="False"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="pdfButton" runat="server" Text="Report Generate" Font-Bold="True" Font-Size="20px" OnClick="pdfButton_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
