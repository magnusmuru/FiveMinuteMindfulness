using System.ComponentModel.DataAnnotations;

namespace FiveMinuteMindfulness.Core.Enums;

public enum ChapterType
{
    [Display(ResourceType = typeof(FiveMinuteMindfulness.Resources.Enums.ChapterType), Name = nameof(Text))]
    Text = 1,
    Audio = 2,
    Video = 3
}