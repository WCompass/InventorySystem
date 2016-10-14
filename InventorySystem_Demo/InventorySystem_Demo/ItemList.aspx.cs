using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edward.DAL;
using System.Data.SqlClient;

namespace InventorySystem_Demo
{
    public partial class ItemList : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            WebPaging.sqlTotalCount = "Select count(ItemId) from Items";
            WebPaging.sqlStringPath = "ItemList.aspx";  
            if (!IsPostBack)
            {
                Bind();
            } 
        }

        protected void Bind()
        {
            string ShowLeft = ((WebPaging.PageSize) * ((WebPaging.curPage)-1)).ToString();
            string ShowRight = ((WebPaging.PageSize) * (WebPaging.curPage)).ToString();
            string sqlShow = "with showCount as(Select ItemId,Code,Name,CategoryName,Price,StatusCodeText,row_number()over(order by ItemId) as show FROM Items) select* from showCount where show > @ShowLeft and show<= @ShowRight";
            SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@ShowLeft",ShowLeft),
                    new SqlParameter("@ShowRight",ShowRight)
                };
            DataTable dt = BaseDAL.DBHelper.GetList(sqlShow,param);
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