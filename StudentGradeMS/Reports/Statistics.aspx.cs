using System;
using System.Data;
using System.Text;
using StudentGradeMS.App_Code;

namespace StudentGradeMS.Reports
{
    public partial class Statistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllStats();
            }
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            LoadAllStats();
        }

        private void LoadAllStats()
        {
            LoadOverviewCards();
            LoadCourseAvg();
            LoadStudentRank();
            LoadScoreDistribution();
        }

        private void LoadOverviewCards()
        {
            StringBuilder sb = new StringBuilder();
            var stats = new (string title, string css, string sql)[]
            {
                ("总人数", "", "SELECT COUNT(DISTINCT StudentId) FROM Grades"),
                ("平均分", "green", "SELECT ISNULL(AVG(Score),0) FROM Grades"),
                ("最高分", "orange", "SELECT ISNULL(MAX(Score),0) FROM Grades"),
                ("最低分", "red", "SELECT ISNULL(MIN(Score),0) FROM Grades")
            };

            foreach (var s in stats)
            {
                DataTable dt = DBHelper.ExecuteQuery(s.sql);
                string value = dt.Rows[0][0].ToString();
                if (decimal.TryParse(value, out decimal d))
                    value = d.ToString("F1");

                sb.AppendFormat(@"<div class=""stat-card {1}""><h3>{0}</h3><div class=""value"">{2}</div></div>",
                    s.title, s.css, value);
            }

            pnlStats.Controls.Add(new System.Web.UI.WebControls.Literal { Text = sb.ToString() });
        }

        private void LoadCourseAvg()
        {
            string sql = @"SELECT c.CourseName,
                           COUNT(*) AS StudentCount,
                           AVG(g.Score) AS AvgScore,
                           MAX(g.Score) AS MaxScore,
                           MIN(g.Score) AS MinScore,
                           CAST(SUM(CASE WHEN g.Score >= 60 THEN 1 ELSE 0 END) * 100.0 / COUNT(*) AS DECIMAL(5,1)) AS PassRate
                           FROM Grades g
                           JOIN Courses c ON g.CourseId = c.Id
                           GROUP BY c.CourseName
                           ORDER BY AvgScore DESC";

            gvCourseAvg.DataSource = DBHelper.ExecuteQuery(sql);
            gvCourseAvg.DataBind();
        }

        private void LoadStudentRank()
        {
            string sql = @"SELECT TOP 20
                           ROW_NUMBER() OVER(ORDER BY AVG(g.Score) DESC) AS Rank,
                           s.StudentNo, s.Name, s.ClassName,
                           AVG(g.Score) AS AvgScore,
                           COUNT(*) AS CourseCount,
                           SUM(g.Score) AS TotalScore
                           FROM Grades g
                           JOIN Students s ON g.StudentId = s.Id
                           GROUP BY s.Id, s.StudentNo, s.Name, s.ClassName
                           ORDER BY AvgScore DESC";

            gvStudentRank.DataSource = DBHelper.ExecuteQuery(sql);
            gvStudentRank.DataBind();
        }

        private void LoadScoreDistribution()
        {
            string sql = @"SELECT '90-100 (优秀)' AS ScoreRange, COUNT(*) AS Count, CAST(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM Grades) AS DECIMAL(5,1)) AS Percentage FROM Grades WHERE Score >= 90
                           UNION ALL
                           SELECT '80-89 (良好)', COUNT(*), CAST(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM Grades) AS DECIMAL(5,1)) FROM Grades WHERE Score >= 80 AND Score < 90
                           UNION ALL
                           SELECT '70-79 (中等)', COUNT(*), CAST(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM Grades) AS DECIMAL(5,1)) FROM Grades WHERE Score >= 70 AND Score < 80
                           UNION ALL
                           SELECT '60-69 (及格)', COUNT(*), CAST(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM Grades) AS DECIMAL(5,1)) FROM Grades WHERE Score >= 60 AND Score < 70
                           UNION ALL
                           SELECT '0-59 (不及格)', COUNT(*), CAST(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM Grades) AS DECIMAL(5,1)) FROM Grades WHERE Score < 60";

            gvScoreDist.DataSource = DBHelper.ExecuteQuery(sql);
            gvScoreDist.DataBind();
        }
    }
}
