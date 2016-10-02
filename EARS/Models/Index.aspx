<%@ Page Language="C#" MasterPageFile="~/Models/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EARS.Models.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script language="javascript" type="text/javascript">
        // the jQuery ready shortcut  
        $(function () {
            // set up our datepicker 
            $('#<%=txtFromDate.ClientID%>').datetimepicker({

                timepicker: false,
                format: 'Y-m-d'
            });
            $('#<%=txtToDate.ClientID%>').datetimepicker({

                timepicker: false,
                format: 'Y-m-d'
            });
        });
    </script>


    <fieldset>
        <legend>Test Report Summary</legend>

        <div>
            <asp:RadioButtonList ID="rdOptionList" runat="server" OnSelectedIndexChanged="rdOptionList_SelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal">
                <asp:ListItem Text="Test Case ID" Value="TCID" />
                <asp:ListItem Text="Name Search" Value="Name" />
                <asp:ListItem Text="Date Search" Value="Date" />
            </asp:RadioButtonList>

        </div>
        <div class="pl-helper-20margin-top pl-helper-20margin-bottom">

            <asp:Label ID="lblFromDate" runat="server" Text="From Date" Font-Bold="True"></asp:Label>&nbsp;<asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>&nbsp;
                <asp:Label ID="lblToDate" runat="server" Text="To Date" Font-Bold="True"></asp:Label><asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>

            <asp:Label ID="lblTestCycleID" runat="server">Test Cycle ID</asp:Label>
            <asp:TextBox ID="txtTestCycleID" runat="server"></asp:TextBox>
            <asp:Label ID="lblName" runat="server">Name</asp:Label>
            <asp:DropDownList ID="ddlName" runat="server"></asp:DropDownList>
            &nbsp;<asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" CssClass="pl-btn pl-btn-medium" />
        </div>

    </fieldset>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="pl-table pl-data-table">
        <Columns>
            <asp:TemplateField HeaderText="Test Cycle ID">
                <ItemTemplate>
                    <asp:LinkButton ID="btlLink" runat="server" Text='<%# Eval("TestCycleID") %>' OnCommand="OnLnkClick" CssClass="pl-btn pl-btn-link"
                        CommandArgument='<%# Eval("TestCycleID") %>'> </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="AUTName" HeaderText="AUTName" SortExpression="AUTName" />
            <asp:BoundField DataField="ExecutedBy" HeaderText="ExecutedBy" SortExpression="ExecutedBy" />
            <asp:BoundField DataField="RequestedBy" HeaderText="RequestedBy" SortExpression="RequestedBy" />
            <asp:BoundField DataField="BuildNo" HeaderText="BuildNo" SortExpression="BuildNo" />
            <asp:BoundField DataField="ApplicationVersion" HeaderText="ApplicationVersion" SortExpression="ApplicationVersion" />
        </Columns>
    </asp:GridView>
</asp:Content>
