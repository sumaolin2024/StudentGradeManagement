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
            if (!IsPostBack) LoadAll();
        }

        protected void btnReload_Click(object sender, EventArgs e) => LoadAll();

        private void LoadAll()
        {
            LoadOverview();
            LoadSubjectStats();
            LoadRank();
            LoadDistribution();
        }

        private void LoadOverview()
        {
            var items = new (string title, string css, string sql)[]
            {
                ("学生总数", "", "SELECT COUNT(*) FROM Exam"),
                ("总平均分", "green", "SELECT ISNULL(AVG((Chinese+Math+English+Computer)/4.0),0) FROM Exam"),
                ("总分最高", "orange", "SELECT ISNULL(MAX(Chinese+Math+English+Computer),0) FROM Exam"),
                ("总分最低", "red", "SELECT ISNULL(MIN(Chinese+Math+English+Computer),0) FROM Exam"),
                ("全科及格率", "", "SELECT ISNULL(CAST(SUM(CASE WHEN Chinese>=60 AND Math>=60 AND English>=60 AND Computer>=60 THEN 1 ELSE 0 END)*100.0/COUNT(*) AS DECIMAL(5,1)),0) FROM Exam")
            };

            StringBuilder sb = new StringBuilder();
            foreach (var it in items)
            {
                object val = DBHelper.ExecuteScalar(it.sql);
                string disp = val is decimal ? ((decimal)val).ToString("F1") : val.ToString();
                sb.AppendFormat(@"<div class=""stat-card {1}""><h3>{0}</h3><div class=""value"">{2}</div></div>", it.title, it.css, disp);
            }
            pnlStats.Controls.Add(new System.Web.UI.WebControls.Literal { Text = sb.ToString() });
        }

        private void LoadSubjectStats()
        {
            string sql = @"
                SELECT '语文' AS Subject, COUNT(*) AS StudentCount, AVG(CAST(Chinese AS DECIMAL)) AS AvgScore, MAX(Chinese) AS MaxScore, MIN(Chinese) AS MinScore, SUM(CASE WHEN Chinese>=60 THEN 1 ELSE 0 END) AS PassCount, CAST(SUM(CASE WHEN Chinese>=60 THEN 1 ELSE 0 END)*100.0/COUNT(*) AS DECIMAL(5,1)) AS PassRate FROM Exam
                UNION ALL SELECT '数学', COUNT(*), AVG(CAST(Math AS DECIMAL)), MAX(Math), MIN(Math), SUM(CASE WHEN Math>=60 THEN 1 ELSE 0 END), CAST(SUM(CASE WHEN Math>=60 THEN 1 ELSE 0 END)*100.0/COUNT(*) AS DECIMAL(5,1)) FROM Exam
                UNION ALL SELECT '英语', COUNT(*), AVG(CAST(English AS DECIMAL)), MAX(English), MIN(English), SUM(CASE WHEN English>=60 THEN 1 ELSE 0 END), CAST(SUM(CASE WHEN English>=60 THEN 1 ELSE 0 END)*100.0/COUNT(*) AS DECIMAL(5,1)) FROM Exam
                UNION ALL SELECT '计算机', COUNT(*), AVG(CAST(Computer AS DECIMAL)), MAX(Computer), MIN(Computer), SUM(CASE WHEN Computer>=60 THEN 1 ELSE 0 END), CAST(SUM(CASE WHEN Computer>=60 THEN 1 ELSE 0 END)*100.0/COUNT(*) AS DECIMAL(5,1)) FROM Exam";
            gvSubjectStats.DataSource = DBHelper.ExecuteQuery(sql);
            gvSubjectStats.DataBind();
        }

        private void LoadRank()
        {
            string sql = @"SELECT TOP 20 ROW_NUMBER() OVER(ORDER BY (Chinese+Math+English+Computer) DESC) AS Rank,
                StudentNo, Sname, Class, Chinese, Math, English, Computer,
                (Chinese+Math+English+Computer) AS Total,
                (Chinese+Math+English+Computer)/4.0 AS Average
                FROM Exam ORDER BY Total DESC";
            gvRank.DataSource = DBHelper.ExecuteQuery(sql);
            gvRank.DataBind();
        }

        private void LoadDistribution()
        {
            string total = "(Chinese+Math+English+Computer)";
            string sql = string.Format(@"
                SELECT '360-400 (优秀)' AS ScoreRange, COUNT(*) AS Count, CAST(COUNT(*)*100.0/(SELECT COUNT(*) FROM Exam) AS DECIMAL(5,1)) AS Percentage FROM Exam WHERE {0} >= 360
                UNION ALL SELECT '320-359 (良好)', COUNT(*), CAST(COUNT(*)*100.0/(SELECT COUNT(*) FROM Exam) AS DECIMAL(5,1)) FROM Exam WHERE {0} >= 320 AND {0} < 360
                UNION ALL SELECT '280-319 (中等)', COUNT(*), CAST(COUNT(*)*100.0/(SELECT COUNT(*) FROM Exam) AS DECIMAL(5,1)) FROM Exam WHERE {0} >= 280 AND {0} < 320
                UNION ALL SELECT '240-279 (及格)', COUNT(*), CAST(COUNT(*)*100.0/(SELECT COUNT(*) FROM Exam) AS DECIMAL(5,1)) FROM Exam WHERE {0} >= 240 AND {0} < 280
                UNION ALL SELECT '0-239 (不及格)', COUNT(*), CAST(COUNT(*)*100.0/(SELECT COUNT(*) FROM Exam) AS DECIMAL(5,1)) FROM Exam WHERE {0} < 240", total);
            gvDist.DataSource = DBHelper.ExecuteQuery(sql);
            gvDist.DataBind();
        }
    }
}
