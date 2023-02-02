using commercetools.Sdk.Api.Models.Categories;
using commercetools.Sdk.Api.Models.Common;
using commercetools.Sdk.Api.Models.Products;
using Enterspeed.Commercetools.Integration.Api.Mappers;
using Enterspeed.Commercetools.Integration.Api.Models;
using Enterspeed.Commercetools.Integration.Api.Providers;
using Enterspeed.Commercetools.Integration.Api.Services;
using Enterspeed.Commercetools.Integration.Domain.Mappers;
using Enterspeed.Commercetools.Integration.Domain.Models;
using Enterspeed.Commercetools.Integration.Domain.Providers;
using Enterspeed.Commercetools.Integration.Domain.Services;
using Enterspeed.Source.Sdk.Api.Models.Properties;
using Enterspeed.Source.Sdk.Configuration;

namespace Enterspeed.Commercetools.Integration.Configuration;

public class EnterspeedCommercetoolsConfiguration
{
    internal void Validate()
    {
        if (string.IsNullOrWhiteSpace(CommercetoolsProjectKey))
        {
            throw new ArgumentNullException(nameof(CommercetoolsProjectKey));
        }
    }

    #region Mappers

    internal Type EnterspeedDateTimeMapper { get; private set; } = typeof(EnterspeedDateTimeMapper);
    public EnterspeedCommercetoolsConfiguration SetDateTimeMapper<T>()
        where T : IMapper<DateTime, IEnterspeedProperty>
    {
        EnterspeedDateTimeMapper = typeof(T);
        return this;
    }

    internal Type EnterspeedPriceMapper { get; private set; } = typeof(EnterspeedPriceMapper);
    public EnterspeedCommercetoolsConfiguration SetPriceMapper<T>()
        where T : IMapper<List<IPrice>, IEnterspeedProperty>
    {
        EnterspeedPriceMapper = typeof(T);
        return this;
    }

    internal Type EnterspeedAvailabilityMapper { get; private set; } = typeof(EnterspeedAvailabilityMapper);
    public EnterspeedCommercetoolsConfiguration SetAvailabilityMapper<T>()
        where T : IMapper<IProductVariantAvailability, IEnterspeedProperty>
    {
        EnterspeedAvailabilityMapper = typeof(T);
        return this;
    }

    internal Type EnterspeedProductEntityMapper { get; private set; } = typeof(EnterspeedProductMapper);
    public EnterspeedCommercetoolsConfiguration SetProductMapper<T>()
        where T : IMapper<IProductProjection, EnterspeedProductEntity>
    {
        EnterspeedProductEntityMapper = typeof(T);
        return this;
    }

    internal Type EnterspeedCategoryEntityMapper { get; private set; } = typeof(EnterspeedCategoryMapper);
    public EnterspeedCommercetoolsConfiguration SetCategoryMapper<T>()
        where T : IMapper<ICategory, EnterspeedCategoryEntity>
    {
        EnterspeedCategoryEntityMapper = typeof(T);
        return this;
    }

    internal Type EnterspeedVariantEntityMapper { get; private set; } = typeof(EnterspeedVariantMapper);
    public EnterspeedCommercetoolsConfiguration SetVariantMapper<T>()
        where T : IMapper<ProductVariantMappingContext, EnterspeedProductVariantEntity>
    {
        EnterspeedVariantEntityMapper = typeof(T);
        return this;
    }

    internal Type EnterspeedPropertyMapper { get; private set; } = typeof(EnterspeedPropertyMapper);
    public EnterspeedCommercetoolsConfiguration SetPropertyMapper<T>()
        where T : IMapper<IEnumerable<IAttribute>, ObjectEnterspeedProperty>
    {
        EnterspeedPropertyMapper = typeof(T);
        return this;
    }

    internal Type EnterspeedAssetMapper { get; private set; } = typeof(EnterspeedAssetMapper);
    public EnterspeedCommercetoolsConfiguration SetAssetMapper<T>()
        where T : IMapper<List<IAsset>, List<IEnterspeedProperty>>
    {
        EnterspeedAssetMapper = typeof(T);
        return this;
    }

    internal Type EnterspeedCustomFieldsMapper { get; private set; } = typeof(EnterspeedPropertyMapper);
    public EnterspeedCommercetoolsConfiguration SetCustomFieldsMapper<T>()
        where T : IMapper<commercetools.Sdk.Api.Models.Types.ICustomFields, Dictionary<string, IEnterspeedProperty>>
    {
        EnterspeedCustomFieldsMapper = typeof(T);
        return this;
    }

    internal Type EnterspeedMoneyMapper { get; private set; } = typeof(EnterspeedMoneyMapper);
    public EnterspeedCommercetoolsConfiguration SetMoneyMapper<T>()
        where T : IMapper<ITypedMoney, IEnterspeedProperty>
    {
        EnterspeedMoneyMapper = typeof(T);
        return this;
    }

    internal Type EnterspeedImageMapper { get; private set; } = typeof(EnterspeedImageMapper);

    public EnterspeedCommercetoolsConfiguration SetImageMapper<T>()
        where T : IMapper<List<IImage>, IEnterspeedProperty>
    {
        EnterspeedImageMapper = typeof(T);
        return this;
    }

    #endregion

    #region Configurations
    internal EnterspeedConfiguration EnterspeedConfiguration { get; private set; } = new EnterspeedConfiguration();
    public EnterspeedCommercetoolsConfiguration SetEnterspeedConfiguration(EnterspeedConfiguration enterspeedConfiguration)
    {
        EnterspeedConfiguration = enterspeedConfiguration;
        return this;
    }

    internal string CommercetoolsProjectKey { get; private set; } = string.Empty;
    public EnterspeedCommercetoolsConfiguration SetCommercetoolsProjectKey(string projectKey)
    {
        CommercetoolsProjectKey = projectKey;
        return this;
    }

    #endregion

    #region Services

    internal Type EnterspeedEntityTypeProvider { get; private set; } = typeof(EnterspeedEntityTypeProvider);
    public EnterspeedCommercetoolsConfiguration SetTypeProvider<T>()
        where T : IEnterspeedEntityTypeProvider
    {
        EnterspeedEntityTypeProvider = typeof(T);
        return this;
    }

    internal Type EnterspeedPropertyKeyFactory { get; private set; } = typeof(EnterspeedPropertyKeyFactory);
    public EnterspeedCommercetoolsConfiguration SetPropertyKeyFactory<T>()
        where T : IEnterspeedPropertyKeyFactory
    {
        EnterspeedPropertyKeyFactory = typeof(T);
        return this;
    }

    internal Type EnterspeedUrlBuilder { get; private set; } = typeof(EnterspeedUrlBuilder);
    public EnterspeedCommercetoolsConfiguration SetUrlBuilder<T>()
        where T : IEnterspeedUrlBuilder
    {
        EnterspeedUrlBuilder = typeof(T);
        return this;
    }
    internal Type ProductVariantIdFactory { get; private set; } = typeof(ProductVariantIdFactory);
    public EnterspeedCommercetoolsConfiguration SetProductVariantIdFactory<T>()
        where T : IProductVariantIdFactory
    {
        ProductVariantIdFactory = typeof(T);
        return this;
    }

    #endregion
}