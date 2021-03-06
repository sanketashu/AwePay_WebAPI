// <auto-generated />
using AwePay_DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AwePay_DataAccess.Migrations
{
    [DbContext(typeof(AwePayContext))]
    [Migration("20210414031842_UserDatabaseCreated")]
    partial class UserDatabaseCreated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AwePay_DataAccess.UserData", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .IsRequired(false);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)")
                        .IsRequired(true);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(100)")
                        .IsRequired(true);

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(15)")
                        .IsRequired(false);

                    b.HasKey("ID");

                    b.ToTable("UserData");
                });
#pragma warning restore 612, 618
        }
    }
}
