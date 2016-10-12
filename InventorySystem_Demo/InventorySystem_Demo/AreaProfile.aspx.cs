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
                BindArea();
                BindLevel();
                BindOwner();
                BindStatusCode();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AreaList.aspx");
        }
        public void Bind()
        {
            DataTable dt = GetAreaId();
            string Name = dt.Rows[0]["Name"].ToString();
            string sqlDevice = "select Name,IMEI,AreaIdName,StatusCodeText from Devices where Name='"+Name+"'";
            DataTable dtDevice = BaseDAL.DBHelper.GetList(sqlDevice);
            GridView1.DataSource = dtDevice;
            GridView1.DataBind();
            GetNull(dt);
        }
        public void GetNull(DataTable dt)
        {
            int columnCount = dt.Columns.Count;
            if (columnCount <= 0)
            {
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columnCount;
                GridView1.Rows[0].Cells[0].Text = "没有记录";
                GridView1.Rows[0].Cells[0].Style.Add("text-align", "center");
                GridView1.Rows[0].Cells[0].Style.Add("color", "red");
            }
        }
        protected void BindArea()
        {
            DataTable dt = GetAreaId();
            if (dt.Rows.Count > 0)
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

        private DataTable GetAreaId()
        {
            string AreaId = Request.QueryString["AreaId"];
            string sql = "select * from Areas where AreaId=@id";
            SqlParameter p = new SqlParameter("@id", AreaId);
            DataTable dt = BaseDAL.DBHelper.GetList(sql, p);
            return dt;
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
            string Level = txtLevel.Text.Trim();
            //int Level = int.Parse(ddlLevel.SelectedValue);
            string Owner = txtOwner.Text.Trim();
            //int Owner=int.Parse(ddlOwner.SelectedValue);
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((LinkButton)(e.CommandSource)).Parent.Parent;//获取父本实例化
            int ID = gvr.RowIndex;//获取行的ID;
            int AID = Convert.ToInt32(GridView1.DataKeys[ID].Value);//获取区域ID
            if (e.CommandName == "Profile")
            {
                Response.Redirect("AreaProfile.aspx?AreaId=" + GridView1.DataKeys[ID].Value.ToString());
                //Session["AID"] = AID;
                //Response.Redirect("~/AreaProfile.aspx");
            }
            if (e.CommandName == "MyDelete")
            {
                SqlParameter[] p = new SqlParameter[] { new SqlParameter("@id", AID) };
                BaseDAL.DBHelper.Update("update TF_Area set StatusCode=2 where AreaId=@id", p);
                //BindArea();
            }
        }
    }
}