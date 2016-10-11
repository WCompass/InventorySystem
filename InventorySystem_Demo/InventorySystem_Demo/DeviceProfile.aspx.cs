using Edward.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySystem_Demo
{
    public partial class DeviceProfile : System.Web.UI.Page
    {
        static int DeviceId = 0;//先定义一个全局变量
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DeviceId = Convert.ToInt32(Request.QueryString["classId"]);
                string sql = string.Format(@"select DeviceId,IMEI,Name,AreaId,Description,CreatedTime,CreatedBy,StatusCode from Devices where DeviceId=@DeviceId");
                SqlParameter param = new SqlParameter("@DeviceId", DeviceId);
                DataTable dt = BaseDAL.DBHelper.GetList(sql, param);
                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["Name"].ToString();
                    txtIMEI.Text=dt.Rows[0]["Name"].ToString();
                    ddlAreaId.DataTextField = dt.Rows[0]["AreaId"].ToString();
                    textDescription.Text = dt.Rows[0]["Description"].ToString();
                    ddlStatusCode.DataTextField = dt.Rows[0]["StatusCode"].ToString();
                    txtCreatedTime.Text = dt.Rows[0]["CreatedTime"].ToString();
                    ddlCreatedBy.DataTextField = dt.Rows[0]["CreatedBy"].ToString();
                }
            }
            bindAreaId();
            bindStatusCode();
            bindCreatedBy();
        }
        public void bindAreaId()
        {
            string sqlStr = string.Format(@"select AreaId,Code,Name,Level,Owner,Description,CreatedTime,CreatedBy,StatusCode from TF_Area");
            DataTable AreaIdTable = BaseDAL.DBHelper.GetList(sqlStr);
            this.ddlAreaId.DataSource = AreaIdTable;
            this.ddlAreaId.DataValueField = "AreaId";
            this.ddlAreaId.DataTextField = "Name";
            this.ddlAreaId.DataBind();
        }
        public void bindStatusCode() 
        {
            string sqlStr = string.Format(@"select StringMapId,TableName,FieldName,AttributeText,AttributeValue,Description,DisplayOrder from StringMap");
            DataTable StatusCodeTable = BaseDAL.DBHelper.GetList(sqlStr);
            this.ddlStatusCode.DataSource = StatusCodeTable;
            this.ddlStatusCode.DataValueField = "StringMapId";
            this.ddlStatusCode.DataTextField = "AttributeText";
            this.ddlStatusCode.DataBind();
        }
        public void bindCreatedBy()
        {
            string sqlStr = string.Format(@"select * from TF_User");
            DataTable CreatedByTable = BaseDAL.DBHelper.GetList(sqlStr);
            this.ddlStatusCode.DataSource = CreatedByTable;
            this.ddlStatusCode.DataValueField = "UserId";
            this.ddlStatusCode.DataTextField = "DomainName";
            this.ddlStatusCode.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string IMEI = txtIMEI.Text;
            int areaId = Convert.ToInt32(ddlAreaId.SelectedValue);
            string description= textDescription.Text;
            int statusCode = Convert.ToInt32(ddlStatusCode.SelectedValue);
            string createdTime = txtCreatedTime.Text;
            int createdBy = Convert.ToInt32(ddlCreatedBy.SelectedValue);
            string sqlstr = "update TF_Device Set Name=@name,IMEI=@IMEI,AreaId=@areaId,Description=@description,StatusCode=@statusCode,CreatedTime=@createdTime,CreatedBy=@createdBy where DeviceId=@deviceId";
            SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@name",name),
                new SqlParameter("@IMEI",IMEI),
                new SqlParameter("@areaId",areaId),
                new SqlParameter("@description",description),
                new SqlParameter("@statusCode",statusCode),
                new SqlParameter("@createdTime",createdTime),
                new SqlParameter("@createdBy",createdBy),
                new SqlParameter("@deviceId",DeviceId)
            };
            if (BaseDAL.DBHelper.Update(sqlstr, param) > 0)
            {
                Response.Write("<script>alert('修改成功！')</script>");
            }
            else
            {
                Response.Write("<script>alert('修改有误！请重新修改')</script>");
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeviceList.aspx");
        }
    }
}