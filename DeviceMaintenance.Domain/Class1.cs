namespace DeviceMaintenance.Domain
{
    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string SerialNumber { get; set; } = "";
        public string Location { get; set; } = "";
        public DateTime PurchaseDate { get; set; }
        public string Status { get; set; } = "Active";
    }

    public class WorkOrder
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string Description { get; set; } = "";
        public DateTime ScheduledDate { get; set; }
        public bool Completed { get; set; } = false;
    }

    public class Ticket
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string Issue { get; set; } = "";
        public string Priority { get; set; } = "Normal";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Open";
    }
}
