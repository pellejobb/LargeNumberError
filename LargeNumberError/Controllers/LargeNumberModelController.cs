using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using SnapObjects.Data;
using DWNet.Data;
using LargeNumberError.Services;
using LargeNumberError.Model;

namespace LargeNumberError.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LargeNumberModelController : ControllerBase
    {
        private readonly ILargeNumberModelService _ilargenumbermodelservice;

        public LargeNumberModelController(ILargeNumberModelService ilargenumbermodelservice)
        {
            _ilargenumbermodelservice = ilargenumbermodelservice;
        }		

		//GET api/LargeNumberModel/Retrieve
		[HttpGet]
		[ProducesResponseType(typeof(IDataStore<LargeNumberModel>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<IDataStore<LargeNumberModel>> Retrieve()
		{
			try
            {
				var result = _ilargenumbermodelservice.Retrieve();
				
				return Ok(result);
			}
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
		}
	
	}
}
