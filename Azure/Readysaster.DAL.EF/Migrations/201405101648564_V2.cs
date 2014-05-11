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
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.School",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        ObjectId = c.Int(nullable: false),
                        Location = c.Geography(),
                        Region = c.String(maxLength: 255),
                        Division = c.String(maxLength: 255),
                        OgrFid = c.Int(nullable: false),
                        ReferenceId = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                        Municipaliti = c.String(maxLength: 255),
                        Legislative = c.String(maxLength: 255),
                        TotalEnrollment = c.Int(nullable: false),
                        TotalInst = c.Int(nullable: false),
                        ColorCode = c.String(maxLength: 255),
                        Barangay = c.String(maxLength: 255),
                        Province = c.String(maxLength: 255),
                        District = c.String(maxLength: 255),
                        TypeOfSchool = c.String(maxLength: 255),
                        GpsSource = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.School");
        }
    }
}
