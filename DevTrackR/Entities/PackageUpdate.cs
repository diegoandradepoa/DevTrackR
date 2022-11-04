namespace DevTrackR.Entities
{
    public class PackageUpdate
    {
        public PackageUpdate(string status, int pakageId) // Construtor
        {
            PakageId = pakageId;
            Status = status;
            UpdateDate = DateTime.Now;
            
        }
        public int Id { get; private set; }
        public int PakageId { get; private set; }
        public string Status { get; private set; }
        public DateTime UpdateDate { get; private set; }

    }
}
