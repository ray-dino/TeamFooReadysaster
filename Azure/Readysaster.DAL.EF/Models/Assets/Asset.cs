
using Readysaster.DAL.EF.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readysaster.DAL.EF.Models.Assets
{
    public class Asset
    {
        public Asset()
        {
            this.AssetLocations = new List<AssetLocation>();
            this.AssetDetails = new List<AssetDetail>();
        }

        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }


        [ForeignKey("ReportedBy")]
        public Guid ReportedById { get; set; }
        public virtual Account ReportedBy { get; set; }


        public ICollection<AssetLocation> AssetLocations { get; set; }
        public ICollection<AssetDetail> AssetDetails { get; set; }
    }

    internal class AssetTypeConfiguration : EntityTypeConfiguration<Asset>
    {
        internal AssetTypeConfiguration()
        {
            //this.HasMany(r => r.ReadAccessAccounts).WithMany();
            this.HasRequired(r => r.ReportedBy).WithMany().HasForeignKey(r => r.ReportedById).WillCascadeOnDelete(false);
        }
    }
}
