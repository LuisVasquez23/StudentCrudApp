using Microsoft.EntityFrameworkCore;
using StudentCrudApp.Data;
using StudentCrudApp.Manager;

var builder = WebApplication.CreateBuilder(args);

#region ADD DB CONFIGURATION
builder.Services.AddDbContext<AppDbContext>( options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion

#region ADD MANAGER 
builder.Services.AddTransient<IStudentManager , StudentManager>();
#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
