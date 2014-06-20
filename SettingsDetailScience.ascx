<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingsDetailScience.ascx.cs" Inherits="ObserverOfScience.SettingsDetailScience" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>

<table cellspacing="0" cellpadding="0" border="0">
	<tr>	
		<td class="SubHead" width="200" valign="top">
			<dnn:Label ID="lblTemplate" runat="server" ControlName="txtTemplate" Suffix=":"></dnn:Label>
		</td>
    	<td valign="top">
        	<asp:TextBox ID="txtTemplate" runat="server" CssClass="NormalTextBox" Width="390" Rows="10" Columns="30" TextMode="MultiLine" MaxLength="2000" />
    	</td>
	</tr>
</table>

