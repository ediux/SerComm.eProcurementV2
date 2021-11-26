using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SerComm.eProcurementV2.Migrations
{
    public partial class addpotabledetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ePrV2_PurchaseOrderDetails",
                columns: table => new
                {
                    uid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mt_list = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    el_no = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    vender_no = table.Column<string>(type: "nchar(30)", maxLength: 30, nullable: true),
                    vender_name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true, defaultValue: ""),
                    ch_sort_no = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
                    ch_sort_name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    reply_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    remark = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    factory_no = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    epr_status = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false, defaultValue: "99"),
                    arn_type = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true, defaultValue: ""),
                    asn_no = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true, defaultValue: ""),
                    asn_qty = table.Column<decimal>(type: "decimal(24,4)", precision: 24, scale: 4, nullable: true, defaultValue: 0m),
                    asn_code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: ""),
                    code_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    code_user = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValue: ""),
                    erp_code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValue: ""),
                    code_mark = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true, defaultValue: ""),
                    po_no = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValue: ""),
                    arn_app_no = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValue: ""),
                    asn_cancel = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true, defaultValue: ""),
                    corp_no = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true, defaultValue: ""),
                    ch_acqty = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValue: "0"),
                    ch_caqty = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: true, defaultValue: 0m),
                    asn_sure = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValue: ""),
                    el_min = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: true, defaultValue: 0m),
                    el_eoq = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: true, defaultValue: 0m),
                    asn_acqty = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: true, defaultValue: 0m),
                    el_abc = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true, defaultValue: ""),
                    oper_time = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2021, 11, 19, 14, 0, 49, 647, DateTimeKind.Local).AddTicks(9520)),
                    version_no = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValue: ""),
                    org_asn_qty = table.Column<decimal>(type: "decimal(24,4)", precision: 24, scale: 4, nullable: true, defaultValue: 0m),
                    org_reply_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    split_uid = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValue: ""),
                    invoice_no = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, defaultValue: ""),
                    plant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    commit_qty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    shipping_qty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    etd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ep_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    delivery_date = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    shipper = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ship_to = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    bill_to = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    port_loading = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    port_delivery = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    bill_no = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ship_term = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ePrV2_PurchaseOrderDetails", x => x.uid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ePrV2_PurchaseOrderDetails");
        }
    }
}
