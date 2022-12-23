using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace etax_generate_pdf.Models;

public partial class EtaxContext : DbContext
{
    public EtaxContext()
    {
    }

    public EtaxContext(DbContextOptions<EtaxContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<Config> Configs { get; set; }

    public virtual DbSet<Config2> Config2s { get; set; }

    public virtual DbSet<ConfigBusinessArea> ConfigBusinessAreas { get; set; }

    public virtual DbSet<ConfigCategory> ConfigCategories { get; set; }

    public virtual DbSet<ConfigEmail> ConfigEmails { get; set; }

    public virtual DbSet<ConfigItem> ConfigItems { get; set; }

    public virtual DbSet<FakturPajakDo> FakturPajakDos { get; set; }

    public virtual DbSet<InboxDatum> InboxData { get; set; }

    public virtual DbSet<LogActivity> LogActivities { get; set; }

    public virtual DbSet<LogApi> LogApis { get; set; }

    public virtual DbSet<LogLogin> LogLogins { get; set; }

    public virtual DbSet<LogSap> LogSaps { get; set; }

    public virtual DbSet<LogSapPi> LogSapPis { get; set; }

    public virtual DbSet<LogScanPdf> LogScanPdfs { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<MasterAdditionalInformation> MasterAdditionalInformations { get; set; }

    public virtual DbSet<MasterCompany> MasterCompanies { get; set; }

    public virtual DbSet<MasterCustomer> MasterCustomers { get; set; }

    public virtual DbSet<MasterDocument> MasterDocuments { get; set; }

    public virtual DbSet<MasterDocumentType> MasterDocumentTypes { get; set; }

    public virtual DbSet<MasterMappingTaxOther> MasterMappingTaxOthers { get; set; }

    public virtual DbSet<MasterMappingTransactionAdditional> MasterMappingTransactionAdditionals { get; set; }

    public virtual DbSet<MasterMappingVendor> MasterMappingVendors { get; set; }

    public virtual DbSet<MasterMaterial> MasterMaterials { get; set; }

    public virtual DbSet<MasterStatus> MasterStatuses { get; set; }

    public virtual DbSet<MasterTaxType> MasterTaxTypes { get; set; }

    public virtual DbSet<MasterTransaction> MasterTransactions { get; set; }

    public virtual DbSet<MasterTransactionType> MasterTransactionTypes { get; set; }

    public virtual DbSet<MasterUnit> MasterUnits { get; set; }

    public virtual DbSet<MasterVendor> MasterVendors { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<Parameter> Parameters { get; set; }

    public virtual DbSet<PaymentStatusSap> PaymentStatusSaps { get; set; }

    public virtual DbSet<Retur> Returs { get; set; }

    public virtual DbSet<ScanRecap> ScanRecaps { get; set; }

    public virtual DbSet<ScanRecapDuplicate> ScanRecapDuplicates { get; set; }

    public virtual DbSet<SecurityApplication> SecurityApplications { get; set; }

    public virtual DbSet<SecurityAuthorization> SecurityAuthorizations { get; set; }

    public virtual DbSet<SecurityEnum> SecurityEnums { get; set; }

    public virtual DbSet<SecurityEnumDomain> SecurityEnumDomains { get; set; }

    public virtual DbSet<SecurityMenu> SecurityMenus { get; set; }

    public virtual DbSet<SecurityOperation> SecurityOperations { get; set; }

    public virtual DbSet<SecurityRole> SecurityRoles { get; set; }

    public virtual DbSet<SecurityRoleMenu> SecurityRoleMenus { get; set; }

    public virtual DbSet<SecurityUser> SecurityUsers { get; set; }

    public virtual DbSet<SecurityUserAuthorization> SecurityUserAuthorizations { get; set; }

    public virtual DbSet<SecurityUserRole> SecurityUserRoles { get; set; }

    public virtual DbSet<ServiceLog> ServiceLogs { get; set; }

    public virtual DbSet<SettingTax> SettingTaxes { get; set; }

    public virtual DbSet<TaxCustomerOther> TaxCustomerOthers { get; set; }

    public virtual DbSet<TaxDetail> TaxDetails { get; set; }

    public virtual DbSet<TaxEnofaSummary> TaxEnofaSummaries { get; set; }

    public virtual DbSet<TaxEnova> TaxEnovas { get; set; }

    public virtual DbSet<TaxHeader> TaxHeaders { get; set; }

    public virtual DbSet<TaxHeaderBackup> TaxHeaderBackups { get; set; }

    public virtual DbSet<TaxHeaderDjp> TaxHeaderDjps { get; set; }

    public virtual DbSet<TaxHeaderTemp> TaxHeaderTemps { get; set; }

    public virtual DbSet<TaxOther> TaxOthers { get; set; }

    public virtual DbSet<VatIn> VatIns { get; set; }

    public virtual DbSet<VatInLeadtime> VatInLeadtimes { get; set; }

    public virtual DbSet<VatInRecieve> VatInRecieves { get; set; }

    public virtual DbSet<VatInRecieveTemporary> VatInRecieveTemporaries { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetRoles");

            entity.HasIndex(e => e.Name, "RoleNameIndex").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUsers");

            entity.HasIndex(e => e.UserName, "UserNameIndex").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK_dbo.AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_RoleId");
                        j.HasIndex(new[] { "UserId" }, "IX_UserId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUserClaims");

            entity.HasIndex(e => e.UserId, "IX_UserId");

            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId }).HasName("PK_dbo.AspNetUserLogins");

            entity.HasIndex(e => e.UserId, "IX_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);
            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<Config>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Config");

            entity.Property(e => e.AtributeTwo).HasColumnType("text");
            entity.Property(e => e.AttributeOne).HasColumnType("text");
            entity.Property(e => e.ConfigName).HasColumnType("text");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.UpdatedOn).HasColumnType("date");
            entity.Property(e => e.ValueOne).HasColumnType("text");
            entity.Property(e => e.ValueTwo).HasColumnType("text");
        });

        modelBuilder.Entity<Config2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Config2");

