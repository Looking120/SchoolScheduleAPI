using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SchoolSchedule.API.Profiles; // Assurez-vous d'importer vos profiles AutoMapper ici

public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    // Configuration d'AutoMapper
    services.AddAutoMapper(typeof(Startup)); // Assurez-vous d'ajouter votre profil ici
}
