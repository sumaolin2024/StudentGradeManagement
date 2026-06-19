<%@ Page Title="首页" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StudentGradeMS.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="page-title">系统首页</h2>
    <div style="display:flex;flex-wrap:wrap;gap:20px;margin-top:20px;">
        <div class="stat-card"><h3>学生总数</h3><div class="value"><asp:Label ID="lblStudentCount" runat="server" Text="0" /></div></div>
        <div class="stat-card green"><h3>总平均分</h3><div class="value"><asp:Label ID="lblAvgScore" runat="server" Text="0" /></div></div>
        <div class="stat-card orange"><h3>最高均分</h3><div class="value"><asp:Label ID="lblMaxAvg" runat="server" Text="0" /></div></div>
        <div class="stat-card red"><h3>全科及格人数</h3><div class="value"><asp:Label ID="lblPassCount" runat="server" Text="0" /></div></div>
        <div class="stat-card"><h3>全科及格率(%)</h3><div class="value"><asp:Label ID="lblPassRate" runat="server" Text="0" /></div></div>
    </div>
    <div style="margin-top:30px;">
        <h3 style="color:#1557b0;margin-bottom:15px;">快捷操作</h3>
        <div style="display:flex;gap:15px;flex-wrap:wrap;">
            <a href="Students/List.aspx" class="btn btn-primary">成绩总表</a>
            <a href="Students/Add.aspx" class="btn btn-success">新增记录</a>
            <a href="Reports/Statistics.aspx" class="btn btn-warning">统计分析</a>
        </div>
    </div>
</asp:Content>
