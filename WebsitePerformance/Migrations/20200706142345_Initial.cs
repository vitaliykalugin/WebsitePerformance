using Microsoft.EntityFrameworkCore.Migrations;

namespace WebsitePerformance.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PerformanceSitemaps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseUri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceSitemaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UriPerformances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uri = table.Column<string>(nullable: true),
                    MaxTime = table.Column<long>(nullable: false),
                    MinTime = table.Column<long>(nullable: false),
                    AverageTime = table.Column<double>(nullable: false),
                    PerformanceSitemapId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UriPerformances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UriPerformances_PerformanceSitemaps_PerformanceSitemapId",
                        column: x => x.PerformanceSitemapId,
                        principalTable: "PerformanceSitemaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UriPerformances_PerformanceSitemapId",
                table: "UriPerformances",
                column: "PerformanceSitemapId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UriPerformances");

            migrationBuilder.DropTable(
                name: "PerformanceSitemaps");
        }
    }
}
