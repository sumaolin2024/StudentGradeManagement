using System;
using System.Data;
using System.Data.SqlClient;
using StudentGradeMS.App_Code;

namespace StudentGradeMS.Grades
{
    public partial class Enter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropdowns();
            }
        }

        private void BindDropdowns()
        {
            DataTable dtStudent = DBHelper.ExecuteQuery("SELECT Id, Name FROM Students ORDER BY Name");
            ddlStudent.DataSource = dtStudent;
            ddlStudent.DataBind();

            DataTable dtCourse = DBHelper.ExecuteQuery("SELECT Id, CourseName FROM Courses ORDER BY CourseName");
            ddlCourse.DataSource = dtCourse;
            ddlCourse.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            string sql = @"INSERT INTO Grades (StudentId, CourseId, Score, ExamDate, Remarks)
                           VALUES (@StudentId, @CourseId, @Score, @ExamDate, @Remarks)";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@StudentId", int.Parse(ddlStudent.SelectedValue)),
                new SqlParameter("@CourseId", int.Parse(ddlCourse.SelectedValue)),
                new SqlParameter("@Score", decimal.Parse(txtScore.Text)),
                new SqlParameter("@ExamDate", string.IsNullOrEmpty(txtExamDate.Text) ? DateTime.Now : DateTime.Parse(txtExamDate.Text)),
                new SqlParameter("@Remarks", txtRemarks.Text.Trim())
            };

            try
            {
                DBHelper.ExecuteNonQuery(sql, parameters);
                lblMsg.Text = "成绩录入成功！";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                txtScore.Text = "";
                txtRemarks.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = "保存失败: " + ex.Message;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
