using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edward.DAL;
using Edward.DBHelper;
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
            string sql = "Select ItemId,I.Code,I.Name,C.Name,I.Price,I.StatusCode=(case I.StatusCode when 1 then '启用' when 2 then '已删除' when 3 then '禁用' else 'Error' end) from TF_Item as I left join TF_Category as C on I.CategoryId = C.CategoryId and I.StatusCode=1";
            DataTable dt = BaseDAL.DBHelper.GetList(sql);
            GridView1.DataSource = dt;
            GridView1.DataKeyNames = new string[] { "ItemId" };
            GridView1.DataBind();
            //GridView1.Columns[0].Visible = false;
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("./NewItem.aspx");
        }
    }
}