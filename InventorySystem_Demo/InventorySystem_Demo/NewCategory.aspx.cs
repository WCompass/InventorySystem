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
    public partial class NewCategory : System.Web.UI.Page
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

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Code = txtCode.Text.Trim();
            string Name = txtName.Text.Trim();
            int Level = int.Parse(txtLevel.Text.Trim());
            string Description = txtDescription.Text.Trim();
            int CreatedBy = 1;
            int StatusCode = 1;

            string sqlAdd = "Insert into TF_Category(Code,Name,Level,Description,CreatedTime,CreatedBy,StatusCode) values (@Code,@Name,@Level,@Description,getdate(),@CreatedBy,@StatusCode)";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@Code",Code),
                new SqlParameter("@Name",Name),
                new SqlParameter("@Level",Level),
                new SqlParameter("@Description",Description),
                new SqlParameter("@CreatedBy",CreatedBy),
                new SqlParameter("@StatusCode",StatusCode)
            };

            if (BaseDAL.DBHelper.Insert(sqlAdd, param) > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "alert('添加成功！');window.location.href='./CategoryList.aspx'", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Fail", "alert('添加失败！')", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("./CategoryList.aspx");
        }
    }
}