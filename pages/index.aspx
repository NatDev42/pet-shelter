<%@ Page Title="Pet Shelter - Home" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="pet_shelter.pages.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="../css/myProjectStyles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main">
        <center>
            <div id="title">
                <h1>
                    Pet Shelter
                </h1>


            </div>
            <div id="description">
            
                <h3>
                    Pets are not our whole lives,
                    <br />But they make our lives whole.
                </h3>
                

                <center><div id="btnLogin"><b><a href="Login.aspx" style="text-decoration:none">Login</a></b></div></center>
            </div>
        </center>
    </div>
</asp:Content>
