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
	// Set caching for table: [Cacheable("ObserverOfScience_Inventions", CacheItemPriority.Default, 20)] 
	// Explicit mapping declaration: [DeclareColumns]
	
	// More attributes for class properties:
	// Custom column name: [ColumnName("InventionID")]
	// Explicit include column: [IncludeColumn]
	// Note: DAL 2 have no AutoJoin analogs from PetaPOCO at this time
	[TableName("Science_Invention")]
	[PrimaryKey("InventionId", AutoIncrement = true)]
	[Scope("ModuleID")]
	public class InventionInfo
	{
        #region Fields
        
	
		#endregion
		
		/// <summary>
		/// Empty default cstor
		/// </summary>
		public InventionInfo ()
		{
		}

        #region Properties

		public int InventionID { get; set; }

		public DateTime YearOfCreation { get; set; }

		public string Description { get; set; }

		public string InventionEssence { get; set; }

		public string Status { get; set; }

		public string Advantages { get; set; }

		public string Name { get; set; }

		public string Image { get; set; }

		public int ModuleID { get; set; }

		//УЧЁНЫЕ
		private List<ScientistInfo> scientists;

		[IgnoreColumn]
		public List<ScientistInfo> Scientists
		{
			get
			{
				if(scientists==null)
				{
					var ctrl= new ObserverOfScienceController();
					scientists=ctrl.GetScientistsByInvention(InventionID);
				}
				return scientists;
			}
		}
		//Выгрузка патентов
		private List<PatentInfo> patents;
		
		[IgnoreColumn]
		public List<PatentInfo> Patents
		{
			get
			{
				if(patents==null)
				{
					var ctrl= new ObserverOfScienceController();
					patents=ctrl.GetPatentsByInvention(InventionID);
				}
				return patents;
			}
		}

		//Выгрузка внедрений

		private List<IntroductionInfo> introductions;
		
		[IgnoreColumn]
		public List<IntroductionInfo> Introductions
		{
			get
			{
				if(introductions==null)
				{
					var ctrl= new ObserverOfScienceController();
					introductions=ctrl.GetIntroductionsByInvention(InventionID);
				}
				return introductions;
			}
		}
		//выгрузка ссылок
		private List<InventionResourceInfo> inventionResources;
		
		[IgnoreColumn]
		public List<InventionResourceInfo> InventionResources
		{
			get
			{
				if(inventionResources==null)
				{
					var ctrl= new ObserverOfScienceController();
					inventionResources=ctrl.GetResourceByInvention(InventionID);
				}
				return inventionResources;
			}
		}
		//выгрузка термов
		private List<InvTermsInfo> terms;
		
		[IgnoreColumn]
		public List<InvTermsInfo> Terms
		{
			get
			{
				if(terms==null)
				{
					var ctrl= new ObserverOfScienceController();
					terms=ctrl.GetTermsByInvention(InventionID);
				}
				return terms;
			}
		}

//		public int PatentID { get; set; }
//		
//		private PatentInfo patents;
//		
//		[IgnoreColumn]
//		public PatentInfo Patents 
//		{
//			get 
//			{
//				if (patents == null)
//				{
//					var ctrl = new ObserverOfScienceController();
//					patents = ctrl.Get<PatentInfo>(PatentID);
//				}
//				return patents;	
//			}
//			set 
//			{
//				patents = value;
//			}
//		}      


	//	[ReadOnlyColumn]
	//	public DateTime CreatedOnDate { get; set; }
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

	}
}

