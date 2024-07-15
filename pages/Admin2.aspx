<%@ Page Title="Pet Shelter - Admin Stats" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Admin2.aspx.cs" Inherits="pet_shelter.pages.Admin2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="divStats">
       <center style="font-size:50px"><h1>Site Stats</h1></center>

        <div style="margin-left:38%;">
            <br /><br />
            <label class="amStats" runat="server">Current Users In The Website: <%=Application["usersCount"]%></label>
            <br /><br />
            <label class="amStats" runat="server">Current Admins In The Website: <%=Application["adminsCount"]%></label>
            <br /><br />

            <label class="amStats" runat="server">Current Registered Users In The Website: <%=Application["loginCount"]%></label>
            <br /><br />

            <label class="amStats" runat="server">Current Guest Users In The Website: <%=Application["guestsCount"]%></label>

            <div id="EntriesIncGuestsId" class="amStats" runat="server">Total Entries of All Time (Not Including Guests): </div>

            <div id="EntriesId" class="amStats" runat="server">Total Entries of All Time (Including Guests): </div>
        </div>
        
    </div>
</asp:Content>
