<%@ Page Title="Index Welcome" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Head Index</title>
    <meta name="description" content="description of the content page" />
    <meta name="keywords" content="key1,key2" />
      Running through content view holder
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Welcome to ContentPlaceHolder 1
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Welcome to ContentPlaceHolder 2
</asp:Content>
