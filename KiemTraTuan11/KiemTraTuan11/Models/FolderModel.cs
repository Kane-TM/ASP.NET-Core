using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KiemTraTuan11.Models
{
    public class FolderModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FolderName { get; set; }

        public int ParentsId { get; set; }

        public bool status { get; set; }

        public ICollection<FileModel> listFile { get; set; }
    }
}
