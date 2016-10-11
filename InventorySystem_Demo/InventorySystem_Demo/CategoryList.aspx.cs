using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edward.DAL;
using Edward.DBHelper;
using System.Data;
using System.Data.SqlClient;

namespace InventorySystem_Demo
{
    public partial class CategoryList : System.Web.UI.Page
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
            string sql = "Select CategoryId,Code,Name,Level,StatusCodeText from Categorys";
            DataTable dt = BaseDAL.DBHelper.GetList(sql);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("./NewCategory.aspx");
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            int CategoryId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            string sqlUpdate = "Update TF_Category set StatusCode=2 where CategoryId=@CategoryId";
            SqlParameter param = new SqlParameter("@CategoryId", CategoryId);
            if (BaseDAL.DBHelper.Update(sqlUpdate, param) > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "alert('删除成功！');window.location.href='./CategoryList.aspx'", true);
                Bind();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Fail", "alert('删除失败！')", true);
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string CategoryId = GridView1.DataKeys[index].Value.ToString();

            if (e.CommandName == "MyNum")
            {
                string url = "./CategoryProfile.aspx?CategoryId=" + CategoryId;
                Response.Redirect(url);
            }
        }
    }
}