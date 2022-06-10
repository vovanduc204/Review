using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.API.Controllers
{
    public class PaymentController : BaseApiController
    {
        [HttpPost("{basketId}")]
        public async Task<ActionResult> CreateOrUpdatePaymentIntent(string basketId)
        {
            return null;
        }
    }
}
