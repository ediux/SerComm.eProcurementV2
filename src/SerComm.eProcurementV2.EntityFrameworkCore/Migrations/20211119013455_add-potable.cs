using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SerComm.eProcurementV2.Migrations
{
    public partial class addpotable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ePrV2_PurchaseOrders",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mt_list = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    el_no = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    mt_replace = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    version_no = table.Column<string>(type: "nchar(20)", maxLength: 20, nullable: true),
                    vender_no = table.Column<string>(type: "nchar(30)", maxLength: 30, nullable: true),
                    vender_name = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: true),
                    ch_sort_no = table.Column<string>(type: "nchar(30)", maxLength: 30, nullable: true),
                    ch_sort_name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    IQC = table.Column<double>(type: "float", nullable: true),
                    lack_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lack_num = table.Column<double>(type: "float", nullable: false),
                    reply_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    remark = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    factory_no = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    corp_no = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    epr_status = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true, defaultValue: "99"),
                    po_no = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    arn_type = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    asn_no = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    asn_qty = table.Column<decimal>(type: "decimal(24,4)", precision: 24, scale: 4, nullable: false),
                    ch_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    asn_code = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    code_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    code_user = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    erp_code = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    code_mark = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ch_acqty = table.Column<double>(type: "float", nullable: true),
                    buyer_sure = table.Column<DateTime>(type: "datetime2", nullable: true),
                    vender_sure = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ch_caqty = table.Column<decimal>(type: "decimal(24,4)", precision: 24, scale: 4, nullable: true),
                    arn_app_no = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    asn_cancel = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    ch_kqty = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: true),
                    el_min = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: true),
                    el_eoq = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: true),
                    asn_acqty = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: true),
                    split_uid = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    el_abc = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ePrV2_PurchaseOrders", x => x.uid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ePrV2_PurchaseOrders");
        }
    }
}
