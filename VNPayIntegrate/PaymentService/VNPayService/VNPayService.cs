using VNPayIntegrate.Models.VNPayModels;

namespace VNPayIntegrate.PaymentService.VNPayService
{
    public class VNPayService : IVNPayService
    {
        private readonly IConfiguration _config;

        public VNPayService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string CreatePaymentURL(RequestVNPayModel requestVNPayModel, HttpContext context)
        {
            VNPayLibrary vnpay = new VNPayLibrary();

            vnpay.AddRequestData("vnp_Version", VNPayLibrary.VERSION);
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", _config["VNPay:vnp_TmnCode"]);
            vnpay.AddRequestData("vnp_Amount", (requestVNPayModel.Amount * 100).ToString());

            vnpay.AddRequestData("vnp_CreateDate", requestVNPayModel.CreatedDate.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(context));
            vnpay.AddRequestData("vnp_Locale", "vn");

            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + requestVNPayModel.OrderId);
            vnpay.AddRequestData("vnp_OrderType", "other"); //default value: other
            vnpay.AddRequestData("vnp_ReturnUrl", _config["VNPay:vnp_Returnurl"]);
            vnpay.AddRequestData("vnp_TxnRef", DateTime.Now.Ticks.ToString());
            
            var paymentUrl = vnpay.CreateRequestUrl(_config["VNPay:vnp_Url"], _config["VNPay:vnp_HashSecret"]);
            return paymentUrl;
        }
    }
}
