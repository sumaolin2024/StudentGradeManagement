<%@ Page Title="统计分析" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="StudentGradeMS.Reports.Statistics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="page-title">统计分析</h2>
    
    <div style="display:flex;flex-wrap:wrap;gap:15px;margin-bottom:20px;">
        <asp:Button ID="btnReload" runat="server" Text="刷新数据" CssClass="btn btn-primary" OnClick="btnReload_Click" />
    </div>

    <h3 style="color:#1557b0;margin-bottom:10px;">成绩概览</h3>
    <div style="display:flex;flex-wrap:wrap;gap:15px;">
        <asp:Panel ID="pnlStats" runat="server">
        </asp:Panel>
    </div>

    <h3 style="color:#1557b0;margin-top:30px;margin-bottom:10px;">各科平均成绩</h3>
    <asp:GridView ID="gvCourseAvg" runat="server" CssClass="grid-table" AutoGenerateColumns="False" ShowFooter="True">
        <Columns>
            <asp:BoundField DataField="CourseName" HeaderText="课程名称" />
            <asp:BoundField DataField="StudentCount" HeaderText="参考人数" />
            <asp:BoundField DataField="AvgScore" HeaderText="平均分" DataFormatString="{0:F2}" />
            <asp:BoundField DataField="MaxScore" HeaderText="最高分" DataFormatString="{0:F1}" />
            <asp:BoundField DataField="MinScore" HeaderText="最低分" DataFormatString="{0:F1}" />
            <asp:BoundField DataField="PassRate" HeaderText="及格率(%)" DataFormatString="{0:F1}" />
        </Columns>
        <EmptyDataTemplate>
            <div class="empty-data">暂无成绩数据</div>
        </EmptyDataTemplate>
    </asp:GridView>

    <h3 style="color:#1557b0;margin-top:30px;margin-bottom:10px;">学生成绩排名 (Top 20)</h3>
    <asp:GridView ID="gvStudentRank" runat="server" CssClass="grid-table" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Rank" HeaderText="排名" />
            <asp:BoundField DataField="StudentNo" HeaderText="学号" />
            <asp:BoundField DataField="Name" HeaderText="姓名" />
            <asp:BoundField DataField="ClassName" HeaderText="班级" />
            <asp:BoundField DataField="AvgScore" HeaderText="平均分" DataFormatString="{0:F2}" />
            <asp:BoundField DataField="CourseCount" HeaderText="科目数" />
            <asp:BoundField DataField="TotalScore" HeaderText="总分" DataFormatString="{0:F1}" />
        </Columns>
        <EmptyDataTemplate>
            <div class="empty-data">暂无成绩数据</div>
        </EmptyDataTemplate>
    </asp:GridView>

    <h3 style="color:#1557b0;margin-top:30px;margin-bottom:10px;">分数段分布</h3>
    <asp:GridView ID="gvScoreDist" runat="server" CssClass="grid-table" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ScoreRange" HeaderText="分数段" />
            <asp:BoundField DataField="Count" HeaderText="人数" />
            <asp:BoundField DataField="Percentage" HeaderText="占比(%)" DataFormatString="{0:F1}" />
        </Columns>
    </asp:GridView>
</asp:Content>
