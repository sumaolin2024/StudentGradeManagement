using System;
using System.Data;
using StudentGradeMS.App_Code;

namespace StudentGradeMS.Students
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            string keyword = txtSearch.Text.Trim();
            string sql = "SELECT * FROM Students WHERE 1=1";
            if (!string.IsNullOrEmpty(keyword))
            {
                sql += " AND (StudentNo LIKE @keyword OR Name LIKE @keyword)";
            }
            sql += " ORDER BY Id DESC";

            var param = new System.Data.SqlClient.SqlParameter("@keyword", "%" + keyword + "%");
            DataTable dt = string.IsNullOrEmpty(keyword) 
                ? DBHelper.ExecuteQuery(sql) 
                : DBHelper.ExecuteQuery(sql, param);

            gvStudents.DataSource = dt;
            gvStudents.DataBind();
        }

        protected void gvStudents_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvStudents.DataKeys[e.RowIndex].Value);
            DBHelper.ExecuteNonQuery("DELETE FROM Students WHERE Id=@Id",
                new System.Data.SqlClient.SqlParameter("@Id", id));
            BindGrid();
        }

        protected void gvStudents_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditStudent")
            {
                Response.Redirect("Edit.aspx?id=" + e.CommandArgument);
            }
        }
    }
}
