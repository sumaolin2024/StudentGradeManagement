using System;
using System.Data;
using System.Data.SqlClient;
using StudentGradeMS.App_Code;

namespace StudentGradeMS.Students
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindGrid();
        }

        protected void btnSearch_Click(object sender, EventArgs e) => BindGrid();

        private void BindGrid()
        {
            string keyword = txtSearch.Text.Trim();
            string sql = "SELECT * FROM Exam WHERE 1=1";
            if (!string.IsNullOrEmpty(keyword))
                sql += " AND (StudentNo LIKE @kw OR Sname LIKE @kw)";
            sql += " ORDER BY StudentNo";

            var param = string.IsNullOrEmpty(keyword) ? null
                : new SqlParameter[] { new SqlParameter("@kw", "%" + keyword + "%") };

            gvStudents.DataSource = DBHelper.ExecuteQuery(sql, param ?? new SqlParameter[0]);
            gvStudents.DataBind();
        }

        protected void gvStudents_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            string sno = gvStudents.Rows[e.RowIndex].Cells[0].Text;
            DBHelper.ExecuteNonQuery("DELETE FROM Exam WHERE StudentNo=@sno",
                new SqlParameter("@sno", sno));
            BindGrid();
        }

        protected void gvStudents_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditStudent")
                Response.Redirect("Edit.aspx?sno=" + Server.UrlEncode(e.CommandArgument.ToString()));
        }
    }
}
