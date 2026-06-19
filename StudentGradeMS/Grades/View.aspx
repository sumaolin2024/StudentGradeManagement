<%@ Page Title="成绩查看" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="StudentGradeMS.Grades.View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="page-title">成绩查看</h2>
    <div class="search-box">
        <div class="form-group">
            <label>学生:</label>
            <asp:DropDownList ID="ddlStudent" runat="server" CssClass="form-control" DataTextField="Name" DataValueField="Id" />
        </div>
        <div class="form-group">
            <label>课程:</label>
            <asp:DropDownList ID="ddlCourse" runat="server" CssClass="form-control" DataTextField="CourseName" DataValueField="Id" />
        </div>
        <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
    </div>
    <asp:GridView ID="gvGrades" runat="server" CssClass="grid-table" AutoGenerateColumns="False"
        DataKeyNames="Id" OnRowDeleting="gvGrades_RowDeleting">
        <Columns>
            <asp:BoundField DataField="StudentNo" HeaderText="学号" />
            <asp:BoundField DataField="StudentName" HeaderText="姓名" />
            <asp:BoundField DataField="ClassName" HeaderText="班级" />
            <asp:BoundField DataField="CourseName" HeaderText="课程" />
            <asp:BoundField DataField="Score" HeaderText="成绩" DataFormatString="{0:F1}" />
            <asp:BoundField DataField="ExamDate" HeaderText="考试日期" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete"
                        CssClass="btn btn-danger" Text="删除" style="padding:4px 10px;font-size:12px;"
                        OnClientClick="return confirm('确定要删除该成绩记录吗？');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <div class="empty-data">暂无成绩数据</div>
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>
