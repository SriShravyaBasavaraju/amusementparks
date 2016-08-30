<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Tickets.aspx.cs" Inherits="AmusementParks.Tickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 900px; overflow: auto; margin: auto; width: 99%; margin-left: 0.5%; border: 1px #A9A9A9 solid;">

        <h2 style="text-align: center"><b>Buy Tickets</b></h2>
        <div style="margin-left: 40%; margin-top: 30px">
            <h3 style="text-align: center"><b>Buy Tickets</b></h3>
            <img style="width: 300px" src="images/visa-mastercard-discover-logo.jpg" /><br />
            <br />
            <b>Name on Card</b>
            <input runat="server" type="text" id="txtName" /><br />
            <br />
            <b>Card Number </b>
            <input runat="server" type="text" id="Text1" /><br />
            <br />
            <b>Expiry Date</b>
            <input runat="server" type="text" id="Text2" /><br />
            <br />
            <b>Security Code </b>
            <input runat="server" type="text" id="Text3" /><br />
            <br />
            <button style="width: 150px" type="button" id="btnPay" class="btn btn-info" onclick="showMessage()">Pay </button>
        </div>
    </div>
</asp:Content>
