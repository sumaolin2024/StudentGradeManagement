using System;
using System.Data;
using System.Data.SqlClient;
using StudentGradeMS.App_Code;

namespace StudentGradeMS.Grades
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropdowns();
                BindGrid();
            }
        }

        private void BindDropdowns()
        {
            DataTable dtStudent = DBHelper.ExecuteQuery("SELECT Id, Name FROM Students ORDER BY Name");
            ddlStudent.DataSource = dtStudent;
            ddlStudent.DataBind();
            ddlStudent.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--全部--", ""));

            DataTable dtCourse = DBHelper.ExecuteQuery("SELECT Id, CourseName FROM Courses ORDER BY CourseName");
            ddlCourse.DataSource = dtCourse;
            ddlCourse.DataBind();
            ddlCourse.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--全部--", ""));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            string sql = @"SELECT g.Id, s.StudentNo, s.Name AS StudentName, s.ClassName,
                           c.CourseName, g.Score, g.ExamDate
                           FROM Grades g
                           JOIN Students s ON g.StudentId = s.Id
                           JOIN Courses c ON g.CourseId = c.Id
                           WHERE 1=1";

            var parameters = new System.Collections.Generic.List<SqlParameter>();

            if (!string.IsNullOrEmpty(ddlStudent.SelectedValue))
            {
                sql += " AND g.StudentId = @StudentId";
                parameters.Add(new SqlParameter("@StudentId", ddlStudent.SelectedValue));
            }
            if (!string.IsNullOrEmpty(ddlCourse.SelectedValue))
            {
                sql += " AND g.CourseId = @CourseId";
                parameters.Add(new SqlParameter("@CourseId", ddlCourse.SelectedValue));
            }

            sql += " ORDER BY g.ExamDate DESC";

            DataTable dt = DBHelper.ExecuteQuery(sql, parameters.ToArray());
            gvGrades.DataSource = dt;
            gvGrades.DataBind();
        }

        protected void gvGrades_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvGrades.DataKeys[e.RowIndex].Value);
            DBHelper.ExecuteNonQuery("DELETE FROM Grades WHERE Id=@Id",
                new SqlParameter("@Id", id));
            BindGrid();
        }
    }
}
