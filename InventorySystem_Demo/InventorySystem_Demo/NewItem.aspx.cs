using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edward.DAL;
using Edward.DBHelper;
using System.Data;

namespace InventorySystem_Demo
{
	public partial class NewItem : System.Web.UI.Page
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
            //绑定类目，状态数据
            string sqlCategory = "Select * from Categorys";
            DataTable dtCategory = BaseDAL.DBHelper.GetList(sqlCategory);
            ddlCategoryId.DataSource = dtCategory;
            ddlCategoryId.DataTextField = "Name";
            ddlCategoryId.DataValueField = "CategoryId";
            ddlCategoryId.DataBind();
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

            string sqlAdd = "Insert into TF_Item (@Code,@Name,@CategoryId,@Price,@Description,getdate(),@CreatedBy,@StatusCode)";
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "alert('添加成功！');window.location.href='./ItemList.aspx'",true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Fail", "alert('添加失败！')");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ItemList.aspx");
        }
    }
}