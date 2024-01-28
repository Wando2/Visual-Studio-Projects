using Store.Domain.Commands;

namespace Store.Domain.Utils;

public static class ExtractGuids
{
    public static IEnumerable<Guid> Extract(IList<CreateOrderItermCommand> items )
    {
        var guids = new List<Guid>();
        foreach (var item in items)
        {
            guids.Add(item.Product);
        }
        return guids;
    }
}