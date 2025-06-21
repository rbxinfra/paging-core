namespace Roblox.Paging;

using System.Collections.Generic;

/// <summary>
/// A generic interface representing a KeyedPagedResult that provides a key to find the next page,
/// abstracting out how paging is implemented under the hood.
/// </summary>
/// <typeparam name="TPageItem">The type of item being returned in the page result.</typeparam>
/// <typeparam name="TPageKey">The type of the page key.</typeparam>
public interface IKeyedPagedResult<out TPageItem, TPageKey> 
    where TPageKey : struct
{
    /// <summary>
    /// The items in the resulting page
    /// </summary>
    IReadOnlyCollection<TPageItem> PageItems { get; }

    /// <summary>
    /// Returns the <see cref="PageKeyInfo{TPageKey}" /> for the next page
    /// </summary>
    PageKeyInfo<TPageKey> NextPageKey { get; }
}
