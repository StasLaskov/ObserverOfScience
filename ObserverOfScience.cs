using System;
using DotNetNuke.Data;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;

namespace ObserverOfScience
{
	// More attributes for class:
	// Set caching for table: [Cacheable("ObserverOfScience_ObserverOfSciences", CacheItemPriority.Default, 20)] 
	// Explicit mapping declaration: [DeclareColumns]
	
	// More attributes for class properties:
	// Custom column name: [ColumnName("ObserverOfScienceID")]
	// Explicit include column: [IncludeColumn]
	// Note: DAL 2 have no AutoJoin analogs from PetaPOCO at this time
	
	[TableName("ObserverOfScience_ObserverOfSciences")]
	[PrimaryKey("ObserverOfScienceID", AutoIncrement = true)]
	[Scope("ModuleID")]
	public class ObserverOfScienceInfo
	{
        #region Fields
        
		private string createdByUserName = null;
		#endregion
		
		/// <summary>
		/// Empty default cstor
		/// </summary>
		public ObserverOfScienceInfo ()
		{
		}
        #region Properties

		public int ObserverOfScienceID { get; set; }

		public int ModuleID { get; set; }

		public string Content { get; set; }

		public int CreatedByUser { get; set; }

		[ReadOnlyColumn]
		public DateTime CreatedOnDate { get; set; }

		[IgnoreColumn] 
		public string CreatedByUserName
		{
			get
			{
				if (createdByUserName == null)
				{
					var portalId = PortalController.GetCurrentPortalSettings ().PortalId;
					var user = UserController.GetUserById (portalId, CreatedByUser);
					createdByUserName = user.DisplayName;
				}

				return createdByUserName; 
			}
		}
        #endregion
	}
}

