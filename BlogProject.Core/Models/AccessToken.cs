using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.Models
{
    public class AccessToken
    {
        [Key]
        public string Token { get; set; } //Token Değeri
        public DateTime Expiration { get; set; } //Geçerlilik Süresi

    }
}
