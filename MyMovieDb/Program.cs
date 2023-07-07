//this code imports the connectivity the necessary namespace and libraries to connect 
using MySql.Data.MySqlClient;
using System.Data;


// this method creates a new instance W.A.B. class, which is responsible for configuring the web application.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDbConnection>((s) =>
{
    IDbConnection conn = new MySqlConnection(builder.Configuration.GetConnectionString("movies_database"));
    conn.Open();
    return conn;
});
//This allows the application to inject an instance of IMoviesRepository whenever it is needed.
builder.Services.AddTransient<MyMovieDb.IMoviesRepository, MyMovieDb.MoviesRepository>();
//this builds the application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{   // if there is an error this message will display
    app.UseExceptionHandler("/Home/Error");
    
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//this redirect will make sure sensitive data will remain secure
app.UseHttpsRedirection();
//static files include HTML,CSS,JAVASCRIPT and images. they will not require server side processing (this is were they go wwwroot )
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// CRUD = create read update delete

//model = represents teh the data and bussiness logic of tthe application. it manages the data.provides methods to manipulate and access it.
//view = is responsible for presenting the data to the user. it generates the user interface and displays information retrieved from the model. the view is what the user sees and interacts with.
//controller = acts as an intermediary between the Model and the View. It receives input from the user through the View, processes that input, and updates the Model accordingly. It also takes data from the Model and sends it to the View for display.

//the purpose of my project was to make a movie database that uses crud 
// I have completed the project it is full functionality
// the frameworks that i used are AspNetCore and NetCore
// the nugget packages i used are Dapper and MySqlData
// I had many challenges while making the project.
// I used many resources to overcome all of them