using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.IO;

using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Content.Taxonomy;
using DotNetNuke.Entities.Content.Data;
using DotNetNuke.Modules;
using ObserverOfScience;



namespace ObserverOfScience
{



	public partial class ViewObserverOfScience : PortalModuleBase, IActionable
	{

    	#region Handlers 
		public static string linkinvention=null;
		public static int n;
		protected void Page_Load (object sender, EventArgs e)
		{	
		

			try
			{
				if (!IsPostBack)
				{


					var settings = new ObserverOfScienceSettings(ModuleId, TabModuleId);


					var ctrl = new ObserverOfScienceController ();
					var items = ctrl.GetList<ObserverOfScienceInfo>();

//					List<ObserverOfScienceInfo> new_items =new List<ObserverOfScienceInfo>(); 
					 n = settings.LenghtText;
//					for(int i=0; i < Math.Min(n,items.Count); i++)
//						new_items.Add (items[i]);
//					
//					items = new_items;

					// bind the data
					lstObserverOfScience.DataSource = items;
					lstObserverOfScience.DataBind ()
						//привязать данные из таблици inventioninfo к таблице observer of sciensinfo
						//поменять Invention на ObserverOfScienceInfo
						//править айтем дата баленд менять связи
						;
				}
			}
			catch (Exception ex)
			{
				Exceptions.ProcessModuleLoadException (this, ex);
			}
		}
		
		#endregion		
		
		#region IActionable implementation
		
		public DotNetNuke.Entities.Modules.Actions.ModuleActionCollection ModuleActions
		{
			get
			{
				// create a new action to add an item, this will be added 
				// to the controls dropdown menu
				var actions = new ModuleActionCollection ();
				actions.Add (
					GetNextActionID (), 
					Localization.GetString (ModuleActionType.AddContent, this.LocalResourceFile),
					ModuleActionType.AddContent, 
					"", 
					"", 
					EditUrl (), 
					false, 
					DotNetNuke.Security.SecurityAccessLevel.Edit,
					true, 
					false
					);
				
				return actions;
			}
		}
		
#endregion

		/// <summary>
		/// Handles the items being bound to the datalist control. In this method we merge the data with the
		/// template defined for this control to produce the result to display to the user
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void lstContent_ItemDataBound (object sender, System.Web.UI.WebControls.DataListItemEventArgs e)
		{
			// use e.Item.DataItem as object of ObserverOfScienceInfo class,
			// as we really know it is:
			var item1 = e.Item.DataItem as ObserverOfScienceInfo;
			var ctrl = new ObserverOfScienceController ();

			var item = ctrl.Get<InventionInfo> (item1.InventionId);

			var HyperName = e.Item.FindControl ("HyperName") as HyperLink;
			var lblContent = e.Item.FindControl ("lblContent") as Label;
		//в таблице нет  поля статусvar lblStatus = e.Item.FindControl ("lblStatus") as Label;
		//	var lblScientists = e.Item.FindControl ("lblScientists") as Label;
			var ImgObserverOfScience = e.Item.FindControl ("ImgObserverOfScience") as Image;
			//var CreateByUser = e.Item.ForeControl ("CreateByUser") as Label;
			var contentValue = string.Empty;

			var edit = e.Item.FindControl ("HyperLink1") as HyperLink;
			edit.NavigateUrl = EditUrl ("InventionID", item.InventionID.ToString ());

			if (item.Image != null)
			{
				ImgObserverOfScience.ImageUrl = item.Image;
			}
			else
			{
				ImgObserverOfScience.ImageUrl="~/DesktopModules/ObserverOfScience/images/irrigation.jpg";
			}



			HyperName.NavigateUrl=EditUrl("ObserverOfScienceID",item.InventionID.ToString(),"DetailView");
			linkinvention=HyperName.NavigateUrl;
			contentValue = Server.HtmlDecode (item.Description);
			HyperName.Text = contentValue;

		//	contentValue = Server.HtmlDecode (LenghtText(item.Content));
		//	lblContent.Text = contentValue;
					
			contentValue = Server.HtmlDecode (item.Name);
			//lblStatus.Text =string.Format(Localization.GetString("lblTitle.Format", LocalResourceFile), contentValue);
			contentValue=null;
		//	foreach(ScientistInfo ind in item.Scientists)
			//	{
			//		contentValue+=ind.User.LastName+" "+ind.User.FirstName+";";
			//	}
		//	lblScientists.Text=string.Format(Localization.GetString("lblScientists.Format", LocalResourceFile),contentValue);
		

		}

		public static string LenghtText (string s)
		{

			string link = "<a class=\"Normal\" href="+linkinvention+">...</a><br>";
			if (s.Length > n)
			{
				s= s.Remove (n);
				s = s + link;
			}

			return s;

		}
	


	}


}

