using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateT4Example.Db.Model
{
    public partial class Subject
    {
        [Key]
        public int SubjectID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
