using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edward.DAL;
using Edward.DBHelper;
using System.Data.SqlClient;

namespace InventorySystem_Demo
{
	public partial class ItemList : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                Bind();
            }            
		}

        protected void Bind()
        {
            string sql = "Select ItemId,Code,Name,CategoryName,Price,StatusCodeText from Items";
            DataTable dt = BaseDAL.DBHelper.GetList(sql);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("./NewItem.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string ItemId = GridView1.DataKeys[index].Value.ToString();

            if (e.CommandName == "MyNum")
            {
                string url = "./ItemProfile.aspx?ItemId=" + ItemId;
                Response.Redirect(url);
            }
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            int ItemId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            string sqlUpdate = "Update TF_Item set StatusCode=2 where ItemId=@ItemId";
            SqlParameter param = new SqlParameter("@ItemId", ItemId);
            if (BaseDAL.DBHelper.Update(sqlUpdate, param) > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "alert('删除成功！');window.location.href='./ItemList.aspx'",true);
                Bind();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Fail", "alert('删除失败！')", true);
            }
        }
    }
}