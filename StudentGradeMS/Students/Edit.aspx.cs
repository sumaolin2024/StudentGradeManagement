using System;
using System.Data;
using System.Data.SqlClient;
using StudentGradeMS.App_Code;

namespace StudentGradeMS.Students
{
    public partial class Edit : System.Web.UI.Page
    {
        private int studentId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["id"], out studentId))
            {
                Response.Redirect("List.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadStudent();
            }
        }

        private void LoadStudent()
        {
            DataTable dt = DBHelper.ExecuteQuery("SELECT * FROM Students WHERE Id=@Id",
                new SqlParameter("@Id", studentId));

            if (dt.Rows.Count == 0)
            {
                Response.Redirect("List.aspx");
                return;
            }

            DataRow row = dt.Rows[0];
            txtStudentNo.Text = row["StudentNo"].ToString();
            txtName.Text = row["Name"].ToString();
            ddlGender.SelectedValue = row["Gender"].ToString();
            txtAge.Text = row["Age"].ToString();
            txtClassName.Text = row["ClassName"].ToString();
            txtPhone.Text = row["Phone"].ToString();
            txtAddress.Text = row["Address"].ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            string sql = @"UPDATE Students SET StudentNo=@StudentNo, Name=@Name, Gender=@Gender,
                           Age=@Age, ClassName=@ClassName, Phone=@Phone, Address=@Address WHERE Id=@Id";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@StudentNo", txtStudentNo.Text.Trim()),
                new SqlParameter("@Name", txtName.Text.Trim()),
                new SqlParameter("@Gender", ddlGender.SelectedValue),
                new SqlParameter("@Age", int.TryParse(txtAge.Text, out int age) ? age : 18),
                new SqlParameter("@ClassName", txtClassName.Text.Trim()),
                new SqlParameter("@Phone", txtPhone.Text.Trim()),
                new SqlParameter("@Address", txtAddress.Text.Trim()),
                new SqlParameter("@Id", studentId)
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
