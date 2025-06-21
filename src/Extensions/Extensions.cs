namespace Roblox.Paging.Extensions;

/// <summary>
/// Extensions for the paging library.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Converts the PageKey type from the original numeric type to long
    /// </summary>
    /// <param name="pageKeyInfo">The page key info to convert</param>
    /// <returns>The converted page key info</returns>
    public static PageKeyInfo<long> ToLongKey(this PageKeyInfo<int> pageKeyInfo)
    {
        if (!pageKeyInfo.HasPage) return PageKeyInfo<long>.NoPage();

        return new PageKeyInfo<long>(pageKeyInfo.PageKey);
    }

    /// <summary>
    /// Converts the PageKey type from the original numeric type to long
    /// </summary>
    /// <param name="pagedResult">The paged result to convert</param>
    /// <returns>The converted paged result</returns>
    public static KeyedPagedResult<TPageItem, long> ToLongKey<TPageItem>(this IKeyedPagedResult<TPageItem, int> pagedResult) 
        => new(pagedResult.PageItems, pagedResult.NextPageKey.ToLongKey());
}
