using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTrackR.Entities
{
    public class Package
    {
        public Package(string title, decimal weight) // Construtor
        {
            Code = Guid.NewGuid().ToString();
            Title = title;
            Weight = weight;
            Delivered = false;
            PostedAt = DateTime.Now;
            Updates = new List<PackageUpdate>();
        }

        public void AddUpdate(string status, bool delivered)
        {
            if (Delivered)
            {
                throw new Exception("Package is already delivered");
            }
            var update = new PackageUpdate(status, Id);
            Updates.Add(update);

            Delivered = delivered;

        }

        public int Id { get; private set; }
        public string Code { get; private set; }
        public string Title { get; private set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Weight { get; private set; }
        public bool Delivered { get; private set; }
        public DateTime PostedAt { get; private set; }
        public List<PackageUpdate>  Updates { get; private set; }
    }
}
