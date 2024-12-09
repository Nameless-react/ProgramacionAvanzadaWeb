namespace Backend.DTO
{
    public class AccessReportDTO
    {
        public int AccessReportId { get; set; }
        public int ClientId { get; set; }
        public DateTime? AccessDate { get; set; }
        public string? IpAddress { get; set; }
        public bool? Success { get; set; }
        public string? AccessDescription { get; set; }
    }
}
