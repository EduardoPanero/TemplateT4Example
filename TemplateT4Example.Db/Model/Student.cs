using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateT4Example.Db.Model
{
    public partial class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Index(IsUnique = true)]
        public string Username { get; set; }

        [Index(IsUnique = true)]
        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Class> Classes { get; set; }

    }
}
