namespace Roblox.Paging;

using System.Collections.Generic;

/// <summary>
/// Default implementation of <see cref="IPagedResult{TCount, TPageItem}"/>.
/// </summary>
/// <typeparam name="TCount">The type of the result count in a page</typeparam>
/// <typeparam name="TPageItem">The type of item being returned in the page result.</typeparam>
/// <seealso cref="IPagedResult{TCount, TPageItem}" />
public class PagedResult<TCount, TPageItem> : IPagedResult<TCount, TPageItem>
{
    /// <inheritdoc cref="IPagedResult{TCount, TPageItem}.Count"/>
    public TCount Count { get; set; }

    /// <inheritdoc cref="IPagedResult{TCount, TPageItem}.PageItems"/>
    public IEnumerable<TPageItem> PageItems { get; set; }
}

/// <summary>
/// Default implementation of <see cref="IPagedResult{TCount, TPageCount, TPageItem}"/>.
/// </summary>
/// <typeparam name="TCount">The type of the result count in a page</typeparam>
/// <typeparam name="TPageItem">The type of item being returned in the page result.</typeparam>
/// <typeparam name="TPageCount">The type of the page count</typeparam>
/// <seealso cref="IPagedResult{TCount, TPageCount, TPageItem}" />
public class PagedResult<TCount, TPageCount, TPageItem> : IPagedResult<TCount, TPageCount, TPageItem>
{
    /// <inheritdoc cref="IPagedResult{TCount, TPageItem}.Count"/>
    public TCount Count { get; set; }

    /// <inheritdoc cref="IPagedResult{TCount, TPageCount, TPageItem}.PageCount"/>
    public TPageCount PageCount { get; set; }

    /// <inheritdoc cref="IPagedResult{TCount, TPageItem}.PageItems"/>
    public IEnumerable<TPageItem> PageItems { get; set; }
}
