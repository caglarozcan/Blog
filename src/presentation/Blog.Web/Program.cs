﻿using Blog.Application.Dto.SettingDto.BlogOptions;
using Blog.Infrastructure;
using Blog.Persistence;
using Blog.Persistence.Configuration;
using Blog.Persistence.EfContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
/*
 * Oturum yönetiminin her Controller için otomatik olarak yapılması için bu şekilde konfigüre edilir.
builder.Services.AddControllersWithViews(config =>
{
	var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
	config.Filters.Add(new AuthorizeFilter(policy));
});*/

builder.Services.AddControllersWithViews().AddMvcOptions(o =>
{
	o.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(_ => "Geçersiz değer girildi. Kontrol ediniz.");
}).AddRazorRuntimeCompilation();

//Veritabanı için connection string tanımlaması.
builder.Services.AddDbContext<EfBlogContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("BlogContext"), x => x.MigrationsAssembly("Blog.Persistence"));
});

builder.Host.ConfigureAppConfiguration(options =>
{
	options.AddSqlServer(builder.Configuration.GetConnectionString("BlogContext"));
});


//Blog.Infrastructure katmanı servisleri inject edilmesi.
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices();

builder.Services.AddHttpContextAccessor();

//Blog Options
builder.Services.Configure<ArticleOptions>(builder.Configuration.GetSection("ArticleSettings"));
builder.Services.Configure<CommentOptions>(builder.Configuration.GetSection("CommentSettings"));
builder.Services.Configure<EmailOptions>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.Configure<FileUploadOptions>(builder.Configuration.GetSection("FileUploadSettings"));
builder.Services.Configure<GeneralSiteOptions>(builder.Configuration.GetSection("GeneralSettings"));
builder.Services.Configure<PaginationOptions>(builder.Configuration.GetSection("PagingSettings"));

//Sessions ve Cookie Authentication
builder.Services.AddSession();
builder.Services.AddAuthentication("CookieAuthentication").AddCookie("CookieAuthentication", option =>
{
	option.LoginPath = "/yonetim";
	option.LogoutPath = "/yonetim";
	option.AccessDeniedPath = "/yonetim/yetkisiz-erisim";
	option.SlidingExpiration = true;
	option.ExpireTimeSpan = TimeSpan.FromDays(3);
	option.Cookie = new CookieBuilder()
	{
		Name = "UserLoginCookie",
		HttpOnly = true,
		SameSite = SameSiteMode.Strict,
		SecurePolicy = CookieSecurePolicy.SameAsRequest
	};
});

//policy bazlı yetki kontrolü
/*builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Administrator"));
	options.AddPolicy("RequireEditor", policy => policy.RequireRole("Editör"));
	options.AddPolicy("YazarEditor", policy => policy.RequireRole("Yazar"));
});*/

