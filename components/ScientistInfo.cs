using System;
using System.Collections.Generic;

using DotNetNuke.Data;
using DotNetNuke.Collections;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.Entities.Modules;

namespace ObserverOfScience
{
	// More attributes for class:
	// Set caching for table: [Cacheable("ObserverOfScience_ScientistInfos", CacheItemPriority.Default, 20)] 
	// Explicit mapping declaration: [DeclareColumns]
	
	// More attributes for class properties:
	// Custom column name: [ColumnName("ScientistInfoID")]
	// Explicit include column: [IncludeColumn]
	// Note: DAL 2 have no AutoJoin analogs from PetaPOCO at this time
	[TableName("Science_Scientist")]
	[PrimaryKey("ScientistId", AutoIncrement = true)]
	//[Scope("ModuleID")]
	public class ScientistInfo
	{
        #region Fields
        
	
		#endregion
		
		/// <summary>
		/// Empty default cstor
		/// </summary>
		public ScientistInfo ()
		{
		}

        #region Properties

		public int ScientistId { get; set; }

		public int UserId { get; set; }

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

		private UserInfo user=null;
		
		[IgnoreColumn]
		public UserInfo User
		{
			
			get
			{
				if (user == null)
				{
					user = UserController.GetUserById (0, UserId);

				}
				return user; 
			}
			set
			{
				user=value;
			}
		}

	}
}

