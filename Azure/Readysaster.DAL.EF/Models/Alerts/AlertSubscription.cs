using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readysaster.DAL.EF.Models.Alerts
{
    public class AlertSubscription
    {
        public Guid? Id { get; set; }
        public DbGeography LastKnownLocation { get; set; }

        [MaxLength(255)]
        public string AddressString { get; set; }

        public DateTime ValidUntil { get; set; }
        
        [MaxLength(63)]
        public string PhoneNumber { get; set; }
    }
}
