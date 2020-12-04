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
    public class FolderController : ControllerBase
    {
        private readonly DPContext _context;

        public FolderController(DPContext context)
        {
            _context = context;
        }

        // GET: api/Folder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FolderModel>>> GetFolder()
        {
            return await _context.Folder.ToListAsync();
        }

        // GET: api/Folder/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FolderModel>> GetFolderModel(int id)
        {
            var folderModel = await _context.Folder.FindAsync(id);

            if (folderModel == null)
            {
                return NotFound();
            }

            return folderModel;
        }

        // PUT: api/Folder/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFolderModel(int id, FolderModel folderModel)
        {
            if (id != folderModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(folderModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FolderModelExists(id))
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

        // POST: api/Folder
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FolderModel>> PostFolderModel(FolderModel folderModel)
        {
            _context.Folder.Add(folderModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFolderModel", new { id = folderModel.Id }, folderModel);
        }

        // DELETE: api/Folder/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFolderModel(int id)
        {
            var folderModel = await _context.Folder.FindAsync(id);
            if (folderModel == null)
            {
                return NotFound();
            }

            _context.Folder.Remove(folderModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FolderModelExists(int id)
        {
            return _context.Folder.Any(e => e.Id == id);
        }
    }
}
