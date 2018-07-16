using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaProject.Context.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationId = table.Column<int>(nullable: false),
                    Dough = table.Column<double>(nullable: false),
                    TomatoSauce = table.Column<double>(nullable: false),
                    WhiteSauce = table.Column<double>(nullable: false),
                    Cheese = table.Column<double>(nullable: false),
                    Pepperoni = table.Column<double>(nullable: false),
                    Ham = table.Column<double>(nullable: false),
                    Chicken = table.Column<double>(nullable: false),
                    Beef = table.Column<double>(nullable: false),
                    Sausage = table.Column<double>(nullable: false),
                    Bacon = table.Column<double>(nullable: false),
                    Anchovies = table.Column<double>(nullable: false),
                    RedPeppers = table.Column<double>(nullable: false),
                    GreenPeppers = table.Column<double>(nullable: false),
                    Pineapple = table.Column<double>(nullable: false),
                    Olives = table.Column<double>(nullable: false),
                    Mushrooms = table.Column<double>(nullable: false),
                    Garlic = table.Column<double>(nullable: false),
                    Onions = table.Column<double>(nullable: false),
                    Tomatoes = table.Column<double>(nullable: false),
                    Spinach = table.Column<double>(nullable: false),
                    Basil = table.Column<double>(nullable: false),
                    Ricotta = table.Column<double>(nullable: false),
                    Parmesan = table.Column<double>(nullable: false),
                    Feta = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    InventoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<decimal>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<decimal>(nullable: false),
                    Crust = table.Column<string>(nullable: true),
                    Sauce = table.Column<string>(nullable: true),
                    Cheese = table.Column<string>(nullable: true),
                    Topping1 = table.Column<string>(nullable: true),
                    Topping2 = table.Column<string>(nullable: true),
                    Topping3 = table.Column<string>(nullable: true),
                    Topping4 = table.Column<string>(nullable: true),
                    Topping5 = table.Column<string>(nullable: true),
                    Topping6 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
