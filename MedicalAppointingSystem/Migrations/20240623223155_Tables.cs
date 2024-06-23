using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalAppointingSystem.Migrations
{
    /// <inheritdoc />
    public partial class Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiagnosisPatient");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_DiagnosisId",
                table: "Patient",
                column: "DiagnosisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Diagnosis_DiagnosisId",
                table: "Patient",
                column: "DiagnosisId",
                principalTable: "Diagnosis",
                principalColumn: "DiagnosisId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Diagnosis_DiagnosisId",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Patient_DiagnosisId",
                table: "Patient");

            migrationBuilder.CreateTable(
                name: "DiagnosisPatient",
                columns: table => new
                {
                    Patient = table.Column<int>(type: "int", nullable: false),
                    PatientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisPatient", x => new { x.Patient, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_DiagnosisPatient_Diagnosis_Patient",
                        column: x => x.Patient,
                        principalTable: "Diagnosis",
                        principalColumn: "DiagnosisId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiagnosisPatient_Patient_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patient",
                        principalColumn: "PatientsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisPatient_PatientsId",
                table: "DiagnosisPatient",
                column: "PatientsId");
        }
    }
}
