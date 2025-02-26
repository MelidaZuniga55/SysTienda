using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SysTienda2.Models;

namespace SysTienda2.Controllers
{
    public class DetalleFacturaController : Controller
    {
        private readonly BDContext _context;

        public DetalleFacturaController(BDContext context)
        {
            _context = context;
        }

        // GET: DetalleFactura
        public async Task<IActionResult> Index()
        {
            var bDContext = _context.DetalleFactura.Include(d => d.IdDetalleFacturaNavigation).Include(d => d.Servicio);
            return View(await bDContext.ToListAsync());
        }

        // GET: DetalleFactura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFactura
                .Include(d => d.IdDetalleFacturaNavigation)
                .Include(d => d.Servicio)
                .FirstOrDefaultAsync(m => m.IdDetalleFactura == id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return View(detalleFactura);
        }

        // GET: DetalleFactura/Create
        public IActionResult Create()
        {
            ViewData["IdDetalleFactura"] = new SelectList(_context.Factura, "IdFactura", "IdFactura");
            ViewData["ServicioId"] = new SelectList(_context.Servicio, "IdServicio", "IdServicio");
            return View();
        }

        // POST: DetalleFactura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleFactura,IdFactura,ServicioId,Cantidad,Precio")] DetalleFactura detalleFactura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleFactura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDetalleFactura"] = new SelectList(_context.Factura, "IdFactura", "IdFactura", detalleFactura.IdDetalleFactura);
            ViewData["ServicioId"] = new SelectList(_context.Servicio, "IdServicio", "IdServicio", detalleFactura.ServicioId);
            return View(detalleFactura);
        }

        // GET: DetalleFactura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFactura.FindAsync(id);
            if (detalleFactura == null)
            {
                return NotFound();
            }
            ViewData["IdDetalleFactura"] = new SelectList(_context.Factura, "IdFactura", "IdFactura", detalleFactura.IdDetalleFactura);
            ViewData["ServicioId"] = new SelectList(_context.Servicio, "IdServicio", "IdServicio", detalleFactura.ServicioId);
            return View(detalleFactura);
        }

        // POST: DetalleFactura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalleFactura,IdFactura,ServicioId,Cantidad,Precio")] DetalleFactura detalleFactura)
        {
            if (id != detalleFactura.IdDetalleFactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleFactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleFacturaExists(detalleFactura.IdDetalleFactura))
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
            ViewData["IdDetalleFactura"] = new SelectList(_context.Factura, "IdFactura", "IdFactura", detalleFactura.IdDetalleFactura);
            ViewData["ServicioId"] = new SelectList(_context.Servicio, "IdServicio", "IdServicio", detalleFactura.ServicioId);
            return View(detalleFactura);
        }

        // GET: DetalleFactura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFactura
                .Include(d => d.IdDetalleFacturaNavigation)
                .Include(d => d.Servicio)
                .FirstOrDefaultAsync(m => m.IdDetalleFactura == id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return View(detalleFactura);
        }

        // POST: DetalleFactura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleFactura = await _context.DetalleFactura.FindAsync(id);
            if (detalleFactura != null)
            {
                _context.DetalleFactura.Remove(detalleFactura);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleFacturaExists(int id)
        {
            return _context.DetalleFactura.Any(e => e.IdDetalleFactura == id);
        }
    }
}
