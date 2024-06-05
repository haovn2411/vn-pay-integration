using VNPayIntegrate.Models.VNPayModels;

namespace VNPayIntegrate.PaymentService.VNPayService
{
    public interface IVNPayService
    {
        public string CreatePaymentURL(RequestVNPayModel requestVNPayModel, HttpContext context);
    }
}
