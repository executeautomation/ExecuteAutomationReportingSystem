<%@ Page Title="" Language="C#" MasterPageFile="~/Models/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetailedReport.aspx.cs" Inherits="EARS.Models.DetailedReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(function () {
            $("#MainContent_detailsGrid").on("click", ".header", function () {
                $(this).toggleClass('expand').nextUntil('tr.header').slideToggle(100);
            });
        })

    </script>


    <div class="image-prev-templ" title="Image Preview">
        <img class="prev-img" />
    </div>

    <div class="pl-helper-20margin-top pl-helper-20margin-right pl-helper-20margin-left pl-helper-30margin-bottom ">
        <fieldset>
            <legend>Detailed Report</legend>

            <asp:Label ID="lblNotExist" Font-Size="Medium" runat="server" />


            <table style="width: 15%;">
                <tr>
                    <td>
                        <asp:GridView ID="grdCountDetails" runat="server" CellPadding="4" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" OnPreRender="grdCountDetails_PreRender">
                        </asp:GridView>
                    </td>
                </tr>
            </table>


            <asp:GridView ID="detailsGrid" runat="server" CssClass="pl-table pl-data-table pl-table-bordered"
                PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false" OnPreRender="detailsGrid_PreRender">
                <Columns>
                    <asp:BoundField DataField="FeatureName" HeaderText="Feature Name" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ScenarioName" HeaderText="Scenario Name">
                        <ItemStyle Width="200px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="StepName" HeaderText="Step Name" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle Width="250px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Exception" HeaderText="Exception">
                        <ItemStyle Width="250px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Result" HeaderText="Result">
                        <ItemStyle Width="50px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HiddenField ID="hfSubCategory" runat="server" Value='<%#Eval("FeatureName")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </fieldset>
    </div>
</asp:Content>
