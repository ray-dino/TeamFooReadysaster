//Team Foo Readysaster 2014

//This program is free software; you can redistribute it and/or modify it
//under the terms of the GNU General Public License as published by the
//Free Software Foundation; either version 3, or (at your option) any later
//version.

//This program is distributed in the hope that it will be useful, but
//WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General
//Public License for more details.

//You should have received a copy of the GNU General Public License along
//with this program; if not, write to the Free Software Foundation, Inc.,
//59 Temple Place - Suite 330, Boston, MA 02111-1307, USA. 

using Readysaster.DAL.EF.Models.Alerts;
using Readysaster.DAL.EF.Models.Assets;
using Readysaster.DAL.EF.Models.Buildings;
using Readysaster.DAL.EF.Models.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readysaster.DAL.EF
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : this("name=DefaultConnection") { }

        public DatabaseContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("modelBuilder");
            }

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Add any configuration or mapping stuff here
            modelBuilder.Configurations.AddFromAssembly(typeof(DatabaseContext).Assembly);
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetLocation> AssetLocations { get; set; }
        public DbSet<AssetDetail> AssetDetails { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<AlertSubscription> AlertSubscriptions { get; set; }
    }
}