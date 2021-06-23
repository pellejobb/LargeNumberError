using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SnapObjects.Data;
using DWNet.Data;
using LargeNumberError;
using LargeNumberError.Model;

namespace LargeNumberError.Services.Impl
{
    /// <summary>
	/// The service needs to be injected into the ConfigureServices method of the Startup class. The sample code is as follows:
    /// services.AddScoped<ILargeNumberModelService, LargeNumberModelService>();
    /// </summary>
	public class LargeNumberModelService : ILargeNumberModelService
	{
		private readonly DataContext _dataContext;
			
		public LargeNumberModelService(DefaultDataContext dataContext)
		{
			_dataContext = dataContext;
		}	
		
		public IDataStore<LargeNumberModel> Retrieve()
		{
			var dataStore = new DataStore<LargeNumberModel>(_dataContext);
		
			dataStore.Retrieve();
		 
			return dataStore;
		}	
    }
}