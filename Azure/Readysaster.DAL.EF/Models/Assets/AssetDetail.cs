using Readysaster.DAL.EF.Models.User;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Readysaster.DAL.EF.Models.Assets
{
    public class AssetDetail
    {
        public AssetDetail()
        {
            this.Timestamp = DateTime.UtcNow;
        }

        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }


        [ForeignKey("Asset")]
        public Guid AssetId { get; set; }
        public virtual Asset Asset { get; set; }


        [MaxLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }


        [ForeignKey("ReportedBy")]
        public Guid ReportedById { get; set; }
        public virtual Account ReportedBy { get; set; }
    }

    internal class AssetDetailTypeConfiguration : EntityTypeConfiguration<AssetDetail>
    {
        internal AssetDetailTypeConfiguration()
        {
            //this.HasMany(r => r.ReadAccessAccounts).WithMany();
            this.HasRequired(r => r.ReportedBy).WithMany().HasForeignKey(r => r.ReportedById).WillCascadeOnDelete(false);
        }
    }
}
