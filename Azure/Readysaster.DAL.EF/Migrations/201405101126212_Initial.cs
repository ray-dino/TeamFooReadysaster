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
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssetDetail",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        AssetId = c.Guid(nullable: false),
                        Name = c.String(maxLength: 255),
                        Description = c.String(),
                        ReportedById = c.Guid(nullable: false),
                        Account_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Asset", t => t.AssetId, cascadeDelete: true)
                .ForeignKey("dbo.Account", t => t.ReportedById)
                .ForeignKey("dbo.Account", t => t.Account_Id)
                .Index(t => t.AssetId)
                .Index(t => t.ReportedById)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.Asset",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Description = c.String(),
                        ReportedById = c.Guid(nullable: false),
                        Account_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.ReportedById)
                .ForeignKey("dbo.Account", t => t.Account_Id)
                .Index(t => t.ReportedById)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.AssetLocation",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 255),
                        AssetId = c.Guid(nullable: false),
                        ReportedById = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Asset", t => t.AssetId, cascadeDelete: true)
                .ForeignKey("dbo.Account", t => t.ReportedById, cascadeDelete: true)
                .Index(t => t.AssetId)
                .Index(t => t.ReportedById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Asset", "Account_Id", "dbo.Account");
            DropForeignKey("dbo.AssetDetail", "Account_Id", "dbo.Account");
            DropForeignKey("dbo.AssetDetail", "ReportedById", "dbo.Account");
            DropForeignKey("dbo.AssetDetail", "AssetId", "dbo.Asset");
            DropForeignKey("dbo.Asset", "ReportedById", "dbo.Account");
            DropForeignKey("dbo.AssetLocation", "ReportedById", "dbo.Account");
            DropForeignKey("dbo.AssetLocation", "AssetId", "dbo.Asset");
            DropIndex("dbo.AssetLocation", new[] { "ReportedById" });
            DropIndex("dbo.AssetLocation", new[] { "AssetId" });
            DropIndex("dbo.Asset", new[] { "Account_Id" });
            DropIndex("dbo.Asset", new[] { "ReportedById" });
            DropIndex("dbo.AssetDetail", new[] { "Account_Id" });
            DropIndex("dbo.AssetDetail", new[] { "ReportedById" });
            DropIndex("dbo.AssetDetail", new[] { "AssetId" });
            DropTable("dbo.AssetLocation");
            DropTable("dbo.Asset");
            DropTable("dbo.AssetDetail");
            DropTable("dbo.Account");
        }
    }
}
