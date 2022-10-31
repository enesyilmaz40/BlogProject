using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.Models
{
    public class AppUser:IdentityUser<int>
    {
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public byte[] PasswordSalt { get; set; }

        //aşağıdaki passwordHash sqldeki PasswordHashin yerine kullanılacaktır...
        public byte[] passwordHash2 { get; set; }




        public List<Blog> Blogs { get; set; }

        public virtual ICollection<Message> WriterSender { get; set; }
        public virtual ICollection<Message> WriterReceiver { get; set; }



    }
}
