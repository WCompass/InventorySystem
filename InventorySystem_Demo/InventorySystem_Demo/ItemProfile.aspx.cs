﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Edward.DAL;
using Edward.DBHelper;
using System.Data.SqlClient;

namespace InventorySystem_Demo
{
    public partial class ItemProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Bind();
            }
        }

        protected void Bind()
        {
            //绑定类目，状态数据
            string sqlCategory = "Select * from Categorys";
            DataTable dtCategory = BaseDAL.DBHelper.GetList(sqlCategory);
            ddlCategoryId.DataSource = dtCategory;
            ddlCategoryId.DataTextField = "Name";
            ddlCategoryId.DataValueField = "CategoryId";
            ddlCategoryId.DataBind();

            string sqlBind = "Select AttributeText,AttributeValue from StringMap";
            DataTable dtBind = BaseDAL.DBHelper.GetList(sqlBind);
            ddlStatus.DataSource = dtBind;
            ddlStatus.DataTextField = "AttributeText";
            ddlStatus.DataValueField = "AttributeValue";
            ddlStatus.DataBind();

            //读取数据
            string ItemId = Request.QueryString["ItemId"];
            string sql = "Select * from Items where ItemId =@id";
            SqlParameter param = new SqlParameter("@id", ItemId);
            DataTable dt = BaseDAL.DBHelper.GetList(sql, param);
            if(dt.Rows.Count > 0)
            {
                txtCode.Text = dt.Rows[0]["Code"].ToString();
                txtName.Text = dt.Rows[0]["Name"].ToString();
                ddlCategoryId.SelectedValue = dt.Rows[0]["CategoryName"].ToString();
                txtPrice.Text = dt.Rows[0]["Price"].ToString();
                txtDescription.Text = dt.Rows[0]["Description"].ToString();
                ddlStatus.SelectedValue = dt.Rows[0]["StatusCode"].ToString();
                txtCreatedTime.Text = dt.Rows[0]["CreatedTime"].ToString();
                txtCreatedBy.Text = dt.Rows[0]["CreatedByName"].ToString();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string Code = txtCode.Text.Trim();
            string Name = txtName.Text.Trim();
            int CategoryId = int.Parse(ddlCategoryId.SelectedValue);
            string Price = txtPrice.Text.Trim();
            string Description = txtDescription.Text.Trim();
            int StatusCode = int.Parse(ddlStatus.SelectedValue);

            //判断是否为空
            if (Code == "" || Name == "" || Price == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Fail", "alert('有必填项未填！')", true);
            }
            else
            {
                string ItemId = Request.QueryString["ItemId"];
                string sqlUpdate = "Update TF_Item set Code=@Code,Name=@Name,CategoryId=@CategoryId,Price=@Price,Description=@Description,StatusCode=@StatusCode where ItemId=@id";
                SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@id", ItemId),
                new SqlParameter("@Code",Code),
                new SqlParameter("@Name",Name),
                new SqlParameter("@CategoryId",CategoryId),
                new SqlParameter("@Price",Price),
                new SqlParameter("@Description",Description),
                new SqlParameter("@StatusCode",StatusCode)
            };
                if (BaseDAL.DBHelper.Update(sqlUpdate, param) > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "alert('修改成功！');window.location.href='./ItemList.aspx'", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Fail", "alert('修改失败！')", true);
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ItemList.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string ItemId = Request.QueryString["ItemId"];
            string sqlUpdate = "Update TF_Item set StatusCode=2 where ItemId=@id";
            SqlParameter param = new SqlParameter("@id", ItemId);
            if (BaseDAL.DBHelper.Update(sqlUpdate, param) > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Success", "alert('删除成功！');window.location.href='./ItemList.aspx'",true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Fail", "alert('删除失败！')", true);
            }
        }

    }
}