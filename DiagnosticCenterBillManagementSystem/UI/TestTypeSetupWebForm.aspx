<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTypeSetupWebForm.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.TestTypeSetupWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Type Setup</title>
    <link href="CSS/StyleSheet4Home.css" rel="stylesheet" />
    <link href="CSS/StyleSheet4Setup.css" rel="stylesheet" />
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

            <div id="TypeBar">
                <h3 id="TypeName">Test Type Setup</h3>
                <table>
                    <tr>
                        <th>
                            <asp:Label ID="Label1" runat="server" Text="Type Name:"></asp:Label></th>
                        <td>
                            <asp:TextBox ID="typeNameTextBox" runat="server" Width="200px" Font-Size="20px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>
                            <td></td>
                        </th>
                    </tr>
                    <tr>
                        <th></th>
                        <td id="Save">
                            <asp:Button ID="saveButton" runat="server" Text="S A V E" Font-Bold="True" Font-Size="20px" OnClick="saveButton_Click" /></td>
                    </tr>
                </table>
                <p>
                    <asp:Label ID="statusLabel" runat="server" Text="[status]"></asp:Label></p>

                <div style="background-color: coral;">
                    <asp:GridView ID="testTypeSetupGridView" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" Width="311px" ForeColor="Black" GridLines="Vertical">
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />

                        <AlternatingRowStyle BackColor="#CCCCCC" />

                        <Columns>
                            <asp:TemplateField HeaderText="#Sl No.">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("SerialNo") %>'>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Type Name">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("TtsName") %>'>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
