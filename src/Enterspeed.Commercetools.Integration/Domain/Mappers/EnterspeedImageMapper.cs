using commercetools.Sdk.Api.Models.Common;
using Enterspeed.Commercetools.Integration.Api.Mappers;
using Enterspeed.Source.Sdk.Api.Models.Properties;

namespace Enterspeed.Commercetools.Integration.Domain.Mappers;

public class EnterspeedImageMapper: IMapper<List<IImage>, IEnterspeedProperty>
{
    public Task<IEnterspeedProperty> MapAsync(List<IImage> source)
    {
        var images = source.Select(image => new ObjectEnterspeedProperty(new Dictionary<string, IEnterspeedProperty>
        {
            ["url"] = new StringEnterspeedProperty(image.Url),
            ["label"] = new StringEnterspeedProperty(image.Label),
            ["dimensions"] = new ObjectEnterspeedProperty(new Dictionary<string, IEnterspeedProperty>
            {
                ["w"] = new NumberEnterspeedProperty(image.Dimensions.W),
                ["h"] = new NumberEnterspeedProperty(image.Dimensions.H)
            })
        })).ToArray();

        return Task.FromResult<IEnterspeedProperty>(new ArrayEnterspeedProperty(string.Empty, images));
    }
}