using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareNet_System.Migrations
{
    /// <inheritdoc />
    public partial class YourMigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Doctors_followUp_doctorID",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_Patients_followUp_doctorID",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "Staff",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "experience_years",
                table: "Staff",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "seniority_level",
                table: "Staff",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "treatment",
                table: "Patients",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    total_amount = table.Column<double>(type: "float", nullable: false),
                    Payment_Method = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    insurance_id = table.Column<int>(type: "int", nullable: false),
                    patient_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_followUp_doctorID",
                table: "Patients",
                column: "followUp_doctorID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_patient_id",
                table: "Bills",
                column: "patient_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Staff_followUp_doctorID",
                table: "Patients",
                column: "followUp_doctorID",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Staff_followUp_doctorID",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Patients_followUp_doctorID",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "experience_years",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "seniority_level",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "treatment",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dept_id = table.Column<int>(type: "int", nullable: false),
                    experience_years = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    seniority_level = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_dept_id",
                        column: x => x.dept_id,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patient_id = table.Column<int>(type: "int", nullable: false),
                    dosage = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medications_Patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    official_id = table.Column<int>(type: "int", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    item_Id = table.Column<int>(type: "int", nullable: false),
                    item_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouse_Staff_official_id",
                        column: x => x.official_id,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_followUp_doctorID",
                table: "Patients",
                column: "followUp_doctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_dept_id",
                table: "Doctors",
                column: "dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_Medications_patient_id",
                table: "Medications",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_official_id",
                table: "Warehouse",
                column: "official_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Doctors_followUp_doctorID",
                table: "Patients",
                column: "followUp_doctorID",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
