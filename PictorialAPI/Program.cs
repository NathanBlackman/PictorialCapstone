using PictorialAPI.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IArtistUserRepository, ArtistUserRepository>();
builder.Services.AddTransient<IPiecesRepository, PiecesRepository>();
builder.Services.AddTransient<IUserPiecesRepository, UserPiecesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
/*app.UseStaticFiles();*/

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.Run();
