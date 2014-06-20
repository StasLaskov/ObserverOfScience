using System;
using System.Collections;
using System.IO;

using DotNetNuke.ComponentModel;
using DotNetNuke.Entities.Tabs;
using DotNetNuke.Entities.Users;
using DotNetNuke.Services.FileSystem;
using DotNetNuke.Data;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Common.Utilities;

using System.ComponentModel;
namespace ObserverOfScience
{
	// More attributes for class:
	// Set caching for table: [Cacheable("ObserverOfScience_InventionResourceInfos", CacheItemPriority.Default, 20)] 
	// Explicit mapping declaration: [DeclareColumns]

	// More attributes for class properties:
	// Custom column name: [ColumnName("InventionResourceInfoID")]
	// Explicit include column: [IncludeColumn]
	// Note: DAL 2 have no AutoJoin analogs from PetaPOCO at this time
	[TableName("Science_InventionResource")]
	[PrimaryKey("ResourceId", AutoIncrement = true)]
	//[Scope("ModuleID")]
	public class InventionResourceInfo
	{
        #region Fields
        

		#endregion
		
		/// <summary>
		/// Empty default cstor
		/// </summary>
		public InventionResourceInfo ()
		{
		}

        #region Properties
		public int ResourceId { get; set; }

		public int InventionId { get; set; }

		public int UrlId { get; set; }

		public int FileId { get; set; }

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
		private UrlInfo url=null;
		
		[IgnoreColumn]
		public UrlInfo Url
		{

			get
			{
				var ctrl= new UrlController();
				if (url == null)
				{
					url=ctrl.GetUrl(0,"");
					
				}
				return url; 
			}
		}
		private DotNetNuke.Services.FileSystem.IFileInfo file=null;
		
		[IgnoreColumn]
		public DotNetNuke.Services.FileSystem.IFileInfo File
		{
			
			get
			{
				//var ctrl= new FileManager();
				//if (file == null)
				//{

				file=DotNetNuke.Services.FileSystem.FileManager.Instance.GetFile(FileId);
				return file;	
				}
			 
			}
		}

	}


