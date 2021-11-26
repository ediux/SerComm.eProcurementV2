using Microsoft.EntityFrameworkCore;

using SerComm.eProcurementV2.Data;

using System;

using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace SerComm.eProcurementV2.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(IIdentityDbContext))]
    [ReplaceDbContext(typeof(ITenantManagementDbContext))]
    [ConnectionStringName("Default")]
    public class eProcurementV2DbContext :
        AbpDbContext<eProcurementV2DbContext>,
        IIdentityDbContext,
        ITenantManagementDbContext
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */

        #region Entities from the modules

        /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
         * and replaced them for this DbContext. This allows you to perform JOIN
         * queries for the entities of these modules over the repositories easily. You
         * typically don't need that for other modules. But, if you need, you can
         * implement the DbContext interface of the needed module and use ReplaceDbContext
         * attribute just like IIdentityDbContext and ITenantManagementDbContext.
         *
         * More info: Replacing a DbContext of a module ensures that the related module
         * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
         */

        //Identity
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityClaimType> ClaimTypes { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
        public DbSet<IdentityLinkUser> LinkUsers { get; set; }

        // Tenant Management
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

        #endregion

        #region Entitites from eProcurement V2.0
        /// <summary>
        /// 採購單主檔
        /// </summary>
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        /// <summary>
        /// 採購明細檔
        /// </summary>
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        #endregion
        public eProcurementV2DbContext(DbContextOptions<eProcurementV2DbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();

            /* Configure your own tables/entities inside here */
            ConfigurePurchaseOrder(builder);
            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(eProcurementV2Consts.DbTablePrefix + "YourEntities", eProcurementV2Consts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }

        /// <summary>
        /// 設定採購單資料表結構組態
        /// </summary>
        /// <param name="builder"></param>
        private void ConfigurePurchaseOrder(ModelBuilder builder)
        {
            builder.Entity<PurchaseOrder>(b =>
            {
                //主檔
                b.ToTable(eProcurementV2Consts.DbTablePrefix + nameof(PurchaseOrders), eProcurementV2Consts.DbSchema);

                b.Property(p => p.Id)
                    .HasColumnName("uid")
                    .UseIdentityColumn();

                b.Property(p => p.mt_list)
                    .IsUnicode(false)
                    .HasMaxLength(50)
                    .IsRequired();

                b.Property(p => p.el_no)
                    .IsUnicode(true)
                    .HasMaxLength(200)
                    .IsRequired();

                b.Property(p => p.mt_replace)
                    .IsUnicode(false)
                    .HasMaxLength(30);

                b.Property(p => p.version_no)
                    .IsFixedLength()
                    .IsUnicode()
                    .HasMaxLength(20);

                b.Property(p => p.vender_no)
                    .IsFixedLength()
                    .IsUnicode()
                    .HasMaxLength(30);

                b.Property(p => p.vender_name)
                    .IsUnicode(true)
                    .HasMaxLength(180);

                b.Property(p => p.ch_sort_no)
                    .IsFixedLength()
                    .IsUnicode()
                    .HasMaxLength(30);

                b.Property(p => p.ch_sort_name)
                    .IsUnicode(true)
                    .HasMaxLength(80);

                b.Property(p => p.lack_date)
                    .IsRequired();

                b.Property(p => p.lack_num)
                    .IsRequired();

                b.Property(p => p.remark)
                    .IsUnicode(true)
                    .HasMaxLength(200);
                
                b.Property(p => p.factory_no)
                .IsUnicode(false)
                .HasMaxLength(20);
                
                b.Property(p => p.corp_no)
                .IsUnicode(false)
                .HasMaxLength(20);

                b.Property(p => p.epr_status)
                .IsUnicode(false)
                .HasMaxLength(4)
                .HasDefaultValue("99");

                b.Property(p => p.po_no)
                .IsUnicode(false)
                .HasMaxLength(20);

                b.Property(p => p.arn_type)
                .IsUnicode(false)
                .HasMaxLength(4);

                b.Property(p=>p.asn_no)
                .IsUnicode(false)
                .HasMaxLength(100);

                b.Property(p => p.asn_qty)
                .HasPrecision(24, 4);

                b.Property(p => p.asn_code)
                .IsUnicode(false)
                .HasMaxLength(1);

                b.Property(p => p.code_user)
                .IsUnicode(false)
                .HasMaxLength(20);

                b.Property(p => p.erp_code)
                .IsUnicode(false)
                .HasMaxLength(1);

                b.Property(p => p.code_mark)
                .IsUnicode(false)
                .HasMaxLength(100);

                b.Property(p => p.ch_caqty)
                .HasPrecision(24, 4);

                b.Property(p => p.arn_app_no)
                .IsUnicode(false)
                .HasMaxLength(50);

                b.Property(p => p.asn_cancel)
                .IsUnicode(false)
                .HasMaxLength(2);

                b.Property(p => p.ch_kqty)
                .HasPrecision(18, 0);

                b.Property(p => p.el_min)
                .HasPrecision(18, 0);

                b.Property(p => p.el_eoq)
                .HasPrecision(18, 0);

                b.Property(p => p.asn_acqty)
                .HasPrecision(18, 0);

                b.Property(p => p.split_uid)
                .IsUnicode(false)
                .HasMaxLength(50);

                b.Property(p => p.el_abc)
                .IsUnicode(false)
                .HasMaxLength(2);

                b.ConfigureByConvention(); //auto configure for the base class props               
            });

            builder.Entity<PurchaseOrderDetail>(b => { 
                b.ToTable(eProcurementV2Consts.DbTablePrefix + nameof(PurchaseOrderDetails), eProcurementV2Consts.DbSchema);

                b.Property(p => p.Id)
                .HasColumnName("uid")
                .UseIdentityColumn();

                b.Property(p => p.mt_list)
                .IsUnicode(false)
                .HasMaxLength(30)
                .IsRequired();

                b.Property(p => p.el_no)
                .IsUnicode()
                .HasMaxLength(100)
                .IsRequired();

                b.Property(p => p.vender_no)
                .IsUnicode()
                .IsFixedLength()
                .HasMaxLength(30);

                b.Property(p => p.vender_name)
                .IsUnicode()
                .HasMaxLength(80)
                .HasDefaultValue(string.Empty);

                b.Property(p => p.ch_sort_no)
                .IsFixedLength()
                .IsUnicode()
                .HasMaxLength(30);

                b.Property(p => p.ch_sort_name)
                .IsUnicode()
                .HasMaxLength(80);

                b.Property(p => p.remark)
                .IsUnicode()
                .HasMaxLength(200);

                b.Property(p => p.factory_no)
                .IsUnicode(false)
                .HasMaxLength(20);

                b.Property(p => p.epr_status)
                .IsUnicode(false)
                .HasMaxLength(4)
                .IsRequired()
                .HasDefaultValue("99");

                b.Property(p => p.arn_type)
                .IsUnicode(false)
                .HasMaxLength(4)
                .HasDefaultValue(string.Empty);

                b.Property(p => p.asn_no)
                .IsUnicode(false)
                .HasMaxLength(100)
                .HasDefaultValue(string.Empty);

                b.Property(p => p.asn_qty)
                .HasPrecision(24, 4)
                .HasDefaultValue((decimal)0.0000);

                b.Property(p => p.asn_code)
                .IsUnicode()
                .HasMaxLength(50)
                .HasDefaultValue(string.Empty);

                b.Property(p => p.code_user)
                .IsUnicode(false)
                .HasMaxLength(20)
                .HasDefaultValue(string.Empty);

                b.Property(p => p.erp_code)
                .IsUnicode()
                .HasMaxLength(50)
                .HasDefaultValue(string.Empty);

                b.Property(p => p.code_mark)
                .IsUnicode(false)
                .HasMaxLength(100)
                .HasDefaultValue(string.Empty);

                b.Property(p => p.po_no)
                .IsUnicode(false)
                .HasMaxLength(20)
                .HasDefaultValue(string.Empty);

                b.Property(p => p.arn_app_no)
                .IsUnicode(false)
                .HasMaxLength(50)
                .HasDefaultValue(string.Empty);

                b.Property(p => p.asn_cancel)
                .IsUnicode(false)
                .HasMaxLength(2)
                .HasDefaultValue(string.Empty);

                b.Property(p => p.corp_no)
                .IsUnicode(false)
                .HasMaxLength(10)
                .HasDefaultValue(string.Empty);

                b.Property(p => p.ch_acqty)
                .IsUnicode(false)
                .HasMaxLength(50)
                .HasDefaultValue("0");

                b.Property(p => p.ch_caqty)
                .HasPrecision(18, 0)
                .HasDefaultValue((decimal)0);

                b.Property(p => p.asn_sure)
                .IsUnicode(false)
                .HasMaxLength(50)
                .HasDefaultValue(string.Empty);

                b.Property(p => p.el_min)
                .HasPrecision(18, 0)
                .HasDefaultValue((decimal)0);

                b.Property(p => p.el_eoq)
                .HasPrecision(18, 0)
                .HasDefaultValue((decimal)0);

                b.Property(p => p.asn_acqty)
                .HasPrecision(18, 0)
                .HasDefaultValue((decimal)0);

                b.Property(p => p.el_abc)
                .IsUnicode(false)
                .HasMaxLength(2)
                .HasDefaultValue(string.Empty);

                b.Property(p=>p.oper_time)
                .HasDefaultValue(DateTime.Now);

                b.Property(p => p.version_no)
                .IsUnicode(false)
                .HasMaxLength(50)
                .HasDefaultValue(string.Empty);

                b.Property(p => p.org_asn_qty)
                .HasPrecision(24, 4)
                .HasDefaultValue((decimal)0);

                b.Property(p => p.split_uid)
                .IsUnicode(false)
                .HasMaxLength(50)
                .HasDefaultValue(string.Empty);

                b.Property(p=>p.invoice_no)
                .IsUnicode()
                .HasMaxLength(150)
                .HasDefaultValue(string.Empty);

                b.Property(p => p.plant)
                .IsUnicode()
                .HasMaxLength(50);

                b.Property(p=>p.commit_qty)
                .IsUnicode()
                .HasMaxLength(50);

                b.Property(p => p.shipping_qty)
                .IsUnicode()
                .HasMaxLength(50);

                b.Property(p => p.etd)
                .IsUnicode()
                .HasMaxLength(50);

                b.Property(p=>p.ep_number)
                .IsUnicode()
                .HasMaxLength(50);

                b.Property(p=>p.delivery_date)
                .IsUnicode()
                .HasMaxLength(50);
                
                b.Property(p=>p.shipper)
                .IsUnicode()
                .HasMaxLength(200);

                b.Property(p => p.ship_to)
                .IsUnicode()
                .HasMaxLength(200);

                b.Property(p => p.bill_to)
                .IsUnicode()
                .HasMaxLength(200);

                b.Property(p => p.port_loading)
                .IsUnicode()
                .HasMaxLength(200);

                b.Property(p => p.port_delivery)
                .IsUnicode()
                .HasMaxLength(50);

                b.Property(p=>p.bill_no)
                .IsUnicode()
                .HasMaxLength(50);

                b.Property(p => p.ship_term)
                .IsUnicode()
                .HasMaxLength(50);
                
                b.ConfigureByConvention();
            });
        }
    }
}
