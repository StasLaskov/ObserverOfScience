using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using DotNetNuke.Collections;
using DotNetNuke.Data;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace ObserverOfScience
{
	public partial class ObserverOfScienceController : ISearchable, IPortable
	{
        #region Public methods

		/// <summary>
		/// Initializes a new instance of the <see cref="ObserverOfScience.ObserverOfScienceController"/> class.
		/// </summary>
		public ObserverOfScienceController ()
		{ 

		}

		/// <summary>
		/// Adds a new T object into the database
		/// </summary>
		/// <param name='info'></param>
		public void Add<T> (T info) where T: class
		{
			using (var ctx = DataContext.Instance())
			{
				var repo = ctx.GetRepository<T> ();
				repo.Insert (info);
			}
		}

		/// <summary>
		/// Get single object from the database
		/// </summary>
		/// <returns>
		/// The object
		/// </returns>
		/// <param name='itemId'>
		/// Item identifier.
		/// </param>
		public T Get<T> (int itemId) where T: class
		{
			T info;

			using (var ctx = DataContext.Instance())
			{
				var repo = ctx.GetRepository<T> ();
				info = repo.GetById (itemId);
			}

			return info;
		}
		
		/// <summary>
		/// Get single object from the database
		/// </summary>
		/// <returns>
		/// The object
		/// </returns>
		/// <param name='itemId'>
		/// Item identifier.
		/// </param>
		/// <param name='scopeId'>
		/// Scope identifier (like moduleId)
		/// </param>
		public T Get<T> (int itemId, int scopeId) where T: class
		{
			T info;

			using (var ctx = DataContext.Instance())
			{
				var repo = ctx.GetRepository<T> ();
				info = repo.GetById (itemId, scopeId);
			}

			return info;
		}

		
		/// <summary>
		/// Updates an object already stored in the database
		/// </summary>
		/// <param name='info'>
		/// Info.
		/// </param>
		public void Update<T> (T info) where T: class
		{
			using (var ctx = DataContext.Instance())
			{
				var repo = ctx.GetRepository<T> ();
				repo.Update (info);
			}
		}

		/// <summary>
		/// Gets all objects for items matching scopeId
		/// </summary>
		/// <param name='scopeId'>
		/// Scope identifier (like moduleId)
		/// </param>
		/// <returns></returns>
		public IEnumerable<T> GetObjects<T> (int scopeId) where T: class
		{
			IEnumerable<T> infos = null;

			using (var ctx = DataContext.Instance())
			{
				var repo = ctx.GetRepository<T> ();
				infos = repo.Get (scopeId);
				
				// Without [Scope("ModuleID")] it should be like:
				// infos = repo.Find ("WHERE ModuleID = @0", moduleId);
			}

			return infos;
		}
		public IEnumerable<T> GetObjects<T> () where T: class
		{
			IEnumerable<T> infos = null;
			
			using (var ctx = DataContext.Instance())
			{
				var repo = ctx.GetRepository<T> ();
				infos = repo.Get ();
				
				// Without [Scope("ModuleID")] it should be like:
				// infos = repo.Find ("WHERE ModuleID = @0", moduleId);
			}
			
			return infos;
		}
		
		/// <summary>
		/// Gets all objects for items matching scopeId in list format
		/// </summary>
		/// <returns>
		/// List of T objects
		/// </returns>
		/// <param name='scopeId'>
		/// Scope identifier (like moduleId)
		/// </param>
		public IList<T> GetList<T> (int scopeId) where T: class
		{
			return new List<T> (GetObjects<T> (scopeId));
		}
		public IList<T> GetList<T> () where T: class
		{
			return new List<T> (GetObjects<T> ());
		}

		/// <summary>
		/// Gets one page of objects
		/// </summary>
		/// <param name="scopeId">Scope identifier (like moduleId)</param>
		/// <param name="index">a page index</param>
		/// <param name="size">a page size</param>
		/// <returns>A paged list of T objects</returns>
		public IPagedList<T> GetPage<T> (int scopeId, int index, int size) where T: class
		{
			IPagedList<T> infos;

			using (var ctx = DataContext.Instance())
			{
				var repo = ctx.GetRepository<T> ();
				infos = repo.GetPage (scopeId, index, size);
			}

			return infos;
		}

		/// <summary>
		/// Delete a given item from the database by instance
		/// </summary>
		/// <param name='info'></param>
		public void Delete<T> (T info) where T: class
		{
			using (var ctx = DataContext.Instance())
			{
				var repo = ctx.GetRepository<T> ();
				repo.Delete (info);
		
			}
		}
		
		/// <summary>
		/// Delete a given item from the database by ID
		/// </summary>
		/// <param name='itemId'></param>
		public void Delete<T> (int itemId) where T: class
		{
			using (var ctx = DataContext.Instance())
			{
				var repo = ctx.GetRepository<T> ();
				repo.Delete (repo.GetById (itemId));
			}
		}
		
        #endregion
        
        #region Class-specific controller members (example)
		public List<ScientistInfo> GetScientistsByInvention (int inventionId)
		{
			IEnumerable<ScientistInfo> infos = null;
			
			using (var ctx = DataContext.Instance())
			{
				var repo = ctx.GetRepository<ScientistInfo> ();
				infos = repo.Find ("WHERE InventionId=@0",inventionId);
				
				// Without [Scope("ModuleID")] it should be like:
				// infos = repo.Find ("WHERE ModuleID = @0", moduleId);
			}
			
			return new List<ScientistInfo>(infos);
		}
		public List<PatentInfo> GetPatentsByInvention (int inventionId)
		{
			IEnumerable<PatentInfo> infos = null;
			
			using (var ctx = DataContext.Instance())
			{
				var repo = ctx.GetRepository<PatentInfo> ();
				infos = repo.Find ("WHERE InventionId=@0",inventionId);
				
				// Without [Scope("ModuleID")] it should be like:
				// infos = repo.Find ("WHERE ModuleID = @0", moduleId);
			}
			
			return new List<PatentInfo>(infos);
		}
		public List<IntroductionInfo> GetIntroductionsByInvention (int inventionId)
		{
			IEnumerable<IntroductionInfo> infos = null;
			
			using (var ctx = DataContext.Instance())
			{
				var repo = ctx.GetRepository<IntroductionInfo> ();
				infos = repo.Find ("WHERE InventionId=@0",inventionId);
				
				// Without [Scope("ModuleID")] it should be like:
				// infos = repo.Find ("WHERE ModuleID = @0", moduleId);
			}
			
			return new List<IntroductionInfo>(infos);
		}
		public List<InventionResourceInfo> GetResourceByInvention (int inventionId)
		{
			IEnumerable<InventionResourceInfo> infos = null;
			
			using (var ctx = DataContext.Instance())
			{
				var repo = ctx.GetRepository<InventionResourceInfo> ();
				infos = repo.Find ("WHERE InventionId=@0",inventionId);
				
				// Without [Scope("ModuleID")] it should be like:
				// infos = repo.Find ("WHERE ModuleID = @0", moduleId);
			}
			
			return new List<InventionResourceInfo>(infos);
		}


		public List<InvTermsInfo> GetTermsByInvention (int inventionId)
		{
			IEnumerable<InvTermsInfo> infos = null;
			
			using (var ctx = DataContext.Instance())
			{
				var repo = ctx.GetRepository<InvTermsInfo> ();
				infos = repo.Find ("WHERE InventionId=@0",inventionId);
				
				// Without [Scope("ModuleID")] it should be like:
				// infos = repo.Find ("WHERE ModuleID = @0", moduleId);
			}
			
			return new List<InvTermsInfo>(infos);
		}
		

        
		/*
        /// <summary>
		/// Delete a given item from the database by ID
		/// </summary>
		/// <param name='itemId'></param>
		public void DeleteObserverOfScience (int itemId)
		{
			using (var ctx = DataContext.Instance())
			{
				var repo = ctx.GetRepository<ObserverOfScienceInfo> ();
				repo.Delete ("WHERE ObserverOfScienceID = @0", itemId);
			}
		}
		*/
	
		#endregion

        #region ISearchable members

		/// <summary>
		/// Implements the search interface required to allow DNN to index/search the content of your
		/// module
		/// </summary>
		/// <param name="modInfo"></param>
		/// <returns></returns>
		public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems (ModuleInfo modInfo)
		{
			var searchItems = new SearchItemInfoCollection ();
			var infos = GetList<ObserverOfScienceInfo> (modInfo.ModuleID);

			foreach (ObserverOfScienceInfo info in infos)
			{
				searchItems.Add (
					new SearchItemInfo (
						modInfo.ModuleTitle, 
						"", 
						info.CreatedByUser, 
						info.CreatedOnDate,
                        modInfo.ModuleID, 
                        info.ObserverOfScienceID.ToString (),
                     //   info.Content, 
                        "Item=" + info.ObserverOfScienceID.ToString ())
				);
			}

			return searchItems;
		}
	
        #endregion

        #region IPortable members

		/// <summary>
		/// Exports a module to XML
		/// </summary>
		/// <param name="ModuleID">a module ID</param>
		/// <returns>XML string with module representation</returns>
		public string ExportModule (int moduleId)
		{
			var sb = new StringBuilder ();
			var infos = GetList<ObserverOfScienceInfo> (moduleId);

			if (infos.Count > 0)
			{
				sb.Append ("<ObserverOfSciences>");
				foreach (var info in infos)
				{
					sb.Append ("<ObserverOfScience>");
					sb.Append ("<content>");
					sb.Append (XmlUtils.XMLEncode (""));
					sb.Append ("</content>");
					sb.Append ("</ObserverOfScience>");
				}
				sb.Append ("</ObserverOfSciences>");
			}
			
			return sb.ToString ();
		}

		/// <summary>
		/// Imports a module from an XML
		/// </summary>
		/// <param name="ModuleID"></param>
		/// <param name="Content"></param>
		/// <param name="Version"></param>
		/// <param name="UserID"></param>
		public void ImportModule (int ModuleID, string Content, string Version, int UserID)
		{
			var infos = DotNetNuke.Common.Globals.GetContent (Content, "ObserverOfSciences");
		
			foreach (XmlNode info in infos.SelectNodes("ObserverOfScience"))
			{
				var item = new ObserverOfScienceInfo ();
				item.ModuleID = ModuleID;
				//item.Content = info.SelectSingleNode ("content").InnerText;
				item.CreatedByUser = UserID;

				Add<ObserverOfScienceInfo> (item);
			}
		}
		
        #endregion



	}
}

