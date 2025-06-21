namespace Roblox.Paging.Extensions;

using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Paging extensions for IEnumerables
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Produces a Keyed Page Result from a collection of items by skipping and taking.
    /// </summary>
    /// <param name="items">The items to page.</param>
    /// <param name="skip">The number of items to skip.</param>
    /// <param name="take">The number of items to take.</param>
    /// <returns>A Keyed Page Result.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="items"/> is null.</exception>
    public static KeyedPagedResult<TPageItem, int> PageBySkipTake<TPageItem>(this ICollection<TPageItem> items, int skip, int take)
    {
        if (items == null) throw new ArgumentNullException(nameof(items));

        var itemsInPage = items.Skip(skip).Take(take).ToArray();
        var nextStartKey = items.Count < skip + take
            ? PageKeyInfo<int>.NoPage()
            : new PageKeyInfo<int>(skip + take);

        return new KeyedPagedResult<TPageItem, int>(itemsInPage, nextStartKey);
    }

    /// <summary>
    /// Produces a Keyed Page Result from a enumerable of items by skipping and taking.
    /// </summary>
    /// <param name="items">The items to page.</param>
    /// <param name="skip">The number of items to skip.</param>
    /// <param name="take">The number of items to take.</param>
    /// <returns>A Keyed Page Result.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="items"/> is null.</exception>
    public static KeyedPagedResult<TPageItem, int> PageBySkipTake<TPageItem>(this IEnumerable<TPageItem> items, int skip, int take)
    {
        if (items == null) throw new ArgumentNullException(nameof(items));

        var itemsInPage = items.Skip(skip).Take(take).ToArray();
        var nextStartKey = itemsInPage.Length < take + skip
            ? PageKeyInfo<int>.NoPage()
            : new PageKeyInfo<int>(skip + take);

        return new KeyedPagedResult<TPageItem, int>(itemsInPage, nextStartKey);
    }
}
