<%@ Page Title="Pet Shelter - Applicant Profile" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="GuestProfile.aspx.cs" Inherits="pet_shelter.ProfileGuest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <lavbel style="font-weight: 600">Description:</lavbel>
                <br />
                <br />
                <div id="pfDescriptionText" runat="server"></div>

            </div>


            <label id="pfp_label" runat="server">
                <img id="pfp" src="../pictures/defaultPP.png" runat="server" />
            </label>

            <div id="pfUsername" runat="server"></div>


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
    </center>

    <br /><br /><br /><br /><br /><br />
    <h2 id='ownedText' runat="server">Sheltered Animals:</h2>
    <input type="hidden" id="convertor" runat="server" />

    <div id="ownedAnimals" runat="server" style="margin-bottom: 80px;"></div>
</asp:Content>
