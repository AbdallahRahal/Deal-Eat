using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DealEat.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using DealEat.WebApp.Authentication;
using DealEat.DAL;

namespace DealEat.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class ReductionController : Controller
    {
        readonly ReductionGateway _reductionGateway;

        public ReductionController(ReductionGateway reductionGateway)
        {
            _reductionGateway = reductionGateway;

        }
        
        [HttpGet]
        public async Task<IActionResult> GetReductionList()
        {
           IEnumerable<ReductionData> result = await _reductionGateway.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetReduction")]
        public async Task<IActionResult> GetReductionById(int id)
        {
            Result<ReductionData> result = await _reductionGateway.FindById(id);
            return this.CreateResult(result);
        }
        [HttpGet("restaurant/{id}", Name = "NewReduction")]
        public async Task<IActionResult> newReduction(int id, [FromBody] SoldViewModel model)
        {
            Result<ReductionData> result = await _reductionGateway.CreateReduction(model.Reduction,model.model.Start_Date,model.End_Date);
            return this.CreateResult(result);
        }
    }
}