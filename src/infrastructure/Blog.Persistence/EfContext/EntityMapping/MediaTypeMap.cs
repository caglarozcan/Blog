using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EfContext.EntityMapping;

public class MediaTypeMap : IEntityTypeConfiguration<MediaType>
{
	public void Configure(EntityTypeBuilder<MediaType> builder)
	{
		builder.ToTable(nameof(MediaType));

		builder.HasKey(k => k.Id).HasName("PK_MediaType_Id");

		builder.Property(p => p.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.ValueGeneratedOnAdd()
			.HasColumnOrder(0)
			.IsRequired(true);

		builder.Property(p => p.Title)
			.HasColumnName("Title")
			.HasColumnType("varchar(50)")
			.HasMaxLength(50)
			.HasColumnOrder(1)
			.IsRequired(true);

		builder.Property(p => p.MimeType)
			.HasColumnName("MimeType")
			.HasColumnType("varchar(30)")
			.HasMaxLength(30)
			.HasColumnOrder(2)
			.IsRequired(true);

		builder.Property(p => p.FileExtension)
			.HasColumnName("FileExtension")
			.HasColumnType("varchar(5)")
			.HasMaxLength(5)
			.HasColumnOrder(3)
			.IsRequired(true);

		builder.Property(p => p.Icon)
			.HasColumnName("Icon")
			.HasColumnType("varchar(20)")
			.HasMaxLength(20)
			.HasColumnOrder(4)
			.IsRequired(true);

		builder.Property(p => p.Color)
			.HasColumnName("Color")
			.HasColumnType("varchar(10)")
			.HasMaxLength(10)
			.HasColumnOrder(5)
			.IsRequired(true);

		builder.Property(p => p.UploadDir)
			.HasColumnName("UploadDir")
			.HasColumnType("varchar(200)")
			.HasMaxLength(200)
			.HasColumnOrder(6)
			.IsRequired(true);

		builder.Property(p => p.CreatedDate)
			.HasColumnName("CreatedDate")
			.HasColumnType("datetime")
			.HasColumnOrder(7)
			.HasDefaultValueSql("GETDATE()")
			.IsRequired(true);

		builder.Property(p => p.UpdatedDate)
			.HasColumnName("UpdatedDate")
			.HasColumnType("datetime")
			.HasColumnOrder(8)
			.IsRequired(false);

		builder.Property(p => p.Status)
			.HasColumnName("Status")
			.HasColumnType("tinyint")
			.HasColumnOrder(9)
			.HasDefaultValue(1)
			.IsRequired(true);

		#region Seed Data
		/*builder.HasData(
			new MediaType()
			{
				Title = "PNG Dosyasi",
				MimeType = "image/png",
				FileExtension = ".png",
				Icon = "--",
				Color = "--",
				UploadDir = "images/png",
				CreatedDate = DateTime.Now
			},
			new MediaType()
			{
				Title = "JPG Dosyasi",
				MimeType = "image/jpg",
				FileExtension = ".jpg",
				Icon = "--",
				Color = "--",
				UploadDir = "images/jpg",
				CreatedDate = DateTime.Now
			},
			new MediaType()
			{
				Title = "JPEG Dosyasi",
				MimeType = "image/jpeg",
				FileExtension = ".jpeg",
				Icon = "--",
				Color = "--",
				UploadDir = "images/jpeg",
				CreatedDate = DateTime.Now
			},
			new MediaType()
			{
				Title = "PDF Dosyasi",
				MimeType = "application/pdf",
				FileExtension = ".pdf",
				Icon = "--",
				Color = "--",
				UploadDir = "files/pdf",
				CreatedDate = DateTime.Now
			},
			new MediaType()
			{
				Title = "Excel Dosyasi",
				MimeType = "application/vnd.ms-excel",
				FileExtension = ".xls",
				Icon = "--",
				Color = "--",
				UploadDir = "files/xls",
				CreatedDate = DateTime.Now
			},
			new MediaType()
			{
				Title = "BMP Dosyasi",
				MimeType = "image/bmp",
				FileExtension = ".bmp",
				Icon = "-",
				Color = "-",
				UploadDir = "images/bmp",
				CreatedDate = DateTime.Now
			},
			new MediaType()
			{
				Title = "CSV Dosyasi",
				MimeType = "text/csv",
				FileExtension = ".csv",
				Icon = "-",
				Color = "-",
				UploadDir = "files/csv",
				CreatedDate = DateTime.Now
			},
			new MediaType()
			{
				Title = "Word Dosyasi",
				MimeType = "application/msword",
				FileExtension = ".doc",
				Icon = "-",
				Color = "-",
				UploadDir = "files/doc",
				CreatedDate = DateTime.Now
			},
			new MediaType()
			{
				Title = "GIF Dosyasi",
				MimeType = "image/gif",
				FileExtension = ".gif",
				Icon = "-",
				Color = "-",
				UploadDir = "images/gif",
				CreatedDate = DateTime.Now
			},
			new MediaType()
			{
				Title = "JSON Dosyasi",
				MimeType = "application/json",
				FileExtension = ".json",
				Icon = "-",
				Color = "-",
				UploadDir = "files/json",
				CreatedDate = DateTime.Now
			},
			new MediaType()
			{
				Title = "MP3 Dosyasi",
				MimeType = "audio/mpeg",
				FileExtension = ".mp3",
				Icon = "-",
				Color = "-",
				UploadDir = "files/mp3",
				CreatedDate = DateTime.Now
			},
			new MediaType()
			{
				Title = "RAR Dosyasi",
				MimeType = "application/vnd.rar",
				FileExtension = ".rar",
				Icon = "-",
				Color = "-",
				UploadDir = "files/rar",
				CreatedDate = DateTime.Now
			},
			new MediaType()
			{
				Title = "SVG Dosyasi",
				MimeType = "image/svg+xml",
				FileExtension = ".svg",
				Icon = "-",
				Color = "-",
				UploadDir = "images/svg",
				CreatedDate = DateTime.Now
			},
			new MediaType()
			{
				Title = "TEXT Dosyasi",
				MimeType = "text/plain",
				FileExtension = ".txt",
				Icon = "-",
				Color = "-",
				UploadDir = "files/text",
				CreatedDate = DateTime.Now
			},
			new MediaType()
			{
				Title = "ZIP Dosyasi",
				MimeType = "application/zip",
				FileExtension = ".zip",
				Icon = "-",
				Color = "-",
				UploadDir = "files/zip",
				CreatedDate = DateTime.Now
			});*/
		#endregion
	}
}
