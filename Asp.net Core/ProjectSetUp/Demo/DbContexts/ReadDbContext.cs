using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TestWeb.Models.Read;

namespace TestWeb.DbContexts
{
    public partial class ReadDbContext : DbContext
    {
        public ReadDbContext()
        {
        }

        public ReadDbContext(DbContextOptions<ReadDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBusinessPartner> TblBusinessPartner { get; set; }
        public virtual DbSet<TblBusinessPartnerRequestForQuotationHeader> TblBusinessPartnerRequestForQuotationHeader { get; set; }
        public virtual DbSet<TblBusinessPartnerRequestForQuotationRow> TblBusinessPartnerRequestForQuotationRow { get; set; }
        public virtual DbSet<TblBusinessUnit> TblBusinessUnit { get; set; }
        public virtual DbSet<TblCurrency> TblCurrency { get; set; }
        public virtual DbSet<TblItemBasicInfo> TblItemBasicInfo { get; set; }
        public virtual DbSet<TblPurchaseOrganization> TblPurchaseOrganization { get; set; }
        public virtual DbSet<TblPurchaseOrganizationBusinessUnitConfig> TblPurchaseOrganizationBusinessUnitConfig { get; set; }
        public virtual DbSet<TblPurchaseRequestHeader> TblPurchaseRequestHeader { get; set; }
        public virtual DbSet<TblPurchaseRequestRow> TblPurchaseRequestRow { get; set; }
        public virtual DbSet<TblPurchaseRequestType> TblPurchaseRequestType { get; set; }
        public virtual DbSet<TblRequestForQuotationHeader> TblRequestForQuotationHeader { get; set; }
        public virtual DbSet<TblRequestForQuotationReceiveHeader> TblRequestForQuotationReceiveHeader { get; set; }
        public virtual DbSet<TblRequestForQuotationReceiveRow> TblRequestForQuotationReceiveRow { get; set; }
        public virtual DbSet<TblRequestForQuotationRow> TblRequestForQuotationRow { get; set; }
        public virtual DbSet<TblUnitOfMeasurement> TblUnitOfMeasurement { get; set; }
        public virtual DbSet<TblWarehouse> TblWarehouse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=10.109.133.151,41527;Initial Catalog=erpm;User ID=erpmapp;Password=wtsa0wdewp@6vpo#08dssd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBusinessPartner>(entity =>
            {
                entity.HasKey(e => e.IntBusinessPartnerId);

                entity.ToTable("tblBusinessPartner", "prt");

                entity.Property(e => e.IntBusinessPartnerId).HasColumnName("intBusinessPartnerId");

                entity.Property(e => e.DteLastActionDateTime)
                    .HasColumnName("dteLastActionDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DteServerDateTime)
                    .HasColumnName("dteServerDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");

                entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");

                entity.Property(e => e.IntBusinessPartnerTypeId).HasColumnName("intBusinessPartnerTypeID");

                entity.Property(e => e.IntBusinessUnitId).HasColumnName("intBusinessUnitId");

                entity.Property(e => e.IntTaxBracketId).HasColumnName("intTaxBracketId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.StrAttachmentLink)
                    .HasColumnName("strAttachmentLink")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StrBin)
                    .HasColumnName("strBIN")
                    .HasMaxLength(20);

                entity.Property(e => e.StrBusinessPartnerAddress)
                    .IsRequired()
                    .HasColumnName("strBusinessPartnerAddress")
                    .HasMaxLength(300);

                entity.Property(e => e.StrBusinessPartnerCode)
                    .IsRequired()
                    .HasColumnName("strBusinessPartnerCode")
                    .HasMaxLength(50);

                entity.Property(e => e.StrBusinessPartnerName)
                    .IsRequired()
                    .HasColumnName("strBusinessPartnerName")
                    .HasMaxLength(100);

                entity.Property(e => e.StrContactNumber)
                    .IsRequired()
                    .HasColumnName("strContactNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.StrEmail)
                    .IsRequired()
                    .HasColumnName("strEmail")
                    .HasMaxLength(100);

                entity.Property(e => e.StrLicenseNo)
                    .HasColumnName("strLicenseNo")
                    .HasMaxLength(50);

                entity.Property(e => e.StrNid)
                    .IsRequired()
                    .HasColumnName("strNID")
                    .HasMaxLength(100);

                entity.Property(e => e.StrPartnerSalesType)
                    .HasColumnName("strPartnerSalesType")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBusinessPartnerRequestForQuotationHeader>(entity =>
            {
                entity.HasKey(e => e.IntPartnerRfqid)
                    .HasName("PK_tblBusinessPartnerRequestForQuotationHeader_1");

                entity.ToTable("tblBusinessPartnerRequestForQuotationHeader", "pro");

                entity.Property(e => e.IntPartnerRfqid).HasColumnName("intPartnerRFQId");

                entity.Property(e => e.DteIssueDate)
                    .HasColumnName("dteIssueDate")
                    .HasColumnType("date");

                entity.Property(e => e.DteLastActionDateTime)
                    .HasColumnName("dteLastActionDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DteReleaseDate)
                    .HasColumnName("dteReleaseDate")
                    .HasColumnType("date");

                entity.Property(e => e.DteServerDateTime)
                    .HasColumnName("dteServerDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DteSupplierRefDate)
                    .HasColumnName("dteSupplierRefDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");

                entity.Property(e => e.IntBusinessPartnerId).HasColumnName("intBusinessPartnerId");

                entity.Property(e => e.IntBusinessUnitId).HasColumnName("intBusinessUnitId");

                entity.Property(e => e.IntLastActionBy).HasColumnName("intLastActionBy");

                entity.Property(e => e.IntRequestForQuotationId).HasColumnName("intRequestForQuotationId");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsEmailSend).HasColumnName("isEmailSend");

                entity.Property(e => e.IsQuotationReceived).HasColumnName("isQuotationReceived");

                entity.Property(e => e.StrContactNumber)
                    .HasColumnName("strContactNumber")
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.StrDocAttachmentLink)
                    .HasColumnName("strDocAttachmentLink")
                    .HasMaxLength(300);

                entity.Property(e => e.StrEmail)
                    .HasColumnName("strEmail")
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.StrSupplierRefNo)
                    .IsRequired()
                    .HasColumnName("strSupplierRefNo")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IntBusinessPartner)
                    .WithMany(p => p.TblBusinessPartnerRequestForQuotationHeader)
                    .HasForeignKey(d => d.IntBusinessPartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblBusinessPartnerRequestForQuotationHeader_tblBusinessPartner");

                entity.HasOne(d => d.IntBusinessUnit)
                    .WithMany(p => p.TblBusinessPartnerRequestForQuotationHeader)
                    .HasForeignKey(d => d.IntBusinessUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblBusinessPartnerRequestForQuotationHeader_tblBusinessUnit");

                entity.HasOne(d => d.IntRequestForQuotation)
                    .WithMany(p => p.TblBusinessPartnerRequestForQuotationHeader)
                    .HasForeignKey(d => d.IntRequestForQuotationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblBusinessPartnerRequestForQuotationHeader_tblRequestForQuotationHeader");
            });

            modelBuilder.Entity<TblBusinessPartnerRequestForQuotationRow>(entity =>
            {
                entity.HasKey(e => e.IntRowId)
                    .HasName("PK_tblBusinessPartnerRequestForQuotationRow_1");

                entity.ToTable("tblBusinessPartnerRequestForQuotationRow", "pro");

                entity.Property(e => e.IntRowId).HasColumnName("intRowId");

                entity.Property(e => e.DteLastActionDateTime)
                    .HasColumnName("dteLastActionDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DteServerDateTime)
                    .HasColumnName("dteServerDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");

                entity.Property(e => e.IntItemId).HasColumnName("intItemId");

                entity.Property(e => e.IntPartnerRfqid).HasColumnName("intPartnerRFQId");

                entity.Property(e => e.IntUoMid).HasColumnName("intUoMId");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsSelected).HasColumnName("isSelected");

                entity.Property(e => e.NumRate)
                    .HasColumnName("numRate")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.NumRequestQuantity)
                    .HasColumnName("numRequestQuantity")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.NumValue)
                    .HasColumnName("numValue")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.StrRemarks)
                    .HasColumnName("strRemarks")
                    .HasMaxLength(500);

                entity.Property(e => e.StrSelectionComments)
                    .HasColumnName("strSelectionComments")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IntItem)
                    .WithMany(p => p.TblBusinessPartnerRequestForQuotationRow)
                    .HasForeignKey(d => d.IntItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblBusinessPartnerRequestForQuotationRow_tblItemBasicInfo");

                entity.HasOne(d => d.IntPartnerRfq)
                    .WithMany(p => p.TblBusinessPartnerRequestForQuotationRow)
                    .HasForeignKey(d => d.IntPartnerRfqid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblBusinessPartnerRequestForQuotationRow_tblBusinessPartnerRequestForQuotationHeader");

                entity.HasOne(d => d.IntUoM)
                    .WithMany(p => p.TblBusinessPartnerRequestForQuotationRow)
                    .HasForeignKey(d => d.IntUoMid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblBusinessPartnerRequestForQuotationRow_tblUnitOfMeasurement");
            });

            modelBuilder.Entity<TblBusinessUnit>(entity =>
            {
                entity.HasKey(e => e.IntBusinessUnitId);

                entity.ToTable("tblBusinessUnit", "dco");

                entity.Property(e => e.IntBusinessUnitId).HasColumnName("intBusinessUnitId");

                entity.Property(e => e.DteLastActionDateTime)
                    .HasColumnName("dteLastActionDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DteServerDateTime)
                    .HasColumnName("dteServerDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");

                entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StrBusinessUnitAddress)
                    .IsRequired()
                    .HasColumnName("strBusinessUnitAddress")
                    .HasMaxLength(300);

                entity.Property(e => e.StrBusinessUnitCode)
                    .IsRequired()
                    .HasColumnName("strBusinessUnitCode")
                    .HasMaxLength(50);

                entity.Property(e => e.StrBusinessUnitName)
                    .IsRequired()
                    .HasColumnName("strBusinessUnitName")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblCurrency>(entity =>
            {
                entity.HasKey(e => e.IntCurrencyId);

                entity.ToTable("tblCurrency", "dco");

                entity.Property(e => e.IntCurrencyId).HasColumnName("intCurrencyId");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StrCurrencyCode)
                    .IsRequired()
                    .HasColumnName("strCurrencyCode")
                    .HasMaxLength(50);

                entity.Property(e => e.StrCurrencyName)
                    .IsRequired()
                    .HasColumnName("strCurrencyName")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblItemBasicInfo>(entity =>
            {
                entity.HasKey(e => e.IntItemId)
                    .HasName("PK_tblItem");

                entity.ToTable("tblItemBasicInfo", "itm");

                entity.Property(e => e.IntItemId).HasColumnName("intItemId");

                entity.Property(e => e.DteLastActionDateTime)
                    .HasColumnName("dteLastActionDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DteServerDateTime)
                    .HasColumnName("dteServerDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");

                entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");

                entity.Property(e => e.IntItemCategoryId).HasColumnName("intItemCategoryId");

                entity.Property(e => e.IntItemSubCategoryId).HasColumnName("intItemSubCategoryId");

                entity.Property(e => e.IntItemTypeId).HasColumnName("intItemTypeId");

                entity.Property(e => e.IntUom).HasColumnName("intUOM");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StrHscode)
                    .HasColumnName("strHSCode")
                    .HasMaxLength(100);

                entity.Property(e => e.StrItemCode)
                    .IsRequired()
                    .HasColumnName("strItemCode")
                    .HasMaxLength(50);

                entity.Property(e => e.StrItemName)
                    .IsRequired()
                    .HasColumnName("strItemName")
                    .HasMaxLength(200);

                entity.Property(e => e.StrPartNumber)
                    .HasColumnName("strPartNumber")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IntUomNavigation)
                    .WithMany(p => p.TblItemBasicInfo)
                    .HasForeignKey(d => d.IntUom)
                    .HasConstraintName("FK_tblItemBasicInfo_tblUnitOfMeasurement");
            });

            modelBuilder.Entity<TblPurchaseOrganization>(entity =>
            {
                entity.HasKey(e => e.IntPurchaseOrganizationId);

                entity.ToTable("tblPurchaseOrganization", "pro");

                entity.Property(e => e.IntPurchaseOrganizationId).HasColumnName("intPurchaseOrganizationId");

                entity.Property(e => e.DteLastActionDateTime)
                    .HasColumnName("dteLastActionDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DteServerDateTime)
                    .HasColumnName("dteServerDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");

                entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StrPurchaseOrganization)
                    .IsRequired()
                    .HasColumnName("strPurchaseOrganization")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblPurchaseOrganizationBusinessUnitConfig>(entity =>
            {
                entity.HasKey(e => e.IntConfigId);

                entity.ToTable("tblPurchaseOrganizationBusinessUnitConfig", "pro");

                entity.Property(e => e.IntConfigId).HasColumnName("intConfigId");

                entity.Property(e => e.DteServerDateTime)
                    .HasColumnName("dteServerDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");

                entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");

                entity.Property(e => e.IntBusinessUnitId).HasColumnName("intBusinessUnitId");

                entity.Property(e => e.IntPurchaseOrganizationId).HasColumnName("intPurchaseOrganizationId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LastActionDateTime)
                    .HasColumnName("lastActionDateTime")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IntBusinessUnit)
                    .WithMany(p => p.TblPurchaseOrganizationBusinessUnitConfig)
                    .HasForeignKey(d => d.IntBusinessUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPurchaseOrganizationBusinessUnitConfig_tblBusinessUnit");

                entity.HasOne(d => d.IntPurchaseOrganization)
                    .WithMany(p => p.TblPurchaseOrganizationBusinessUnitConfig)
                    .HasForeignKey(d => d.IntPurchaseOrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPurchaseOrganizationBusinessUnitConfig_tblPurchaseOrganization");
            });

            modelBuilder.Entity<TblPurchaseRequestHeader>(entity =>
            {
                entity.HasKey(e => e.IntPurchaseRequestId);

                entity.ToTable("tblPurchaseRequestHeader", "pro");

                entity.Property(e => e.IntPurchaseRequestId).HasColumnName("intPurchaseRequestId");

                entity.Property(e => e.DteClosedDateTime)
                    .HasColumnName("dteClosedDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DteLastActionDateTime)
                    .HasColumnName("dteLastActionDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DteRequestDate)
                    .HasColumnName("dteRequestDate")
                    .HasColumnType("date");

                entity.Property(e => e.DteServerDateTime)
                    .HasColumnName("dteServerDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");

                entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");

                entity.Property(e => e.IntBusinessUnitId).HasColumnName("intBusinessUnitId");

                entity.Property(e => e.IntClosedBy).HasColumnName("intClosedBy");

                entity.Property(e => e.IntPurchaseOrganizationId).HasColumnName("intPurchaseOrganizationId");

                entity.Property(e => e.IntPurchaseRequestTypeId).HasColumnName("intPurchaseRequestTypeId");

                entity.Property(e => e.IntWarehouseId).HasColumnName("intWarehouseId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsApproved).HasColumnName("isApproved");

                entity.Property(e => e.IsClosed).HasColumnName("isClosed");

                entity.Property(e => e.IsComplete).HasColumnName("isComplete");

                entity.Property(e => e.StrAccountName)
                    .IsRequired()
                    .HasColumnName("strAccountName")
                    .HasMaxLength(100);

                entity.Property(e => e.StrBusinessUnitName)
                    .IsRequired()
                    .HasColumnName("strBusinessUnitName")
                    .HasMaxLength(100);

                entity.Property(e => e.StrClosedBy)
                    .HasColumnName("strClosedBy")
                    .HasMaxLength(100);

                entity.Property(e => e.StrDeliveryAddress)
                    .IsRequired()
                    .HasColumnName("strDeliveryAddress")
                    .HasMaxLength(300);

                entity.Property(e => e.StrNarration)
                    .HasColumnName("strNarration")
                    .HasMaxLength(100);

                entity.Property(e => e.StrPurchaseOrganizationName)
                    .IsRequired()
                    .HasColumnName("strPurchaseOrganizationName")
                    .HasMaxLength(100);

                entity.Property(e => e.StrPurchaseRequestCode)
                    .HasColumnName("strPurchaseRequestCode")
                    .HasMaxLength(50);

                entity.Property(e => e.StrPurchaseRequestTypeName)
                    .IsRequired()
                    .HasColumnName("strPurchaseRequestTypeName")
                    .HasMaxLength(100);

                entity.Property(e => e.StrWarehouseName)
                    .IsRequired()
                    .HasColumnName("strWarehouseName")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblPurchaseRequestRow>(entity =>
            {
                entity.HasKey(e => e.IntRowId);

                entity.ToTable("tblPurchaseRequestRow", "pro");

                entity.Property(e => e.IntRowId).HasColumnName("intRowId");

                entity.Property(e => e.DteRequiredDate)
                    .HasColumnName("dteRequiredDate")
                    .HasColumnType("date");

                entity.Property(e => e.IntCostElementId).HasColumnName("intCostElementId");

                entity.Property(e => e.IntCostcenterId).HasColumnName("intCostcenterId");

                entity.Property(e => e.IntItemId).HasColumnName("intItemId");

                entity.Property(e => e.IntPurchaseRequestId).HasColumnName("intPurchaseRequestId");

                entity.Property(e => e.IntUoMid).HasColumnName("intUoMId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.NumApprovedQuantity)
                    .HasColumnName("numApprovedQuantity")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.NumPurchaseOrderQuantity)
                    .HasColumnName("numPurchaseOrderQuantity")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.NumRequestQuantity)
                    .HasColumnName("numRequestQuantity")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.StrCostCenterName)
                    .HasColumnName("strCostCenterName")
                    .HasMaxLength(100);

                entity.Property(e => e.StrCostElementName)
                    .HasColumnName("strCostElementName")
                    .HasMaxLength(100);

                entity.Property(e => e.StrItemCode)
                    .HasColumnName("strItemCode")
                    .HasMaxLength(50);

                entity.Property(e => e.StrItemName)
                    .IsRequired()
                    .HasColumnName("strItemName")
                    .HasMaxLength(100);

                entity.Property(e => e.StrUoMname)
                    .IsRequired()
                    .HasColumnName("strUoMName")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IntPurchaseRequest)
                    .WithMany(p => p.TblPurchaseRequestRow)
                    .HasForeignKey(d => d.IntPurchaseRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPurchaseRequestRow_tblPurchaseRequestHeader");
            });

            modelBuilder.Entity<TblPurchaseRequestType>(entity =>
            {
                entity.HasKey(e => e.IntPurchaseRequestTypeId);

                entity.ToTable("tblPurchaseRequestType", "pro");

                entity.Property(e => e.IntPurchaseRequestTypeId).HasColumnName("intPurchaseRequestTypeId");

                entity.Property(e => e.DteLastActionDateTime)
                    .HasColumnName("dteLastActionDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DteServerDateTime)
                    .HasColumnName("dteServerDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StrPurchaseRequestTypeName)
                    .IsRequired()
                    .HasColumnName("strPurchaseRequestTypeName")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblRequestForQuotationHeader>(entity =>
            {
                entity.HasKey(e => e.IntRequestForQuotationId);

                entity.ToTable("tblRequestForQuotationHeader", "pro");

                entity.Property(e => e.IntRequestForQuotationId).HasColumnName("intRequestForQuotationId");

                entity.Property(e => e.DteApprovalDate)
                    .HasColumnName("dteApprovalDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DteLastActionDateTime)
                    .HasColumnName("dteLastActionDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DteRfqdate)
                    .HasColumnName("dteRFQDate")
                    .HasColumnType("date");

                entity.Property(e => e.DteServerDateTime)
                    .HasColumnName("dteServerDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DteValidTillDate)
                    .HasColumnName("dteValidTillDate")
                    .HasColumnType("date");

                entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");

                entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");

                entity.Property(e => e.IntApprovedBy).HasColumnName("intApprovedBy");

                entity.Property(e => e.IntBusinessUnitId).HasColumnName("intBusinessUnitId");

                entity.Property(e => e.IntCurrencyId).HasColumnName("intCurrencyId");

                entity.Property(e => e.IntPurchaseOrganizationId).HasColumnName("intPurchaseOrganizationId");

                entity.Property(e => e.IntRequestTypeId).HasColumnName("intRequestTypeId");

                entity.Property(e => e.IntWarehouseId).HasColumnName("intWarehouseId");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsApproved).HasColumnName("isApproved");

                entity.Property(e => e.StrReferenceTypeName)
                    .IsRequired()
                    .HasColumnName("strReferenceTypeName")
                    .HasMaxLength(100);

                entity.Property(e => e.StrRequestForQuotationCode)
                    .IsRequired()
                    .HasColumnName("strRequestForQuotationCode")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IntBusinessUnit)
                    .WithMany(p => p.TblRequestForQuotationHeader)
                    .HasForeignKey(d => d.IntBusinessUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRequestForQuotationHeader_tblBusinessUnit");

                entity.HasOne(d => d.IntCurrency)
                    .WithMany(p => p.TblRequestForQuotationHeader)
                    .HasForeignKey(d => d.IntCurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRequestForQuotationHeader_tblCurrency");

                entity.HasOne(d => d.IntPurchaseOrganization)
                    .WithMany(p => p.TblRequestForQuotationHeader)
                    .HasForeignKey(d => d.IntPurchaseOrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRequestForQuotationHeader_tblPurchaseOrganization");

                entity.HasOne(d => d.IntRequestType)
                    .WithMany(p => p.TblRequestForQuotationHeader)
                    .HasForeignKey(d => d.IntRequestTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRequestForQuotationHeader_tblPurchaseRequestType");

                entity.HasOne(d => d.IntWarehouse)
                    .WithMany(p => p.TblRequestForQuotationHeader)
                    .HasForeignKey(d => d.IntWarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRequestForQuotationHeader_tblWarehouse");
            });

            modelBuilder.Entity<TblRequestForQuotationReceiveHeader>(entity =>
            {
                entity.HasKey(e => e.IntPartnerRfqid)
                    .HasName("PK_tblBusinessPartnerRequestForQuotationHeader");

                entity.ToTable("tblRequestForQuotationReceiveHeader", "pro");

                entity.Property(e => e.IntPartnerRfqid).HasColumnName("intPartnerRFQId");

                entity.Property(e => e.DteIssueDate)
                    .HasColumnName("dteIssueDate")
                    .HasColumnType("date");

                entity.Property(e => e.DteLastActionDateTime)
                    .HasColumnName("dteLastActionDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DteReleaseDate)
                    .HasColumnName("dteReleaseDate")
                    .HasColumnType("date");

                entity.Property(e => e.DteServerDateTime)
                    .HasColumnName("dteServerDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DteSupplierRefDate)
                    .HasColumnName("dteSupplierRefDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");

                entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");

                entity.Property(e => e.IntBusinessUnitId).HasColumnName("intBusinessUnitId");

                entity.Property(e => e.IntRequestForQuotationId).HasColumnName("intRequestForQuotationId");

                entity.Property(e => e.IntSupplierId).HasColumnName("intSupplierId");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsEmailSend).HasColumnName("isEmailSend");

                entity.Property(e => e.IsQuotationReceived).HasColumnName("isQuotationReceived");

                entity.Property(e => e.StrContactNumber)
                    .HasColumnName("strContactNumber")
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.StrDocAttachmentLink)
                    .HasColumnName("strDocAttachmentLink")
                    .HasMaxLength(300);

                entity.Property(e => e.StrEmail)
                    .HasColumnName("strEmail")
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.StrRequestForQuotationCode)
                    .IsRequired()
                    .HasColumnName("strRequestForQuotationCode")
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.StrSupplierAddress)
                    .IsRequired()
                    .HasColumnName("strSupplierAddress")
                    .HasMaxLength(300);

                entity.Property(e => e.StrSupplierCode)
                    .IsRequired()
                    .HasColumnName("strSupplierCode")
                    .HasMaxLength(50);

                entity.Property(e => e.StrSupplierName)
                    .IsRequired()
                    .HasColumnName("strSupplierName")
                    .HasMaxLength(100);

                entity.Property(e => e.StrSupplierRefNo)
                    .IsRequired()
                    .HasColumnName("strSupplierRefNo")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblRequestForQuotationReceiveRow>(entity =>
            {
                entity.HasKey(e => e.IntRowId)
                    .HasName("PK_tblBusinessPartnerRequestForQuotationRow");

                entity.ToTable("tblRequestForQuotationReceiveRow", "pro");

                entity.Property(e => e.IntRowId).HasColumnName("intRowId");

                entity.Property(e => e.DteLastActionDateTime)
                    .HasColumnName("dteLastActionDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DteServerDateTime)
                    .HasColumnName("dteServerDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");

                entity.Property(e => e.IntItemId).HasColumnName("intItemId");

                entity.Property(e => e.IntPartnerRfqid).HasColumnName("intPartnerRFQId");

                entity.Property(e => e.IntUoMid).HasColumnName("intUoMId");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsSelected).HasColumnName("isSelected");

                entity.Property(e => e.NumRate)
                    .HasColumnName("numRate")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.NumRequestQuantity)
                    .HasColumnName("numRequestQuantity")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.NumValue)
                    .HasColumnName("numValue")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.StrItemCode)
                    .IsRequired()
                    .HasColumnName("strItemCode")
                    .HasMaxLength(50);

                entity.Property(e => e.StrItemName)
                    .IsRequired()
                    .HasColumnName("strItemName")
                    .HasMaxLength(100);

                entity.Property(e => e.StrNarration)
                    .HasColumnName("strNarration")
                    .HasMaxLength(500);

                entity.Property(e => e.StrSelectionComments)
                    .HasColumnName("strSelectionComments")
                    .HasMaxLength(500);

                entity.Property(e => e.StrUoMname)
                    .IsRequired()
                    .HasColumnName("strUoMName")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IntPartnerRfq)
                    .WithMany(p => p.TblRequestForQuotationReceiveRow)
                    .HasForeignKey(d => d.IntPartnerRfqid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRequestForQuotationReceiveRow_tblRequestForQuotationReceiveHeader");
            });

            modelBuilder.Entity<TblRequestForQuotationRow>(entity =>
            {
                entity.HasKey(e => e.IntRowId);

                entity.ToTable("tblRequestForQuotationRow", "pro");

                entity.Property(e => e.IntRowId).HasColumnName("intRowId");

                entity.Property(e => e.IntItemId).HasColumnName("intItemId");

                entity.Property(e => e.IntReferenceCode)
                    .HasColumnName("intReferenceCode")
                    .HasMaxLength(100);

                entity.Property(e => e.IntReferenceId).HasColumnName("intReferenceId");

                entity.Property(e => e.IntRequestForQuotationId).HasColumnName("intRequestForQuotationId");

                entity.Property(e => e.IntUoMid).HasColumnName("intUoMId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.NumReferenceQuantity)
                    .HasColumnName("numReferenceQuantity")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.NumRfqquantity)
                    .HasColumnName("numRFQQuantity")
                    .HasColumnType("numeric(18, 6)");

                entity.Property(e => e.StrDescription)
                    .IsRequired()
                    .HasColumnName("strDescription")
                    .HasMaxLength(300);

                entity.HasOne(d => d.IntItem)
                    .WithMany(p => p.TblRequestForQuotationRow)
                    .HasForeignKey(d => d.IntItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRequestForQuotationRow_tblItemBasicInfo");

                entity.HasOne(d => d.IntRequestForQuotation)
                    .WithMany(p => p.TblRequestForQuotationRow)
                    .HasForeignKey(d => d.IntRequestForQuotationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRequestForQuotationRow_tblRequestForQuotationHeader");

                entity.HasOne(d => d.IntUoM)
                    .WithMany(p => p.TblRequestForQuotationRow)
                    .HasForeignKey(d => d.IntUoMid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRequestForQuotationRow_tblUnitOfMeasurement");
            });

            modelBuilder.Entity<TblUnitOfMeasurement>(entity =>
            {
                entity.HasKey(e => e.IntUomid);

                entity.ToTable("tblUnitOfMeasurement", "itm");

                entity.Property(e => e.IntUomid).HasColumnName("intUOMId");

                entity.Property(e => e.DteLastActionDateTime)
                    .HasColumnName("dteLastActionDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DteServerDateTime)
                    .HasColumnName("dteServerDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");

                entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");

                entity.Property(e => e.IntBusinessUnitId).HasColumnName("intBusinessUnitId");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StrUomCode)
                    .IsRequired()
                    .HasColumnName("strUomCode")
                    .HasMaxLength(50);

                entity.Property(e => e.StrUomName)
                    .IsRequired()
                    .HasColumnName("strUomName")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblWarehouse>(entity =>
            {
                entity.HasKey(e => e.IntWarehouseId);

                entity.ToTable("tblWarehouse", "inv");

                entity.Property(e => e.IntWarehouseId).HasColumnName("intWarehouseId");

                entity.Property(e => e.DteLastActionDateTime)
                    .HasColumnName("dteLastActionDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DteServerDateTime)
                    .HasColumnName("dteServerDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntAccountId).HasColumnName("intAccountId");

                entity.Property(e => e.IntActionBy).HasColumnName("intActionBy");

                entity.Property(e => e.IntWarehouseTypeId).HasColumnName("intWarehouseTypeId");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StrWarehouseAddress)
                    .IsRequired()
                    .HasColumnName("strWarehouseAddress")
                    .HasMaxLength(300);

                entity.Property(e => e.StrWarehouseCode)
                    .IsRequired()
                    .HasColumnName("strWarehouseCode")
                    .HasMaxLength(50);

                entity.Property(e => e.StrWarehouseName)
                    .IsRequired()
                    .HasColumnName("strWarehouseName")
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
