using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edward.DAL;
using Edward.BLL;
using Edward.DBHelper;
using Edward.Framework;
using System.Data;
using System.Data.SqlClient;

namespace InventorySystem_Demo
{
    public partial class AreaList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind(); 
            }
        }
        public void Bind()
        {
            string sql = "select * from TF_Area where StatusCode=1";
            DataTable dt = BaseDAL.DBHelper.GetList(sql);
            GridView1.DataSource = dt;
            GridView1.DataKeyNames = new string[] { "AreaId" };
            GridView1.DataBind();
            GetNull(dt);
        }

        public void GetNull(DataTable dt)
        {
            int columnCount = dt.Columns.Count;
            //if (columnCount==0)
            //{
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columnCount;
                GridView1.Rows[0].Cells[0].Text = "没有记录";
                GridView1.Rows[0].Cells[0].Style.Add("text-align", "center");
                GridView1.Rows[0].Cells[0].Style.Add("color", "red"); 
            //}
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((LinkButton)(e.CommandSource)).Parent.Parent;//获取父本实例化
            int ID = gvr.RowIndex;//获取行的ID;
            int AID = Convert.ToInt32(GridView1.DataKeys[ID].Value);//获取区域ID
            if (e.CommandName== "Profile")
            {
                Session["AID"] = AID;
                Response.Redirect("~/AreaProfile.aspx");
            }
            if (e.CommandName=="MyDelete")
            {
                SqlParameter[] p = new SqlParameter[] { new SqlParameter("@id", AID) };
                BaseDAL.DBHelper.Update("update TF_Area set StatusCode=2 where AreaId=@id", p);
                Bind();
            }
        }
    }
}