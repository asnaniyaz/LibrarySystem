<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecentQuestionsNew.aspx.cs" Inherits="Library.RecentQuestionsNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

    <title></title>
    <script>
        function loadQuestions() {
            var apiUrl = "https://api.stackexchange.com/2.3/questions?pagesize=50&order=desc&sort=creation&site=stackoverflow";
            
            fetch(apiUrl)
                .then(response => response.json())
                .then(result => {
                    var questions = result.items;
                    var questionsContainer = document.getElementById("questionsContainer");
                    
                    questions.forEach(question => {
                        var questionLink = document.createElement("a");
                        questionLink.href = "QuestionDetails.aspx?id=" + question.question_id;
                        questionLink.textContent = question.title;
                        
                        var listItem = document.createElement("li");
                        listItem.appendChild(questionLink);
                        
                        questionsContainer.appendChild(listItem);
                    });
                })
                .catch(error => {
                    var errorMessage = "An error occurred while retrieving questions: " + error.message;
                    var errorElement = document.createElement("p");
                    errorElement.textContent = errorMessage;
                    
                    var errorContainer = document.getElementById("errorContainer");
                    errorContainer.appendChild(errorElement);
                });
        }
        
        document.addEventListener("DOMContentLoaded", function() {
            loadQuestions();
        });
    </script>

<body>
    <div id="questionsContainer"></div>
    <div id="errorContainer"></div>
    <div>
    <asp:GridView ID="questionsGridView" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink ID="questionLink" runat="server" Text='<%# Eval("title") %>'
                    NavigateUrl='<%# "QuestionDetails.aspx?id=" + Eval("question_id") %>'></asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView></div>

</body>
</html>
</asp:Content>

