using StudentCredits.Contracts.Enums;

namespace StudentCredits.Helpers.Extensions;

public static class FileFormatTypesExtensions
{
  static readonly Dictionary<FileFormatTypes, string> _formatTypes = new()
  {
    { FileFormatTypes.PlainText, ".txt" },
    { FileFormatTypes.Xml, ".xml" }
  };

  public static string GetFormatType(this FileFormatTypes formatType) => _formatTypes.GetValueOrDefault(formatType) ?? Enum.GetName(formatType)!;
}
