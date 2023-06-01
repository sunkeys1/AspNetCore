using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCore.Models
{
    public class UserGroup
    {
        /// <summary>
        /// Code - статус группы (Active/Blocked/Other)
        /// </summary>

        [Key]
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string? Code { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "Описание группы должно быть больше 3 символов")]
        [MaxLength(25, ErrorMessage = "Описание группы не должно превышать 25 символов")]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int MemberId { get; set; }
        [ForeignKey("MemberId")]
        [ValidateNever]
        public User User { get; set; }
    }
}
