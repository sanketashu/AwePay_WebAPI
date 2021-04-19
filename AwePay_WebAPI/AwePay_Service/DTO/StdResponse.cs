namespace AwePay_Service.DTO
{
    public class StdResponse<T>
    {
        public string responseCode { get; set; }
        public string responseMessage { get; set; }
        public T response { get; set; }
    }
}
