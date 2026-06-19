<%@ Page Title="首页" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StudentGradeMS.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="page-title">系统首页</h2>
    <div style="display:flex;flex-wrap:wrap;gap:20px;margin-top:20px;">
        <asp:Panel ID="pnlStats" runat="server">
            <div class="stat-card">
                <h3>学生总数</h3>
                <div class="value"><asp:Label ID="lblStudentCount" runat="server" Text="0" /></div>
            </div>
            <div class="stat-card green">
                <h3>课程总数</h3>
                <div class="value"><asp:Label ID="lblCourseCount" runat="server" Text="0" /></div>
            </div>
            <div class="stat-card orange">
                <h3>成绩记录</h3>
                <div class="value"><asp:Label ID="lblGradeCount" runat="server" Text="0" /></div>
            </div>
            <div class="stat-card red">
                <h3>平均成绩</h3>
                <div class="value"><asp:Label ID="lblAvgScore" runat="server" Text="0" /></div>
            </div>
        </asp:Panel>
    </div>
    <div style="margin-top:30px;">
        <h3 style="color:#1557b0;margin-bottom:15px;">快捷操作</h3>
        <div style="display:flex;gap:15px;flex-wrap:wrap;">
            <a href="Students/Add.aspx" class="btn btn-primary">新增学生</a>
            <a href="Courses/Add.aspx" class="btn btn-success">新增课程</a>
            <a href="Grades/Enter.aspx" class="btn btn-warning">录入成绩</a>
            <a href="Reports/Statistics.aspx" class="btn btn-primary">统计报表</a>
        </div>
    </div>
</asp:Content>
