using System;
using System.Data.SqlClient;
using StudentGradeMS.App_Code;

namespace StudentGradeMS.Courses
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            string sql = @"INSERT INTO Courses (CourseNo, CourseName, Credit, TeacherName, Semester)
                           VALUES (@CourseNo, @CourseName, @Credit, @TeacherName, @Semester)";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@CourseNo", txtCourseNo.Text.Trim()),
                new SqlParameter("@CourseName", txtCourseName.Text.Trim()),
                new SqlParameter("@Credit", int.TryParse(txtCredit.Text, out int credit) ? credit : 2),
                new SqlParameter("@TeacherName", txtTeacherName.Text.Trim()),
                new SqlParameter("@Semester", txtSemester.Text.Trim())
            };

            try
            {
                DBHelper.ExecuteNonQuery(sql, parameters);
                Response.Redirect("List.aspx");
            }
            catch (Exception ex)
            {
                lblMsg.Text = "保存失败: " + ex.Message;
            }
        }
    }
}
