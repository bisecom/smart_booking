namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataSbMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BusinessId = c.Int(nullable: false),
                        WebpageLink = c.String(),
                        IsEntityLogoRemoved = c.Boolean(nullable: false),
                        IsMemberSelecting = c.Boolean(nullable: false),
                        SlotDuration = c.Int(nullable: false),
                        PageLanguageId = c.Int(),
                        BannerPicture = c.Binary(),
                        SklypeLink = c.String(),
                        FacebookLink = c.String(),
                        TwitterLink = c.String(),
                        InstagramkLink = c.String(),
                        YoutubeLink = c.String(),
                        PageOverview = c.String(),
                        IsContactsAvailable = c.Boolean(nullable: false),
                        IsServicesAvailable = c.Boolean(nullable: false),
                        IsPriceAvailable = c.Boolean(nullable: false),
                        IsDurationAvailable = c.Boolean(nullable: false),
                        IsDescriptionAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BusinessId)
                .ForeignKey("dbo.Businesses", t => t.BusinessId)
                .Index(t => t.BusinessId);
            
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        CountryId = c.Int(),
                        CurrencyId = c.Int(),
                        Time_zoneId = c.Int(),
                        Logo = c.Binary(),
                        Webpage = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        RegistrationNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.Time_zone", t => t.Time_zoneId)
                .ForeignKey("dbo.Currencies", t => t.CurrencyId)
                .Index(t => t.CountryId)
                .Index(t => t.CurrencyId)
                .Index(t => t.Time_zoneId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusinessId = c.Int(),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        ClientCompanyName = c.String(),
                        Email = c.String(),
                        MobilePhone = c.String(),
                        OfficePhone = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip_Code = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                        Image = c.Binary(),
                        IsMale = c.Boolean(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Businesses", t => t.BusinessId)
                .Index(t => t.BusinessId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Native = c.String(),
                        PhonePrefix = c.String(),
                        Capital = c.String(),
                        Currency_ = c.String(),
                        Emoji = c.String(),
                        EmojiU = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Time_zone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Zone = c.String(),
                        CountryCode = c.String(),
                        UTC_Jan_1_2020 = c.String(),
                        DST_Jul_1_2020 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        PhoneMobile = c.String(),
                        PhoneOffice = c.String(),
                        CountryId = c.Int(),
                        Time_ZoneId = c.Int(),
                        UserPicture = c.Binary(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        PlanId = c.Int(nullable: false),
                        PaymentOverdue = c.Byte(),
                        IsMale = c.Boolean(),
                        Birthdate = c.DateTime(),
                        MUserRoleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.MUserRoles", t => t.MUserRoleId)
                .ForeignKey("dbo.Time_zone", t => t.Time_ZoneId)
                .Index(t => t.CountryId)
                .Index(t => t.Time_ZoneId)
                .Index(t => t.MUserRoleId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusinessId = c.Int(),
                        UserId = c.Int(),
                        IsOwner = c.Boolean(nullable: false),
                        Slot_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Businesses", t => t.BusinessId)
                .ForeignKey("dbo.Slots", t => t.Slot_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.BusinessId)
                .Index(t => t.Slot_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.CalendarSettings",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        View = c.Int(nullable: false),
                        FirstHour = c.DateTime(nullable: false),
                        WorkingDayDuration = c.Int(nullable: false),
                        SlotDuration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.CustomerNotifications",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        AfterBooked = c.Boolean(nullable: false),
                        AfterRescheduled = c.Boolean(nullable: false),
                        AfterCancelled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        IsSummary = c.Boolean(nullable: false),
                        IsOthersCalendar = c.Boolean(nullable: false),
                        IsClients = c.Boolean(nullable: false),
                        IsServices = c.Boolean(nullable: false),
                        IsReports = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Slots",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        EmployeeId = c.Int(),
                        CountryId = c.Int(nullable: false),
                        SlotDateTime = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        IsPadding = c.Boolean(nullable: false),
                        PaddingAfter = c.Int(nullable: false),
                        Reiteration = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        ResponsibleId = c.Int(nullable: false),
                        Note = c.String(),
                        Status = c.String(),
                        IsTimeBlock = c.Boolean(nullable: false),
                        IsReminderNeeded = c.Boolean(nullable: false),
                        ReminderInterval = c.Int(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.ResponsibleId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Id)
                .Index(t => t.CountryId)
                .Index(t => t.ResponsibleId)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusinessId = c.Int(),
                        CategoryId = c.Int(),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Single(nullable: false),
                        Duration = c.Int(nullable: false),
                        PaddingAfter = c.Int(nullable: false),
                        Picture = c.Binary(),
                        ServiceCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Businesses", t => t.BusinessId)
                .ForeignKey("dbo.ServiceCategories", t => t.ServiceCategory_Id)
                .Index(t => t.BusinessId)
                .Index(t => t.ServiceCategory_Id);
            
            CreateTable(
                "dbo.ServiceCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeamNotifications",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        AfterBooked = c.Boolean(nullable: false),
                        AfterRescheduled = c.Boolean(nullable: false),
                        Collegue = c.Boolean(nullable: false),
                        CollegueAndOwner = c.Boolean(nullable: false),
                        Owner = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.WorkingHours",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        MondayStart = c.DateTime(nullable: false),
                        MondayStop = c.DateTime(nullable: false),
                        TuesdayStart = c.DateTime(nullable: false),
                        TuesdayStop = c.DateTime(nullable: false),
                        WednesdayStart = c.DateTime(nullable: false),
                        WednesdayStop = c.DateTime(nullable: false),
                        ThursdayStart = c.DateTime(nullable: false),
                        ThursdayStop = c.DateTime(nullable: false),
                        FridayStart = c.DateTime(nullable: false),
                        FridayStop = c.DateTime(nullable: false),
                        SaturdayStart = c.DateTime(nullable: false),
                        SaturdayStop = c.DateTime(nullable: false),
                        SundayStart = c.DateTime(nullable: false),
                        SundayStop = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.WorkingBreaks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkingHourId = c.Int(),
                        WeekDay = c.Int(nullable: false),
                        BreakStart = c.DateTime(nullable: false),
                        BreakStop = c.DateTime(nullable: false),
                        WorkingHour_EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkingHours", t => t.WorkingHour_EmployeeId)
                .Index(t => t.WorkingHour_EmployeeId);
            
            CreateTable(
                "dbo.MUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Time_zoneCountry",
                c => new
                    {
                        Time_zone_Id = c.Int(nullable: false),
                        Country_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Time_zone_Id, t.Country_Id })
                .ForeignKey("dbo.Time_zone", t => t.Time_zone_Id, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.Country_Id, cascadeDelete: true)
                .Index(t => t.Time_zone_Id)
                .Index(t => t.Country_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "BusinessId", "dbo.Businesses");
            DropForeignKey("dbo.Businesses", "CurrencyId", "dbo.Currencies");
            DropForeignKey("dbo.Users", "Time_ZoneId", "dbo.Time_zone");
            DropForeignKey("dbo.Users", "MUserRoleId", "dbo.MUserRoles");
            DropForeignKey("dbo.WorkingBreaks", "WorkingHour_EmployeeId", "dbo.WorkingHours");
            DropForeignKey("dbo.WorkingHours", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TeamNotifications", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Slots", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Slot_Id", "dbo.Slots");
            DropForeignKey("dbo.Slots", "Id", "dbo.Services");
            DropForeignKey("dbo.Services", "ServiceCategory_Id", "dbo.ServiceCategories");
            DropForeignKey("dbo.Services", "BusinessId", "dbo.Businesses");
            DropForeignKey("dbo.Slots", "ResponsibleId", "dbo.Employees");
            DropForeignKey("dbo.Slots", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Permissions", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CustomerNotifications", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CalendarSettings", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "BusinessId", "dbo.Businesses");
            DropForeignKey("dbo.Users", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Time_zoneCountry", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Time_zoneCountry", "Time_zone_Id", "dbo.Time_zone");
            DropForeignKey("dbo.Businesses", "Time_zoneId", "dbo.Time_zone");
            DropForeignKey("dbo.Businesses", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Clients", "BusinessId", "dbo.Businesses");
            DropIndex("dbo.Time_zoneCountry", new[] { "Country_Id" });
            DropIndex("dbo.Time_zoneCountry", new[] { "Time_zone_Id" });
            DropIndex("dbo.WorkingBreaks", new[] { "WorkingHour_EmployeeId" });
            DropIndex("dbo.WorkingHours", new[] { "EmployeeId" });
            DropIndex("dbo.TeamNotifications", new[] { "EmployeeId" });
            DropIndex("dbo.Services", new[] { "ServiceCategory_Id" });
            DropIndex("dbo.Services", new[] { "BusinessId" });
            DropIndex("dbo.Slots", new[] { "Employee_Id" });
            DropIndex("dbo.Slots", new[] { "ResponsibleId" });
            DropIndex("dbo.Slots", new[] { "CountryId" });
            DropIndex("dbo.Slots", new[] { "Id" });
            DropIndex("dbo.Permissions", new[] { "EmployeeId" });
            DropIndex("dbo.CustomerNotifications", new[] { "EmployeeId" });
            DropIndex("dbo.CalendarSettings", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "User_Id" });
            DropIndex("dbo.Employees", new[] { "Slot_Id" });
            DropIndex("dbo.Employees", new[] { "BusinessId" });
            DropIndex("dbo.Users", new[] { "MUserRoleId" });
            DropIndex("dbo.Users", new[] { "Time_ZoneId" });
            DropIndex("dbo.Users", new[] { "CountryId" });
            DropIndex("dbo.Clients", new[] { "BusinessId" });
            DropIndex("dbo.Businesses", new[] { "Time_zoneId" });
            DropIndex("dbo.Businesses", new[] { "CurrencyId" });
            DropIndex("dbo.Businesses", new[] { "CountryId" });
            DropIndex("dbo.Bookings", new[] { "BusinessId" });
            DropTable("dbo.Time_zoneCountry");
            DropTable("dbo.Currencies");
            DropTable("dbo.MUserRoles");
            DropTable("dbo.WorkingBreaks");
            DropTable("dbo.WorkingHours");
            DropTable("dbo.TeamNotifications");
            DropTable("dbo.ServiceCategories");
            DropTable("dbo.Services");
            DropTable("dbo.Slots");
            DropTable("dbo.Permissions");
            DropTable("dbo.CustomerNotifications");
            DropTable("dbo.CalendarSettings");
            DropTable("dbo.Employees");
            DropTable("dbo.Users");
            DropTable("dbo.Time_zone");
            DropTable("dbo.Countries");
            DropTable("dbo.Clients");
            DropTable("dbo.Businesses");
            DropTable("dbo.Bookings");
        }
    }
}
