using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ISUCorp.Reservation.Data.Migrations
{
    public partial class addprocedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetReservationCount]
                    @Count int output
                AS
                BEGIN
                    SET NOCOUNT ON;
                    SELECT  @Count = COUNT(*) from Reservations
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
