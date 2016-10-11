using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edward.DAL;
using Edward.DBHelper;
using System.Data;

namespace InventorySystem_Demo
{
    public partial class DeviceList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
        public void bind()
        {
            string sqlStr = "select DeviceId,IMEI,Name,AreaIdName,StatusCodeText from Devices";
            DataTable dt = BaseDAL.DBHelper.GetList(sqlStr);
            this.GridView1.DataSource = dt;
            GridView1.DataKeyNames = new string[] { "DeviceId" };
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id=GridView1.DataKeys[e.RowIndex].Value.ToString();
            string sqlStr = "update TF_Device Set StatusCode = 2 where DeviceId='" + id + "'";
            BaseDAL.DBHelper.Delete(sqlStr.ToString());
            bind();
            this.GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Response.Redirect("DeviceProfile.aspx?DeviceId=" + GridView1.DataKeys[e.RowIndex].Value.ToString());
            bind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewDevice.aspx");
        }
    }
}