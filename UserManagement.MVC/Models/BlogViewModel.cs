using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models
{
    public class BlogViewModel
    {
        public String UserId { get; set; }
        public String Title { get; set; }

        [DisplayName("Short Description")]
        public String ShortDescription { get; set; }

        [DisplayName("Description")]
        public String Description { get; set; }

        [DisplayName("Picture")]
        public IFormFile BlogPostPicture { get; set; }
    }
}
