using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Monitoramento.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "veiculo",
                columns: table => new
                {
                    codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marca = table.Column<string>(nullable: true),
                    modelo = table.Column<string>(nullable: true),
                    anoFabricacao = table.Column<string>(nullable: true),
                    veiculo_fk_usuario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo", x => x.codigo);
                    table.ForeignKey(
                        name: "FK_veiculo_usuario_veiculo_fk_usuario",
                        column: x => x.veiculo_fk_usuario,
                        principalTable: "usuario",
                        principalColumn: "codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "resumoUltimaViagem",
                columns: table => new
                {
                    codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    consumo = table.Column<double>(nullable: false),
                    notaConducao = table.Column<double>(nullable: false),
                    distancia = table.Column<double>(nullable: false),
                    distanciaAbastecimento = table.Column<double>(nullable: false),
                    avarias = table.Column<int>(nullable: false),
                    proximaRevisao = table.Column<double>(nullable: false),
                    origem = table.Column<string>(nullable: true),
                    destino = table.Column<string>(nullable: true),
                    resumo_fk_veiculo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resumoUltimaViagem", x => x.codigo);
                    table.ForeignKey(
                        name: "FK_resumoUltimaViagem_veiculo_resumo_fk_veiculo",
                        column: x => x.resumo_fk_veiculo,
                        principalTable: "veiculo",
                        principalColumn: "codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_resumoUltimaViagem_resumo_fk_veiculo",
                table: "resumoUltimaViagem",
                column: "resumo_fk_veiculo");

            migrationBuilder.CreateIndex(
                name: "IX_veiculo_veiculo_fk_usuario",
                table: "veiculo",
                column: "veiculo_fk_usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "resumoUltimaViagem");

            migrationBuilder.DropTable(
                name: "veiculo");
        }
    }
}
