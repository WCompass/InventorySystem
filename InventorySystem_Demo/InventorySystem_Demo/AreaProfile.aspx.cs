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
    public partial class AreaProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
                BindLevel();
                BindOwner();
                BindStatusCode();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AreaList.aspx");
        }
        protected void Bind()
        {
            string AreaId = Request.QueryString["AreaId"];
            string sql = "select * from Areas where AreaId=@id";
            SqlParameter p = new SqlParameter("@id", AreaId);
            DataTable dt = BaseDAL.DBHelper.GetList(sql, p);
            if (dt.Rows.Count>0)
            {
                txtCode.Text = dt.Rows[0]["Code"].ToString();
                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtLevel.Text = dt.Rows[0]["Level"].ToString();
                txtOwner.Text = dt.Rows[0]["Owner"].ToString();
                txtCreatedBy.Text = dt.Rows[0]["CreatedBy"].ToString();
                txtCreatedTime.Text = dt.Rows[0]["CreatedTime"].ToString();
                ddlStatusCode.SelectedValue = dt.Rows[0]["StatusCode"].ToString();
                txtDescription.Text = dt.Rows[0]["Description"].ToString();
            }
        }
        protected void BindLevel()
        {
            string sql = "select Level,Code from TF_Category";
            DataTable AreaId = BaseDAL.DBHelper.GetList(sql);
            ddlLevel.DataSource = AreaId;
            ddlLevel.DataTextField = "Level";
            ddlLevel.DataValueField = "Code";
            ddlLevel.DataBind();
            ddlLevel.Items.Insert(0, new ListItem(""));
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
        protected void BindStatusCode()
        {
            string sql = "select AttributeText,AttributeValue from StringMap";
            DataTable StringMapId = BaseDAL.DBHelper.GetList(sql);
            ddlStatusCode.DataSource = StringMapId;
            ddlStatusCode.DataTextField = "AttributeText";
            ddlStatusCode.DataValueField = "AttributeValue";
            ddlStatusCode.DataBind();
            ddlStatusCode.Items.Insert(0, new ListItem(""));
        }
        protected void btnSubmt_Click(object sender, EventArgs e)
        {
            string Code = txtCode.Text.Trim();
            string Name = txtName.Text.Trim();
            //string Level = txtLevel.Text.Trim();
            int Level = int.Parse(ddlLevel.SelectedValue);
            //string Owner = txtOwner.Text.Trim();
            int Owner=int.Parse(ddlOwner.SelectedValue);
            int StatusCode = int.Parse(ddlStatusCode.SelectedValue);
            string Description = txtDescription.Text.Trim();

            string AreaId = Request.QueryString["AreaId"];
            SqlParameter[] p = new SqlParameter[] {
                new SqlParameter("@id",AreaId),
                new SqlParameter("@Code",Code),
                new SqlParameter("@Name",Name),
                new SqlParameter("@Level",Level),
                new SqlParameter("@Owner",Owner),
                new SqlParameter("@StatusCode",StatusCode),
                new SqlParameter("@Description",Description)
            };
            string Update = "update TF_Area set Code=@Code,Name=@Name,Level=@Level,Owner=@Owner,StatusCode=@StatusCode,Description=@Description where AreaId=@id";
            if (BaseDAL.DBHelper.Update(Update,p)>0)
            {
                Response.Write("<script>alert('修改成功!');window.location.href='./AreaList.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败!');</script>");
            }
        }
    }
}