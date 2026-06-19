using System;
using System.Data;
using StudentGradeMS.App_Code;

namespace StudentGradeMS
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStatistics();
            }
        }

        private void LoadStatistics()
        {
            DataTable studentDt = DBHelper.ExecuteQuery("SELECT COUNT(*) AS Cnt FROM Students");
            DataTable courseDt = DBHelper.ExecuteQuery("SELECT COUNT(*) AS Cnt FROM Courses");
            DataTable gradeDt = DBHelper.ExecuteQuery("SELECT COUNT(*) AS Cnt FROM Grades");
            DataTable avgDt = DBHelper.ExecuteQuery("SELECT ISNULL(AVG(Score),0) AS AvgScore FROM Grades");

            lblStudentCount.Text = studentDt.Rows[0]["Cnt"].ToString();
            lblCourseCount.Text = courseDt.Rows[0]["Cnt"].ToString();
            lblGradeCount.Text = gradeDt.Rows[0]["Cnt"].ToString();
            lblAvgScore.Text = decimal.Parse(avgDt.Rows[0]["AvgScore"].ToString()).ToString("F1");
        }
    }
}
