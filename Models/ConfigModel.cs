using System.ComponentModel.DataAnnotations;

namespace Rating_App.Models
{
    public class ConfigModel
    {
        [Key]
        public string Key { get; set; }
        [Required]
        [MaxLength(128)]
        public string Value { get; set; }
    }
}
