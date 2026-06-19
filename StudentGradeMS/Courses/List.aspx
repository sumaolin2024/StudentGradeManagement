<%@ Page Title="课程列表" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="StudentGradeMS.Courses.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="page-title">课程管理</h2>
    <div class="action-bar">
        <a href="Add.aspx" class="btn btn-success">新增课程</a>
    </div>
    <asp:GridView ID="gvCourses" runat="server" CssClass="grid-table" AutoGenerateColumns="False"
        DataKeyNames="Id" OnRowDeleting="gvCourses_RowDeleting">
        <Columns>
            <asp:BoundField DataField="CourseNo" HeaderText="课程编号" />
            <asp:BoundField DataField="CourseName" HeaderText="课程名称" />
            <asp:BoundField DataField="Credit" HeaderText="学分" />
            <asp:BoundField DataField="TeacherName" HeaderText="授课教师" />
            <asp:BoundField DataField="Semester" HeaderText="学期" />
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete"
                        CssClass="btn btn-danger" Text="删除" style="padding:4px 10px;font-size:12px;"
                        OnClientClick="return confirm('确定要删除该课程吗？');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <div class="empty-data">暂无课程数据</div>
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>
