using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models
{
    public class Blog
    {

        public int BlogPostId { get; set; }

        [DisplayName("Author")]
        public String UserId { get; set; }

        public String Title { get; set; }

        public String ShortDescription { get; set; }

        public String Description { get; set; }

        public byte[] BlogPostPicture { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
