using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KiemTraTuan11.Models;

namespace KiemTraTuan11.Data
{
    public class DPContext:DbContext
    {
        public DPContext(DbContextOptions<DPContext> options ) : base (options)
        {

        }
        public DbSet<FileModel> File { get; set; }

        public DbSet<FolderModel> Folder { get; set; }
    }
}
