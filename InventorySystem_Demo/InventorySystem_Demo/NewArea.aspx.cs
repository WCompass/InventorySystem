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
    public partial class NewArea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
                BindOwner();
            }
        }
        protected void Bind()
        {
            
        }
        protected void BindOwner()
        {
            string sql = "select Name,Code from TF_User";
            DataTable UserId = BaseDAL.DBHelper.GetList(sql);
            ddlOwner.DataSource = UserId;
            ddlOwner.DataTextField = "Name";
            ddlOwner.DataValueField = "Code";
            ddlOwner.DataBind();
            ddlOwner.Items.Insert(0, new ListItem(""));
        }
        protected void btnSubmt_Click(object sender, EventArgs e)
        {
            string Code = txtCode.Text.Trim();
            string Name = txtName.Text.Trim();
            string Level = txtLevel.Text.Trim();
            //int Level = int.Parse(ddlLevel.SelectedValue);
            //string Owner = txtOwner.Text.Trim();
            int Owner=int.Parse(ddlOwner.SelectedValue);
            string time = DateTime.Now.ToString();

            string Description = txtDescription.Text.Trim();
            
            SqlParameter[] p = new SqlParameter[] {
                new SqlParameter("@Code",Code),
                new SqlParameter("@Name",Name),
                new SqlParameter("@Level",Level),
                new SqlParameter("@Owner",Owner),
                new SqlParameter("@time",time),
                new SqlParameter("@Description",Description)
            };
            string insert = "Insert into TF_Area(Code,Name,Level,Owner,Description,CreatedTime,CreatedBy,StatusCode) values (@Code,@Name,@Level,@Owner,@Description,@time,1,1)";
            if (BaseDAL.DBHelper.Update(insert, p) > 0)
            {
                Response.Write("<script>alert('修改成功!');window.location.href='./AreaList.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败!');</script>");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AreaList.aspx");
        }
    }
}