            entity.Property(e => e.AtributeTwo).HasColumnType("text");
            entity.Property(e => e.AttributeOne).HasColumnType("text");
            entity.Property(e => e.ConfigName).HasColumnType("text");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("date");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.UpdatedOn).HasColumnType("date");
            entity.Property(e => e.ValueOne).HasColumnType("text");
            entity.Property(e => e.ValueTwo).HasColumnType("text");
        });

        modelBuilder.Entity<ConfigBusinessArea>(entity =>
        {
            entity.HasKey(e => e.BusinessAreaId);

            entity.ToTable("config_business_area");

            entity.Property(e => e.BusinessAreaId).HasColumnName("business_area_id");
            entity.Property(e => e.BusinessArea)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("business_area");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
        });

        modelBuilder.Entity<ConfigCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryCode).HasName("PK__config_c__BC9D1E7D27E9BCA8");

            entity.ToTable("config_categories");

            entity.Property(e => e.CategoryCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("category_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
        });

        modelBuilder.Entity<ConfigEmail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("config_email");

            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.ConfigEmailId)
                .ValueGeneratedOnAdd()
                .HasColumnName("config_email_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.EmailFrom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email_from");
            entity.Property(e => e.EmailPic1)
                .IsUnicode(false)
                .HasColumnName("email_pic1");
            entity.Property(e => e.EmailPic2)
                .IsUnicode(false)
                .HasColumnName("email_pic2");
            entity.Property(e => e.EmailSmtp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email_smtp");
            entity.Property(e => e.EmailType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email_type");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
        });

        modelBuilder.Entity<ConfigItem>(entity =>
        {
            entity.HasKey(e => e.ItemsId).HasName("PK__config_i__F0AAC808E6511FC2");

            entity.ToTable("config_items");

            entity.Property(e => e.ItemsId).HasColumnName("items_id");
            entity.Property(e => e.CategoryCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("category_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Key)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("key");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
            entity.Property(e => e.Value)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("value");

            entity.HasOne(d => d.CategoryCodeNavigation).WithMany(p => p.ConfigItems)
                .HasForeignKey(d => d.CategoryCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_config_items_config_categories");
        });

        modelBuilder.Entity<FakturPajakDo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FakturPa__3214EC27B14ADA1C");

            entity.ToTable("FakturPajakDOS");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.ClaimId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ClaimID");
            entity.Property(e => e.ClaimType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateScan).HasColumnType("date");
            entity.Property(e => e.IsProcess1).HasColumnName("isProcess1");
            entity.Property(e => e.IsProcess3).HasColumnName("isProcess3");
            entity.Property(e => e.KodeDealer)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.KodeOutlet)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.KwitansiId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("KwitansiID");
            entity.Property(e => e.LinkFakturPajak).IsUnicode(false);
            entity.Property(e => e.NomorFakturPajak)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PathFile).IsUnicode(false);
            entity.Property(e => e.UnitType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<InboxDatum>(entity =>
        {
            entity.ToTable("inbox_data");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Value1)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LogActivity>(entity =>
        {
            entity.HasKey(e => e.ActivitiesUid).HasName("PK__log_acti__2AA3018E9621E247");

            entity.ToTable("log_activities");

            entity.Property(e => e.ActivitiesUid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("activities_uid");
            entity.Property(e => e.AccessDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("access_date");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.DomainUser)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("domain_user");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.LoginUid).HasColumnName("login_uid");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");

            entity.HasOne(d => d.LoginU).WithMany(p => p.LogActivities)
                .HasForeignKey(d => d.LoginUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_log_activities_log_logins");
        });

        modelBuilder.Entity<LogApi>(entity =>
        {
            entity.ToTable("log_api");

            entity.Property(e => e.LogApiId).HasColumnName("log_api_id");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Message)
                .IsUnicode(false)
                .HasColumnName("message");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.ParameterJson)
                .IsUnicode(false)
                .HasColumnName("parameter_json");
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("row_status");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tax_number");
        });

        modelBuilder.Entity<LogLogin>(entity =>
        {
            entity.HasKey(e => e.LoginUid).HasName("PK__log_logi__0EA820B9EC971386");

            entity.ToTable("log_logins");

            entity.Property(e => e.LoginUid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("login_uid");
            entity.Property(e => e.AccessDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("access_date");
            entity.Property(e => e.ClientHostname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("client_hostname");
            entity.Property(e => e.ClientIp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('0.0.0.0')")
                .HasColumnName("client_ip");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.DomainUser)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("domain_user");
            entity.Property(e => e.IsLogged)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("is_logged");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
        });

        modelBuilder.Entity<LogSap>(entity =>
        {
            entity.HasKey(e => e.LogImportSapId).HasName("PK_log_import_sap");

            entity.ToTable("log_sap");

            entity.Property(e => e.LogImportSapId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("log_import_sap_id");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.FileName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("file_name");
            entity.Property(e => e.FullPath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("full_path");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Note)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
            entity.Property(e => e.StatusId)
                .HasComment("success\r\nfailed\r\nsuccess with retry")
                .HasColumnName("status_id");
        });

        modelBuilder.Entity<LogSapPi>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK_log_sap_pi_1");

            entity.ToTable("log_sap_pi");

            entity.Property(e => e.LogId).HasColumnName("log_id");
            entity.Property(e => e.Batch).HasColumnName("batch");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Message)
                .IsUnicode(false)
                .HasColumnName("message");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
            entity.Property(e => e.Status)
                .HasComment("look master status")
                .HasColumnName("status");
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tax_number");
            entity.Property(e => e.Type)
                .HasComment("0: scan 1\r\n1: upload csv\r\n2: scan 3\r\n3:input manual\r\n4:upload txt  (IPPI)")
                .HasColumnName("type");
        });

        modelBuilder.Entity<LogScanPdf>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LogScanP__3213E83F87DBC23F");

            entity.ToTable("LogScanPDF");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyCode)
                .IsUnicode(false)
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.FileName)
                .IsUnicode(false)
                .HasColumnName("file_name");
            entity.Property(e => e.FullPath)
                .IsUnicode(false)
                .HasColumnName("full_path");
            entity.Property(e => e.Notes)
                .IsUnicode(false)
                .HasColumnName("notes");
            entity.Property(e => e.Status)
                .IsUnicode(false)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.ToTable("Login");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<MasterAdditionalInformation>(entity =>
        {
            entity.HasKey(e => e.AdditionalInformationId);

            entity.ToTable("master_additional_information");

            entity.Property(e => e.AdditionalInformationId).HasColumnName("additional_information_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
        });

        modelBuilder.Entity<MasterCompany>(entity =>
        {
            entity.HasKey(e => e.CompanyCode);

            entity.ToTable("master_company");

            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.Address)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Domain)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("domain");
            entity.Property(e => e.Fax)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("fax");
            entity.Property(e => e.Hp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("hp");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Npwp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("npwp");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("position");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("postal_code");
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("row_status");
            entity.Property(e => e.Telp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("telp");
            entity.Property(e => e.Ttd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ttd");
        });

        modelBuilder.Entity<MasterCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.ToTable("master_customer", tb =>
                {
                    tb.HasTrigger("trg_Customer_OnInsert");
                    tb.HasTrigger("trg_Customer_OnUpdate");
                });

            entity.HasIndex(e => e.CustomerId, "master_customer_idx_customer_id");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.AdditionalInformationId).HasColumnName("additional_information_id");
            entity.Property(e => e.Address)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Blok)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("blok");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.CustomerCode)
                .HasMaxLength(50)
                .HasColumnName("customer_code");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullAddress)
                .IsUnicode(false)
                .HasColumnName("full_address");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Kabupaten)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("kabupaten");
            entity.Property(e => e.Kecamatan)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("kecamatan");
            entity.Property(e => e.Kelurahan)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("kelurahan");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.No)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("no");
            entity.Property(e => e.Npwp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("npwp");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("postal_code");
            entity.Property(e => e.Propinsi)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("propinsi");
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("row_status");
            entity.Property(e => e.Rt)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("rt");
            entity.Property(e => e.Rw)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("rw");
            entity.Property(e => e.Telpon)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telpon");
            entity.Property(e => e.TransactionTypeCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("transaction_type_code");

            entity.HasOne(d => d.AdditionalInformation).WithMany(p => p.MasterCustomers)
                .HasForeignKey(d => d.AdditionalInformationId)
                .HasConstraintName("FK_master_customer_master_additional_information");

            entity.HasOne(d => d.TransactionTypeCodeNavigation).WithMany(p => p.MasterCustomers)
                .HasForeignKey(d => d.TransactionTypeCode)
                .HasConstraintName("FK_master_customer_master_customer");
        });

        modelBuilder.Entity<MasterDocument>(entity =>
        {
            entity.HasKey(e => e.DocumentId);

            entity.ToTable("master_document");

            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.DocumentCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("document_code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
        });

        modelBuilder.Entity<MasterDocumentType>(entity =>
        {
            entity.HasKey(e => e.DocumentTypeId);

            entity.ToTable("master_document_type");

            entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
        });

        modelBuilder.Entity<MasterMappingTaxOther>(entity =>
        {
            entity.HasKey(e => e.MasterMappingTaxOthersId);

            entity.ToTable("master_mapping_tax_others");

            entity.Property(e => e.MasterMappingTaxOthersId).HasColumnName("master_mapping_tax_others_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.DocumentType).HasColumnName("document_type");
            entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");
            entity.Property(e => e.IsRetur)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("is_retur");
            entity.Property(e => e.MappingDocumentTypeId).HasColumnName("mapping_document_type_id");
            entity.Property(e => e.MappingIsRetur).HasColumnName("mapping_is_retur");
            entity.Property(e => e.MappingTransactionId).HasColumnName("mapping_transaction_id");
            entity.Property(e => e.MappingTransactionTypeCode).HasColumnName("mapping_transaction_type_code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.TransactionTypeCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("transaction_type_code");
        });

        modelBuilder.Entity<MasterMappingTransactionAdditional>(entity =>
        {
            entity.HasKey(e => e.MappingTransactionAdditionalId);

            entity.ToTable("master_mapping_transaction_additional");

            entity.Property(e => e.MappingTransactionAdditionalId).HasColumnName("mapping_transaction_additional_id");
            entity.Property(e => e.AdditionalInformationId).HasColumnName("additional_information_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
            entity.Property(e => e.TransactionTypeCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("transaction_type_code");
        });

        modelBuilder.Entity<MasterMappingVendor>(entity =>
        {
            entity.HasKey(e => e.MappingVendorId);

            entity.ToTable("master_mapping_vendor");

            entity.Property(e => e.MappingVendorId).HasColumnName("mapping_vendor_id");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Pic)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pic");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
            entity.Property(e => e.VendorNpwp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("vendor_npwp");
        });

        modelBuilder.Entity<MasterMaterial>(entity =>
        {
            entity.HasKey(e => e.MaterialId);

            entity.ToTable("master_material");

            entity.Property(e => e.MaterialId).HasColumnName("material_id");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.MaterialCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("material_code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
        });

        modelBuilder.Entity<MasterStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId);

            entity.ToTable("master_status");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.Root)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("root");
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("row_status");
        });

        modelBuilder.Entity<MasterTaxType>(entity =>
        {
            entity.HasKey(e => e.TaxTypeId);

            entity.ToTable("master_tax_type");

            entity.Property(e => e.TaxTypeId).HasColumnName("tax_type_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.DetailCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("detail_code");
            entity.Property(e => e.HeaderCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("header_code");
            entity.Property(e => e.MiddleCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("middle_code");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("row_status");
        });

        modelBuilder.Entity<MasterTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId);

            entity.ToTable("master_transaction");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
        });

        modelBuilder.Entity<MasterTransactionType>(entity =>
        {
            entity.HasKey(e => e.TransactionTypeCode);

            entity.ToTable("master_transaction_type");

            entity.Property(e => e.TransactionTypeCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("transaction_type_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Note)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
        });

        modelBuilder.Entity<MasterUnit>(entity =>
        {
            entity.ToTable("master_unit");

            entity.Property(e => e.MasterUnitId).HasColumnName("master_unit_id");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("row_status");
            entity.Property(e => e.Unit)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("unit");
        });

        modelBuilder.Entity<MasterVendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PK_Table_1");

            entity.ToTable("master_vendor");

            entity.Property(e => e.VendorId).HasColumnName("vendor_id");
            entity.Property(e => e.Address)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Npwp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("npwp");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Material");

            entity.Property(e => e.ClassNumber)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.FileName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FuncAreaId).HasColumnName("FuncAreaID");
            entity.Property(e => e.InventoryUnitSymbol)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.IsSendPss).HasColumnName("IsSendPSS");
            entity.Property(e => e.IsSendSap).HasColumnName("IsSendSAP");
            entity.Property(e => e.ItemMajorGroupId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("ItemMajorGroupID");
            entity.Property(e => e.ItemMinorGroupId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("ItemMinorGroupID");
            entity.Property(e => e.MaterialCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaterialDesc).IsUnicode(false);
            entity.Property(e => e.MaterialType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Parameter>(entity =>
        {
            entity.ToTable("parameter");

            entity.Property(e => e.ParameterId).HasColumnName("parameter_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Description)
                .HasColumnType("ntext")
                .HasColumnName("description");
            entity.Property(e => e.KeyParam)
                .HasMaxLength(50)
                .HasColumnName("key_param");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
            entity.Property(e => e.Value1)
                .HasMaxLength(255)
                .HasColumnName("value1");
            entity.Property(e => e.Value2)
                .IsUnicode(false)
                .HasColumnName("value2");
        });

        modelBuilder.Entity<PaymentStatusSap>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__payment___ED1FC9EA5790BF6F");

            entity.ToTable("payment_status_sap");

            entity.HasIndex(e => e.TaxNumber, "payment_status_sap_idx_tax_number");

            entity.Property(e => e.PaymentId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("payment_id");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("payment_status");
            entity.Property(e => e.PostingDate)
                .HasColumnType("date")
                .HasColumnName("posting_date");
            entity.Property(e => e.PostingDateSap)
                .HasColumnType("date")
                .HasColumnName("posting_date_sap");
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tax_number");
            entity.Property(e => e.TaxPeriodMonth)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("tax_period_month");
            entity.Property(e => e.TaxPeriodYear).HasColumnName("tax_period_year");
            entity.Property(e => e.TaxPpn)
                .HasColumnType("money")
                .HasColumnName("tax_ppn");
            entity.Property(e => e.TransNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("trans_number");
            entity.Property(e => e.VendorNpwp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vendor_npwp");
        });

        modelBuilder.Entity<Retur>(entity =>
        {
            entity.ToTable("retur", tb => tb.HasTrigger("trg_Retur_OnInsert"));

            entity.Property(e => e.ReturId).HasColumnName("retur_id");
            entity.Property(e => e.ApprovalDate)
                .HasColumnType("date")
                .HasColumnName("approval_date");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Dpp)
                .HasColumnType("money")
                .HasColumnName("dpp");
            entity.Property(e => e.IsCreditable).HasColumnName("is_creditable");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Npwp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("npwp");
            entity.Property(e => e.Ppn)
                .HasColumnType("money")
                .HasColumnName("ppn");
            entity.Property(e => e.Ppnbm)
                .HasColumnType("money")
                .HasColumnName("ppnbm");
            entity.Property(e => e.ReturDate)
                .HasColumnType("date")
                .HasColumnName("retur_date");
            entity.Property(e => e.ReturFp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("retur_fp");
            entity.Property(e => e.ReturNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("retur_number");
            entity.Property(e => e.ReturPeriodMonth)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("retur_period_month");
            entity.Property(e => e.ReturPeriodYear).HasColumnName("retur_period_year");
            entity.Property(e => e.ReturType)
                .HasComment("0:keluaran\r\n1:masukan")
                .HasColumnName("retur_type");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TaxDate)
                .HasColumnType("date")
                .HasColumnName("tax_date");
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tax_number");
            entity.Property(e => e.TransactionTypeCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("transaction_type_code");
            entity.Property(e => e.UploadDate)
                .HasColumnType("date")
                .HasColumnName("upload_date");
        });

        modelBuilder.Entity<ScanRecap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__scan_rec__3214EC2714D68D9F");

            entity.ToTable("scan_recap");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.ErrorMessage)
                .HasColumnType("text")
                .HasColumnName("error_message");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.ScanType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("scan_type");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tax_number");
        });

        modelBuilder.Entity<ScanRecapDuplicate>(entity =>
        {
            entity.ToTable("scan_recap_duplicate");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.ErrorMessage)
                .HasColumnType("text")
                .HasColumnName("error_message");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.ScanType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("scan_type");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tax_number");
        });

        modelBuilder.Entity<SecurityApplication>(entity =>
        {
            entity.HasKey(e => e.ApplicationCode).HasName("PK__security__3BEB6127C935834A");

            entity.ToTable("security_applications");

            entity.Property(e => e.ApplicationCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("application_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("name");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
        });

        modelBuilder.Entity<SecurityAuthorization>(entity =>
        {
            entity.HasKey(e => e.AuthorizationsId).HasName("PK__security__8410F1FB19DFD96B");

            entity.ToTable("security_authorizations");

            entity.Property(e => e.AuthorizationsId).HasColumnName("authorizations_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.OperationsCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("operations_code");
            entity.Property(e => e.RolesCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("roles_code");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");

            entity.HasOne(d => d.RolesCodeNavigation).WithMany(p => p.SecurityAuthorizations)
                .HasForeignKey(d => d.RolesCode)
                .HasConstraintName("FK_security_authorizations_security_roles");
        });

        modelBuilder.Entity<SecurityEnum>(entity =>
        {
            entity.ToTable("security_enum");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Enumdesc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("enumdesc");
            entity.Property(e => e.Enumname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("enumname");
            entity.Property(e => e.Enumvalue)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("enumvalue");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Rowstatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("rowstatus");
        });

        modelBuilder.Entity<SecurityEnumDomain>(entity =>
        {
            entity.HasKey(e => e.DomainId).HasName("PK__security__E72BC76621E3AA54");

            entity.ToTable("security_enum_domains");

            entity.Property(e => e.DomainId)
                .ValueGeneratedNever()
                .HasColumnName("domain_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
        });

        modelBuilder.Entity<SecurityMenu>(entity =>
        {
            entity.HasKey(e => e.MenuId);

            entity.ToTable("security_menu");

            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.ApplicationCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("application_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.GroupMenu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("group_menu");
            entity.Property(e => e.MenuName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("menu_name");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("row_status");
            entity.Property(e => e.Url)
                .HasMaxLength(50)
                .HasColumnName("url");
        });

        modelBuilder.Entity<SecurityOperation>(entity =>
        {
            entity.HasKey(e => e.OperationsCode).HasName("PK__security__532C9F58C478FEE5");

            entity.ToTable("security_operations");

            entity.Property(e => e.OperationsCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("operations_code");
            entity.Property(e => e.ApplicationCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("application_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");

            entity.HasOne(d => d.ApplicationCodeNavigation).WithMany(p => p.SecurityOperations)
                .HasForeignKey(d => d.ApplicationCode)
                .HasConstraintName("fk_security_operations_security_applications");
        });

        modelBuilder.Entity<SecurityRole>(entity =>
        {
            entity.HasKey(e => e.RolesCode).HasName("PK__security__357D4CF84F7CD00D");

            entity.ToTable("security_roles");

            entity.Property(e => e.RolesCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("roles_code");
            entity.Property(e => e.ApplicationCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("application_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("row_status");

            entity.HasOne(d => d.ApplicationCodeNavigation).WithMany(p => p.SecurityRoles)
                .HasForeignKey(d => d.ApplicationCode)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_security_roles_security_applications");
        });

        modelBuilder.Entity<SecurityRoleMenu>(entity =>
        {
            entity.HasKey(e => e.RoleMenuId).HasName("PK_security_roles_menu");

            entity.ToTable("security_role_menu");

            entity.Property(e => e.RoleMenuId).HasColumnName("role_menu_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RolesCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("roles_code");
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("row_status");

            entity.HasOne(d => d.Menu).WithMany(p => p.SecurityRoleMenus)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("FK_security_role_menu_security_menu");
        });

        modelBuilder.Entity<SecurityUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__security__B9BE370F54257FE5");

            entity.ToTable("security_users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("department");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("display_name");
            entity.Property(e => e.Domain)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("domain");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IsExternal).HasColumnName("is_external");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("row_status");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<SecurityUserAuthorization>(entity =>
        {
            entity.HasKey(e => e.UserAuthorizationsId).HasName("PK__security__E07CD8942BFE89A6");

            entity.ToTable("security_user_authorizations");

            entity.Property(e => e.UserAuthorizationsId).HasColumnName("user_authorizations_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.DomainUsername)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("domain_username");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.OperationsCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("operations_code");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
        });

        modelBuilder.Entity<SecurityUserRole>(entity =>
        {
            entity.HasKey(e => e.UserRolesId).HasName("PK__security__00C6D13D077587B2");

            entity.ToTable("security_user_roles");

            entity.Property(e => e.UserRolesId).HasColumnName("user_roles_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RolesCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("roles_code");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.RolesCodeNavigation).WithMany(p => p.SecurityUserRoles)
                .HasForeignKey(d => d.RolesCode)
                .HasConstraintName("fk_security_user_roles_security_roles");

            entity.HasOne(d => d.User).WithMany(p => p.SecurityUserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_security_user_roles_security_users");
        });

        modelBuilder.Entity<ServiceLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceL__3214EC071BA53F49");

            entity.ToTable("ServiceLog");

            entity.Property(e => e.ErrorMessage).HasColumnType("text");
            entity.Property(e => e.Message).HasColumnType("text");
        });

        modelBuilder.Entity<SettingTax>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("setting_tax");

            entity.Property(e => e.TaxEnd)
                .HasColumnType("datetime")
                .HasColumnName("tax_end");
            entity.Property(e => e.TaxId).HasColumnName("tax_id");
            entity.Property(e => e.TaxName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tax_name");
            entity.Property(e => e.TaxPercen).HasColumnName("tax_percen");
            entity.Property(e => e.TaxStart)
                .HasColumnType("datetime")
                .HasColumnName("tax_start");
        });

        modelBuilder.Entity<TaxCustomerOther>(entity =>
        {
            entity.HasKey(e => e.CustomerOthersId);

            entity.ToTable("tax_customer_others");

            entity.HasIndex(e => e.CustomerOthersId, "tax_customer_other_idx_customer_id");

            entity.Property(e => e.CustomerOthersId).HasColumnName("customer_others_id");
            entity.Property(e => e.Address)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Blok)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("blok");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Email)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Kabupaten)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("kabupaten");
            entity.Property(e => e.Kecamatan)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("kecamatan");
            entity.Property(e => e.Kelurahan)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("kelurahan");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.No)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("no");
            entity.Property(e => e.Npwp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("npwp");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("postal_code");
            entity.Property(e => e.Propinsi)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("propinsi");
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("row_status");
            entity.Property(e => e.Rt)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("rt");
            entity.Property(e => e.Rw)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("rw");
            entity.Property(e => e.Telpon)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telpon");
        });

        modelBuilder.Entity<TaxDetail>(entity =>
        {
            entity.ToTable("tax_detail");

            entity.Property(e => e.TaxDetailId).HasColumnName("tax_detail_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Discount)
                .HasColumnType("money")
                .HasColumnName("discount");
            entity.Property(e => e.DocumentReference)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("document_reference");
            entity.Property(e => e.Dpp)
                .HasColumnType("money")
                .HasColumnName("dpp");
            entity.Property(e => e.ItemReference)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("item_reference");
            entity.Property(e => e.MaterialCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("material_code");
            entity.Property(e => e.MaterialName)
                .IsUnicode(false)
                .HasColumnName("material_name");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Pph22)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pph22");
            entity.Property(e => e.Ppn)
                .HasColumnType("money")
                .HasColumnName("ppn");
            entity.Property(e => e.Ppnbm)
                .HasColumnType("money")
                .HasColumnName("ppnbm");
            entity.Property(e => e.PpnbmCharge)
                .HasColumnType("money")
                .HasColumnName("ppnbm_charge");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Qty)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("qty");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
            entity.Property(e => e.Subtotal)
                .HasColumnType("money")
                .HasColumnName("subtotal");
            entity.Property(e => e.TaxHeaderId).HasColumnName("tax_header_id");
        });

        modelBuilder.Entity<TaxEnofaSummary>(entity =>
        {
            entity.HasKey(e => e.SumarryEnofaId);

            entity.ToTable("tax_enofa_summary");

            entity.Property(e => e.SumarryEnofaId).HasColumnName("sumarry_enofa_id");
            entity.Property(e => e.Available).HasColumnName("available");
            entity.Property(e => e.Batch).HasColumnName("batch");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.FirstRange)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("first_range");
            entity.Property(e => e.LastRange)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("last_range");
            entity.Property(e => e.LastUsedTaxnumber)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("last_used_taxnumber");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
            entity.Property(e => e.SkDate)
                .HasColumnType("date")
                .HasColumnName("sk_date");
            entity.Property(e => e.Total).HasColumnName("total");
        });

        modelBuilder.Entity<TaxEnova>(entity =>
        {
            entity.HasKey(e => e.EnovaId);

            entity.ToTable("tax_enova", tb =>
                {
                    tb.HasTrigger("trg_enofa_OnInsert");
                    tb.HasTrigger("trg_enofa_OnUpdated");
                });

            entity.HasIndex(e => e.CompanyCode, "IX_tax_company_code");

            entity.HasIndex(e => new { e.IsUsed, e.CompanyCode, e.RowStatus, e.SkDate }, "IX_tax_enova_isused_companycode_rowstatus_skdate");

            entity.HasIndex(e => e.TaxNumber, "IX_tax_number");

            entity.HasIndex(e => e.SkDate, "IX_tax_sk_date");

            entity.Property(e => e.EnovaId).HasColumnName("enova_id");
            entity.Property(e => e.Batch).HasColumnName("batch");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.IsUsed).HasColumnName("is_used");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('')")
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus)
                .HasDefaultValueSql("((0))")
                .HasColumnName("row_status");
            entity.Property(e => e.SkDate)
                .HasColumnType("date")
                .HasColumnName("sk_date");
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_number");
        });

        modelBuilder.Entity<TaxHeader>(entity =>
        {
            entity.ToTable("tax_header", tb => tb.HasTrigger("trg_TaxHeader_OnInsert"));

            entity.HasIndex(e => new { e.CompanyCode, e.Ref, e.RowStatus }, "tax_header_idx_company_co_ref_row_status");

            entity.HasIndex(e => new { e.CompanyCode, e.RowStatus, e.Ref }, "tax_header_idx_company_co_row_status_ref");

            entity.HasIndex(e => new { e.Ref, e.TaxNumber }, "tax_header_idx_ref_tax_number");

            entity.HasIndex(e => new { e.TaxFp, e.Ref, e.TaxNumber }, "tax_header_idx_tax_fp_ref_tax_number");

            entity.HasIndex(e => e.TaxNumber, "tax_number_index");

            entity.Property(e => e.TaxHeaderId).HasColumnName("tax_header_id");
            entity.Property(e => e.AdditionalInformationId).HasColumnName("additional_information_id");
            entity.Property(e => e.ApprovalDate)
                .HasColumnType("date")
                .HasColumnName("approval_date");
            entity.Property(e => e.BillingNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("billing_no");
            entity.Property(e => e.BillingType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("billing_type");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.CsvPath)
                .IsUnicode(false)
                .HasColumnName("csv_path");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("currency");
            entity.Property(e => e.CustomerAddress)
                .IsUnicode(false)
                .HasColumnName("customer_address");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CustomerOthersId).HasColumnName("customer_others_id");
            entity.Property(e => e.DokumenPendukung)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Dokumen_Pendukung");
            entity.Property(e => e.InvoiceList)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("invoice_list");
            entity.Property(e => e.IsExpired)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("isExpired");
            entity.Property(e => e.IsMailExpired)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("isMailExpired");
            entity.Property(e => e.IsMailReminder)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("isMailReminder");
            entity.Property(e => e.IsManual).HasColumnName("is_manual");
            entity.Property(e => e.LastDpp)
                .HasColumnType("money")
                .HasColumnName("last_dpp");
            entity.Property(e => e.LastPpnbm)
                .HasColumnType("money")
                .HasColumnName("last_ppnbm");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Note)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.PdfPath)
                .IsUnicode(false)
                .HasColumnName("pdf_path");
            entity.Property(e => e.Ref)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ref");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TaxAddress)
                .IsUnicode(false)
                .HasColumnName("tax_address");
            entity.Property(e => e.TaxDate)
                .HasColumnType("date")
                .HasColumnName("tax_date");
            entity.Property(e => e.TaxDp)
                .HasComment("1:uang muka")
                .HasColumnName("tax_dp");
            entity.Property(e => e.TaxDpDpp)
                .HasColumnType("money")
                .HasColumnName("tax_dp_dpp");
            entity.Property(e => e.TaxDpPpn)
                .HasColumnType("money")
                .HasColumnName("tax_dp_ppn");
            entity.Property(e => e.TaxDpPpnbm)
                .HasColumnType("money")
                .HasColumnName("tax_dp_ppnbm");
            entity.Property(e => e.TaxDpp)
                .HasColumnType("money")
                .HasColumnName("tax_dpp");
            entity.Property(e => e.TaxFp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_fp");
            entity.Property(e => e.TaxName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tax_name");
            entity.Property(e => e.TaxNpwp)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tax_npwp");
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tax_number");
            entity.Property(e => e.TaxPeriodMonth)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("tax_period_month");
            entity.Property(e => e.TaxPeriodYear).HasColumnName("tax_period_year");
            entity.Property(e => e.TaxPpn)
                .HasColumnType("money")
                .HasColumnName("tax_ppn");
            entity.Property(e => e.TaxPpnbm)
                .HasColumnType("money")
                .HasColumnName("tax_ppnbm");
            entity.Property(e => e.TaxReference)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tax_reference");
            entity.Property(e => e.TransactionTypeCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("transaction_type_code");
            entity.Property(e => e.UploadDate)
                .HasColumnType("date")
                .HasColumnName("upload_date");

            entity.HasOne(d => d.CustomerOthers).WithMany(p => p.TaxHeaders)
                .HasForeignKey(d => d.CustomerOthersId)
                .HasConstraintName("FK_tax_header_tax_customer_others");
        });

        modelBuilder.Entity<TaxHeaderBackup>(entity =>
        {
            entity.HasKey(e => e.TaxHeaderId).HasName("PK__tax_head__059DF4753E65D0F0");

            entity.ToTable("tax_header_backup", tb => tb.HasTrigger("trg_TaxHeader_OnInsert_copy1"));

            entity.HasIndex(e => new { e.CompanyCode, e.Ref, e.RowStatus }, "tax_header_idx_company_co_ref_row_status_copy1");

            entity.HasIndex(e => new { e.CompanyCode, e.RowStatus, e.Ref }, "tax_header_idx_company_co_row_status_ref_copy1");

            entity.HasIndex(e => new { e.Ref, e.TaxNumber }, "tax_header_idx_ref_tax_number_copy1");

            entity.HasIndex(e => new { e.TaxFp, e.Ref, e.TaxNumber }, "tax_header_idx_tax_fp_ref_tax_number_copy1");

            entity.HasIndex(e => e.TaxNumber, "tax_number_index_copy1");

            entity.Property(e => e.TaxHeaderId).HasColumnName("tax_header_id");
            entity.Property(e => e.AdditionalInformationId).HasColumnName("additional_information_id");
            entity.Property(e => e.ApprovalDate)
                .HasColumnType("date")
                .HasColumnName("approval_date");
            entity.Property(e => e.BillingNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("billing_no");
            entity.Property(e => e.BillingType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("billing_type");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.CsvPath)
                .IsUnicode(false)
                .HasColumnName("csv_path");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("currency");
            entity.Property(e => e.CustomerAddress)
                .IsUnicode(false)
                .HasColumnName("customer_address");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CustomerOthersId).HasColumnName("customer_others_id");
            entity.Property(e => e.DokumenPendukung)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Dokumen_Pendukung");
            entity.Property(e => e.InvoiceList)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("invoice_list");
            entity.Property(e => e.IsManual).HasColumnName("is_manual");
            entity.Property(e => e.LastDpp)
                .HasColumnType("money")
                .HasColumnName("last_dpp");
            entity.Property(e => e.LastPpnbm)
                .HasColumnType("money")
                .HasColumnName("last_ppnbm");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Note)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.PdfPath)
                .IsUnicode(false)
                .HasColumnName("pdf_path");
            entity.Property(e => e.Ref)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ref");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TaxAddress)
                .IsUnicode(false)
                .HasColumnName("tax_address");
            entity.Property(e => e.TaxDate)
                .HasColumnType("date")
                .HasColumnName("tax_date");
            entity.Property(e => e.TaxDp)
                .HasComment("1:uang muka")
                .HasColumnName("tax_dp");
            entity.Property(e => e.TaxDpDpp)
                .HasColumnType("money")
                .HasColumnName("tax_dp_dpp");
            entity.Property(e => e.TaxDpPpn)
                .HasColumnType("money")
                .HasColumnName("tax_dp_ppn");
            entity.Property(e => e.TaxDpPpnbm)
                .HasColumnType("money")
                .HasColumnName("tax_dp_ppnbm");
            entity.Property(e => e.TaxDpp)
                .HasColumnType("money")
                .HasColumnName("tax_dpp");
            entity.Property(e => e.TaxFp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_fp");
            entity.Property(e => e.TaxName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tax_name");
            entity.Property(e => e.TaxNpwp)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tax_npwp");
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tax_number");
            entity.Property(e => e.TaxPeriodMonth)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("tax_period_month");
            entity.Property(e => e.TaxPeriodYear).HasColumnName("tax_period_year");
            entity.Property(e => e.TaxPpn)
                .HasColumnType("money")
                .HasColumnName("tax_ppn");
            entity.Property(e => e.TaxPpnbm)
                .HasColumnType("money")
                .HasColumnName("tax_ppnbm");
            entity.Property(e => e.TaxReference)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tax_reference");
            entity.Property(e => e.TransactionTypeCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("transaction_type_code");
            entity.Property(e => e.UploadDate)
                .HasColumnType("date")
                .HasColumnName("upload_date");

            entity.HasOne(d => d.AdditionalInformation).WithMany(p => p.TaxHeaderBackups)
                .HasForeignKey(d => d.AdditionalInformationId)
                .HasConstraintName("FK__tax_heade__addit__5792F321");

            entity.HasOne(d => d.CompanyCodeNavigation).WithMany(p => p.TaxHeaderBackups)
                .HasForeignKey(d => d.CompanyCode)
                .HasConstraintName("FK__tax_heade__compa__5887175A");

            entity.HasOne(d => d.Customer).WithMany(p => p.TaxHeaderBackups)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__tax_heade__custo__5B638405");

            entity.HasOne(d => d.CustomerOthers).WithMany(p => p.TaxHeaderBackups)
                .HasForeignKey(d => d.CustomerOthersId)
                .HasConstraintName("FK__tax_heade__custo__5C57A83E");

            entity.HasOne(d => d.Status).WithMany(p => p.TaxHeaderBackups)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__tax_heade__statu__597B3B93");

            entity.HasOne(d => d.TransactionTypeCodeNavigation).WithMany(p => p.TaxHeaderBackups)
                .HasForeignKey(d => d.TransactionTypeCode)
                .HasConstraintName("FK__tax_heade__trans__5A6F5FCC");
        });

        modelBuilder.Entity<TaxHeaderDjp>(entity =>
        {
            entity.HasKey(e => e.TaxHeaderId).HasName("PK__tax_head__059DF475C92B62A7");

            entity.ToTable("tax_header_djp");

            entity.HasIndex(e => e.TaxNumber, "UQ__tax_head__8A87F631C6AFA84B").IsUnique();

            entity.Property(e => e.TaxHeaderId).HasColumnName("tax_header_id");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tax_number");
        });

        modelBuilder.Entity<TaxHeaderTemp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tax_header_temp");

            entity.Property(e => e.AdditionalInformationId).HasColumnName("additional_information_id");
            entity.Property(e => e.ApprovalDate)
                .HasColumnType("date")
                .HasColumnName("approval_date");
            entity.Property(e => e.BillingNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("billing_no");
            entity.Property(e => e.BillingType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("billing_type");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.CsvPath)
                .IsUnicode(false)
                .HasColumnName("csv_path");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("currency");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CustomerOthersId).HasColumnName("customer_others_id");
            entity.Property(e => e.DokumenPendukung)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Dokumen_Pendukung");
            entity.Property(e => e.InvoiceList)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("invoice_list");
            entity.Property(e => e.IsManual).HasColumnName("is_manual");
            entity.Property(e => e.LastDpp)
                .HasColumnType("money")
                .HasColumnName("last_dpp");
            entity.Property(e => e.LastPpnbm)
                .HasColumnType("money")
                .HasColumnName("last_ppnbm");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Note)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.PdfPath)
                .IsUnicode(false)
                .HasColumnName("pdf_path");
            entity.Property(e => e.Ref)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ref");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TaxAddress)
                .IsUnicode(false)
                .HasColumnName("tax_address");
            entity.Property(e => e.TaxDate)
                .HasColumnType("date")
                .HasColumnName("tax_date");
            entity.Property(e => e.TaxDp).HasColumnName("tax_dp");
            entity.Property(e => e.TaxDpDpp)
                .HasColumnType("money")
                .HasColumnName("tax_dp_dpp");
            entity.Property(e => e.TaxDpPpn)
                .HasColumnType("money")
                .HasColumnName("tax_dp_ppn");
            entity.Property(e => e.TaxDpPpnbm)
                .HasColumnType("money")
                .HasColumnName("tax_dp_ppnbm");
            entity.Property(e => e.TaxDpp)
                .HasColumnType("money")
                .HasColumnName("tax_dpp");
            entity.Property(e => e.TaxFp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_fp");
            entity.Property(e => e.TaxHeaderId)
                .ValueGeneratedOnAdd()
                .HasColumnName("tax_header_id");
            entity.Property(e => e.TaxName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tax_name");
            entity.Property(e => e.TaxNpwp)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tax_npwp");
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tax_number");
            entity.Property(e => e.TaxPeriodMonth)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("tax_period_month");
            entity.Property(e => e.TaxPeriodYear).HasColumnName("tax_period_year");
            entity.Property(e => e.TaxPpn)
                .HasColumnType("money")
                .HasColumnName("tax_ppn");
            entity.Property(e => e.TaxPpnbm)
                .HasColumnType("money")
                .HasColumnName("tax_ppnbm");
            entity.Property(e => e.TaxReference)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tax_reference");
            entity.Property(e => e.TransactionTypeCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("transaction_type_code");
            entity.Property(e => e.UploadDate)
                .HasColumnType("date")
                .HasColumnName("upload_date");
        });

        modelBuilder.Entity<TaxOther>(entity =>
        {
            entity.HasKey(e => e.TaxOthersId);

            entity.ToTable("tax_others", tb => tb.HasTrigger("trg_TaxOthers_OnInsert"));

            entity.Property(e => e.TaxOthersId).HasColumnName("tax_others_id");
            entity.Property(e => e.Aju)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("aju");
            entity.Property(e => e.ApprovalDate)
                .HasColumnType("date")
                .HasColumnName("approval_date");
            entity.Property(e => e.Assigment)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("assigment");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.DocumentDate)
                .HasColumnType("date")
                .HasColumnName("document_date");
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("document_number");
            entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");
            entity.Property(e => e.IsRetur)
                .HasComment("1:retur\r\n0:transaction")
                .HasColumnName("is_retur");
            entity.Property(e => e.LastDpp)
                .HasColumnType("money")
                .HasColumnName("last_dpp");
            entity.Property(e => e.LastPpnbm)
                .HasColumnType("money")
                .HasColumnName("last_ppnbm");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.PeriodMonth)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("period_month");
            entity.Property(e => e.PeriodYear).HasColumnName("period_year");
            entity.Property(e => e.Reference)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("reference");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TaxOthersAddress)
                .IsUnicode(false)
                .HasColumnName("tax_others_address");
            entity.Property(e => e.TaxOthersDpp)
                .HasColumnType("money")
                .HasColumnName("tax_others_dpp");
            entity.Property(e => e.TaxOthersFp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_others_fp");
            entity.Property(e => e.TaxOthersName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tax_others_name");
            entity.Property(e => e.TaxOthersNpwp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tax_others_npwp");
            entity.Property(e => e.TaxOthersPpn)
                .HasColumnType("money")
                .HasColumnName("tax_others_ppn");
            entity.Property(e => e.TaxOthersPpnbm)
                .HasColumnType("money")
                .HasColumnName("tax_others_ppnbm");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.TransactionTypeCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("transaction_type_code");
            entity.Property(e => e.Type)
                .HasComment("0:keluaran\r\n1:masukan")
                .HasColumnName("type");
            entity.Property(e => e.UploadDate)
                .HasColumnType("date")
                .HasColumnName("upload_date");

            entity.HasOne(d => d.CompanyCodeNavigation).WithMany(p => p.TaxOthers)
                .HasForeignKey(d => d.CompanyCode)
                .HasConstraintName("FK_tax_others_master_company");

            entity.HasOne(d => d.DocumentType).WithMany(p => p.TaxOthers)
                .HasForeignKey(d => d.DocumentTypeId)
                .HasConstraintName("FK_tax_others_master_document_type");

            entity.HasOne(d => d.Status).WithMany(p => p.TaxOthers)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_tax_others_master_status");

            entity.HasOne(d => d.Transaction).WithMany(p => p.TaxOthers)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("FK_tax_others_master_transaction");

            entity.HasOne(d => d.TransactionTypeCodeNavigation).WithMany(p => p.TaxOthers)
                .HasForeignKey(d => d.TransactionTypeCode)
                .HasConstraintName("FK_tax_others_master_transaction_type");
        });

        modelBuilder.Entity<VatIn>(entity =>
        {
            entity.HasKey(e => e.TaxNumber);

            entity.ToTable("vat_in", tb => tb.HasTrigger("CreateLogScanSatu"));

            entity.Property(e => e.TaxNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tax_number");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.IsCreditable).HasColumnName("is_creditable");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
            entity.Property(e => e.StatusApproval)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status_approval");
            entity.Property(e => e.TaxDate)
                .HasColumnType("date")
                .HasColumnName("tax_date");
            entity.Property(e => e.TaxDpp)
                .HasColumnType("money")
                .HasColumnName("tax_dpp");
            entity.Property(e => e.TaxFp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_fp");
            entity.Property(e => e.TaxPpn)
                .HasColumnType("money")
                .HasColumnName("tax_ppn");
            entity.Property(e => e.TaxPpnbm)
                .HasColumnType("money")
                .HasColumnName("tax_ppnbm");
            entity.Property(e => e.TransactionTypeCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("transaction_type_code");
            entity.Property(e => e.Url)
                .IsUnicode(false)
                .HasColumnName("url");
            entity.Property(e => e.VendorAddress)
                .IsUnicode(false)
                .HasColumnName("vendor_address");
            entity.Property(e => e.VendorName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("vendor_name");
            entity.Property(e => e.VendorNpwp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vendor_npwp");
        });

        modelBuilder.Entity<VatInLeadtime>(entity =>
        {
            entity.HasKey(e => e.LeadTimeId);

            entity.ToTable("vat_in_leadtime");

            entity.Property(e => e.LeadTimeId).HasColumnName("lead_time_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
            entity.Property(e => e.Scan1Date)
                .HasColumnType("datetime")
                .HasColumnName("scan1_date");
            entity.Property(e => e.Scan2Date)
                .HasColumnType("datetime")
                .HasColumnName("scan2_date");
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tax_number");
        });

        modelBuilder.Entity<VatInRecieve>(entity =>
        {
            entity.HasKey(e => e.TaxNumber);

            entity.ToTable("vat_in_recieve", tb =>
                {
                    tb.HasTrigger("CreateLogScanTiga");
                    tb.HasTrigger("trg_OnInsert_IPI");
                    tb.HasTrigger("trg_Vatin_OnInsert");
                });

            entity.Property(e => e.TaxNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tax_number");
            entity.Property(e => e.ApprovalDate)
                .HasColumnType("date")
                .HasColumnName("approval_date");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.IsCreditable).HasColumnName("is_creditable");
            entity.Property(e => e.LastDpp)
                .HasColumnType("money")
                .HasColumnName("last_dpp");
            entity.Property(e => e.LastPpnbm)
                .HasColumnType("money")
                .HasColumnName("last_ppnbm");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Note)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.PostingDate)
                .HasColumnType("date")
                .HasColumnName("posting_date");
            entity.Property(e => e.Ref)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ref");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
            entity.Property(e => e.Scan1By)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("scan1_by");
            entity.Property(e => e.Source)
                .HasComment("1:scan\r\n2:upload csv\r\n3:manual\r\n4:upload txt (IPPI)")
                .HasColumnName("source");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TaxDate)
                .HasColumnType("date")
                .HasColumnName("tax_date");
            entity.Property(e => e.TaxDpp)
                .HasColumnType("money")
                .HasColumnName("tax_dpp");
            entity.Property(e => e.TaxFp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_fp");
            entity.Property(e => e.TaxPeriodMonth)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("tax_period_month");
            entity.Property(e => e.TaxPeriodYear).HasColumnName("tax_period_year");
            entity.Property(e => e.TaxPpn)
                .HasColumnType("money")
                .HasColumnName("tax_ppn");
            entity.Property(e => e.TaxPpnbm)
                .HasColumnType("money")
                .HasColumnName("tax_ppnbm");
            entity.Property(e => e.TransactionTypeCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("transaction_type_code");
            entity.Property(e => e.TypeInput)
                .HasDefaultValueSql("((0))")
                .HasComment("0: normal\r\n1:proses merge Scan1 & 3 IAMI")
                .HasColumnName("type_input");
            entity.Property(e => e.UploadDate)
                .HasColumnType("date")
                .HasColumnName("upload_date");
            entity.Property(e => e.Url)
                .IsUnicode(false)
                .HasColumnName("url");
            entity.Property(e => e.VendorAddress)
                .IsUnicode(false)
                .HasColumnName("vendor_address");
            entity.Property(e => e.VendorName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("vendor_name");
            entity.Property(e => e.VendorNpwp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vendor_npwp");

            entity.HasOne(d => d.Status).WithMany(p => p.VatInRecieves)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_vat_in_recieve_master_status");

            entity.HasOne(d => d.TransactionTypeCodeNavigation).WithMany(p => p.VatInRecieves)
                .HasForeignKey(d => d.TransactionTypeCode)
                .HasConstraintName("FK_vat_in_recieve_vat_in_recieve");
        });

        modelBuilder.Entity<VatInRecieveTemporary>(entity =>
        {
            entity.HasKey(e => e.VatInTemporary);

            entity.ToTable("vat_in_recieve_temporary");

            entity.Property(e => e.VatInTemporary).HasColumnName("vat_in_temporary");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("company_code");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.IsCreditable).HasColumnName("is_creditable");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("modified_date");
            entity.Property(e => e.Note)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.OriBusinessArea)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ori_business_area");
            entity.Property(e => e.OriNpwp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ori_npwp");
            entity.Property(e => e.OriPostingDate)
                .HasColumnType("date")
                .HasColumnName("ori_posting_date");
            entity.Property(e => e.OriPpn)
                .HasColumnType("money")
                .HasColumnName("ori_ppn");
            entity.Property(e => e.PostingDate)
                .HasColumnType("date")
                .HasColumnName("posting_date");
            entity.Property(e => e.RowStatus).HasColumnName("row_status");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TaxDate)
                .HasColumnType("date")
                .HasColumnName("tax_date");
            entity.Property(e => e.TaxDpp)
                .HasColumnType("money")
                .HasColumnName("tax_dpp");
            entity.Property(e => e.TaxFp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tax_fp");
            entity.Property(e => e.TaxNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tax_number");
            entity.Property(e => e.TaxPeriodMonth)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("tax_period_month");
            entity.Property(e => e.TaxPeriodYear).HasColumnName("tax_period_year");
            entity.Property(e => e.TaxPpn)
                .HasColumnType("money")
                .HasColumnName("tax_ppn");
            entity.Property(e => e.TaxPpnbm)
                .HasColumnType("money")
                .HasColumnName("tax_ppnbm");
            entity.Property(e => e.Url)
                .IsUnicode(false)
                .HasColumnName("url");
            entity.Property(e => e.VendorAddress)
                .IsUnicode(false)
                .HasColumnName("vendor_address");
            entity.Property(e => e.VendorName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("vendor_name");
            entity.Property(e => e.VendorNpwp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vendor_npwp");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
