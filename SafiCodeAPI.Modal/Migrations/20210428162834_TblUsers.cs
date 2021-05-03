using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SafiCodeAPI.Modal.Migrations
{
    public partial class TblUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_User_Contacts",
                columns: table => new
                {
                    UserContactID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<long>(nullable: false),
                    ContactName = table.Column<string>(maxLength: 250, nullable: false),
                    EmailID = table.Column<string>(maxLength: 250, nullable: false),
                    Title = table.Column<string>(nullable: true),
                    MainPhone = table.Column<string>(maxLength: 20, nullable: true),
                    MobilePhone = table.Column<string>(maxLength: 20, nullable: true),
                    CompanyName = table.Column<string>(maxLength: 250, nullable: true),
                    Address = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<long>(nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyBy = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_User_Contacts", x => x.UserContactID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserType",
                columns: table => new
                {
                    UserTypeID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserType = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserType", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Users",
                columns: table => new
                {
                    UserID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserTypeID = table.Column<long>(nullable: true),
                    FullName = table.Column<string>(maxLength: 400, nullable: true),
                    CompanyName = table.Column<string>(maxLength: 400, nullable: true),
                    EmailID = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 200, nullable: true),
                    MobileNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Industry = table.Column<string>(maxLength: 500, nullable: true),
                    ISTermsCondition = table.Column<bool>(nullable: true),
                    ClientType = table.Column<int>(nullable: true),
                    HouseOfficeNo = table.Column<string>(maxLength: 200, nullable: true),
                    Area = table.Column<string>(maxLength: 300, nullable: true),
                    City = table.Column<string>(maxLength: 200, nullable: true),
                    StateProvince = table.Column<string>(maxLength: 200, nullable: true),
                    Zip = table.Column<string>(maxLength: 20, nullable: true),
                    CountryID = table.Column<long>(nullable: true),
                    CurrencyName = table.Column<string>(maxLength: 200, nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<long>(nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyBy = table.Column<long>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_tbl_Users_tbl_Users",
                        column: x => x.UserTypeID,
                        principalTable: "tbl_UserType",
                        principalColumn: "UserTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Users_UserTypeID",
                table: "tbl_Users",
                column: "UserTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_User_Contacts");

            migrationBuilder.DropTable(
                name: "tbl_Users");

            migrationBuilder.DropTable(
                name: "tbl_UserType");
        }
    }
}
