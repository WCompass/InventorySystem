using System;
using System.Web.UI;
using Edward.DAL;
using System.Text.RegularExpressions;

namespace InventorySystem_Demo
{
    public partial class WebPaging : System.Web.UI.UserControl
    {
        protected static int TotalCount = 0;//记录一共有多少条数据，这个是系统自动算出来的
        protected static int PageCount = 0;//所有记录一共分成几页，这个是系统自动算出来的
        public static int curPage = 1;//当前显示第几页
        public static int PageSize = 10;//每页显示几条
        public static string sqlTotalCount = null;//sql绑定显示数字
        public static string sqlStringPath = null;//显示地址

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindTotalCount();
                BindPageTotal();
                BindControls();
            }
        }

        /// <summary>
        /// 显示总条数
        /// </summary>
        /// <returns>总条数</returns>
        protected void BindTotalCount()
        {
            string MaxCount = BaseDAL.DBHelper.GetScalar(sqlTotalCount);
            if(!String.IsNullOrEmpty(MaxCount))
            {
                TotalCount = Convert.ToInt32(MaxCount);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Fail", "alert('数据读取失败，请刷新！')", true);
            }
        }

        /// <summary>
        /// 显示总页数
        /// </summary>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        protected void BindPageTotal()
        {
            if (TotalCount % 10 != 0)
            {
                PageCount = TotalCount / 10 + 1;
            }
            else
            {
                PageCount = TotalCount / 10;
            }           
        }

        /// <summary>
        /// 显示分页数据
        /// </summary>
        protected void BindControls()
        {
            if((curPage==1)&&(curPage==PageCount))
            {
                lbUp.Enabled = false;
                lbDown.Enabled = false;
            }
            else if(curPage==1)
            {
                lbUp.Enabled = false;
            }
            else if(curPage==PageCount)
            {
                lbDown.Enabled = false;
            }
            else
            {
                lbUp.Enabled = true;
                lbDown.Enabled = true;
            }
            lblRecord.Text = TotalCount.ToString();
            lblPageTotal.Text = PageCount.ToString();
            lblPage.Text = curPage.ToString();
        }

        protected void PagePaging()
        {
            Response.Redirect(sqlStringPath + "?curPage=" + curPage);
        }

        protected void lbFirst_Click(object sender, EventArgs e)
        {
            curPage = 1;
            PagePaging();
            BindControls();
        }

        protected void lbUp_Click(object sender, EventArgs e)
        {
            if (curPage <= 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Fail", "alert('当前已为首页！')", true);
            }
            else
            {
                curPage = curPage - 1;
                PagePaging();
                BindControls();           
            }
        }

        protected void lbDown_Click(object sender, EventArgs e)
        {
            if (curPage >= PageCount)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Fail", "alert('当前已为末页！')", true);
            }
            else
            {
                curPage = curPage + 1;
                PagePaging();
                BindControls();   
            }
        }

        protected void lbLast_Click(object sender, EventArgs e)
        {
            curPage = PageCount;
            PagePaging();
            BindControls();
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            string PageGo = txtPage.Text.Trim();
            string RegularNumber = "^([1-9]d*)$";
            if ((PageGo == ""))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Fail", "alert('请输入跳转页数！')", true);
            }
            else
            {
                if (Regex.IsMatch(PageGo, RegularNumber))
                {
                    if ((Convert.ToInt32(PageGo) < 1) || (Convert.ToInt32(PageGo) > PageCount))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Fail", "alert('查无此页！')", true);

                    }
                    else
                    {
                        curPage = Convert.ToInt32(PageGo);
                        PagePaging();
                        BindControls();
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Fail", "alert('请输入正确的跳转页数！')", true);
                }
            }
        }
    }
}