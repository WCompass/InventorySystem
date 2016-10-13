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
    public partial class NewDevice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bindAreaId();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string IMEI = txtIMEI.Text;
            int areaId = Convert.ToInt32(ddlAreaId.SelectedValue);
            string description = textDescription.Text;
            string time = DateTime.Now.ToString("yyyy-MM-dd");
            string sqlstr = "insert into TF_Device(IMEI,Name,AreaId,Description,CreatedTime,CreatedBy,StatusCode) values(@IMEI,@Name,@AreaId,@Description,@time,1,1)";
            SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@name",name),
                new SqlParameter("@IMEI",IMEI),
                new SqlParameter("@areaId",areaId),
                new SqlParameter("@description",description),
                new SqlParameter("@time",time)
                //new SqlParameter("@CreatedBy",CreatedBy)
            };
            if (BaseDAL.DBHelper.Insert(sqlstr, param) > 0)
            {
                Response.Write("<script>alert('添加成功！')</script>");
                Response.Redirect("DeviceList.aspx");
            }
            else
            {
                Response.Write("<script>alert('添加有误！请重新填写信息')</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeviceList.aspx");
        }
    }
}