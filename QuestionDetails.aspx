<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuestionDetails.aspx.cs" Inherits="Library.QuestionDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Question Details</h2>
    <div>
        <asp:Label ID="lblQuestionTitle" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblQuestionContent" runat="server" Text=""></asp:Label><br /><br />
        <asp:Label ID="noAnswersLabel" runat="server" Text="" Visible = "false">NO DATA</asp:Label>
    </div>
    <%--<div>
        <asp:GridView ID="answersGridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
          
            <asp:BoundField DataField="questionId" HeaderText="Answer ID" />
           <asp:BoundField DataField="answer_text" HeaderText="Answer Text" />
            
        </Columns>
    </asp:GridView></div>--%>

    <div>
     <asp:GridView ID="answersGridView" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="AnswerId" HeaderText="Answer ID" />
            <asp:BoundField DataField="QuestionId" HeaderText="Question ID" />
            <asp:BoundField DataField="Text" HeaderText="Answer Text" />
        </Columns>
    </asp:GridView>
    </div>

</asp:Content>
