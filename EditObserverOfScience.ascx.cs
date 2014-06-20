using System;
using System.Web.UI.WebControls;

using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.UI.UserControls;

namespace ObserverOfScience
{
	public partial class EditObserverOfScience : PortalModuleBase
	{


		// ALT: private int itemId = Null.NullInteger;
		private int? itemId = null; 
		
		#region Handlers

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
				// parse querystring parameters
				int tmpItemId;
				if (int.TryParse (Request.QueryString ["InventionID"], out tmpItemId))
					itemId = tmpItemId;
      
				if (!IsPostBack)
				{
					// load the data into the control the first time we hit this page

					cmdDelete.Attributes.Add ("onClick", "javascript:return confirm('" + Localization.GetString ("DeleteItem") + "');");

					// check we have an item to lookup
					// ALT: if (!Null.IsNull (itemId) 
					if (itemId.HasValue)
					{
						// load the item
						var ctrl = new ObserverOfScienceController ();
						var item = ctrl.Get<InventionInfo> (itemId.Value, this.ModuleId);

						if (item != null)
						{
							//TODO: Fill controls with data
							txtTitle.Text=item.Name;
						//	txtListOfDevelopment.Text=item.ListOfDevelopment;
							//txtDevelopment.Text=item.Development;
							txtDescription.Text = item.Description;
						//	txtYearOfDevelopment.Text = item.YearOfDevelopment.ToString();
							//setup audit control;
							//ctlAudit.CreatedByUser = item.CreatedByUserName;
						//	ctlAudit.CreatedDate = item.CreatedOnDate.ToLongDateString ();

						}
						else
							Response.Redirect (Globals.NavigateURL (), true);
					}
					else
					{
						cmdDelete.Visible = false;
						ctlAudit.Visible = false;
					}
				}
			}
			catch (Exception ex)
			{
				Exceptions.ProcessModuleLoadException (this, ex);
			}
		}

		/// <summary>
		/// Handles Click event for cmdUpdate button
		/// </summary>
		/// <param name='sender'>
		/// Sender.
		/// </param>
		/// <param name='e'>
		/// Event args.
		/// </param>
		protected void cmdUpdate_Click (object sender, EventArgs e)
		{
			try
			{
				var ctrl = new ObserverOfScienceController ();
				ObserverOfScienceInfo item;
				InventionInfo inv;


				// determine if we are adding or updating
				// ALT: if (Null.IsNull (itemId))
				if (!itemId.HasValue)
				{
					// TODO: populate new object properties with data from controls 
					// to add new record
					//Описание разработки
					inv = new InventionInfo();
					inv.Description = txtDescription.Text;
					inv.Status = txtStatus.Text;
					inv.YearOfCreation = DateTime.Today;// временно
					inv.Advantages = txtAdvantages.Text;	
					inv.InventionEssence = txtInventionEssence.Text;

					inv.Name = txtTitle.Text;
					ctrl.Add<InventionInfo>(inv);


					item = new ObserverOfScienceInfo ();
					item.ModuleID = ModuleId;
					item.CreatedByUser = this.UserId;					
					item.InventionId = inv.InventionID;
					ctrl.Add<ObserverOfScienceInfo> (item);

			
					//inv.Name = txtTitle.Text;
					//ctrl.Add<InventionInfo>(inv);

					//Суть разработки


					//inv.Name = txtTitle.Text;
					//ctrAdd<InventionInfo>(inv);

				}
				else
				{

					inv = ctrl.Get<InventionInfo> (itemId.Value);
					inv.Description = txtDescription.Text;
					inv.Advantages = txtAdvantages.Text;
					inv.InventionEssence = txtInventionEssence.Text;
					inv.Name = txtTitle.Text;
					ctrl.Update<InventionInfo>(inv);


					/*
					inv = ctrl.Get<InventionInfo> (itemId.Value);
					inv.Advantages = txtTitle.Text;
					ctrl.Update<InventionInfo>(inv);
					inv = ctrl.Get<InventionInfo> (itemId.Value);
					inv.Name = txtTitle.Text;
					ctrl.Update<InventionInfo>(inv);
*/

					//по аналогии с выше написанным + править поля в таблицах инвеншанинфо и удалить поля из оbserver of sience кроме invenrionid и modulId
					// TODO: update properties of existing object with data from controls 
					// to update existing record
					//item = ctrl.Get<ObserverOfScienceInfo> (itemId.Value, this.ModuleId);
					//item.Content = txtDescription.Text;
					//ctrl.Update<ObserverOfScienceInfo> (item);
				}

				Response.Redirect (Globals.NavigateURL (), true);
			}
			catch (Exception ex)
			{
				Exceptions.ProcessModuleLoadException (this, ex);
			}
		}

		/// <summary>
		/// Handles Click event for cmdCancel button
		/// </summary>
		/// <param name='sender'>
		/// Sender.
		/// </param>
		/// <param name='e'>
		/// Event args.
		/// </param>
		protected void cmdCancel_Click (object sender, EventArgs e)
		{
			try
			{
				Response.Redirect (Globals.NavigateURL (), true);
			}
			catch (Exception ex)
			{
				Exceptions.ProcessModuleLoadException (this, ex);
			}
		}

		/// <summary>
		/// Handles Click event for cmdDelete button
		/// </summary>
		/// <param name='sender'>
		/// Sender.
		/// </param>
		/// <param name='e'>
		/// Event args.
		/// </param>
		protected void cmdDelete_Click (object sender, EventArgs e)
		{
			try
			{
				// ALT: if (!Null.IsNull (itemId))
				if (itemId.HasValue)
				{
					var ctrl = new ObserverOfScienceController ();
					ctrl.Delete<ObserverOfScienceInfo> (itemId.Value);
					Response.Redirect (Globals.NavigateURL (), true);
				}
			}
			catch (Exception ex)
			{
				Exceptions.ProcessModuleLoadException (this, ex);
			}
		}
		
		#endregion
	}
}

