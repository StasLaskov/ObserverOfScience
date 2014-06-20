using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Content.Data;
using DotNetNuke.Modules;
using ObserverOfScience;

namespace ObserverOfScience
{
	public partial class ViewDetailScience : PortalModuleBase, IActionable
	{
		private int? itemId = null; 
    	#region Handlers 
		private int patent=0;
		/// <summary>
		/// Handles Page_Load event for a control
		/// </summary>
		/// <param name='sender'>
		/// Sender.
		/// </param>
		/// <param name='e'>
		/// Event args.
		/// </param>
protected void Page_Load (object sender, EventArgs e)
{

	try
	{
		int tmpItemId;
		if (int.TryParse (Request.QueryString ["InventionID"], out tmpItemId))
			itemId = tmpItemId;
		if (!IsPostBack)
		{
			if (itemId.HasValue)
			{
				// load the item
				var ctrl = new ObserverOfScienceController ();
				var item = ctrl.Get<InventionInfo> (itemId.Value);
				var contentValue=string.Empty;
				if (item != null)
				{
					lblDetailInventionEssence.Text=item.Description +"<p>" + item.InventionEssence;
					lblDetailName.Text=item.Name;
					
				//	lblDetailStatus.Text=string.Format(Localization.GetString("lblDetailStatus.Format", LocalResourceFile),item.Status);
					lblDetailStatus.Text=item.Status;
					lblAdvantages.Text=item.Advantages;
					
					if(item.YearOfCreation.Year!=1)
					{
						lblYearOfCreation.Text="<b>Год разработки:</b>"+ item.YearOfCreation.Year.ToString()+"г.";
					}
					foreach(ScientistInfo ind in item.Scientists)
						{
							contentValue+=ind.User.LastName+" "+ind.User.FirstName+";"+"<br>";
						}
							lblDetailScientist.Text=contentValue;
					//lblDetailScientist.Text=string.Format(Localization.GetString("lblDetailScientist.Format", LocalResourceFile),contentValue);

					#region Патент

					RepeaterPatent.DataSource=item.Patents;
					RepeaterPatent.DataBind();
					if(patent==0)
					{
						lblPatent.Text="Патенты отсутсвуют";	
					}
					#endregion

					#region Термы
					RepeaterTerms.DataSource=item.Terms;
					RepeaterTerms.DataBind();
					#endregion
					
					#region Ресурсы
					RepeaterResources.DataSource=item.InventionResources;
					RepeaterResources.DataBind();
					if(patent!=2)
						{
							lblResources.Text="У данной разработки материалы отсутствуют";	
						}
					#endregion
					
					#region Внедрения
					if(item.Introductions.Count>0)
						{
							foreach(IntroductionInfo introduction in item.Introductions)
							{
								lblIntroduction.Text="<b>Была внедренна:</b><br/>";
								HyperIntroduction.Text="<i>"+introduction.Vendor.VendorName+"</i>";
								YearIntroduction.Text=" В "+introduction.YearIntroduction.Date.Year+ "г.";
							}
						}
					else
						{
							
								lblIntroduction.Text="Разработка ещё не внедрялась";
						}


					#endregion

				}
				else
					Response.Redirect (Globals.NavigateURL (), true);
			}

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

		protected void Rpt_Patent (object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{

			var item2=e.Item;

			var HyperPatent= item2.FindControl("HyperPatent") as HyperLink;
			var lblDate= item2.FindControl("lblDatePatent") as Label;
			lblDate.Text=string.Empty;
			var ctrl = new ObserverOfScienceController ();
			var item = e.Item.DataItem as PatentInfo;
			HyperPatent.Text+="№ патента:"+item.NumberPatent.ToString();
				
			if(item.DatePatent.Year!=1)
				{

					lblDate.Text=" Дата выдачи патента:"+item.DatePatent.Day.ToString()+":"+item.DatePatent.Month.ToString()+":"+item.DatePatent.Year.ToString()+"г. <br>";
				}
			else
				{
					HyperPatent.Text=HyperPatent.Text+"<br>";
				}
			patent=1;

		}

		protected void Rpt_Terms (object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			var item2 = e.Item;

			var HyperTerms = item2.FindControl ("HyperTerms") as HyperLink;
			var VocabularyName = item2.FindControl ("VocabularyName") as Label;
			
			var ctrl = new ObserverOfScienceController ();
			var item = e.Item.DataItem as InvTermsInfo;

			switch (item.Term.Vocabulary.Name)
			{
				case "GroupOfDevelopment":
					VocabularyName.Text=item.Term.Vocabulary.Description+":<br/>";
					HyperTerms.Text=item.Term.Name+";";
					HyperTerms.NavigateUrl=EditUrl("TermID",item.TermId.ToString(),"TermInventionView");
				break;
				
				case "IndustryInProduction":
					VocabularyName.Text=item.Term.Vocabulary.Description+":<br/>";
					HyperTerms.Text=item.Term.Name+";";
					HyperTerms.NavigateUrl=EditUrl("TermID",item.TermId.ToString(),"TermInventionView");
				break;
				
				case "IndustryInScience":
					VocabularyName.Text=item.Term.Vocabulary.Description+":<br/>";
					HyperTerms.Text=item.Term.Name+";";
					HyperTerms.NavigateUrl=EditUrl("TermID",item.TermId.ToString(),"TermInventionView");
				break;

			}

		}	
		protected void Rpt_Resource (object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			var item2 = e.Item;
			
			var HyperResource = item2.FindControl ("HyperResource") as HyperLink;
			var ImgResource = item2.FindControl ("ImgResource") as Image;
			
			var ctrl = new ObserverOfScienceController ();
			var item = e.Item.DataItem as InventionResourceInfo;
			
			switch (item.File.Extension)
			{
				case "doc":
					ImgResource.ImageUrl="~/DesktopModules/ObserverOfScience/images/Extension/word.png";
					HyperResource.Text=item.File.FileName;
					HyperResource.NavigateUrl=item.File.FileName;
				break;
				case "docx":
					ImgResource.ImageUrl="~/DesktopModules/ObserverOfScience/images/Extension/word.png";
					HyperResource.Text=item.File.FileName;
					HyperResource.NavigateUrl=Globals.LinkClick(item.File.PhysicalPath,this.TabId,this.ModuleId);
					break;
				case "pdf":
					ImgResource.ImageUrl="~/DesktopModules/ObserverOfScience/images/Extension/pdf.png";
					HyperResource.Text=item.File.FileName;
					HyperResource.NavigateUrl=Globals.LinkClick(item.File.RelativePath,this.TabId,this.ModuleId);
					break;
				case "rtf":
					ImgResource.ImageUrl="~/DesktopModules/ObserverOfScience/images/Extension/word.png";
					HyperResource.Text=item.File.FileName;
					HyperResource.NavigateUrl=Globals.LinkClick(item.File.PhysicalPath,this.TabId,this.ModuleId);
					break;

				case "jpg":
					ImgResource.ImageUrl="~/DesktopModules/ObserverOfScience/images/Extension/img.png";
					HyperResource.Text=item.File.FileName;
					HyperResource.NavigateUrl=Globals.LinkClick(item.File.PhysicalPath,this.TabId,this.ModuleId);
					break;
				case "bmp":
					ImgResource.ImageUrl="~/DesktopModules/ObserverOfScience/images/Extension/img.png";
					HyperResource.Text=item.File.FileName;
					HyperResource.NavigateUrl=Globals.LinkClick(item.File.PhysicalPath,this.TabId,this.ModuleId);
					break;
				case "png":
					ImgResource.ImageUrl="~/DesktopModules/ObserverOfScience/images/Extension/img.png";
					HyperResource.Text=item.File.FileName;
					HyperResource.NavigateUrl=Globals.LinkClick(item.File.PhysicalPath,this.TabId,this.ModuleId);
					break;
				case "gif":
					ImgResource.ImageUrl="~/DesktopModules/ObserverOfScience/images/Extension/img.png";
					HyperResource.Text=item.File.FileName;
					HyperResource.NavigateUrl=Globals.LinkClick(item.File.PhysicalPath,this.TabId,this.ModuleId);
					break;
				
				case "xls":
					ImgResource.ImageUrl="~/DesktopModules/ObserverOfScience/images/Extension/excel.png";
					HyperResource.Text=item.File.FileName;
					HyperResource.NavigateUrl=Globals.LinkClick(item.File.PhysicalPath,this.TabId,this.ModuleId);
					break;
				case "xlsx":
					ImgResource.ImageUrl="~/DesktopModules/ObserverOfScience/images/Extension/excel.png";
					HyperResource.Text=item.File.FileName;
					HyperResource.NavigateUrl=Globals.LinkClick(item.File.PhysicalPath,this.TabId,this.ModuleId);
					break;
				case "avi":
					ImgResource.ImageUrl="~/DesktopModules/ObserverOfScience/images/Extension/video.png";
					HyperResource.Text=item.File.FileName;
					HyperResource.NavigateUrl=Globals.LinkClick(item.File.PhysicalPath,this.TabId,this.ModuleId);
					break;
				case "wmv":
					ImgResource.ImageUrl="~/DesktopModules/ObserverOfScience/images/Extension/video.png";
					HyperResource.Text=item.File.FileName;
					HyperResource.NavigateUrl=Globals.LinkClick(item.File.PhysicalPath,this.TabId,this.ModuleId);
					break;
				case "mpeg":
					ImgResource.ImageUrl="~/DesktopModules/ObserverOfScience/images/Extension/video.png";
					HyperResource.Text=item.File.FileName;
					HyperResource.NavigateUrl=Globals.LinkClick(item.File.PhysicalPath,this.TabId,this.ModuleId);
					break;
				case "rar":
					ImgResource.ImageUrl="~/DesktopModules/ObserverOfScience/images/Extension/rar.png";
					HyperResource.Text=item.File.FileName;
					HyperResource.NavigateUrl=Globals.LinkClick(item.File.PhysicalPath,this.TabId,this.ModuleId);
					break;
				case "zip":
					ImgResource.ImageUrl="~/DesktopModules/ObserverOfScience/images/Extension/rar.png";
					HyperResource.Text=item.File.FileName;
					HyperResource.NavigateUrl=Globals.LinkClick(item.File.PhysicalPath,this.TabId,this.ModuleId);
					break;
				case "ppt":
					ImgResource.ImageUrl="~/DesktopModules/ObserverOfScience/images/Extension/ppt.png";
					HyperResource.Text=item.File.FileName;
					HyperResource.NavigateUrl=Globals.LinkClick(item.File.PhysicalPath,this.TabId,this.ModuleId);
					break;
				case "pptm":
					ImgResource.ImageUrl="~/DesktopModules/ObserverOfScience/images/Extension/ppt.png";
					HyperResource.Text=item.File.FileName;
					HyperResource.NavigateUrl=Globals.LinkClick(item.File.PhysicalPath,this.TabId,this.ModuleId);
					break;
				
				default:
					HyperResource.Text=item.File.FileName;
					HyperResource.NavigateUrl= Globals.LinkClick(item.File.PhysicalPath,this.TabId,this.ModuleId);
				break;

			}
			patent=2;
			
		}	


		/// <summary>
		/// Handles the items being bound to the datalist control. In this method we merge the data with the
		/// template defined for this control to produce the result to display to the user
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
	}
}


