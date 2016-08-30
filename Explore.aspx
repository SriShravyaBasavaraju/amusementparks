<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Explore.aspx.cs" Inherits="AmusementParks.Explore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:DropDownList ID="statesDropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="statesDropDown_SelectedIndexChanged"></asp:DropDownList>
        <asp:DropDownList ID="parksDropDown" AutoPostBack="true" runat="server"></asp:DropDownList>
        <asp:Button ID="btnDirections" runat="server" OnClick="btnDirections_Click" Text="Get Directions" />
    </div>
    <iframe id="gmap" runat="server" src="https://www.google.com/maps/embed?pb=!1m10!1m8!1m3!1d13060.944511967657!2d-106.63503649999998!3d35.07583245000001!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sen!2sus!4v1470126722922"
        width="800" height="600" frameborder="0" style="border: 0" allowfullscreen></iframe>
</asp:Content>
