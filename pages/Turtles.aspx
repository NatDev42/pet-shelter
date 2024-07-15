<%@ Page Title="Pet Shelter - Turtles" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Turtles.aspx.cs" Inherits="pet_shelter.pages.Turtles" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="../css/myProjectStyles.css" />
    <script src="../js/myProjectCode.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input type="hidden" id="animalId_Html" runat="server">
    
    <div class="menu" id="tableContent" runat="server">
        <h3>Content Interest</h3>
        <hr />
    </div>

    <hr />
    <br />
    <br />
    <div class="title" dir="rtl">
        <h3>Turtles to Adopt</h3>
    </div>

    <div id="userAnimals" runat="server"></div>

    <div class="divToUp">
        <button class="perfectBut" onclick="event.preventDefault(); window.scrollTo(0, 0)" style="margin-bottom: 50px; margin-top: 40px;"><b>בחזרה למעלה</b></button>
    </div>
</asp:Content>