/*builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
	config.Filters.Add(new AuthorizeFilter(policy));
});*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	//app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	//app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	#region Admin
	#region Admin Menu
	endpoints.MapAreaControllerRoute(
		name: "AdminLogin",
		areaName: "Admin",
		pattern: "yonetim",
		defaults: new { area = "Admin", controller = "Authentication", action = "Index" }
	);
	endpoints.MapAreaControllerRoute(
		name: "AdminLogout",
		areaName: "Admin",
		pattern: "cikis",
		defaults: new { area = "Admin", controller = "Authentication", action = "LogOut" }
	);
	endpoints.MapAreaControllerRoute(
		name: "AdminHome",
		areaName: "Admin",
		pattern: "yonetim/panel",
		defaults: new { area = "Admin", controller = "Home", action = "Index" }
	);
	#endregion

	#region Category
	endpoints.MapAreaControllerRoute(
		name: "AdminCategories",
		areaName: "Admin",
		pattern: "yonetim/kategori",
		defaults: new { area = "Admin", controller = "Category", action = "Index" }
	);
	endpoints.MapAreaControllerRoute(
		name: "CategoryInsert",
		areaName: "Admin",
		pattern: "yonetim/kategori-ekle",
		defaults: new { area = "Admin", controller = "Category", action = "Insert" }
	);
	endpoints.MapAreaControllerRoute(
		name: "CategoryEdit",
		areaName: "Admin",
		pattern: "yonetim/kategori-duzenle",
		defaults: new { area = "Admin", controller = "Category", action = "Edit" }
	);
	#endregion

	#region Article
	endpoints.MapAreaControllerRoute(
		name: "AdminArticle",
		areaName: "Admin",
		pattern: "yonetim/makale",
		defaults: new { area = "Admin", controller = "Article", action = "Index" }
	);
	endpoints.MapAreaControllerRoute(
		name: "AdminArticleInsert",
		areaName: "Admin",
		pattern: "yonetim/makale-ekle",
		defaults: new { area = "Admin", controller = "Article", action = "Insert" }
	);
	endpoints.MapAreaControllerRoute(
		name: "AdminArticleSeries",
		areaName: "Admin",
		pattern: "yonetim/seri-makaleler",
		defaults: new { area = "Admin", controller = "Article", action = "Series" }
	);
	#endregion

	#region Bibliography
	endpoints.MapAreaControllerRoute(
		name: "AdminBibliographies",
		areaName: "Admin",
		pattern: "yonetim/kaynakca",
		defaults: new { area = "Admin", controller = "Bibliography", action = "Index" }
	);
	
	endpoints.MapAreaControllerRoute(
		name: "BibliographyInsert",
		areaName: "Admin",
		pattern: "yonetim/kaynakca-ekle",
		defaults: new { area = "Admin", controller = "Bibliography", action = "Insert" }
	);
	
	endpoints.MapAreaControllerRoute(
		name: "BibliographyEdit",
		areaName: "Admin",
		pattern: "yonetim/kaynakca-duzenle",
		defaults: new { area = "Admin", controller = "Bibliography", action = "Edit" }
	);
	#endregion

	#region User
	endpoints.MapAreaControllerRoute(
		name: "AdminUsers",
		areaName: "Admin",
		pattern: "yonetim/kullanici",
		defaults: new { area = "Admin", controller = "Users", action = "Index" }
	);
	endpoints.MapAreaControllerRoute(
		name: "UserInsert",
		areaName: "Admin",
		pattern: "yonetim/kullanici-ekle",
		defaults: new { area = "Admin", controller = "Users", action = "Insert" }
	);
	endpoints.MapAreaControllerRoute(
		name: "UserUpdate",
		areaName: "Admin",
		pattern: "yonetim/kullanici-duzenle/{id}",
		defaults: new { area = "Admin", controller = "Users", action = "Update" }
	);
	#endregion

	#region Media
	endpoints.MapAreaControllerRoute(
		name: "AdminMedias",
		areaName: "Admin",
		pattern: "yonetim/medya",
		defaults: new { area = "Admin", controller = "Media", action = "Index" }
	);
	endpoints.MapAreaControllerRoute(
		name: "FileUpload",
		areaName: "Admin",
		pattern: "yonetim/dosya-yukle",
		defaults: new { area = "Admin", controller = "Media", action = "FileUpload" }
	);
	endpoints.MapAreaControllerRoute(
		name: "MediaType",
		areaName: "Admin",
		pattern: "yonetim/dosya-turleri",
		defaults: new { area = "Admin", controller = "MediaType", action = "Index" }
	);
	#endregion

	#region MediaType
	endpoints.MapAreaControllerRoute(
		name: "MediaTypeInsert",
		areaName: "Admin",
		pattern: "yonetim/medya-turu-ekle",
		defaults: new { area = "Admin", controller = "MediaType", action = "Insert" }
	);
	endpoints.MapAreaControllerRoute(
		name: "MediaTypeUpdate",
		areaName: "Admin",
		pattern: "yonetim/medya-turu-duzenle",
		defaults: new { area = "Admin", controller = "MediaType", action = "Edit" }
	);
	#endregion

	#region Settgins
	endpoints.MapAreaControllerRoute(
		name: "AdminSettings",
		areaName: "Admin",
		pattern: "yonetim/ayarlar",
		defaults: new { area = "Admin", controller = "Setting", action = "Index" }
	);
	#endregion

	#region Tags
	endpoints.MapAreaControllerRoute(
		name: "AdminTags",
		areaName: "Admin",
		pattern: "yonetim/etiket",
		defaults: new { area = "Admin", controller = "Tags", action = "Index" }
	);
	endpoints.MapAreaControllerRoute(
		name: "TagInsert",
		areaName: "Admin",
		pattern: "yonetim/etiket-ekle",
		defaults: new { area = "Admin", controller = "Tags", action = "Insert" }
	);
	endpoints.MapAreaControllerRoute(
		name: "TagEdit",
		areaName: "Admin",
		pattern: "yonetim/etiket-duzenle",
		defaults: new { area = "Admin", controller = "Tags", action = "Edit" }
	);
	#endregion

	#region Comments
	endpoints.MapAreaControllerRoute(
		name: "AdminComments",
		areaName: "Admin",
		pattern: "yonetim/yorum",
		defaults: new { area = "Admin", controller = "Comment", action = "Index" }
	);
	#endregion
	#endregion

	#region Subscribers
	endpoints.MapAreaControllerRoute(
		name: "AdminSubscribers",
		areaName: "Admin",
		pattern: "yonetim/aboneler",
		defaults: new { area = "Admin", controller = "Subscriber", action = "Index" }
	);
	#endregion

	#region Base Routes
	endpoints.MapControllerRoute(
		name: "areas",
		pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);

	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{Controller=Home}/{Action=Index}/{id?}"
	);
	#endregion
});

app.Run();
