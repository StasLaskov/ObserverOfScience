<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewObserverOfScience.ascx.cs" Inherits="ObserverOfScience.ViewObserverOfScience" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" %>
<asp:DataList ID="lstObserverOfScience"  DataKeyField="ObserverOfScienceID" runat="server" CssClass="ObserverOfScience_ContentList" OnItemDataBound="lstContent_ItemDataBound">
	<ItemTemplate>
	
		<asp:HyperLink ID="HyperLink1" runat="server" Visible="<%# IsEditable %>">
		<asp:Image ID="Image1" runat="server" ImageUrl="~/images/edit.gif" AlternateText="Edit" Visible="<%#IsEditable%>" ResourceKey="Edit" />
		</asp:HyperLink><br/>
	<div class="OneInvention">
		<div align="left"><h1 class="HyperName"><asp:HyperLink ID="HyperName" runat="server" CssClass="HyperName" ></asp:HyperLink></h1></div>
		<div align="left" ><asp:Label ID="lblStatus" runat="server"/></div><br/>
		<div align="justify" class="ObserverOfScience"><p><asp:Label ID="lblInventionEssence" runat="server" CssClass="Normal"/></p></div><br/>
		<div align="left"><asp:Label id="lblScientists" runat="server"/></div>
	</div>
	<div Class="ImgInvention">
		<asp:Image id="ImgObserverOfScience" runat="server" CssClass="ImgObserverOfScience" />
	</div>
	<hr class="Hrlist"/>
	
	</ItemTemplate>
	<ItemStyle CssClass="ObserverOfScience_ContentListItem" />
	
</asp:DataList>
										
