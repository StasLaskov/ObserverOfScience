using System;

using DotNetNuke.Data;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace ObserverOfScience
{
	// More attributes for class:
	// Set caching for table: [Cacheable("ObserverOfScience_PatentInfos", CacheItemPriority.Default, 20)] 
	// Explicit mapping declaration: [DeclareColumns]
	
	// More attributes for class properties:
	// Custom column name: [ColumnName("PatentInfoID")]
	// Explicit include column: [IncludeColumn]
	// Note: DAL 2 have no AutoJoin analogs from PetaPOCO at this time
	[TableName("Science_Patent")]
	[PrimaryKey("PatentId", AutoIncrement = true)]
	//[Scope("ModuleID")]
	public class PatentInfo
	{
        #region Fields
        

		#endregion
		
		/// <summary>
		/// Empty default cstor
		/// </summary>
		public PatentInfo ()
		{
		}

        #region Properties

		public int PatentId { get; set; }

		public int UrlId { get; set; }

		public int FileId { get; set; }

		public int NumberPatent { get; set; }

		public DateTime	DatePatent { get; set; }

		public int	InventionId { get; set; }

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
	
		//public int InventionID { get; set; }

//		private InventionInfo patents;
//		
//		[IgnoreColumn]
//		public InventionInfo Patents 
//		{
//			get 
//			{
//				if (patents == null)
//				{
//					var ctrl = new ObserverOfScienceController();
//					patents = ctrl.Get<InventionInfo>(InventionId);
//				}
//				return patents;	
//			}
//			set 
//			{
//				patents = value;
//			}
//		}      
	
	
	}
}

