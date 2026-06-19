<%@ Page Title="学生列表" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="StudentGradeMS.Students.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="page-title">学生管理</h2>
    <div class="search-box">
        <div class="form-group">
            <label>学号/姓名:</label>
            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="输入学号或姓名搜索" />
        </div>
        <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
    </div>
    <div class="action-bar">
        <a href="Add.aspx" class="btn btn-success">新增学生</a>
    </div>
    <asp:GridView ID="gvStudents" runat="server" CssClass="grid-table" AutoGenerateColumns="False"
        OnRowDeleting="gvStudents_RowDeleting" OnRowCommand="gvStudents_RowCommand">
        <Columns>
            <asp:BoundField DataField="StudentNo" HeaderText="学号" />
            <asp:BoundField DataField="Sname" HeaderText="姓名" />
            <asp:BoundField DataField="Class" HeaderText="班级" />
            <asp:BoundField DataField="Chinese" HeaderText="语文" />
            <asp:BoundField DataField="Math" HeaderText="数学" />
            <asp:BoundField DataField="English" HeaderText="英语" />
            <asp:BoundField DataField="Computer" HeaderText="计算机" />
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditStudent" CommandArgument='<%# Eval("StudentNo") %>'
                        CssClass="btn btn-primary" Text="编辑" style="padding:4px 10px;font-size:12px;" />
                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete"
                        CssClass="btn btn-danger" Text="删除" style="padding:4px 10px;font-size:12px;"
                        OnClientClick="return confirm('确定要删除该学生吗？');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate><div class="empty-data">暂无学生数据</div></EmptyDataTemplate>
    </asp:GridView>
</asp:Content>
