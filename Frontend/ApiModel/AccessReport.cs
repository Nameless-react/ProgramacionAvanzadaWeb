namespace Frontend.ApiModel
{
    public class AccessReport
    {
        public int AccessReportId { get; set; }
        public int ClientID { get; set; }
        public DateTime? AccessDate { get; set; }
        public string? IPAddress { get; set; }
        public bool? Success { get; set; }
        public string? AccessDescription { get; set; }
    }
}
