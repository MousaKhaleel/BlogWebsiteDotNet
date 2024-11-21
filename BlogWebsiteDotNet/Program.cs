using BlogWebsiteDotNet.Data;
using BlogWebsiteDotNet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//builder.Services.AddAuthorization();
//builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentity<User, IdentityRole>(
	options =>
	{
		//temp for dev
		options.Password.RequiredUniqueChars = 0;
		options.Password.RequireUppercase = false;
		options.Password.RequireLowercase = false;
		options.Password.RequiredLength = 8;
		options.Password.RequireNonAlphanumeric = false;
	})
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
	var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
	var roles = new[] { "Admin", "Author", "Commenter" };
	foreach (var role in roles)
	{
		if (!await _roleManager.RoleExistsAsync(role))
		{
			await _roleManager.CreateAsync(new IdentityRole(role));
		}
	}
}

using (var scope = app.Services.CreateScope())
{
	var _userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
	var name = "Admin";
	var email = "Admin@adm.com";
	var password = "Admin@1234";
	if (await _userManager.FindByEmailAsync(email) == null)
	{
		var user = new IdentityUser();
		user.UserName = name;
		user.Email = email;
		await _userManager.CreateAsync(user, password);
		await _userManager.AddToRoleAsync(user, "Admin");
	}
}

app.Run();
