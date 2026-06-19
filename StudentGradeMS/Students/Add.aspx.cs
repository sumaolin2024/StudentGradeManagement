using System;
using System.Data.SqlClient;
using StudentGradeMS.App_Code;

namespace StudentGradeMS.Students
{
    public partial class Add : System.Web.UI.Page
    {
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            string sql = @"INSERT INTO Exam (StudentNo,Sname,Class,Chinese,Math,English,Computer) VALUES (@a,@b,@c,@d,@e,@f,@g)";
            try
            {
                DBHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@a", txtStudentNo.Text.Trim()),
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
