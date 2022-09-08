using Material.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


builder.Services.AddMBServices(options =>
    {
        options.LoggingServiceConfiguration = new MBLoggingServiceConfiguration()
        {
            LoggingLevel = MBLoggingLevel.Debug,
        };
        options.ToastServiceConfiguration = new MBToastServiceConfiguration()
        {
            CloseMethod = MBNotifierCloseMethod.TimeoutAndDismissButton,
            ErrorDefaultHeading = "Error",
            InfoDefaultHeading = "Info",
            MaxToastsShowing = 3,
            Position = MBToastPosition.CenterLeft,
            SuccessDefaultHeading = "Success",
            Timeout = 3000,
            WarningDefaultHeading = "Warning",
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
