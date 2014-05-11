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

namespace Readysaster.DAL.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlertSubscription",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LastKnownLocation = c.Geography(),
                        AddressString = c.String(maxLength: 255),
                        ValidUntil = c.DateTime(nullable: false),
                        PhoneNumber = c.String(maxLength: 63),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AlertSubscription");
        }
    }
}
