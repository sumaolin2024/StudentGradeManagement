<%@ Page Title="新增学生" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="StudentGradeMS.Students.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="page-title">新增学生</h2>
    <div class="form-group">
        <label>学号:</label>
        <asp:TextBox ID="txtStudentNo" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="rfvStudentNo" runat="server" ControlToValidate="txtStudentNo" 
            ErrorMessage="学号不能为空" ForeColor="Red" Display="Dynamic" />
    </div>
    <div class="form-group">
        <label>姓名:</label>
        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" 
            ErrorMessage="姓名不能为空" ForeColor="Red" Display="Dynamic" />
    </div>
    <div class="form-group">
        <label>性别:</label>
        <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
            <asp:ListItem Value="男" Text="男" />
            <asp:ListItem Value="女" Text="女" />
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <label>年龄:</label>
        <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" TextMode="Number" Text="18" />
    </div>
    <div class="form-group">
        <label>班级:</label>
        <asp:TextBox ID="txtClassName" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <label>电话:</label>
        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <label>地址:</label>
        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine" style="width:400px;height:60px;" />
    </div>
    <div class="form-group" style="margin-top:20px;">
        <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn btn-primary" OnClick="btnSave_Click" />
        <a href="List.aspx" class="btn" style="background:#ccc;color:#333;margin-left:10px;">返回</a>
    </div>
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />
</asp:Content>
