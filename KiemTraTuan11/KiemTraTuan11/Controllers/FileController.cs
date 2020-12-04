using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KiemTraTuan11.Data;
using KiemTraTuan11.Models;

namespace KiemTraTuan11.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly DPContext _context;

        public FileController(DPContext context)
        {
            _context = context;
        }

        // GET: api/File
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FileModel>>> GetFile()
        {
            return await _context.File.ToListAsync();
        }

        // GET: api/File/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FileModel>> GetFileModel(int id)
        {
            var fileModel = await _context.File.FindAsync(id);

            if (fileModel == null)
            {
                return NotFound();
            }

            return fileModel;
        }

        // PUT: api/File/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFileModel(int id, FileModel fileModel)
        {
            if (id != fileModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(fileModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/File
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FileModel>> PostFileModel(FileModel fileModel)
        {
            _context.File.Add(fileModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFileModel", new { id = fileModel.Id }, fileModel);
        }

        // DELETE: api/File/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFileModel(int id)
        {
            var fileModel = await _context.File.FindAsync(id);
            if (fileModel == null)
            {
                return NotFound();
            }

            _context.File.Remove(fileModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FileModelExists(int id)
        {
            return _context.File.Any(e => e.Id == id);
        }
    }
}
