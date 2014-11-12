<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SPCacheOperationsWebpartUserControl.ascx.cs" Inherits="SharePointCaching.Webparts.SPCacheOperationsWebpart.SPCacheOperationsWebpartUserControl" %>

<h2>SPCache Operations</h2>
<table style="padding-left: 10px;">
    <tr>
        <td colspan="2">
            <h3>Adding Items To Cache</h3>
        </td>
    </tr>
    <tr>
        <td style="width: 300px;">
            Item Name  : <br/>
            <asp:TextBox runat="server" ID="ItemNameTextBox"></asp:TextBox><br/>
            Item Value : <br/>
            <asp:TextBox runat="server" ID="ItemValueTextBox"></asp:TextBox><br/>
            <br/>
            <asp:Button runat="server" ID="AddItemButton" Text="Add Item" OnClick="AddItemButton_OnClick"/>
        </td>
        <td>
            <asp:TextBox runat="server" ID="AddItemsOutputTextBox" Rows="10" TextMode="MultiLine" Width="500"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td colspan="2">
            <h3>Reading Items From Cache</h3>
        </td>
    </tr>
    <tr>
        <td>
            Item Name  : <br/>
            <asp:TextBox runat="server" ID="ItemNameToGetTextBox"></asp:TextBox><br/>
            <br/>
            <asp:Button runat="server" ID="ReadItemButton" Text="Get Item" OnClick="ReadItemButton_OnClick"/>
        </td>
        <td>
            <asp:TextBox runat="server" ID="ReadItemsOutputTextBox" Rows="10" TextMode="MultiLine" Width="500"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td colspan="2">
            <h3>Deleting Items from Cache</h3>
        </td>
    </tr>
    <tr>
        <td>
            Item Name  : <br/>
            <asp:TextBox runat="server" ID="ItemNameToDeleteTextBox"></asp:TextBox><br/>
            <br/>
            <asp:Button runat="server" ID="DeleteItemButton" Text="Delete Item" OnClick="DeleteItemButton_OnClick"/>
        </td>
        <td>
            <asp:TextBox runat="server" ID="DeleteItemsOutputTextBox" Rows="10" TextMode="MultiLine" Width="500"></asp:TextBox>
        </td>
    </tr>
    
    <tr>
        <td colspan="2">
            <h3>Cache Other Operations</h3>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button runat="server" ID="CacheExistsButton" Text="Check Cache Status" OnClick="CacheExistsButton_OnClick"/><br/>
        </td>
        <td>
            <asp:TextBox runat="server" ID="OtherOperationsTextBox" Rows="10" TextMode="MultiLine" Width="500"></asp:TextBox>
        </td>
    </tr>
</table>