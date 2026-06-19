<%@ Page Title="成绩录入" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Enter.aspx.cs" Inherits="StudentGradeMS.Grades.Enter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="page-title">成绩录入</h2>
    <div class="form-group">
        <label>选择学生:</label>
        <asp:DropDownList ID="ddlStudent" runat="server" CssClass="form-control" DataTextField="Name" DataValueField="Id" />
    </div>
    <div class="form-group">
        <label>选择课程:</label>
        <asp:DropDownList ID="ddlCourse" runat="server" CssClass="form-control" DataTextField="CourseName" DataValueField="Id" />
    </div>
    <div class="form-group">
        <label>成绩:</label>
        <asp:TextBox ID="txtScore" runat="server" CssClass="form-control" TextMode="Number" />
        <asp:RequiredFieldValidator ID="rfvScore" runat="server" ControlToValidate="txtScore"
            ErrorMessage="成绩不能为空" ForeColor="Red" Display="Dynamic" />
        <asp:RangeValidator ID="rvScore" runat="server" ControlToValidate="txtScore"
            MinimumValue="0" MaximumValue="100" Type="Double" ErrorMessage="成绩范围0-100" ForeColor="Red" Display="Dynamic" />
    </div>
    <div class="form-group">
        <label>考试日期:</label>
        <asp:TextBox ID="txtExamDate" runat="server" CssClass="form-control" TextMode="Date" />
    </div>
    <div class="form-group">
        <label>备注:</label>
        <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine" style="width:400px;height:60px;" />
    </div>
    <div class="form-group" style="margin-top:20px;">
        <asp:Button ID="btnSave" runat="server" Text="保存成绩" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>
    <asp:Label ID="lblMsg" runat="server" />
</asp:Content>
