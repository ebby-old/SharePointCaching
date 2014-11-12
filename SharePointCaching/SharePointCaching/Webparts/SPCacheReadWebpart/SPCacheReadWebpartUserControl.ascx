<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SPCacheReadWebpartUserControl.ascx.cs" Inherits="SharePointCaching.Webparts.SPCacheReadWebpart.SPCacheReadWebpartUserControl" %>

<h2>SPCache Read</h2>
<table style="padding-left: 10px;">
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
</table>