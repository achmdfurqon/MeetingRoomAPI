namespace MeetingRoomAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelsToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_M_Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TB_M_Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id);
                           
            CreateTable(
                "dbo.TB_T_RoomLoans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        LoanDate = c.DateTime(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TB_M_Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.UsersVMRolesVMs",
                c => new
                    {
                        UsersVM_Id = c.Int(nullable: false),
                        RolesVM_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UsersVM_Id, t.RolesVM_Id })
                .ForeignKey("dbo.TB_M_Users", t => t.UsersVM_Id, cascadeDelete: true)
                .ForeignKey("dbo.TB_M_Roles", t => t.RolesVM_Id, cascadeDelete: true)
                .Index(t => t.UsersVM_Id)
                .Index(t => t.RolesVM_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersVMRolesVMs", "RolesVM_Id", "dbo.TB_M_Roles");
            DropForeignKey("dbo.UsersVMRolesVMs", "UsersVM_Id", "dbo.TB_M_Users");
            DropIndex("dbo.UsersVMRolesVMs", new[] { "RolesVM_Id" });
            DropIndex("dbo.UsersVMRolesVMs", new[] { "UsersVM_Id" });
            DropTable("dbo.UsersVMRolesVMs");
            DropTable("dbo.TB_M_Rooms");
            DropTable("dbo.TB_T_RoomLoans");
            DropTable("dbo.TB_M_Users");
            DropTable("dbo.TB_M_Roles");
        }
    }
}
