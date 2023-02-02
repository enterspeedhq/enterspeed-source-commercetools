using commercetools.Sdk.Api.Models.Categories;
using commercetools.Sdk.Api.Models.Common;
using commercetools.Sdk.Api.Models.Products;
using commercetools.Sdk.Api.Models.Types;
using Enterspeed.Commercetools.Integration.Api.Mappers;
using Enterspeed.Commercetools.Integration.Api.Models;
using Enterspeed.Commercetools.Integration.Api.Providers;
using Enterspeed.Commercetools.Integration.Api.Repositories;
using Enterspeed.Commercetools.Integration.Api.Services;
using Enterspeed.Commercetools.Integration.Domain.Models;
using Enterspeed.Commercetools.Integration.Domain.Repositories;
using Enterspeed.Commercetools.Integration.Domain.Services;
using Enterspeed.Source.Sdk.Api.Connection;
using Enterspeed.Source.Sdk.Api.Models.Properties;
using Enterspeed.Source.Sdk.Api.Providers;
using Enterspeed.Source.Sdk.Api.Services;
using Enterspeed.Source.Sdk.Domain.Connection;
using Enterspeed.Source.Sdk.Domain.Services;
using Enterspeed.Source.Sdk.Domain.SystemTextJson;
using Microsoft.Extensions.DependencyInjection;

namespace Enterspeed.Commercetools.Integration.Configuration;

public static class ServiceCollectionExtension
{
    public static void AddEnterspeedCommercetoolsIntegration(this IServiceCollection services, Action<EnterspeedCommercetoolsConfiguration> config)
    {
        var configModel = new EnterspeedCommercetoolsConfiguration();
        config(configModel);
        configModel.Validate();
        services.AddSingleton(configModel);

        //Enterspeed
        services.AddScoped<IEnterspeedConnection, EnterspeedConnection>();
        services.AddTransient<IEnterspeedIngestService, EnterspeedIngestService>();
        services.AddScoped<IJsonSerializer, SystemTextJsonSerializer>();
        services.AddSingleton<IEnterspeedConfigurationProvider>(new InMemoryEnterspeedConfigurationProvider(configModel.EnterspeedConfiguration));

        //Commercetools
        services.AddScoped<ICommercetoolsRepository, CommercetoolsRepository>();

        //Mappers
        services.AddTransient(typeof(IMapper<IProductProjection, EnterspeedProductEntity>), configModel.EnterspeedProductEntityMapper);
        services.AddTransient(typeof(IMapper<ICategory, EnterspeedCategoryEntity>), configModel.EnterspeedCategoryEntityMapper);
        services.AddTransient(typeof(IMapper<ProductVariantMappingContext, EnterspeedProductVariantEntity>), configModel.EnterspeedVariantEntityMapper);
        services.AddTransient(typeof(IMapper<IEnumerable<IAttribute>, ObjectEnterspeedProperty>), configModel.EnterspeedPropertyMapper);
        services.AddTransient(typeof(IMapper<List<IAsset>, List<IEnterspeedProperty>>), configModel.EnterspeedAssetMapper);
        services.AddTransient(typeof(IMapper<ICustomFields, IEnterspeedProperty>), configModel.EnterspeedCustomFieldsMapper);
        services.AddTransient(typeof(IMapper<ITypedMoney, IEnterspeedProperty>), configModel.EnterspeedMoneyMapper);
        services.AddTransient(typeof(IMapper<IProductVariantAvailability, IEnterspeedProperty>), configModel.EnterspeedAvailabilityMapper);
        services.AddTransient(typeof(IMapper<DateTime, IEnterspeedProperty>), configModel.EnterspeedDateTimeMapper);
        services.AddTransient(typeof(IMapper<List<IPrice>, IEnterspeedProperty>), configModel.EnterspeedPriceMapper);
        services.AddTransient(typeof(IMapper<List<IImage>, IEnterspeedProperty>), configModel.EnterspeedImageMapper);

        //Services
        services.AddScoped(typeof(IEnterspeedEntityTypeProvider), configModel.EnterspeedEntityTypeProvider);
        services.AddScoped<IEnterspeedImportService, EnterspeedImportService>();
        services.AddScoped<IEnterspeedImportAllCategories, InMemoryImportAllCategories>();
        services.AddScoped<IEnterspeedImportAllProducts, InMemoryImportAllProducts>();
        services.AddScoped(typeof(IEnterspeedPropertyKeyFactory), configModel.EnterspeedPropertyKeyFactory);
        services.AddScoped(typeof(IEnterspeedUrlBuilder), configModel.EnterspeedUrlBuilder);
        services.AddScoped(typeof(IProductVariantIdFactory), configModel.ProductVariantIdFactory);
    }
}