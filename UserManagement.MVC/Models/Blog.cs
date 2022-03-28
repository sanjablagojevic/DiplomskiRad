using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models
{
    public class Blog
    {

        [Key]
        public int BlogPostId { get; set; }

        [DisplayName("Author")]
        public String UserId { get; set; }

        public String Title { get; set; }

        [DisplayName("Short Description")]
        public String ShortDescription { get; set; }

        [DisplayName("Description")]
        public String Description { get; set; }

        [NotMapped]
        [DisplayName("Picture")]
        public IFormFile BlogPostPicture { get; set; }

        public DateTime Created { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
