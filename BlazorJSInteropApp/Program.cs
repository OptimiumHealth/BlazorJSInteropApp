using BlazorJSInteropApp.Data;

using Material.Blazor;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


builder.Services.AddMBServices(
    loggingServiceConfiguration: new MBLoggingServiceConfiguration()
    {
        LoggingLevel = MBLoggingLevel.Debug
    },
    toastServiceConfiguration: new MBToastServiceConfiguration()
    {
        InfoDefaultHeading = "Info",
        SuccessDefaultHeading = "Success",
        WarningDefaultHeading = "Warning",
        ErrorDefaultHeading = "Error",
        Timeout = 10000,
        MaxToastsShowing = 3,
        CloseMethod = MBNotifierCloseMethod.TimeoutAndDismissButton,
        Position = MBToastPosition.CenterLeft
    },
    snackbarServiceConfiguration: new MBSnackbarServiceConfiguration()
    {
        CloseMethod = MBNotifierCloseMethod.TimeoutAndDismissButton,
        Leading = false,
        Stacked = true,
        Timeout = 5000,
    }
    );

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
