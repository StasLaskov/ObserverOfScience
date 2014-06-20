using System;
using System.Collections.Generic;

using DotNetNuke.Data;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.Entities.Content.Taxonomy;

namespace ObserverOfScience
{
	// More attributes for class:
	// Set caching for table: [Cacheable("ObserverOfScience_InvTermsInfos", CacheItemPriority.Default, 20)] 
	// Explicit mapping declaration: [DeclareColumns]
	
	// More attributes for class properties:
	// Custom column name: [ColumnName("InvTermsInfoID")]
	// Explicit include column: [IncludeColumn]
	// Note: DAL 2 have no AutoJoin analogs from PetaPOCO at this time
	[TableName("Science_InvTerms")]
	[PrimaryKey("InvTermId", AutoIncrement = true)]
//	[Scope("ModuleID")]
	public class InvTermsInfo
	{
        #region Fields
        
	
		#endregion
		
		/// <summary>
		/// Empty default cstor
		/// </summary>
		public InvTermsInfo ()
		{
		}

        #region Properties

		public int InvTermId { get; set; }

		public int TermId { get; set; }

		public int InventionId { get; set; }

		public int VocabularyId { get; set; }

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

		private Term term=null;
		
		[IgnoreColumn]
		public Term Term
		{
			
			get
			{

				if (term == null)
				{
					TermController tctrl=new TermController();
					term = tctrl.GetTerm(TermId);
					
				}
				return term; 
			}
			set
			{
				term=value;
			}
		}
	}
}

