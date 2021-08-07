namespace OlympicApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Athlets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SurName = c.String(),
                        ImagePath = c.String(),
                        FlagPath = c.String(),
                        Weight = c.Int(nullable: false),
                        BirthDay = c.DateTime(nullable: false),
                        Country_Id = c.Int(),
                        Gender_Id = c.Int(),
                        Sport_Id = c.Int(),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.Genders", t => t.Gender_Id)
                .ForeignKey("dbo.Sports", t => t.Sport_Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Id)
                .Index(t => t.Country_Id)
                .Index(t => t.Gender_Id)
                .Index(t => t.Sport_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        FlagPath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Medals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeOfWon = c.DateTime(nullable: false),
                        MedalType_Id = c.Int(),
                        SportCathegory_Id = c.Int(),
                        Country_Id = c.Int(),
                        Athlet_Id = c.Int(),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedalTypes", t => t.MedalType_Id)
                .ForeignKey("dbo.SportCathegories", t => t.SportCathegory_Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.Athlets", t => t.Athlet_Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Id)
                .Index(t => t.MedalType_Id)
                .Index(t => t.SportCathegory_Id)
                .Index(t => t.Country_Id)
                .Index(t => t.Athlet_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.MedalTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Point = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.SportCathegories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender_Id = c.Int(),
                        Sport_Id = c.Int(),
                        TeamOrOwn_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.Gender_Id)
                .ForeignKey("dbo.Sports", t => t.Sport_Id)
                .ForeignKey("dbo.TeamOrOwns", t => t.TeamOrOwn_Id)
                .Index(t => t.Id)
                .Index(t => t.Gender_Id)
                .Index(t => t.Sport_Id)
                .Index(t => t.TeamOrOwn_Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FemaleOrMale = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Sports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.TeamOrOwns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TOrOwn = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RaceDegrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Place = c.Double(nullable: false),
                        Race_Id = c.Int(),
                        SportCathegory_Id = c.Int(),
                        Athlet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Races", t => t.Race_Id)
                .ForeignKey("dbo.SportCathegories", t => t.SportCathegory_Id)
                .ForeignKey("dbo.Athlets", t => t.Athlet_Id)
                .Index(t => t.Id)
                .Index(t => t.Race_Id)
                .Index(t => t.SportCathegory_Id)
                .Index(t => t.Athlet_Id);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Second_Id = c.Int(),
                        SportCathegory_Id = c.Int(),
                        Third_Id = c.Int(),
                        Winner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Athlets", t => t.Second_Id)
                .ForeignKey("dbo.SportCathegories", t => t.SportCathegory_Id)
                .ForeignKey("dbo.Athlets", t => t.Third_Id)
                .ForeignKey("dbo.Athlets", t => t.Winner_Id)
                .Index(t => t.Id)
                .Index(t => t.Second_Id)
                .Index(t => t.SportCathegory_Id)
                .Index(t => t.Third_Id)
                .Index(t => t.Winner_Id);
            
            CreateTable(
                "dbo.Stages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Race_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Races", t => t.Race_Id)
                .Index(t => t.Id)
                .Index(t => t.Race_Id);
            
            CreateTable(
                "dbo.OppositeTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Team1_Id = c.Int(),
                        Team2_Id = c.Int(),
                        StageForTeam_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team1_Id)
                .ForeignKey("dbo.Teams", t => t.Team2_Id)
                .ForeignKey("dbo.StageForTeams", t => t.StageForTeam_Id)
                .Index(t => t.Id)
                .Index(t => t.Team1_Id)
                .Index(t => t.Team2_Id)
                .Index(t => t.StageForTeam_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlagPath = c.String(),
                        Country_Id = c.Int(),
                        SportCathegory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.SportCathegories", t => t.SportCathegory_Id)
                .Index(t => t.Id)
                .Index(t => t.Country_Id)
                .Index(t => t.SportCathegory_Id);
            
            CreateTable(
                "dbo.RaceForTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Second_Id = c.Int(),
                        SportCathegory_Id = c.Int(),
                        Third_Id = c.Int(),
                        Winner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Second_Id)
                .ForeignKey("dbo.SportCathegories", t => t.SportCathegory_Id)
                .ForeignKey("dbo.Teams", t => t.Third_Id)
                .ForeignKey("dbo.Teams", t => t.Winner_Id)
                .Index(t => t.Id)
                .Index(t => t.Second_Id)
                .Index(t => t.SportCathegory_Id)
                .Index(t => t.Third_Id)
                .Index(t => t.Winner_Id);
            
            CreateTable(
                "dbo.StageForTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Race_Id = c.Int(),
                        RaceForTeam_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Races", t => t.Race_Id)
                .ForeignKey("dbo.RaceForTeams", t => t.RaceForTeam_Id)
                .Index(t => t.Id)
                .Index(t => t.Race_Id)
                .Index(t => t.RaceForTeam_Id);
            
            CreateTable(
                "dbo.SportCathegoryAthlets",
                c => new
                    {
                        SportCathegory_Id = c.Int(nullable: false),
                        Athlet_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SportCathegory_Id, t.Athlet_Id })
                .ForeignKey("dbo.SportCathegories", t => t.SportCathegory_Id, cascadeDelete: true)
                .ForeignKey("dbo.Athlets", t => t.Athlet_Id, cascadeDelete: true)
                .Index(t => t.SportCathegory_Id)
                .Index(t => t.Athlet_Id);
            
            CreateTable(
                "dbo.StageAthlets",
                c => new
                    {
                        Stage_Id = c.Int(nullable: false),
                        Athlet_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Stage_Id, t.Athlet_Id })
                .ForeignKey("dbo.Stages", t => t.Stage_Id, cascadeDelete: true)
                .ForeignKey("dbo.Athlets", t => t.Athlet_Id, cascadeDelete: true)
                .Index(t => t.Stage_Id)
                .Index(t => t.Athlet_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RaceForTeams", "Winner_Id", "dbo.Teams");
            DropForeignKey("dbo.RaceForTeams", "Third_Id", "dbo.Teams");
            DropForeignKey("dbo.StageForTeams", "RaceForTeam_Id", "dbo.RaceForTeams");
            DropForeignKey("dbo.StageForTeams", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.OppositeTeams", "StageForTeam_Id", "dbo.StageForTeams");
            DropForeignKey("dbo.RaceForTeams", "SportCathegory_Id", "dbo.SportCathegories");
            DropForeignKey("dbo.RaceForTeams", "Second_Id", "dbo.Teams");
            DropForeignKey("dbo.OppositeTeams", "Team2_Id", "dbo.Teams");
            DropForeignKey("dbo.OppositeTeams", "Team1_Id", "dbo.Teams");
            DropForeignKey("dbo.Teams", "SportCathegory_Id", "dbo.SportCathegories");
            DropForeignKey("dbo.Medals", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Teams", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Athlets", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Athlets", "Sport_Id", "dbo.Sports");
            DropForeignKey("dbo.RaceDegrees", "Athlet_Id", "dbo.Athlets");
            DropForeignKey("dbo.RaceDegrees", "SportCathegory_Id", "dbo.SportCathegories");
            DropForeignKey("dbo.RaceDegrees", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.Races", "Winner_Id", "dbo.Athlets");
            DropForeignKey("dbo.Races", "Third_Id", "dbo.Athlets");
            DropForeignKey("dbo.Races", "SportCathegory_Id", "dbo.SportCathegories");
            DropForeignKey("dbo.Races", "Second_Id", "dbo.Athlets");
            DropForeignKey("dbo.Stages", "Race_Id", "dbo.Races");
            DropForeignKey("dbo.StageAthlets", "Athlet_Id", "dbo.Athlets");
            DropForeignKey("dbo.StageAthlets", "Stage_Id", "dbo.Stages");
            DropForeignKey("dbo.Medals", "Athlet_Id", "dbo.Athlets");
            DropForeignKey("dbo.Athlets", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.Medals", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Medals", "SportCathegory_Id", "dbo.SportCathegories");
            DropForeignKey("dbo.SportCathegories", "TeamOrOwn_Id", "dbo.TeamOrOwns");
            DropForeignKey("dbo.SportCathegories", "Sport_Id", "dbo.Sports");
            DropForeignKey("dbo.SportCathegories", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.SportCathegoryAthlets", "Athlet_Id", "dbo.Athlets");
            DropForeignKey("dbo.SportCathegoryAthlets", "SportCathegory_Id", "dbo.SportCathegories");
            DropForeignKey("dbo.Medals", "MedalType_Id", "dbo.MedalTypes");
            DropForeignKey("dbo.Athlets", "Country_Id", "dbo.Countries");
            DropIndex("dbo.StageAthlets", new[] { "Athlet_Id" });
            DropIndex("dbo.StageAthlets", new[] { "Stage_Id" });
            DropIndex("dbo.SportCathegoryAthlets", new[] { "Athlet_Id" });
            DropIndex("dbo.SportCathegoryAthlets", new[] { "SportCathegory_Id" });
            DropIndex("dbo.StageForTeams", new[] { "RaceForTeam_Id" });
            DropIndex("dbo.StageForTeams", new[] { "Race_Id" });
            DropIndex("dbo.StageForTeams", new[] { "Id" });
            DropIndex("dbo.RaceForTeams", new[] { "Winner_Id" });
            DropIndex("dbo.RaceForTeams", new[] { "Third_Id" });
            DropIndex("dbo.RaceForTeams", new[] { "SportCathegory_Id" });
            DropIndex("dbo.RaceForTeams", new[] { "Second_Id" });
            DropIndex("dbo.RaceForTeams", new[] { "Id" });
            DropIndex("dbo.Teams", new[] { "SportCathegory_Id" });
            DropIndex("dbo.Teams", new[] { "Country_Id" });
            DropIndex("dbo.Teams", new[] { "Id" });
            DropIndex("dbo.OppositeTeams", new[] { "StageForTeam_Id" });
            DropIndex("dbo.OppositeTeams", new[] { "Team2_Id" });
            DropIndex("dbo.OppositeTeams", new[] { "Team1_Id" });
            DropIndex("dbo.OppositeTeams", new[] { "Id" });
            DropIndex("dbo.Stages", new[] { "Race_Id" });
            DropIndex("dbo.Stages", new[] { "Id" });
            DropIndex("dbo.Races", new[] { "Winner_Id" });
            DropIndex("dbo.Races", new[] { "Third_Id" });
            DropIndex("dbo.Races", new[] { "SportCathegory_Id" });
            DropIndex("dbo.Races", new[] { "Second_Id" });
            DropIndex("dbo.Races", new[] { "Id" });
            DropIndex("dbo.RaceDegrees", new[] { "Athlet_Id" });
            DropIndex("dbo.RaceDegrees", new[] { "SportCathegory_Id" });
            DropIndex("dbo.RaceDegrees", new[] { "Race_Id" });
            DropIndex("dbo.RaceDegrees", new[] { "Id" });
            DropIndex("dbo.Sports", new[] { "Id" });
            DropIndex("dbo.Genders", new[] { "Id" });
            DropIndex("dbo.SportCathegories", new[] { "TeamOrOwn_Id" });
            DropIndex("dbo.SportCathegories", new[] { "Sport_Id" });
            DropIndex("dbo.SportCathegories", new[] { "Gender_Id" });
            DropIndex("dbo.SportCathegories", new[] { "Id" });
            DropIndex("dbo.MedalTypes", new[] { "Id" });
            DropIndex("dbo.Medals", new[] { "Team_Id" });
            DropIndex("dbo.Medals", new[] { "Athlet_Id" });
            DropIndex("dbo.Medals", new[] { "Country_Id" });
            DropIndex("dbo.Medals", new[] { "SportCathegory_Id" });
            DropIndex("dbo.Medals", new[] { "MedalType_Id" });
            DropIndex("dbo.Medals", new[] { "Id" });
            DropIndex("dbo.Countries", new[] { "Id" });
            DropIndex("dbo.Athlets", new[] { "Team_Id" });
            DropIndex("dbo.Athlets", new[] { "Sport_Id" });
            DropIndex("dbo.Athlets", new[] { "Gender_Id" });
            DropIndex("dbo.Athlets", new[] { "Country_Id" });
            DropIndex("dbo.Athlets", new[] { "Id" });
            DropTable("dbo.StageAthlets");
            DropTable("dbo.SportCathegoryAthlets");
            DropTable("dbo.StageForTeams");
            DropTable("dbo.RaceForTeams");
            DropTable("dbo.Teams");
            DropTable("dbo.OppositeTeams");
            DropTable("dbo.Stages");
            DropTable("dbo.Races");
            DropTable("dbo.RaceDegrees");
            DropTable("dbo.TeamOrOwns");
            DropTable("dbo.Sports");
            DropTable("dbo.Genders");
            DropTable("dbo.SportCathegories");
            DropTable("dbo.MedalTypes");
            DropTable("dbo.Medals");
            DropTable("dbo.Countries");
            DropTable("dbo.Athlets");
        }
    }
}
