using System;
using System.Web.UI.WebControls;

using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.UI.UserControls;
using DotNetNuke.Entities.Content.Taxonomy;
using System.Collections.Generic;


namespace ObserverOfScience
{	
	public partial class SettingsObserverOfScience : ModuleSettingsBase
	{
		/// <summary>
		/// Handles the loading of the module setting for this control
		/// </summary>
		public override void LoadSettings ()
		{
			try
			{
				if (!IsPostBack)
				{

					Localize ();	
					var settings = new ObserverOfScienceSettings (this.ModuleId, this.TabModuleId);
					// var tc = new TermController();
					termsSelector.PortalId = PortalId;
					termsSelector.Terms = new List<Term>(); // ни один из термов не выбран
					termsSelector.DataBind();

					if (!string.IsNullOrWhiteSpace (settings.Template))
					{
						txtCountInvention.Text = settings.CountInvention.ToString();
						txtLenghtText.Text = settings.LenghtText.ToString();
					}



				}
			}
			catch (Exception ex)
			{
				Exceptions.ProcessModuleLoadException (this, ex);
			}
		}
       
		/// <summary>
		/// Localizes native ASP.NET controls. 
		/// DotNetNuke controls have localization of their own.  
		/// </summary>
		private void Localize ()
		{
			// someControl.Value = Localization.GetString ("SomeControl.Text", LocalResourceFile);
		}

		/// <summary>
		/// handles updating the module settings for this control
		/// </summary>
		public override void UpdateSettings ()
		{
			try
			{
				var settings = new ObserverOfScienceSettings (this.ModuleId, this.TabModuleId);
				settings.LenghtText =int.Parse( txtLenghtText.Text);
				settings.CountInvention = int.Parse(txtCountInvention.Text);
			}
			catch (Exception ex)
			{
				Exceptions.ProcessModuleLoadException (this, ex);
			}
		}
	}
}

