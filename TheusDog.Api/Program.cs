using TheusDog.Infrastructure.Data;
using TheusDog.Infrastructure.Repositories;
using TheusDog.Application.Services;
using TheusDog.Application.Interfaces;
using TheusDog.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ─── Controllers ────────────────────────────────────────────
builder.Services.AddControllers();

// ─── Swagger ────────────────────────────────────────────────
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ─── Banco de dados ─────────────────────────────────────────
builder.Services.AddDbContext<DogHotelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ─── Repositórios ───────────────────────────────────────────
builder.Services.AddScoped<ITutorRepository, TutorRepository>();
builder.Services.AddScoped<IDogRepository, DogRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

// ─── Services ───────────────────────────────────────────────
builder.Services.AddScoped<ITutorService, TutorService>();
builder.Services.AddScoped<IDogService, DogService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IBookingService, BookingService>();

var app = builder.Build();

// ─── Pipeline ───────────────────────────────────────────────
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();