<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingsObserverOfScience.ascx.cs" Inherits="ObserverOfScience.SettingsObserverOfScience" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.UI.WebControls" Assembly="DotNetNuke.Web" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>


<table cellspacing="0" cellpadding="0" border="0">
	<tr>	
		<td class="SubHead" width="200" valign="top">
			<dnn:Label ID="lblLenghtText" runat="server" ControlName="txtLenghtText" Suffix=":"></dnn:Label>
		</td>
    	<td valign="top">
        	<asp:TextBox ID="txtLenghtText" runat="server" CssClass="NormalTextBox" Width="390" Rows="10" Columns="30" TextMode="MultiLine" MaxLength="2000" />
    	</td>
	</tr>
	<tr>	
		<td class="SubHead" width="200" valign="top">
			<dnn:Label ID="lblCountInvention" runat="server" ControlName="txtCountInvention" Suffix=":"></dnn:Label>
		</td>
    	<td valign="top">
        	<asp:TextBox ID="txtCountInvention" runat="server" CssClass="NormalTextBox" Width="390" Rows="10" Columns="30" TextMode="MultiLine" MaxLength="2000" />
    	</td>
	</tr>
	<tr>	
		<td class="SubHead" width="200" valign="top">
			<dnn:Label ID="lbltermsSelector" runat="server" ControlName="termsSelector" Suffix=":"></dnn:Label>
		</td>
    	<td valign="top">
        	<dnn:TermsSelector id="termsSelector" AutoPostBack="true" runat="server" Height="450" Width="300"/>
    	</td>
	</tr>
</table>