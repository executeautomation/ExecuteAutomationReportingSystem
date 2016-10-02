using EARS.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EARS.Models
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                LoadPage();
                //Connect with the EARS_DB
                DBHelper.ConnectReportingServer();

                //Execute a query to fetch the data for grid
                string query = "SELECT [TestCycleID],[AUTName], [ExecutedBy], [RequestedBy], [BuildNo], [ApplicationVersion] FROM [tblTestCycle]";
                DataTable table = Settings.ReportingConn.ExecuteQuery(query);

                //Bind the data to the gridview
                GridView1.DataSource = table;
                GridView1.DataBind();

                query = "select distinct ExecutedBy from tblTestCycle";
                DataTable source = Settings.ReportingConn.ExecuteQuery(query);
                PopulateCombobox(source, ddlName, "ExecutedBy");
            }

        }

        public void PopulateCombobox(DataTable dsSource, DropDownList cmbbox, string columnName)
        {
            try
            {
                cmbbox.DataTextField = columnName;
                cmbbox.DataValueField = columnName;
                cmbbox.DataSource = dsSource;
                cmbbox.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }


        protected void btnShow_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            try
            {
                string sFromDate = txtFromDate.Text;
                string sToDate = txtToDate.Text;
                int nTestCycleID = int.Parse(txtTestCycleID.Text.Length > 0 ? txtTestCycleID.Text : "-1");
                string userName = string.Empty;
                //Only set value if the visibility True
                if (ddlName.Visible == true)
                    userName = ddlName.SelectedItem.ToString();
                else
                    userName = string.Empty;

                ht.Add("@FromDate", sFromDate);
                ht.Add("@ToDate", sToDate);
                ht.Add("@TestCycleID", nTestCycleID);
                ht.Add("@ExecutedBy", userName);
                DataTable dt = Settings.ReportingConn.ExecuteProcWithParamsDT("sp_GetFilterData", ht);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ht = null;
            }
            finally
            {
                ht = null;
            }
        }


        public void LoadPage()
        {
            lblToDate.Visible = false;
            lblFromDate.Visible = false;
            txtFromDate.Visible = false;
            txtToDate.Visible = false;
            lblTestCycleID.Visible = false;
            txtTestCycleID.Visible = false;
            lblName.Visible = false;
            ddlName.Visible = false;
            btnShow.Visible = false;
        }

        protected void rdOptionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnShow.Visible = true;
            if (rdOptionList.SelectedItem.Value == "TCID")
            {
                lblTestCycleID.Visible = true;
                txtTestCycleID.Visible = true;
                lblToDate.Visible = false;
                lblFromDate.Visible = false;
                txtFromDate.Visible = false;
                txtToDate.Visible = false;
                lblName.Visible = false;
                ddlName.Visible = false;
                txtFromDate.Text = string.Empty;
                txtToDate.Text = string.Empty;
            }
            if (rdOptionList.SelectedItem.Value == "Date")
            {
                lblToDate.Visible = true;
                lblFromDate.Visible = true;
                txtFromDate.Visible = true;
                txtToDate.Visible = true;
                lblTestCycleID.Visible = false;
                txtTestCycleID.Visible = false;
                lblName.Visible = false;
                ddlName.Visible = false;
                txtTestCycleID.Text = string.Empty;
            }
            if (rdOptionList.SelectedItem.Value == "Name")
            {
                lblName.Visible = true;
                ddlName.Visible = true;
                lblToDate.Visible = false;
                lblFromDate.Visible = false;
                txtFromDate.Visible = false;
                txtToDate.Visible = false;
                lblTestCycleID.Visible = false;
                txtTestCycleID.Visible = false;
                txtTestCycleID.Text = string.Empty;
                txtFromDate.Text = string.Empty;
                txtToDate.Text = string.Empty;
            }
        }

        protected void OnLnkClick(object sender, CommandEventArgs e)
        {
            Response.Redirect("DetailedReport.aspx?ParentCycleID=" + e.CommandArgument.ToString());
        }
    }
}