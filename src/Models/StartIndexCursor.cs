namespace Roblox.Paging;

using System.Runtime.Serialization;

/// <summary>
/// Cursor information for start index based cursors.
/// </summary>
[DataContract]
public class StartIndexCursor : CursorBase
{
    /// <summary>
    /// The start index value.
    /// </summary>
    [DataMember(Name = "startIndex")]
    public long StartIndex { get; set; }
}
