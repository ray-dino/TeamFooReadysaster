using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readysaster.DAL.EF.Models.Buildings
{
    public class School
    {
        public School()
        {
            this.Timestamp = DateTime.UtcNow;
        }

        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }

        public int ObjectId { get; set; }
        public DbGeography Location { get; set; }

        [MaxLength(255)]
        public string Region { get; set; }
        [MaxLength(255)]
        public string Division { get; set; }
        public int OgrFid { get; set; }
        public int ReferenceId { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Municipaliti { get; set; }
        [MaxLength(255)]
        public string Legislative { get; set; }

        public int TotalEnrollment { get; set; }
        public int TotalInst { get; set; }
        [MaxLength(255)]
        public string ColorCode { get; set; }
        [MaxLength(255)]
        public string Barangay { get; set; }
        [MaxLength(255)]
        public string Province { get; set; }
        [MaxLength(255)]
        public string District { get; set; }
        [MaxLength(255)]
        public string TypeOfSchool { get; set; }
        [MaxLength(255)]
        public string GpsSource { get; set; }
    }
}