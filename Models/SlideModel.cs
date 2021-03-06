using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rating_App.Models
{
    public class SlideModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Path { get; set; }
        [Required]
        [MaxLength(1)]
        public int Type { get; set; } //1: image, //2: video
        [Required]
        [MaxLength(1)]
        public int Index { get; set; }
    }

    public class SlideViewModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int Index { get; set; }
        public string Type { get; set; }
    }
}
