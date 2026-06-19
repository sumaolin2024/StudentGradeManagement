<%@ Page Title="统计分析" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="StudentGradeMS.Reports.Statistics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="page-title">统计分析</h2>
    <asp:Button ID="btnReload" runat="server" Text="刷新数据" CssClass="btn btn-primary" OnClick="btnReload_Click" style="margin-bottom:20px;" />

    <h3 style="color:#1557b0;margin-bottom:10px;">成绩概览</h3>
    <div style="display:flex;flex-wrap:wrap;gap:15px;">
        <asp:Panel ID="pnlStats" runat="server"></asp:Panel>
    </div>

    <h3 style="color:#1557b0;margin-top:30px;margin-bottom:10px;">各科成绩统计</h3>
    <asp:GridView ID="gvSubjectStats" runat="server" CssClass="grid-table" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Subject" HeaderText="科目" />
            <asp:BoundField DataField="StudentCount" HeaderText="参考人数" />
            <asp:BoundField DataField="AvgScore" HeaderText="平均分" DataFormatString="{0:F1}" />
            <asp:BoundField DataField="MaxScore" HeaderText="最高分" />
            <asp:BoundField DataField="MinScore" HeaderText="最低分" />
            <asp:BoundField DataField="PassCount" HeaderText="及格人数" />
            <asp:BoundField DataField="PassRate" HeaderText="及格率(%)" DataFormatString="{0:F1}" />
        </Columns>
    </asp:GridView>

    <h3 style="color:#1557b0;margin-top:30px;margin-bottom:10px;">学生总分排名 (Top 20)</h3>
    <asp:GridView ID="gvRank" runat="server" CssClass="grid-table" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Rank" HeaderText="排名" />
            <asp:BoundField DataField="StudentNo" HeaderText="学号" />
            <asp:BoundField DataField="Sname" HeaderText="姓名" />
            <asp:BoundField DataField="Class" HeaderText="班级" />
            <asp:BoundField DataField="Chinese" HeaderText="语文" />
            <asp:BoundField DataField="Math" HeaderText="数学" />
            <asp:BoundField DataField="English" HeaderText="英语" />
            <asp:BoundField DataField="Computer" HeaderText="计算机" />
            <asp:BoundField DataField="Total" HeaderText="总分" />
            <asp:BoundField DataField="Average" HeaderText="均分" DataFormatString="{0:F1}" />
        </Columns>
    </asp:GridView>

    <h3 style="color:#1557b0;margin-top:30px;margin-bottom:10px;">总分分段统计</h3>
    <asp:GridView ID="gvDist" runat="server" CssClass="grid-table" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ScoreRange" HeaderText="总分段" />
            <asp:BoundField DataField="Count" HeaderText="人数" />
            <asp:BoundField DataField="Percentage" HeaderText="占比(%)" DataFormatString="{0:F1}" />
        </Columns>
    </asp:GridView>
</asp:Content>
