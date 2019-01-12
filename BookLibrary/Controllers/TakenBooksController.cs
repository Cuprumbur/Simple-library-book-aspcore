using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookLibrary.Models;

namespace BookLibrary.Controllers
{
    public class TakenBooksController : Controller
    {
        private readonly BookLibraryContext _context;

        public TakenBooksController(BookLibraryContext context)
        {
            _context = context;
        }

        // GET: TakenBooks
        public async Task<IActionResult> Index()
        {
            var bookLibraryContext = _context.TakenBooks.Include(t => t.Book).Include(t => t.Reader);
            return View(await bookLibraryContext.ToListAsync());
        }

        // GET: TakenBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var takenBook = await _context.TakenBooks
                .Include(t => t.Book)
                .Include(t => t.Reader)
                .FirstOrDefaultAsync(m => m.TakenBookId == id);
            if (takenBook == null)
            {
                return NotFound();
            }

            return View(takenBook);
        }

        // GET: TakenBooks/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId");
            ViewData["ReaderId"] = new SelectList(_context.Readers, "ReaderId", "ReaderId");
            return View();
        }

        // POST: TakenBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TakenBookId,ReaderId,BookId,DateIssue,ReturnDate,IsReturned")] TakenBook takenBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(takenBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", takenBook.BookId);
            ViewData["ReaderId"] = new SelectList(_context.Readers, "ReaderId", "ReaderId", takenBook.ReaderId);
            return View(takenBook);
        }

        // GET: TakenBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var takenBook = await _context.TakenBooks.FindAsync(id);
            if (takenBook == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", takenBook.BookId);
            ViewData["ReaderId"] = new SelectList(_context.Readers, "ReaderId", "ReaderId", takenBook.ReaderId);
            return View(takenBook);
        }

        // POST: TakenBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TakenBookId,ReaderId,BookId,DateIssue,ReturnDate,IsReturned")] TakenBook takenBook)
        {
            if (id != takenBook.TakenBookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(takenBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TakenBookExists(takenBook.TakenBookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", takenBook.BookId);
            ViewData["ReaderId"] = new SelectList(_context.Readers, "ReaderId", "ReaderId", takenBook.ReaderId);
            return View(takenBook);
        }

        // GET: TakenBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var takenBook = await _context.TakenBooks
                .Include(t => t.Book)
                .Include(t => t.Reader)
                .FirstOrDefaultAsync(m => m.TakenBookId == id);
            if (takenBook == null)
            {
                return NotFound();
            }

            return View(takenBook);
        }

        // POST: TakenBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var takenBook = await _context.TakenBooks.FindAsync(id);
            _context.TakenBooks.Remove(takenBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TakenBookExists(int id)
        {
            return _context.TakenBooks.Any(e => e.TakenBookId == id);
        }
    }
}
