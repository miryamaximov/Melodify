using BL;
using DAL;
using DAL.models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(opt => opt.AddPolicy("AllowOrigin", policy =>
{
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

}));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MusicContext>();
builder.Services.AddScoped<Album_DAL>();
builder.Services.AddScoped<Album_BL>();
builder.Services.AddScoped<AlbumsDetail_DAL>();
builder.Services.AddScoped<AlbumsDetail_BL>();
builder.Services.AddScoped<CategoriesDetail_DAL>();
builder.Services.AddScoped<CategoriesDetail_BL>();
builder.Services.AddScoped<Category_DAL>();
builder.Services.AddScoped<Category_BL>();
builder.Services.AddScoped<Follower_DAL>();
builder.Services.AddScoped<Follower_BL>();
builder.Services.AddScoped<Playlist_DAL>();
builder.Services.AddScoped<Playlist_BL>();
builder.Services.AddScoped<PlaylistsDetail_DAL>();
builder.Services.AddScoped<PlaylistsDetail_BL>();
builder.Services.AddScoped<SharedPlaylistsDetail_DAL>();
builder.Services.AddScoped<SharedPlaylistsDeatail_BL>();
builder.Services.AddScoped<Singer_DAL>();
builder.Services.AddScoped<Singer_BL>();
builder.Services.AddScoped<Song_DAL>();
builder.Services.AddScoped<Song_BL>();
builder.Services.AddScoped<User_DAL>();
builder.Services.AddScoped<User_BL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
