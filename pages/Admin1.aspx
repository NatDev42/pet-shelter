<%@ Page Title="Pet Shelter - Admin Tables" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Admin1.aspx.cs" Inherits="pet_shelter.pages.Admin1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/myProjectCode.js">     
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <center>
        <center style="font-size: 30px">
            <h1>Database Info</h1>
        </center>
        <div class="select" onload="hideDataInfo()">
        <select id="mainSelect" onchange="ShowData()">
            <option id="empty" value="Nope"></option>
            <option id="usersInfoId" value="UsersInfo" >Users Info</option>
            <option id="animalsInfoId" value="AnimalsInfo">AnimalsInfo</option>
        </select>
        </div>
    </center>
    <br /><br /><br />
    <hr />
    <!---------------------------------------------------------------------------------->

    <div id="usersData">
    <br /><br />
    <center style="font-size: 20px">
        <h1>User Data Table</h1>
    </center>
    <br />
    <center>
        <div id="DivUserTable" runat="server"></div>
    </center>

    <!---------------------------------------------------------------------------------->
    <table border="0" style="margin-bottom:100px;">
        <tr>
            <td>
                <div class="adminDatabaseDiv" runat="server" style="margin-left:20px;">

                    <h1>Update</h1>

                    <div>
                        <br />
                        <label>Id</label>
                        <br />
                        <input id="updateIdUsers" runat="server" type="text" class="textLook AdminInput" />
                    </div>

                    <div>
                        <br />
                        <label>username</label>
                        <br />
                        <input id="updateUsernameUsers" runat="server" type="text" class="textLook AdminInput" />
                    </div>

                    <div>
                        <br />
                        <label>password</label>
                        <br />
                        <input id="updatePasswordUsers" runat="server" type="text" class="textLook AdminInput" />
                    </div>

                    <div>
                        <br />
                        <input id="updateIsAdminUsers" type="checkbox" runat="server" />
                        <label>Is Admin </label>
                    </div>

                    <button id="SubmitUpdateUsers" class="chosen Submit adminDatabaseBtn" runat="server" onserverclick="SubmitUpdateUsers_ServerClick">Update</button>
                    <div id="updateResultIdUsers" runat="server" style="margin-top:-10px;" class="warning"/>
                </div>
            </td>

            <!---------------------------------------------------------------------------------->
            <td>
                <div class="adminDatabaseDiv DeleteDiv">
                    <h1>Delete</h1>

                    <div>
                        <br />
                        <label>Username</label>
                        <br />
                        <input id="deleteUsernameUsers" runat="server" type="text" class="textLook AdminInput" />
                    </div>

                    <button id="SubmitDeleteUsers" class="chosen Submit adminDatabaseBtn" runat="server" onserverclick="SubmitDeleteUsers_ServerClick">Delete</button>
                    <div id="deleteResultIdUsers" runat="server"/>
                </div>
            </td>
        </tr>
    </table>
    </div>
    <!----------------------------------------------------------------------------------------------------->

    <div id="animalsData">
    <br /><br />
    <center style="font-size: 20px">
        <h1>Animals Data Table</h1>
    </center>
    <br />
    <center>
        <div id="DivAnimalsTable" runat="server" style="margin-bottom: 100px;margin-left:20px;"></div>
    </center>

    <!---------------------------------------------------------------------------------->
    <table border="0" style="margin-bottom:100px;">
        <tr>
            <td>
                <div id="updateAnimalsDiv" class="adminDatabaseDiv" runat="server">

                    <h1>Update</h1>

                    <div>
                        <br />
                        <label>Id</label>
                        <br />
                        <input id="updateIdAnimals" runat="server" type="text" class="textLook AdminInput" />
                    </div>

                    <div>
                        <br />
                        <label>Name</label>
                        <br />
                        <input id="updateNameAnimals" runat="server" type="text" class="textLook AdminInput" />
                    </div>

                    <div>
                        <br />
                        <label>Applicant</label>
                        <br />
                        <input id="updateApplicantAnimals" runat="server" type="text" class="textLook AdminInput" />
                    </div>

                    <button id="SubmitUpdateAnimals" class="chosen Submit adminDatabaseBtn" runat="server" onserverclick="SubmitUpdateAnimals_ServerClick">Update</button>
                    <div id="updateResultIdAnimals" runat="server" style="margin-top:-10px;" class="warning"/>
                </div>
            </td>

            <!---------------------------------------------------------------------------------->
            <td>
                <div id="deleteAnimalsDiv" class="adminDatabaseDiv DeleteDiv" >
                    <h1>Delete</h1>

                    <div>
                        <br />
                        <label>Username</label>
                        <br />
                        <input id="deleteUsernameAnimals" runat="server" type="text" class="textLook AdminInput" />
                    </div>

                    <button id="SubmitDeleteAnimals" class="chosen Submit adminDatabaseBtn" runat="server" onserverclick="SubmitDeleteAnimals_ServerClick">Delete</button>
                    <div id="deleteResultIdAnimals" runat="server"/>                
                </div>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
