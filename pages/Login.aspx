<%@ Page Title="Pet Shelter - Sign In" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="pet_shelter.pages.Login" ClientIDMode="Static"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="../css/myProjectStyles.css" />
    <script src="../js/myProjectCode.js"></script>
    <style>
        #bottomRow{
            bottom: 0;
            position:absolute;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">'
    <center>
     <div id="lgDocument">
        <div name="lgForm" runat="server" id="lgForm">
                <h2>Log In</h2>

                <br /><br />
                Username
                <br />
                <input id="lgUsername" type="text" runat="server" class="textLook"/>

                <br /><br />
                Password
                <br />
                <input id="lgPassword" type="password" runat="server" class="textLook"/>

                <br /><br /><br />
                <a href="Register.aspx">Don't have an account? Click here to register</a>
                <div id="lgErrors" runat="server" class="warning" style="display:none"><br />*Username or password is incorrect*</div>

                <br /><br /><br />
                <button id="lgSubmit" class="Submit chosen" runat="server" onclick="if(!ValidateLogin()) return false;" onserverclick="lgSubmit_ServerClick">Login</button>
                <button class="Reset chosenReset" onclick="LgResetWarnings()" type="reset"> Reset </button>


            </div>

            <br />
    </div>
    </center>
</asp:Content>
