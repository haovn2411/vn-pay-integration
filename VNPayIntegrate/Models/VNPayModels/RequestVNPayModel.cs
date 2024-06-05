namespace VNPayIntegrate.Models.VNPayModels
{
    public class RequestVNPayModel
    {
        public string? OrderId { get; set; } = Guid.NewGuid().ToString("N");
        public double? Amount { get; set; } = 100000;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
