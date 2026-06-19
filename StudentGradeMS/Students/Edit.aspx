<%@ Page Title="编辑学生" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="StudentGradeMS.Students.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="page-title">编辑学生</h2>
    <div class="form-group"><label>学号:</label><asp:TextBox ID="txtStudentNo" runat="server" CssClass="form-control" ReadOnly="true" /></div>
    <div class="form-group"><label>姓名:</label><asp:TextBox ID="txtSname" runat="server" CssClass="form-control" MaxLength="10" /><asp:RequiredFieldValidator ID="rfvSname" runat="server" ControlToValidate="txtSname" ErrorMessage="*" ForeColor="Red" /></div>
    <div class="form-group"><label>班级:</label><asp:TextBox ID="txtClass" runat="server" CssClass="form-control" MaxLength="2" /></div>
    <div class="form-group"><label>语文:</label><asp:TextBox ID="txtChinese" runat="server" CssClass="form-control" TextMode="Number" /></div>
    <div class="form-group"><label>数学:</label><asp:TextBox ID="txtMath" runat="server" CssClass="form-control" TextMode="Number" /></div>
    <div class="form-group"><label>英语:</label><asp:TextBox ID="txtEnglish" runat="server" CssClass="form-control" TextMode="Number" /></div>
    <div class="form-group"><label>计算机:</label><asp:TextBox ID="txtComputer" runat="server" CssClass="form-control" TextMode="Number" /></div>
    <div class="form-group" style="margin-top:20px;">
        <asp:Button ID="btnSave" runat="server" Text="保存修改" CssClass="btn btn-primary" OnClick="btnSave_Click" />
        <a href="List.aspx" class="btn" style="background:#ccc;color:#333;margin-left:10px;">返回</a>
    </div>
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />
</asp:Content>
