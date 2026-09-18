using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullSack.Data.Migrations
{
    /// <inheritdoc />
    public partial class Recipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Position",
                table: "Instructions",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfileImage",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KeywordsRecipes",
                columns: table => new
                {
                    RecipeId = table.Column<string>(type: "NVARCHAR(450)", nullable: false),
                    KeywordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeywordsRecipes", x => new { x.RecipeId, x.KeywordId });
                    table.ForeignKey(
                        name: "FK_KeywordsRecipes_Keywords_KeywordId",
                        column: x => x.KeywordId,
                        principalTable: "Keywords",
                        principalColumn: "KeywordId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeywordsRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_Slug",
                table: "Recipes",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_Category",
                table: "Measurements",
                column: "Category",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_Symbol",
                table: "Measurements",
                column: "Symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Keywords_Title",
                table: "Keywords",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KeywordCategories_Title",
                table: "KeywordCategories",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KeywordsRecipes_KeywordId",
                table: "KeywordsRecipes",
                column: "KeywordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeywordsRecipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_Slug",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_Category",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_Symbol",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Keywords_Title",
                table: "Keywords");

            migrationBuilder.DropIndex(
                name: "IX_KeywordCategories_Title",
                table: "KeywordCategories");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Instructions");

            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "AspNetUsers");
        }
    }
}
