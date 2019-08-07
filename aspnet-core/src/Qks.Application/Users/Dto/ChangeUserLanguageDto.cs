using System.ComponentModel.DataAnnotations;

namespace Qks.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}