using System;
using System.Collections.Generic;

using DotNetNuke.Data;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.Services.Vendors;
using DotNetNuke.Collections;
using DotNetNuke.Entities.Modules;

using DotNetNuke.Common.Utilities;

using System.Collections;


namespace ObserverOfScience
{
	// More attributes for class:
	// Set caching for table: [Cacheable("ObserverOfScience_IntroductionInfos", CacheItemPriority.Default, 20)] 
	// Explicit mapping declaration: [DeclareColumns]
	
	// More attributes for class properties:
	// Custom column name: [ColumnName("IntroductionInfoID")]
	// Explicit include column: [IncludeColumn]
	// Note: DAL 2 have no AutoJoin analogs from PetaPOCO at this time
	[TableName("Science_Introduction")]
	[PrimaryKey("IntroductionId", AutoIncrement = true)]
	//[Scope("ModuleID")]
	public class IntroductionInfo
	{
        #region Fields
        

		#endregion
		
		/// <summary>
		/// Empty default cstor
		/// </summary>
		public IntroductionInfo ()
		{
		}

        #region Properties

		public int IntroductionId { get; set; }

		public DateTime YearIntroduction { get; set; }

		public int VendorId { get; set; }

		public int InventionId { get; set; }

//		[ReadOnlyColumn]
//		public DateTime CreatedOnDate { get; set; }
//        
//		[IgnoreColumn] 
//		public string CreatedByUserName
//		{
//			get
//			{
//				if (createdByUserName == null)
//				{
//					var portalId = PortalController.GetCurrentPortalSettings ().PortalId;
//					var user = UserController.GetUserById (portalId, CreatedByUser);
//					createdByUserName = user.DisplayName;
//				}
//
//				return createdByUserName; 
//			}
//		}

        #endregion
		private VendorInfo vendor=null;

		[IgnoreColumn]
		public VendorInfo Vendor
		{

			get
			{

				if (vendor == null&&IntroductionId!=null)
				{

					var ctrl= new VendorController();
					vendor =ctrl.GetVendor(VendorId,0);
					
				}
				return vendor; 
			}
			set
			{
				vendor=value;
			}
		}

	}
}

