using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EfContext.EntityMapping
{
	public class CategoryMap : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable(nameof(Category));

			builder.HasKey(k => k.Id).HasName("PK_Category_Id");

			builder.Property(p => p.Id)
				.HasColumnName("Id")
				.HasColumnType("uniqueidentifier")
				.ValueGeneratedOnAdd()
				.HasColumnOrder(0)
				.IsRequired(true);

			builder.Property(p => p.ParentId)
				.HasColumnName("ParentId")
				.HasColumnType("uniqueidentifier")
				.HasColumnOrder(1)
				.IsRequired(false);

			builder.Property(p => p.Title)
				.HasColumnName("Title")
				.HasColumnType("varchar(60)")
				.HasMaxLength(60)
				.HasColumnOrder(2)
				.IsRequired(true);

			builder.Property(p => p.Description)
				.HasColumnName("Description")
				.HasColumnType("varchar(500)")
				.HasMaxLength(500)
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
				.HasColumnType("varchar(20)")
				.HasMaxLength(20)
				.HasColumnOrder(5)
				.IsRequired(true);

			builder.Property(p => p.CreatedDate)
				.HasColumnName("CreatedDate")
				.HasColumnType("datetime")
				.HasColumnOrder(6)
				.HasDefaultValueSql("GETDATE()")
				.IsRequired(true);

			builder.Property(p => p.UpdatedDate)
				.HasColumnName("UpdatedDate")
				.HasColumnType("datetime")
				.HasColumnOrder(7)
				.IsRequired(false);

			builder.Property(p => p.Slug)
				.HasColumnName("Slug")
				.HasColumnType("varchar(200)")
				.HasMaxLength(200)
				.HasColumnOrder(8)
				.IsRequired(true);

			builder.Property(p => p.Status)
				.HasColumnName("Status")
				.HasColumnType("tinyint")
				.HasColumnOrder(9)
				.HasDefaultValue(1)
				.IsRequired(true);

			#region Keys and Foreignkeys
			builder.HasOne(o => o.Parent)
				.WithMany(m => m.Childs)
				.HasForeignKey(f => f.ParentId)
				.HasConstraintName("FK_Category_Parent_Id")
				.OnDelete(DeleteBehavior.NoAction);
			#endregion

			#region Seed Data
			/*builder.HasData(new Category()
			{
				Color = "--",
				CreatedDate = DateTime.Now,
				Description = "Genel Kategorisi.",
				Icon = "--",
				Title = "Genel",
				Slug = "genel",
				Status = 1
			});*/
			#endregion
		}
	}
}
