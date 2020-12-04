using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KiemTraTuan11.Models
{
    public class FileModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FileName { get; set; }

        public int FolderId { get; set; }
        [ForeignKey("FolderId")]
        public virtual FolderModel Folder { get; set; }

        public bool Status { get; set; }
    }
}
