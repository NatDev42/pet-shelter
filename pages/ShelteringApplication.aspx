<%@ Page Title="Pet Shelter - Sheltering Application" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="ShelteringApplication.aspx.cs" Inherits="pet_shelter.pages.WebForm2" ClientIDMode="Static"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div id="shDocument" onload="wiwindowdow.scrollTo(0, document.body.scrollHeightT0, 1000);">
            <div name="shForm" runat="server" id="shForm">
                <h2 style="text-align:center">Sheltering Application</h2>

                <br /><br />
                Pet Name
                <br />
                <input id="shName" type="text" runat="server" required class="textLook shlength"/>

                <br /><br />
                Type
                <br />
                <input id="shTypeDogs"     type="radio" name="shType" runat="server" value="Dog"/>Dog
                <input id="shTypeCats"     type="radio" name="shType" runat="server" value="Cat" />Cat
                <input id="shTypeRodents" type="radio" name="shType" runat="server" value="Rodents" />Rodent
                <input id="shTypeTurtles" type="radio" name="shType" runat="server" value="Turtles" />Turtle
                <input id="shTypeHorses"  type="radio" name="shType" runat="server" value="Horses" required/>Horse


                <br /><br />
                Breed
                <br />
                <input id="shBreed" type="text" runat="server" class="textLook shlength2"/>

                <br /><br />
                Color
                <br />
                <input id="shColor" type="text" runat="server" required class="textLook shlength2"/>   

                <br /><br />
                <label id="shAgeText">Age</label>
                <label id="shGenderText">Gender</label>
                <label id="shSizeText">Size</label>
                <br />
                <input id="shAge" type="text" runat="server" placeholder="Senior/Adult/Young" class="textLook shInfo"/>
                <input id="shGender" type="text" runat="server" placeholder="Female/Male" class="textLook shInfo"/>
                <input id="shSize" type="text" runat="server" placeholder="Large/Medium/Small" class="textLook shInfo"/>
                
                           

                <br /><br />
                Characteristics
                <br />
                <textarea id="shCharacteristics" runat="server" required class="textLook shlength3" placeholder="Friendly, Lazy, Loyal, Spoilt, Playful"></textarea>

                <br /><br />
                Description
                <br />
                <textarea id="shDescription" runat="server" required class="textLook shlength3" placeholder="Describe the regular behavior of the animal"></textarea>
0
                <br /><br />
                Picture Url
                <br />
                <input id="shPicUrl" type="url" runat="server" class="textLook shlength"/>
                
                <br /><br /><br />
                <button id="shSubmit" class="Submit chosen" runat="server" onserverclick="shSubmit_ServerClick">Apply</button>
                <br /><br /><button id="shReset" class="Reset" type="reset"> Reset </button>


            </div>

            <br />
        </div>
    </center>
</asp:Content>
