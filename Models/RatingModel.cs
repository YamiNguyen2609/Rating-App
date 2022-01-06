using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rating_App.Models
{
    class RatingModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(1)]
        public int Type { get; set; } //1: Phòng đào tạo ĐH; 2: Phòng đào tạo sau ĐH;3: Phòng công tác sinh viên; 4:Trung tâm dịch vụ
        [Required]
        [MaxLength(1)]
        public bool State { get; set; } //1: Like, 2: Unlike
        [Required]
        [MaxLength(50)]
        public DateTime CreateAt { get; set; }
    }

    class RatingViewModel
    {
        public string Type { get; set; }

        public string Like { get; set; }

        public string DisLike { get; set; }
    }
}
