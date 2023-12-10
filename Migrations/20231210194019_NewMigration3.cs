using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "Appointments");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "timeTo",
                table: "WorkingHours",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "timeFrom",
                table: "WorkingHours",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "WorkingHours",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Patients",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Unknown_person.jpg",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Unknown_person.jpg");

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "Patients",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Doctors",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Unknown_person.jpg",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Unknown_person.jpg");

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "Doctors",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "doctorCouponID",
                table: "Discounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Admins",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Unknown_person.jpg",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Unknown_person.jpg");

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "Admins",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_doctorCouponID",
                table: "Discounts",
                column: "doctorCouponID");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Doctors_doctorCouponID",
                table: "Discounts",
                column: "doctorCouponID",
                principalTable: "Doctors",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Doctors_doctorCouponID",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_doctorCouponID",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "price",
                table: "WorkingHours");

            migrationBuilder.DropColumn(
                name: "doctorCouponID",
                table: "Discounts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "timeTo",
                table: "WorkingHours",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "timeFrom",
                table: "WorkingHours",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Unknown_person.jpg",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Unknown_person.jpg");

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Unknown_person.jpg",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Unknown_person.jpg");

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "Appointments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Unknown_person.jpg",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Unknown_person.jpg");

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
