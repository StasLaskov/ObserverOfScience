<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditObserverOfScience.ascx.cs" Inherits="ObserverOfScience.EditObserverOfScience" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="~/controls/TextEditor.ascx"%>
<%@ Register TagPrefix="dnn" TagName="Audit" Src="~/controls/ModuleAuditControl.ascx" %>

<table width="100%" cellspacing="0" cellpadding="0" border="0">

<tr valign="top">
		<td class="SubHead" width="33%">
			<dnn:Label ID="lblTitle" runat="server" ControlName="lblTitle" Suffix=":"></dnn:Label>
		</td>
		<td valign="top">
			<asp:TextBox ID="txtTitle" runat="server"  Width="80%"/>
			<asp:RequiredFieldValidator ID="valTitle" runat="server" resourcekey="valTitle.ErrorMessage" ControlToValidate="txtTitle"
				CssClass="NormalRed" Display="Dynamic" ErrorMessage="<br />Title is required" />
		</td>
	</tr>
<td class="SubHead" width="33%">
			<dnn:Label ID="lblStatus" runat="server" ControlName="lblStatus" Suffix=":"></dnn:Label>
		</td>
		<td valign="top">
			<asp:TextBox ID="txtStatus" runat="server" />



		</td>
	</tr>
	
<tr valign="top">

		<td class="SubHead" width="33%">
			<dnn:Label ID="lblYearOfCreation" runat="server" ControlName="lblYearOfCreation" Suffix=":"></dnn:Label>
		</td>
		<td valign="top">
			<asp:TextBox ID="txtYearOfCreation" runat="server" />
		</td>
	
</tr>

<tr valign="top">
		<td class="SubHead" width="33%">
			<dnn:Label ID="lblDescription" runat="server" ControlName="lblDescription" Suffix=":"></dnn:Label>
		</td>
		<td valign="top">
			<dnn:TextEditor ID="txtDescription" runat="server" Height="200" Width="95%" />
		</td>
	</tr>
<tr valign="top">
		<td class="SubHead" width="33%">
			<dnn:Label ID="lblInventionEssence" runat="server" ControlName="lblInventionEssence" Suffix=":"></dnn:Label>
		</td>
		<td valign="top">
			<dnn:TextEditor ID="txtInventionEssence" runat="server" Height="200" Width="95%" />
		</td>
	</tr>	
<tr valign="top">
		<td class="SubHead" width="33%">
			<dnn:Label ID="lblAdvantages" runat="server" ControlName="lblAdvantages" Suffix=":"></dnn:Label>
		</td>
		<td valign="top">
			<dnn:TextEditor ID="txtAdvantages" runat="server" Height="200" Width="95%" />
		</td>
	</tr>	
	
	
</table>
<p>
    <asp:LinkButton ID="cmdUpdate" runat="server" CssClass="CommandButton" ResourceKey="cmdUpdate" BorderStyle="none" Text="Update" OnClick="cmdUpdate_Click"></asp:LinkButton>&#160;
    <asp:LinkButton ID="cmdCancel" runat="server" CssClass="CommandButton" ResourceKey="cmdCancel" BorderStyle="none" Text="Cancel" CausesValidation="False" OnClick="cmdCancel_Click"></asp:LinkButton>&#160;
    <asp:LinkButton ID="cmdDelete" runat="server" CssClass="CommandButton" ResourceKey="cmdDelete" BorderStyle="none" Text="Delete" CausesValidation="False" OnClick="cmdDelete_Click"></asp:LinkButton>
</p>
<dnn:Audit id="ctlAudit" runat="server" />

