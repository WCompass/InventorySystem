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
            if (!IsPostBack)
            {
                Bind();
            }            
		}

        protected void Bind()
        {
            string sql = "Select ItemId,Code,I.Name,C.Name,Price,StatusCode from TF_Item as I left join TF_Category as C on I.CategoryId = C.CategoryId";
            DataTable dt=
        }
	}
}