<%@ Page Title="Pet Shelter - Registeration" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="pet_shelter.pages.Register" ClientIDMode="Static"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="Stylesheet" href="../css/myProjectStyles.css" />
    <script src="../js/myProjectCode.js"></script>

    <style>

        body {
            height:fit-content;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <div id="rgDocument">
        <div name="rgForm" id="rgForm" runat="server">

                <h2 style="font-size:30px;">Register</h2>

                <br />
                <label id="rgFirstNameText">First Name</label>
                <label id="rgLastNameText">Last Name</label>

                <br />
                <input id="rgFirstName" type="text" required class="textLook" runat="server"/>
                <input id="rgLastName" type="text" required class="textLook" runat="server"/>

                <label id="rgFirstNameWarning" class="warning" style="display:none">
                    *First name has to be at least 2 characters*
                </label>
                <label id="rgLastNameWarning" class="warning" style="display:none">
                    *Last name has to be at least 2 characters*
                </label>

                <br /><br />
                Gender:
                <input type="radio" id="genderFemale" name="Gender" onclick="genderOtherText.hidden = true" runat="server" value="She/Her" required/>female
                <input type="radio" id="genderMale"   name="Gender" onclick="genderOtherText.hidden = true" runat="server" value="He/Him"/>male
                <input type="radio" id="genderOther"  name="Gender" onclick="genderOtherText.hidden = false" runat="server"/>other
                <input type="text" id="genderOtherText" hidden="hidden" runat="server" value="They/Them"/>

                <br /><br />
                <label id="birthDateText">Birth Date</label>
                <label id="rgCountryText">Country</label><label id="rgCityText">City</label>
                <br />
                <input id="rgBirthDate" type="date" runat="server" required class="textLook"/>

                <input id="rgCountry" class="rgLocation textLook" runat="server" required/>
                <input id="rgCity" class="rgLocation textLook" runat="server" required/>
                <br /><br />
                Animals you own
                <br />
                <input id="rgAnimals" type="text" runat="server" placeholder="Mitsi, Pitsi, Garry" class="textLook"/>

                <br /><br />

                Phone Number
                <br />
                <input id="rgPhoneNum" type="text" runat="server" required class="textLook"/>
                <label id="rgPhoneNumWarning" class="warning" style="display:none">
                    *Phone Number has to be between 9-10 characters*
                </label>

                <br /><br />
                Email Address
                <br />
                <input id="rgEmail" type="email" runat="server" class="textLook" required/>

                <br /><br />
                Username
                <br />
                <input id="rgUsername" type="text" runat="server" required class="textLook" />
                <label id="rgUsernameWarning" class="warning" style="display:none">
                    *Username has to be at least 3 characters*
                </label>
                <div id="UsernameTaken" runat="server" class="warning" style="display:none">
                    *This username already exist. Please try another username*
                </div>

                            <br /><br />
                Enter your prefered color in hex [#nnnnn], rgb [rgb(r,g,b)], rgba [rgba(r,g,b)] or a basic css color
                <br />
                <input id="color" type="text" runat="server" required class="textLook" />

                <br /><br />
                Password
                <br />
                <input id="rgPassword" type="password" runat="server" required class="textLook" />
                <label id="rgPasswordWarning" class="warning" style="display:none">
                    *Password has to be at least 5 characters*
                    <br />
                </label>


                <br /><br />
                Password Confirm
                <br />
                <input id="rgPasswordConfirm" type="password" required class="textLook"/>
                <label id="rgPasswordConfirmWarning" class="warning" style="display:none">
                    *password confirm isn't the same as the password*
                </label>

                <br /><br /><br />
                <a href="Login.aspx">already have an account? click here to log in</a>


                <br /><br /><br />
                <button id="rgsubmit" class="Submit chosen" onclick="if(!ValidateRegister()) return false;" runat="server" onserverclick="rgsubmit_ServerClick">Register</button>
                <button class="Reset chosenReset" onclick="RgResetWarnings()" type="reset"> Reset </button>

            </div>            
    </div>
    </center>
</asp:Content>
