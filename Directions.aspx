<%@ Page Language="C#" Title="Amusement Zone: Explore" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Directions.aspx.cs" Inherits="AmusementParks.Directions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="parksContent" runat="server">
        <table>
            <tr>
                <td>
                    <asp:DropDownList ID="statesDropDown" runat="server"></asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Find Attractions" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
        <div id="content1" runat="server" style="height: 270px; width: 98%; margin-left: 12px; margin-top: 10px; border: 1px #A9A9A9 solid;">
            <%--<%=GenerateParksContent() %>--%>
            <asp:Repeater runat="server" ID="parkContent">
                <ItemTemplate>
                    <div style="height: 270px; width: 98%; margin-left: 12px; margin-top: 10px; border: 1px #A9A9A9 solid;">
                        <table style="text-align: center">
                            <tr>
                                <td>
                                    <img style="margin: 15px" class="boxImage" src="<%#DataBinder.Eval(Container.DataItem, "AttractionImage") %>" /></td>
                                <td>
                                    <h3><b><%#DataBinder.Eval(Container.DataItem, "ParkName") %></b> </h3>
                                    <p><%#DataBinder.Eval(Container.DataItem, "AttractionName") %> </p>
                                    <p><%#DataBinder.Eval(Container.DataItem, "ParkTimings") %> </p>
                                    <br />
                                    <br />
                                    <button id="btnTckts" style="width: 150px" type="button" class="btn btn-info" onclick="btnTckts_Click">Buy Tickets</button>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
