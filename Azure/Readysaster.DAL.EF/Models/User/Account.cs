
using Readysaster.DAL.EF.Models.Assets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readysaster.DAL.EF.Models.User
{
    public class Account
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public ICollection<Asset> Assets { get; set; }
        public ICollection<AssetLocation> AssetLocations { get; set; }
        public ICollection<AssetDetail> AssetDetails { get; set; }
    }
}
