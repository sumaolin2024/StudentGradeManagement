using System;
using System.Data;
using System.Data.SqlClient;
using StudentGradeMS.App_Code;

namespace StudentGradeMS.Students
{
    public partial class Edit : System.Web.UI.Page
    {
        private string sno = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            sno = Request.QueryString["sno"] ?? "";
            if (string.IsNullOrEmpty(sno)) { Response.Redirect("List.aspx"); return; }
            if (!IsPostBack) LoadData();
        }

        private void LoadData()
        {
            DataTable dt = DBHelper.ExecuteQuery("SELECT * FROM Exam WHERE StudentNo=@sno", new SqlParameter("@sno", sno));
            if (dt.Rows.Count == 0) { Response.Redirect("List.aspx"); return; }
            DataRow r = dt.Rows[0];
            txtStudentNo.Text = r["StudentNo"].ToString();
            txtSname.Text = r["Sname"].ToString();
            txtClass.Text = r["Class"].ToString();
            txtChinese.Text = r["Chinese"].ToString();
            txtMath.Text = r["Math"].ToString();
            txtEnglish.Text = r["English"].ToString();
            txtComputer.Text = r["Computer"].ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            string sql = @"UPDATE Exam SET Sname=@b,Class=@c,Chinese=@d,Math=@e,English=@f,Computer=@g WHERE StudentNo=@a";
            try
            {
                DBHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@a", sno),
                    new SqlParameter("@b", txtSname.Text.Trim()),
                    new SqlParameter("@c", txtClass.Text.Trim()),
                    new SqlParameter("@d", int.TryParse(txtChinese.Text, out int v1) ? v1 : 0),
                    new SqlParameter("@e", int.TryParse(txtMath.Text, out int v2) ? v2 : 0),
                    new SqlParameter("@f", int.TryParse(txtEnglish.Text, out int v3) ? v3 : 0),
                    new SqlParameter("@g", int.TryParse(txtComputer.Text, out int v4) ? v4 : 0));
                Response.Redirect("List.aspx");
            }
            catch (Exception ex) { lblMsg.Text = "保存失败: " + ex.Message; }
        }
    }
}
