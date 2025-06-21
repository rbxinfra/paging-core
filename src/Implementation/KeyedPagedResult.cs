namespace Roblox.Paging;

using System;
using System.Collections.Generic;

/// <summary>
/// A default implementation of <see cref="IKeyedPagedResult{TPageItem, TPageKey}" />.
/// </summary>
public class KeyedPagedResult<TPageItem, TPageKey> : IKeyedPagedResult<TPageItem, TPageKey> where TPageKey : struct
{
    /// <inheritdoc cref="IKeyedPagedResult{TPageItem, TPageKey}.PageItems" />
    public IReadOnlyCollection<TPageItem> PageItems { get; }

    /// <inheritdoc cref="IKeyedPagedResult{TPageItem, TPageKey}.NextPageKey" />
    public PageKeyInfo<TPageKey> NextPageKey { get; }

    /// <summary>
    /// Instantiates a new <see cref="KeyedPagedResult{TPageItem, TPageKey}" />.
    /// </summary>
    public KeyedPagedResult(IReadOnlyCollection<TPageItem> pageItems, PageKeyInfo<TPageKey> nextPageKey)
    {
        PageItems = pageItems ?? Array.Empty<TPageItem>();
        NextPageKey = nextPageKey;
    }

    /// <summary>
    /// A static factory method to return a KeyedPagedResult representing an empty result with no next page.
    /// </summary>
    public static KeyedPagedResult<TPageItem, TPageKey> EmptyLastPage()
    {
        var pageKey = PageKeyInfo<TPageKey>.NoPage();

        return new KeyedPagedResult<TPageItem, TPageKey>(null, pageKey);
    }
}
