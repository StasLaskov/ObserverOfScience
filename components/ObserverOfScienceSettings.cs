using System;

namespace ObserverOfScience
{
	/// <summary>
	/// Provides strong typed access to settings used by module
	/// </summary>
	public partial class ObserverOfScienceSettings
	{
		#region Properties for settings

		/// <summary>
		/// Template used to render the module content
		/// </summary>
		public string Template
		{
			get
			{ 
				return ReadSetting<string> ("template", 
				                            "<i>[CREATEDONDATE]<i> <b>[CREATEDBYUSERNAME]</b>:<br/> [TITLE] <br />[LISTOFDEVELOPMENT]<br/> [DEVELOPMENT] <br/> [YEAROFDEVELOPMENT] <br/> [CONTENT] <br/> [NAME]", 
					true); 
			}
			set { WriteSetting ("template", value, true); }
		}

		public int RecordsReturned
		{
			get
			{
				return ReadSetting<int> ("recordsreturned", 15, true);
			}
			set
			{
				WriteSetting("recordsreturned", value.ToString(), true); 
			}
		}
		public int LenghtText
		{
			get
			{
				return ReadSetting<int> ("lenghttext", 745, true);
			}
			set
			{
				WriteSetting("lenghttext", value.ToString(), true); 
			}
		}
		public int CountInvention
		{
			get
			{
				return ReadSetting<int> ("countinvention", 15, true);
			}
			set
			{
				WriteSetting("countinvention", value.ToString(), true); 
			}
		}
        #endregion
	}
}

