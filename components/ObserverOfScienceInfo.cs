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
	// Set caching for table: [Cacheable("ObserverOfScience_ObserverOfScienceInfos", CacheItemPriority.Default, 20)] 
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
		public ObserverOfScienceInfo()
		{
		}

        #region Properties

		public int ObserverOfScienceID { get; set; }

		public int ModuleID { get; set; }

		//public string Content { get; set; }

		//public string Title { get; set; }

		//public string ListOfDevelopment { get; set; }

		//public string Development { get; set; }

		//public int YearOfDevelopment { get; set; }

		public int CreatedByUser { get; set; }

		//public string Image { get; set; }

		public int InventionId { get; set;} //связь с observer of sience

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

		//выгрузка учёных
		private List<ScientistInfo> scientists;

		[IgnoreColumn]
		public List<ScientistInfo> Scientists
		{
			get
			{
				if(scientists==null)
				{
					var ctrl= new ObserverOfScienceController();
					scientists=ctrl.GetScientistsByInvention(ObserverOfScienceID);
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
					patents=ctrl.GetPatentsByInvention(ObserverOfScienceID);
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
					introductions=ctrl.GetIntroductionsByInvention(ObserverOfScienceID);
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
					inventionResources=ctrl.GetResourceByInvention(ObserverOfScienceID);
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
					terms=ctrl.GetTermsByInvention(ObserverOfScienceID);
				}
				return terms;
			}
		}
        #endregion
        
		/* // Joins example
     	
     	// foreign key
     	public int AnotherID { get; set; }
     	
     	// private object reference
     	private AnotherInfo _another;
     	
     	// public object reference
     	public AnotherInfo Another 
     	{
     	   	// this getter method hide underlying access to database, 
     	   	// and perform simple caching by storing reference
     	   	// to retrived AnotherInfo object in a private field "_another"
     		get 
     		{
     			if (_other == null)
     			{
     				// load joined object to reference it
     				var ctrl = new ObserverOfScienceController();
     				_another = ctrl.Get<AnotherInfo>(AnotherID);
     			}
     			return _another;	
     		}
     		set 
     		{
     			_another = value;
     		}
     	}      
     	
     	/// <summary>
     	/// Nullifies all private fields with references to joined objects,
     	/// so next access to corresponding object properties 
     	/// results in reloading them from the database  
     	/// </summary>
     	public void ResetJoins ()
     	{
     		_another = null;
     	}
        
        // Now we have ability to use ObserverOfScienceInfo objects
        // to access members of joined AnotherInfo objects 
        
       	// Get ObserverOfScienceInfo object by it's primary key (ID):
       	// var ctrl = new ObserverOfScienceController();
     	// var item = ctrl.Get<ObserverOfScienceInfo>(itemId);
     	
     	// Now simply get data from another table:
     	// Console.WriteLine(item.Another.SomeProperty);
     	
        // True is, that it is not very effective way to retrieve multiple objects, 
        // but it is 1) simple and 2) object-oriented, so then PetaPOCO AutoJoin 
        // attribute will be included in DAL 2, existing business logic code 
        // can be upgraded with almost no efforts.
       
        */
	}


}

