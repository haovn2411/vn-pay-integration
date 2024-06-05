using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VNPayIntegrate.Models.VNPayModels;
using VNPayIntegrate.PaymentService.VNPayService;

namespace VNPayIntegrate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VNPayController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IVNPayService _VNPayService;

        public VNPayController(IVNPayService VNPayService, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _VNPayService = VNPayService;
        }
        [HttpGet]
        public IActionResult actionResult()
        {
            var requestModel = new RequestVNPayModel();
            var paymentURL = _VNPayService.CreatePaymentURL(requestModel, _httpContextAccessor.HttpContext);
            return Ok(paymentURL);
        }
    }
}
