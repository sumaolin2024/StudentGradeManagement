using System;
using System.Data;
using StudentGradeMS.App_Code;

namespace StudentGradeMS.Students
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            string sql = @"INSERT INTO Students (StudentNo, Name, Gender, Age, ClassName, Phone, Address)
                           VALUES (@StudentNo, @Name, @Gender, @Age, @ClassName, @Phone, @Address)";

            var parameters = new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@StudentNo", txtStudentNo.Text.Trim()),
                new System.Data.SqlClient.SqlParameter("@Name", txtName.Text.Trim()),
                new System.Data.SqlClient.SqlParameter("@Gender", ddlGender.SelectedValue),
                new System.Data.SqlClient.SqlParameter("@Age", int.TryParse(txtAge.Text, out int age) ? age : 18),
                new System.Data.SqlClient.SqlParameter("@ClassName", txtClassName.Text.Trim()),
                new System.Data.SqlClient.SqlParameter("@Phone", txtPhone.Text.Trim()),
                new System.Data.SqlClient.SqlParameter("@Address", txtAddress.Text.Trim())
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
