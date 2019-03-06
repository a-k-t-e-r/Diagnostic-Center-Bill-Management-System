<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRequestEntryWebForm.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.TestRequestEntryWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Request Entry</title>
    <link href="CSS/StyleSheet4Home.css" rel="stylesheet" />
    <link href="CSS/StyleSheet4Request.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-datepicker.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/bootstrap-datepicker.min.js"></script>
    <script type="text/javascript">
        $(Document).ready(function() {
            $('#birthTextBox').datepicker({
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
                    <dd><a href="PaymentWebForm.aspx">Payment Model</a></dd>
                </dl>

                <dl>
                    <dt>Report</dt>
                    <dd><a href="TestWiseReportWebForm.aspx">Test Wise Report</a></dd>
                    <dd><a href="TypeWiseReportWebForm.aspx">Type Wise Report</a></dd>
                    <dd><a href="UnpaidBillReportWebForm.aspx">Unpaid Bill Report</a></dd>
                </dl>
            </div>

            <div id="EntryBar">
                <h3 id="EntryName">Test Request Entry</h3>
                <table>
                    <tr>
                        <th>
                            <asp:Label ID="Label1" runat="server" Text="Name Of The Patient:"></asp:Label></th>
                        <td>
                            <asp:TextBox ID="patientNameTextBox" runat="server" Width="200px" Font-Size="20px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="Label2" runat="server" Text="Date Of Birth:"></asp:Label></th>
                        <td id="dateOfBirth">
                            <asp:TextBox ID="birthTextBox" runat="server" Width="200px" Font-Size="20px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="Label4" runat="server" Text="Mobile No."></asp:Label></th>
                        <td>
                            <asp:TextBox ID="mobileNo" runat="server" Width="200px" Font-Size="20px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="Label3" runat="server" Text="Select Test:"></asp:Label></th>
                        <td>
                            <asp:DropDownList ID="testReqEntryDropDownList" runat="server" Width="203px" Font-Size="20px" OnSelectedIndexChanged="testTypeDropDownList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="Label5" runat="server" Text="Fee"></asp:Label></th>
                        <td id="fee">
                            <asp:TextBox ID="feeTextBox" runat="server" Width="100px" Font-Size="20px" ReadOnly="True" Enabled="False"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th></th>
                    </tr>
                    <tr>
                        <th></th>
                        <td id="add">
                            <asp:Button ID="addButton" runat="server" Text="A D D" Font-Bold="True" Font-Size="20px" OnClick="addButton_Click" /></td>
                    </tr>
                </table>
                <p>
                    <asp:Label ID="statusLabel" runat="server" Text="[status]"></asp:Label>
                </p>

                <div class="GridView">
                    <asp:GridView ID="TestRequestEntryGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="515px" AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

                        <Columns>
                            <asp:TemplateField HeaderText="#Sl No.">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("SerialNo") %>'>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Patient Name">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("trePatientName") %>'>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Date Of Birth">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("treDoB") %>'>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Test Name">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("TsName") %>'>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Test Fee">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("TsFee") %>'>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <br />
                <div class="afterGV">
                    <asp:Label ID="Label6" runat="server" Text="TOTAL"></asp:Label>
                    <br />
                    <asp:TextBox ID="totalTextBox" runat="server" Height="40px" Width="105px" Font-Size="30px" Enabled="False"></asp:TextBox>
                    <br />
                    <asp:Button ID="saveButton" runat="server" Text="S A V E" Font-Bold="True" Font-Size="20px" OnClick="saveButton_Click" />
                </div>
            </div>
        </div>
    </form>

    <script src="CSS/Bootstrap/js/bootstrap.js"></script>
    <script>
        $(document).ready(function () {
            $('#dateOfBirth').datepicker({
                format: "dd-MM-yyyy",
                autoclose: true,
                todayHighlight: true
            });
        });
    </script>
</body>
</html>
