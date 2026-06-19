using System;
using System.Data;
using StudentGradeMS.App_Code;

namespace StudentGradeMS
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadStats();
        }

        private void LoadStats()
        {
            DataTable cnt = DBHelper.ExecuteQuery("SELECT COUNT(*) AS Cnt FROM Exam");
            DataTable avg = DBHelper.ExecuteQuery("SELECT ISNULL(AVG((Chinese+Math+English+Computer)/4.0),0) AS AvgTotal FROM Exam");
            DataTable maxAvg = DBHelper.ExecuteQuery("SELECT ISNULL(MAX((Chinese+Math+English+Computer)/4.0),0) AS MaxAvg FROM Exam");
            DataTable pass = DBHelper.ExecuteQuery("SELECT COUNT(*) AS Cnt FROM Exam WHERE Chinese>=60 AND Math>=60 AND English>=60 AND Computer>=60");

            lblStudentCount.Text = cnt.Rows[0]["Cnt"].ToString();
            lblAvgScore.Text = decimal.Parse(avg.Rows[0]["AvgTotal"].ToString()).ToString("F1");
            lblMaxAvg.Text = decimal.Parse(maxAvg.Rows[0]["MaxAvg"].ToString()).ToString("F1");
            lblPassCount.Text = pass.Rows[0]["Cnt"].ToString();
            lblPassRate.Text = cnt.Rows[0]["Cnt"].ToString() == "0" ? "0" :
                (int.Parse(pass.Rows[0]["Cnt"].ToString()) * 100.0 / int.Parse(cnt.Rows[0]["Cnt"].ToString())).ToString("F1");
        }
    }
}
