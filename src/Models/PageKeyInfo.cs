namespace Roblox.Paging;

using System;

/// <summary>
/// A struct wrapping a PageKey for the <see cref="IKeyedPagedResult{TPageItem, TPageKey}" /> with information about whether the key exists.
/// </summary>
/// <typeparam name="TPageKey"></typeparam>
public readonly struct PageKeyInfo<TPageKey> 
    where TPageKey : struct
{
    private readonly TPageKey _PageKey;

    /// <summary>
    /// Informs whether a page (and thus its key) exists.
    /// </summary>
    public bool HasPage { get; }

    /// <summary>
    /// The key of the page.
    /// </summary>
    public TPageKey PageKey
    {
        get
        {
            if (!HasPage) throw new InvalidOperationException(string.Format("The {0} property is false.", nameof(HasPage)));

            return _PageKey;
        }
    }

    /// <summary>
    /// Constructs a PagedKeyInfo for a page with the specified page key.
    /// </summary>
    public PageKeyInfo(TPageKey pageKey)
    {
        _PageKey = pageKey;
        HasPage = true;
    }

    /// <summary>
    /// A static factory method to return a PagedKeyInfo representing the absence of a page
    /// </summary>
    public static PageKeyInfo<TPageKey> NoPage() => new(false);

    private PageKeyInfo(bool hasPage)
    {
        HasPage = hasPage;
        _PageKey = default(TPageKey);
    }
}
