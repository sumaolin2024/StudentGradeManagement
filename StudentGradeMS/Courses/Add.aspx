<%@ Page Title="新增课程" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="StudentGradeMS.Courses.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="page-title">新增课程</h2>
    <div class="form-group">
        <label>课程编号:</label>
        <asp:TextBox ID="txtCourseNo" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="rfvCourseNo" runat="server" ControlToValidate="txtCourseNo"
            ErrorMessage="课程编号不能为空" ForeColor="Red" Display="Dynamic" />
    </div>
    <div class="form-group">
        <label>课程名称:</label>
        <asp:TextBox ID="txtCourseName" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="rfvCourseName" runat="server" ControlToValidate="txtCourseName"
            ErrorMessage="课程名称不能为空" ForeColor="Red" Display="Dynamic" />
    </div>
    <div class="form-group">
        <label>学分:</label>
        <asp:TextBox ID="txtCredit" runat="server" CssClass="form-control" TextMode="Number" Text="2" />
    </div>
    <div class="form-group">
        <label>授课教师:</label>
        <asp:TextBox ID="txtTeacherName" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <label>学期:</label>
        <asp:TextBox ID="txtSemester" runat="server" CssClass="form-control" placeholder="如:2024-2025-1" />
    </div>
    <div class="form-group" style="margin-top:20px;">
        <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary" OnClick="btnSave_Click" />
        <a href="List.aspx" class="btn" style="background:#ccc;color:#333;margin-left:10px;">返回</a>
    </div>
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />
</asp:Content>
