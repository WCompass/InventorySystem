using Aspose.Cells;
using Edward.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

namespace InventorySystem_Demo
{
    public partial class AreaList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
            
        }
        public void Bind()
        {
            string sql = "select AreaId,Code,Name,Level,OwnerName,StatusCodeText from Areas where StatusCode=1";
            DataTable dt = BaseDAL.DBHelper.GetList(sql);
            GridView1.DataSource = dt;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt">要导出的数据</param>
        /// <param name="tableName">表格标题</param>
        /// <param name="path">保存路径</param>
        private void dataTableToCsv(DataTable table, string file)
        {
            string title = "";
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(new BufferedStream(fs), System.Text.Encoding.Default);
            #region 1
            for (int i = 0; i < table.Columns.Count; i++)
            {
                title += table.Columns[i].ColumnName + "\t"; //栏位：自动跳到下一单元格
            }
            title = title.Substring(0, title.Length - 1) + "\n";
            sw.Write(title);
            foreach (DataRow row in table.Rows)
            {
                string line = "";
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    line += row[i].ToString().Trim() + "\t"; //内容：自动跳到下一单元格
                }
                line = line.Substring(0, line.Length - 1) + "\n";
                sw.Write(line);
            }
            #endregion
            sw.Close();
            fs.Close();
        }
        /// <summary> 
        /// 导出数据到本地 
        /// </summary> 
        /// <param name="dt">要导出的数据</param> 
        /// <param name="tableName">表格标题</param> 
        /// <param name="path">保存路径</param> 
        public static void OutFileToDisk(DataTable dt, string tableName, string path)
        {
            Workbook workbook = new Workbook(); //工作簿 
            Worksheet sheet = workbook.Worksheets[0]; //工作表 
            Cells cells = sheet.Cells;//单元格 

            //为标题设置样式     
            Aspose.Cells.Style styleTitle = workbook.Styles[workbook.Styles.Add()];//新增样式 
            styleTitle.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            styleTitle.Font.Name = "宋体";//文字字体 
            styleTitle.Font.Size = 18;//文字大小 
            styleTitle.Font.IsBold = true;//粗体 

            //样式2 
            Aspose.Cells.Style style2 = workbook.Styles[workbook.Styles.Add()];//新增样式 
            style2.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            style2.Font.Name = "宋体";//文字字体 
            style2.Font.Size = 14;//文字大小 
            style2.Font.IsBold = true;//粗体 
            style2.IsTextWrapped = true;//单元格内容自动换行 
            style2.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

            //样式3 
            Aspose.Cells.Style style3 = workbook.Styles[workbook.Styles.Add()];//新增样式 
            style3.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            style3.Font.Name = "宋体";//文字字体 
            style3.Font.Size = 12;//文字大小 
            style3.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

            int Colnum = dt.Columns.Count;//表格列数 
            int Rownum = dt.Rows.Count;//表格行数 

            //生成行1 标题行    
            cells.Merge(0, 0, 1, Colnum);//合并单元格 
            cells[0, 0].PutValue(tableName);//填写内容 
            cells[0, 0].SetStyle(styleTitle);
            cells.SetRowHeight(0, 38);

            //生成行2 列名行 
            for (int i = 0; i < Colnum; i++)
            {
                cells[1, i].PutValue(dt.Columns[i].ColumnName);
                cells[1, i].SetStyle(style2);
                cells.SetRowHeight(1, 25);
            }

            //生成数据行 
            for (int i = 0; i < Rownum; i++)
            {
                for (int k = 0; k < Colnum; k++)
                {
                    cells[2 + i, k].PutValue(dt.Rows[i][k].ToString());
                    cells[2 + i, k].SetStyle(style3);
                }
                cells.SetRowHeight(2 + i, 24);
            }

            workbook.Save(path);
        }
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public MemoryStream OutFileToStream(DataTable dt, string tableName)
        {
            Workbook workbook = new Workbook(); //工作簿 
            Worksheet sheet = workbook.Worksheets[0]; //工作表 
            Cells cells = sheet.Cells;//单元格 

            //为标题设置样式     
            Aspose.Cells.Style styleTitle = workbook.Styles[workbook.Styles.Add()];//新增样式 
            styleTitle.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            styleTitle.Font.Name = "宋体";//文字字体 
            styleTitle.Font.Size = 18;//文字大小 
            styleTitle.Font.IsBold = true;//粗体 

            //样式2 
            Aspose.Cells.Style style2 = workbook.Styles[workbook.Styles.Add()];//新增样式 
            style2.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            style2.Font.Name = "宋体";//文字字体 
            style2.Font.Size = 14;//文字大小 
            style2.Font.IsBold = true;//粗体 
            style2.IsTextWrapped = true;//单元格内容自动换行 
            style2.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            style2.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

            //样式3 
            Aspose.Cells.Style style3 = workbook.Styles[workbook.Styles.Add()];//新增样式 
            style3.HorizontalAlignment = TextAlignmentType.Center;//文字居中 
            style3.Font.Name = "宋体";//文字字体 
            style3.Font.Size = 12;//文字大小 
            style3.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
            style3.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;

            int Colnum = dt.Columns.Count;//表格列数 
            int Rownum = dt.Rows.Count;//表格行数 

            //生成行1 标题行    
            cells.Merge(0, 0, 1, Colnum);//合并单元格 
            cells[0, 0].PutValue(tableName);//填写内容 
            cells[0, 0].SetStyle(styleTitle);
            cells.SetRowHeight(0, 38);

            //生成行2 列名行 
            for (int i = 0; i < Colnum; i++)
            {
                cells[1, i].PutValue(dt.Columns[i].ColumnName);
                cells[1, i].SetStyle(style2);
                cells.SetRowHeight(1, 25);
            }
            //生成数据行 
            for (int i = 0; i < Rownum; i++)
            {
                for (int k = 0; k < Colnum; k++)
                {
                    cells[2 + i, k].PutValue(dt.Rows[i][k].ToString());
                    cells[2 + i, k].SetStyle(style3);
                }
                cells.SetRowHeight(2 + i, 24);
            }
            MemoryStream ms = workbook.SaveToStream();
            return ms;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((LinkButton)(e.CommandSource)).Parent.Parent;//获取父本实例化
            int ID = gvr.RowIndex;//获取行的ID;
            int AID = Convert.ToInt32(GridView1.DataKeys[ID].Value);//获取区域ID
            Session["AreaId"] = ID;
            if (e.CommandName == "Profile")
            {
                Response.Redirect("AreaProfile.aspx?AreaId=" + GridView1.DataKeys[ID].Value.ToString());
            }
            if (e.CommandName == "MyDelete")
            {
                SqlParameter[] p = new SqlParameter[] { new SqlParameter("@id", AID) };
                BaseDAL.DBHelper.Update("update TF_Area set StatusCode=2 where AreaId=@id", p);
                Bind();
            }
        }
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewArea.aspx");
        }
        protected void BtnExel_Click(object sender, EventArgs e)
        {
            #region 方法一
            //string sql = "select AreaId,Code,Name,Level,OwnerName,StatusCodeText from Areas where StatusCode=1";
            //DataTable dt = BaseDAL.DBHelper.GetList(sql);
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
            //DateTime Today = DateTime.Now;
            //string day = Today.ToString("yyyyMMddHHmmss");
            //dataTableToCsv((DataTable)this.GridView1.DataSource, @"/" + day + ".xls"); //调用函数
            //Response.Redirect("./" + day + ".xls");
            //OutFileToDisk(dt, "区域表", Server.MapPath("/") + @"/" + day + ".xls");

            //System.Diagnostics.Process.Start(@"F:\Images\1.xlsx");  //打开excel文件
            //try
            //{
            //    File.Move(@"F:\Images\1.xlsx", @"F:\Images\1.xlsx");
            //    Response.Write("<script>alert('成功导出到F盘中Images文件夹');</script>");
            //}
            //catch (Exception)
            //{
            //    Response.Write("<script>alert('已打开Excel');</script>");
            //}
            #endregion

            #region 方法二
            //DataTable dt = this.GridView1.DataSource as DataTable;
            //string sql = "select Code as 区域编号,Name as 区域名称,Level as 区域等级,OwnerName as 负责人,StatusCodeText as 状态 from Areas where StatusCode=1";
            //DataTable dt = BaseDAL.DBHelper.GetList(sql);
            //GridView1.DataSource = dt;
            //DataRow dr = dt.NewRow();
            //dr["name"] = "名称1";
            //dr["sex"] = "性别1";
            //dt.Rows.Add(dr);

            //DataRow dr1 = dt.NewRow();
            //dr1["name"] = "名称2";
            //dr1["sex"] = "性别2";
            //dt.Rows.Add(dr1);
            //DateTime time = new DateTime().ToString("yyyyMMddHHmmssfff");
            DataTable dt = (DataTable)GridView1.DataSource;
            GridView1.DataSource = dt;
            DateTime Today = DateTime.Now;
            string day = Today.ToString("yyyyMMddHHmmss");
            OutFileToDisk(dt, "区域表", Server.MapPath("/") + @"/" + day + ".xls");
            Response.Redirect("./" + day + ".xls");
            if (this.Session["AreaId"] == null)
            {
                System.IO.Directory.Delete(@"/" + day + ".xls");
            }
            #endregion

            #region 方法三
            //Workbook wb = new Workbook();
            //wb.Save(Response, HttpUtility.UrlEncode(filename,System.Text.Encoding.UTF8) + ".xls", ContentDisposition.Attachment, new XlsSaveOptions(SaveFormat.Excel97To2003));
            #endregion

        }
    }
}