using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PaySafe.IoC.Settings;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace PaySafe.IoC.Configurations.Swagger
{
    public class SwaggerOptions(IApiVersionDescriptionProvider provider,
                                IConfiguration configuration) : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {
            var settings = configuration.GetSection("Application").Get<ApplicationSettings>()!;

            foreach (var apiVersionDescription in provider.ApiVersionDescriptions)
                options.SwaggerDoc(apiVersionDescription.GroupName, CriarVersao(apiVersionDescription, settings));

            var executePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            var xmlFiles = Directory.GetFiles(executePath, "*.xml");

            foreach (var file in xmlFiles)
                options.IncludeXmlComments(file, true);
        }

        private static OpenApiInfo CriarVersao(
            ApiVersionDescription description, ApplicationSettings settings)
        {
            var versao = description.ApiVersion.ToString();

            var openApiInfo = new OpenApiInfo
            {
                Title = settings.Name,
                Version = versao,
                Description = settings.Description
            };

            if (description.IsDeprecated)
                openApiInfo.Description += $"A versão {versao} está depreciada.";

            return openApiInfo;
        }
    }
}
