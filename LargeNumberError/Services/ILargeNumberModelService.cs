using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWNet.Data;
using LargeNumberError;
using LargeNumberError.Model;
	
namespace LargeNumberError.Services
{
	public interface ILargeNumberModelService
	{	
		IDataStore<LargeNumberModel> Retrieve();
    }
}