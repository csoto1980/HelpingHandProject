using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpingHand.Data.Migrations
{
    public partial class attemptingjointables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keywords_Donors_DonorId",
                table: "Keywords");

            migrationBuilder.DropForeignKey(
                name: "FK_Keywords_Organizations_OrganizationId",
                table: "Keywords");

            migrationBuilder.DropIndex(
                name: "IX_Keywords_DonorId",
                table: "Keywords");

            migrationBuilder.DropIndex(
                name: "IX_Keywords_OrganizationId",
                table: "Keywords");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f3d80c4-2f52-4135-94b2-c96785d0bbbf");

            migrationBuilder.DropColumn(
                name: "KeywordId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "DonorId",
                table: "Keywords");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Keywords");

            migrationBuilder.DropColumn(
                name: "KeywordId",
                table: "Donors");

            migrationBuilder.CreateTable(
                name: "DonorKeyword",
                columns: table => new
                {
                    KeywordId = table.Column<int>(nullable: false),
                    DonorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorKeyword", x => new { x.DonorId, x.KeywordId });
                    table.ForeignKey(
                        name: "FK_DonorKeyword_Donors_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donors",
                        principalColumn: "DonorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonorKeyword_Keywords_KeywordId",
                        column: x => x.KeywordId,
                        principalTable: "Keywords",
                        principalColumn: "KeywordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationKeyword",
                columns: table => new
                {
                    KeywordId = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationKeyword", x => new { x.OrganizationId, x.KeywordId });
                    table.ForeignKey(
                        name: "FK_OrganizationKeyword_Keywords_KeywordId",
                        column: x => x.KeywordId,
                        principalTable: "Keywords",
                        principalColumn: "KeywordId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationKeyword_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "31122a12-6f92-4091-b089-c916aa282646", "09dd57aa-9a08-4e49-9616-cd0537803623", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_DonorKeyword_KeywordId",
                table: "DonorKeyword",
                column: "KeywordId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationKeyword_KeywordId",
                table: "OrganizationKeyword",
                column: "KeywordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonorKeyword");

            migrationBuilder.DropTable(
                name: "OrganizationKeyword");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31122a12-6f92-4091-b089-c916aa282646");

            migrationBuilder.AddColumn<int>(
                name: "KeywordId",
                table: "Organizations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DonorId",
                table: "Keywords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Keywords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KeywordId",
                table: "Donors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7f3d80c4-2f52-4135-94b2-c96785d0bbbf", "5dd6339d-83b9-41f8-be27-a9cecf064e7e", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Keywords_DonorId",
                table: "Keywords",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Keywords_OrganizationId",
                table: "Keywords",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Keywords_Donors_DonorId",
                table: "Keywords",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "DonorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Keywords_Organizations_OrganizationId",
                table: "Keywords",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
