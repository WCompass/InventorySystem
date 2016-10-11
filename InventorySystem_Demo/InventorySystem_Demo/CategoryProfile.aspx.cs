using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edward.DAL;
using Edward.DBHelper;

namespace InventorySystem_Demo
{
    public partial class CategoryProfile : System.Web.UI.Page
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
            //绑定状态数据
            string sqlBind = "Select AttributeText,AttributeValue from StringMap";
            DataTable dtBind = BaseDAL.DBHelper.GetList(sqlBind);
            ddlStatus.DataSource = dtBind;
            ddlStatus.DataTextField = "AttributeText";
            ddlStatus.DataValueField = "AttributeValue";
            ddlStatus.DataBind();

            //读取数据
            string CategoryId = Request.QueryString["CategoryId"];
            string sql = "Select * from Categorys where CategoryId =@id";
            SqlParameter param = new SqlParameter("@id", CategoryId);
            DataTable dt = BaseDAL.DBHelper.GetList(sql, param);
            if (dt.Rows.Count > 0)
            {
                txtCode.Text = dt.Rows[0]["Code"].ToString();
                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtLevel.Text = dt.Rows[0]["Level"].ToString();
                txtDescription.Text = dt.Rows[0]["Description"].ToString();
                ddlStatus.SelectedValue = dt.Rows[0]["StatusCode"].ToString();
                txtCreatedTime.Text = dt.Rows[0]["CreatedTime"].ToString();
                txtCreatedBy.Text = dt.Rows[0]["CreatedByName"].ToString();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string CategoryId = Request.QueryString["CategoryId"];
            string Code = txtCode.Text.Trim();
            string Name = txtName.Text.Trim();
            int Level = int.Parse(txtLevel.Text.Trim());
            string Description = txtDescription.Text.Trim();
            int CreatedBy = 1;
            int StatusCode = 1;

            string sqlAdd = "Update TF_Category set Code=@Code,Name=@Name,Level=@Level,Description=@Description,StatusCode=@StatusCode where CategoryId=@id";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@id",CategoryId),
                new SqlParameter("@Code",Code),
                new SqlParameter("@Name",Name),
                new SqlParameter("@Level",Level),
                new SqlParameter("@Description",Description),
                new SqlParameter("@CreatedBy",CreatedBy),
                new SqlParameter("@StatusCode",StatusCode)
            };

            if (BaseDAL.DBHelper.Insert(sqlAdd, param) > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "alert('修改成功！');window.location.href='./CategoryList.aspx'", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Fail", "alert('修改失败！')", true);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("./CategoryList.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string CategoryId = Request.QueryString["CategoryId"];
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
    }
}