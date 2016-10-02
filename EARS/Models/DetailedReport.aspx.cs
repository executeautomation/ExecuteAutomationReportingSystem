using EARS.Utilities;
using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EARS.Models
{
    public partial class DetailedReport : System.Web.UI.Page
    {
        bool IsReportExist = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Hashtable ht = new Hashtable();
                lblNotExist.Visible = false;
                DBHelper.ConnectReportingServer();
                string cycleId = Request.QueryString["ParentCycleID"] != null ? Request.QueryString["ParentCycleID"].ToString() : "-1";
                string query = "select distinct FeatureName,ScenarioName,StepName,Exception,Result from tblDetailReport Where ParentCycleId='" + cycleId + "'";

                var table = Settings.ReportingConn.ExecuteQuery(query);

                ht.Add("@ParentCycleID", cycleId);

                DataTable dt = Settings.ReportingConn.ExecuteProcWithParamsDT("sp_TCDetailsCount", ht);


                if (table != null && table.Rows.Count > 0)
                {
                    //Count Grid
                    grdCountDetails.DataSource = FlipDataTable(dt);
                    grdCountDetails.DataBind();
                    grdCountDetails.HeaderRow.Visible = false;

                    //Detail Grid
                    detailsGrid.DataSource = table;
                    detailsGrid.DataBind();
                    IsReportExist = true;
                }
                else
                {
                    lblNotExist.Visible = true;
                    string msgstring = "This might happen because of following reasons \n";
                    msgstring = msgstring + "1. No Report Found for the selected Test Cycle ID \n";
                    msgstring = msgstring + "2. Test execution is still in progress \n";
                    lblNotExist.Text = msgstring;
                }
            }
        }
        protected void detailsGrid_PreRender(object sender, EventArgs e)
        {
            if (IsReportExist)
            {
                string lastSubCategory = String.Empty;
                Table gridTable = (Table)detailsGrid.Controls[0];
                foreach (GridViewRow gvr in detailsGrid.Rows)
                {
                    HiddenField hfSubCategory = gvr.FindControl("hfSubCategory") as
                                                HiddenField;
                    string currSubCategory = hfSubCategory.Value;
                    if (lastSubCategory.CompareTo(currSubCategory) != 0)
                    {
                        int rowIndex = gridTable.Rows.GetRowIndex(gvr);
                        // Add new group header row
                        GridViewRow headerRow = new GridViewRow(rowIndex, rowIndex,
                            DataControlRowType.DataRow, DataControlRowState.Normal);
                        headerRow.CssClass = "header expand pl-light-blue-theme";
                        TableCell headerCell = new TableCell();
                        headerCell.ColumnSpan = detailsGrid.Columns.Count;
                        headerCell.Text = string.Format("{0}", currSubCategory);
                        // Add header Cell to header Row, and header Row to gridTable
                        headerRow.Cells.Add(headerCell);
                        gridTable.Controls.AddAt(rowIndex, headerRow);
                        // Update lastValue
                        lastSubCategory = currSubCategory;
                    }
                    if (gvr.Cells[4].Text.Contains("FAILED"))
                    {
                        gvr.Cells[4].BackColor = System.Drawing.Color.Red;
                    }
                }
            }
        }



        protected void grdCountDetails_PreRender(object sender, EventArgs e)
        {
            foreach (GridViewRow gvr in grdCountDetails.Rows)
            {
                gvr.Cells[0].BackColor = System.Drawing.Color.Yellow;
                gvr.Cells[0].Font.Bold = true;
            }
        }

        public static DataTable FlipDataTable(DataTable dt)
        {
            DataTable table = new DataTable();
            //Get all the rows and change into columns
            for (int i = 0; i <= dt.Rows.Count; i++)
            {
                table.Columns.Add(Convert.ToString(i));
            }
            DataRow dr;
            //get all the columns and make it as rows
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                dr = table.NewRow();
                dr[0] = dt.Columns[j].ToString();
                for (int k = 1; k <= dt.Rows.Count; k++)
                    dr[k] = dt.Rows[k - 1][j];
                table.Rows.Add(dr);
            }

            return table;
        }
    }
}