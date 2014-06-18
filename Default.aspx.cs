using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;  

namespace WebApplication3
{
    public partial class _Default : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        int currGridRowIndex;

        protected override void Render(HtmlTextWriter writer)
	    {
	        ClientScriptManager manager = Page.ClientScript;
	        for (int i=0; i< Grid1.Rows.Count;i++)
	        {
	            manager.RegisterForEventValidation(new System.Web.UI.PostBackOptions((Grid1), "SELECT$" + i.ToString()));
	        }
	        base.Render(writer);
	}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string[]> stringList = new List<string[]>();


                dt.Columns.Add("systemPrefix", System.Type.GetType("System.String"));
                dt.Columns.Add("appName", System.Type.GetType("System.String"));
                dt.Columns.Add("code", System.Type.GetType("System.String"));

                dr = dt.NewRow();

                dr["systemPrefix"] = "A";
                dr["appName"] = "ItemDetail";
                dr["code"] = "12941";

                dt.Rows.Add(dr);

                dr = dt.NewRow();

                dr["systemPrefix"] = "B";
                dr["appName"] = "Claims";
                dr["code"] = "901294";

                dt.Rows.Add(dr);

                dr = dt.NewRow();


                dr["systemPrefix"] = "C";
                dr["appName"] = "Uhhh";
                dr["code"] = "3532";

                dt.Rows.Add(dr);


                dt.AcceptChanges();
                Grid1.DataSource = dt;
                Grid1.DataBind();
            }
        }

        //save edited changes... 

        /* 
         * if (gvRow.RowType == DataControlRowType.DataRow)
               {
                   
                   gvRow.FindControl("SystemTxtBox").Visible = true;
                   gvRow.FindControl("SystemLabel").Visible = false;
               }             
         */

        protected void UpdateRow(object sender, EventArgs e)
        {
           foreach (GridViewRow gvRow in Grid1.Rows)
           {
               string val = ((TextBox)gvRow.FindControl("SystemTxtBox")).Text;

               dr["systemPrefix"] = val;
               

                //do something with all the values you have parsed from the row
           }
            
            dt.AcceptChanges();
            Grid1.DataSource = dt;
            Grid1.DataBind();
            
        }

        protected void SelectRow(object sender, EventArgs e)
        {
            updateBtn1.Enabled = true;
            deleteBtn1.Enabled = true;

            updateBtn1.BackColor = System.Drawing.Color.Red;
            deleteBtn1.BackColor = System.Drawing.Color.Black;
            deleteBtn1.ForeColor = System.Drawing.Color.White;
        }

        protected void DeleteRow(object sender, EventArgs e)
        { 
            dt.Rows.RemoveAt(Grid1.SelectedIndex);
            Grid1.DataSource = dt;
            Grid1.DataBind();
        }



        protected void RowData(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                   /* e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#eeff00';";

                    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='#ffffff';";
                    //e.Row.Attributes["onclick"] = manager.GetPostBackEventReference(sender as GridView, "SELECT$" + e.Row.RowIndex);
                */

                    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(sender as GridView, "SELECT$" + e.Row.RowIndex);

                    currGridRowIndex = e.Row.RowIndex;

               

    	    }
        }
    }
}
