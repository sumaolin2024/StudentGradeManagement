using System;
using System.Data;
using System.Data.SqlClient;
using StudentGradeMS.App_Code;

namespace StudentGradeMS.Courses
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

        private void BindGrid()
        {
            DataTable dt = DBHelper.ExecuteQuery("SELECT * FROM Courses ORDER BY Id DESC");
            gvCourses.DataSource = dt;
            gvCourses.DataBind();
        }

        protected void gvCourses_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvCourses.DataKeys[e.RowIndex].Value);
            DBHelper.ExecuteNonQuery("DELETE FROM Courses WHERE Id=@Id",
                new SqlParameter("@Id", id));
            BindGrid();
        }
    }
}
