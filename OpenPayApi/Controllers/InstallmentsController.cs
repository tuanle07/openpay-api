using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using OpenPayApi.Models;
using OpenPayApi.Services;

namespace OpenPayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallmentsController : ControllerBase
    {
        private readonly IInstallmentService _installmentService;

        public InstallmentsController(IInstallmentService installmentService)
        {
            _installmentService = installmentService;
        }

        // GET api/installments
        [HttpGet]
        [ProducesResponseType(typeof(List<InstallmentsDto>), (int)HttpStatusCode.OK)]
        public ActionResult<List<InstallmentsDto>> Get(decimal purchasePrice, DateTime purchaseDate)
        {
            return _installmentService.GetInstallmentPlan(purchasePrice, purchaseDate);
        }
    }
}