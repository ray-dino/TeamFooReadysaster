using Readysaster.DAL.EF.Models.User;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Readysaster.DAL.EF.Models.Assets
{
    public class AssetLocation
    {
        public AssetLocation()
        {
            this.Timestamp = DateTime.UtcNow;
        }

        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime Timestamp { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }


        [ForeignKey("Asset")]
        public Guid AssetId { get; set; }
        public virtual Asset Asset { get; set; }


        [ForeignKey("ReportedBy")]
        public Guid ReportedById { get; set; }
        public virtual Account ReportedBy { get; set; }
    }
}
