using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventorySystem_Demo
{
    public partial class ItemList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind(null, null);
        }

        protected void Bind(object sender, EventArgs e)
        {
            string sql = "Select ItemId,Code,Name,CategoryId,Price,StatusCode from TF_Item";
            DataTable dt=
        }
    }
}