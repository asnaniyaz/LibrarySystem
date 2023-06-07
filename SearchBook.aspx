<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchBook.aspx.cs" Inherits="Library.SearchBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div align = "Center"><br /><br/>
<asp:Label ID="Label1" runat="server" Text="Label" Width = "15%"> Search by Category</asp:Label>
     <asp:DropDownList ID="dlSearch" runat="server" AutoPostBack="True" 
                   onselectedindexchanged="dlSearch_SelectedIndexChanged"  Width="160px">
                </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                <asp:Label ID="Label6" runat="server" Text="Label" Width = "10%"> SubCategory</asp:Label>
     <asp:DropDownList ID="dlSubCat" runat="server" AutoPostBack="True" 
                    Width="160px">
                </asp:DropDownList>
               
      <br/><br/></div>
     <%-- <asp:Label ID="Label2" runat="server" Text="Label" Width = "10%"> Password</asp:Label>
      <asp:TextBox ID="txtPas" runat="server" TextMode="Password"></asp:TextBox>
      <br /><br/>
    
       <asp:Label ID="Label3" runat="server" Text="Label" Width = "10%"> Name</asp:Label>
      <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
      <br/><br/>
      <asp:Label ID="Label4" runat="server" Text="Label" Width = "10%"> Address</asp:Label>
      <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
      <br /><br/>
      
      
--%><br/><div align = "Center">
    <asp:Button ID="btnSearch" runat="server" Text="search" onclick="btnSearch_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label5" runat="server"> </asp:Label></div>  
    <br/><div>
     <asp:GridView ID="gvSearch" runat="server" AllowPaging="True" 
             AllowSorting="True" HorizontalAlign="Left" 
              PageSize="50" 
             width="100%">
             <AlternatingRowStyle CssClass="AlternatingRowStyle" />
             <FooterStyle CssClass="FooterRowStyle" />
             <HeaderStyle CssClass="HeaderStyle" />
             <PagerStyle CssClass="PagerStyle" />
             <RowStyle CssClass="RowStyle" />
             
         </asp:GridView></div>
</asp:Content>
