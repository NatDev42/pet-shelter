<%@ Page Title="Pet Shelter - Profile" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="pet_shelter.pages.Profile" ClientIDMode="Static"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/myProjectStyles.css" rel="stylesheet" />
    <link href='https://fonts.googleapis.com/css?family=Alegreya' rel='stylesheet'>
    <script src="../js/myProjectCode.js">
        window.onload = function () {
        $('input[type="text"]').focus();
        };
    </script>
    <style>
        #bottomRow {
            bottom: 0;
            position: fixed;
            margin-top: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input type="hidden" id="adopterId_Html" runat="server" />
    <input type="hidden" id="animalId_Html" runat="server" />
    <center>
        <div id="pfBox">
            <div id="pfRightDiv">
                <center>
                    <img src="../pictures/map-pin.png" />
                    <div id="pfLocation" runat="server"></div>
                    <br />
                    <div id="pfAge_Pronouns" runat="server"></div>
                </center>
                <br />
            </div>
            <div id="pfDescription" runat="server">
                <br />
                <lavbel style="font-weight: 600; font-size:20px;">Description:</lavbel>
                <br />
                <br />
                <div id="pfDescriptionText" runat="server"></div>
                <textarea id="editDes" runat="server"></textarea>


                <br />
                <br />
                <button id="editBtn" runat="server" class="coolBtn" onserverclick="editBtn_ServerClick">Edit Description</button>
                <button id="doneBtn" runat="server" class="coolBtn" onserverclick="DoneBtn_ServerClick">Done</button>

            </div>


            <label id="pfp_label" runat="server">
                <img id="pfp" src="../pictures/defaultPP.png" runat="server" />
                <button id="pfp_button" runat="server" onclick="changeImage();" onserverclick="pfp_button_ServerClick" style="display: none"></button>
            </label>

            <div id="pfUsername" runat="server"><%=Session["User"]%></div>


            <br />
            <center id="pfUserStats">
                <table id="statsT">
                    <tr>
                        <td><img src="../pictures/cat-overlord.png" /></td>
                        <td><img src="../pictures/house.png" /></td>
                        <td><img src="../pictures/doggo.png" /></td>
                    </tr>
                    <tr>
                        <td><b>Owned </b></td>
                        <td><b>Adopted</b></td>
                        <td><b>Sheltering</b></td>
                    </tr>
                    <tr style="color: #575757">
                        <td id="pfOwned" style="text-align: center;" runat="server"></td>
                        <td id="pfAdopted" style="text-align: center;" runat="server"></td>
                        <td id="pfSheltetring" style="text-align: center;" runat="server"></td>
                    </tr>
                </table>
            </center>



            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />       
            <hr id="pfLine" runat="server" />
            <div id="pfOwnerOf" runat="server"></div>

        </div>
        <input id="picUrl_html" type="hidden" runat="server" />

        <div id="addPet">
            <center>
                Click here if you are sheltering an animal and would like us to help you find a house for them
                <br />
                <button id="btAddAnimal" class="coolBtn" runat="server" onserverclick="btAddAnimal_ServerClick">Add Animal +</button>
            </center>
        </div>
    </center>

    <br /><br /><br /><br /><br /><br />
    <input type="hidden" id="convertor" runat="server" />

    <div id="ownedAnimals" runat="server" style="margin-bottom: 80px;"></div>
</asp:Content>
