using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edward.DAL;
using Edward.DBHelper;

namespace InventorySystem_Demo
{
	public partial class NewItem : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {

            }
		}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Code = txtCode.Text.Trim();
            string Name = txtName.Text.Trim();
            int CategoryId = int.Parse(ddlCategoryId.SelectedValue);
            float Price = float.Parse(txtPrice.Text.Trim());
            string Description = txtDescription.Text.Trim();
            int CreatedBy = 1;
            int StatusCode = 1;

            string sqlAdd = "Insert into Item (@Code,@Name,@CategoryId,@Price,@Description,getdate(),@CreatedBy,@StatusCode)";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@Code",Code),
                new SqlParameter("@Name",Name),
                new SqlParameter("@CategoryId",CategoryId),
                new SqlParameter("@Price",Price),
                new SqlParameter("@Description",Description),
                new SqlParameter("@CreatedBy",CreatedBy),
                new SqlParameter("@StatusCode",StatusCode)
            };

            if (BaseDAL.DBHelper.Insert(sqlAdd, param) > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "success", "alert('添加成功！');window.location.href='./ItemList.aspx'");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "success", "alert('添加失败！')");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ItemList.aspx");
        }
    }
}