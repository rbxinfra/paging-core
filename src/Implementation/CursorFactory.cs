namespace Roblox.Paging;

using System;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

using Hashing;

/// <inheritdoc cref="ICursorFactory" />
public class CursorFactory : ICursorFactory
{
    private const char _CursorSplitter = '\n';

    private readonly Func<string> _CursorSaltGetter;

    /// <summary>
    /// Initializes a new <see cref="CursorFactory" />.
    /// </summary>
    /// <param name="cursorSaltGetter">The salt for the cursors.</param>
    /// <exception cref="ArgumentNullException">
    /// - <paramref name="cursorSaltGetter" />
    /// </exception>
    public CursorFactory(Func<string> cursorSaltGetter)
    {
        _CursorSaltGetter = cursorSaltGetter ?? throw new ArgumentNullException(nameof(cursorSaltGetter));
    }

    /// <inheritdoc cref="ICursorFactory.CreateCursor{TCursorInformation}(TCursorInformation)" />
    public string CreateCursor<TCursorInformation>(TCursorInformation cursorInformation) 
        where TCursorInformation : CursorBase
    {
        if (cursorInformation == null) throw new ArgumentNullException(nameof(cursorInformation));

        var serializedCursor = JsonConvert.SerializeObject(cursorInformation);
        var cursorHash = SHA256Hasher.BuildSHA256HashString(string.Format("{0}_{1}", serializedCursor, _CursorSaltGetter()));

        return Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}{1}{2}", serializedCursor, _CursorSplitter, cursorHash)));
    }

    /// <inheritdoc cref="ICursorFactory.ParseCursor{TCursorInformation}(string, string)" />
    public TCursorInformation ParseCursor<TCursorInformation>(string cursor, string discriminator = "") 
        where TCursorInformation : CursorBase
    {
        if (string.IsNullOrWhiteSpace(cursor)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(cursor));

        TCursorInformation cursorInformation;
        try
        {
            var rawCursor = Convert.FromBase64String(cursor);

            cursorInformation = JsonConvert.DeserializeObject<TCursorInformation>(Encoding.UTF8.GetString(rawCursor).Split(_CursorSplitter).First());
        }
        catch (Exception e)
        {
            throw new ArgumentException("Failed to deserialize cursor information.", nameof(cursor), e);
        }

        if (CreateCursor(cursorInformation) != cursor)
            throw new ArgumentException("Cursor failed verification (considered spoofed).", nameof(cursor));
        if (cursorInformation.Discriminator != discriminator)
            throw new ArgumentException("Cursor failed verification (cursor discriminator).", nameof(cursor));
            
        return cursorInformation;
    }

    /// <inheritdoc cref="ICursorFactory.TryParseCursor{TCursorInformation}(string, out TCursorInformation, string)" />
    public bool TryParseCursor<TCursorInformation>(string cursor, out TCursorInformation cursorInformation, string discriminator = "") 
        where TCursorInformation : CursorBase
    {
        try
        {
            cursorInformation = ParseCursor<TCursorInformation>(cursor, discriminator);
            
            return true;
        }
        catch (ArgumentException)
        {
            cursorInformation = default(TCursorInformation);
            return false;
        }
    }
}
