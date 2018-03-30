using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Encuestas_cep_decero.Data;
using encuestas_cep_decero.Models;

namespace Encuestas_cep_decero.Controllers
{
    public class EncuestasController : Controller
    {
        private readonly EncuestaContexto _context;

        public EncuestasController(EncuestaContexto context)
        {
            _context = context;
        }

        // GET: Encuestas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Encuesta.ToListAsync());
        }

        // GET: Encuestas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encuesta = await _context.Encuesta
                .SingleOrDefaultAsync(m => m.EncuestaID == id);
            if (encuesta == null)
            {
                return NotFound();
            }

            return View(encuesta);
        }

        // GET: Encuestas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Encuestas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EncuestaID,Nombre,Apellido,Dni_Libreta,Domicilio,Localidad,Telefono,Email,Pregunta_Aumento_Transporte,Pregunta_Boleto_Edu,Pregunta_Beca_Transporte,Pregunta_Politica_Permanencia,Pregunta_Politica_Iniciativas,Pregunta_Comentarios,Estado")] Encuesta encuesta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(encuesta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(encuesta);
        }

        // GET: Encuestas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encuesta = await _context.Encuesta.SingleOrDefaultAsync(m => m.EncuestaID == id);
            if (encuesta == null)
            {
                return NotFound();
            }
            return View(encuesta);
        }

        // POST: Encuestas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EncuestaID,Nombre,Apellido,Dni_Libreta,Domicilio,Localidad,Telefono,Email,Pregunta_Aumento_Transporte,Pregunta_Boleto_Edu,Pregunta_Beca_Transporte,Pregunta_Politica_Permanencia,Pregunta_Politica_Iniciativas,Pregunta_Comentarios,Estado")] Encuesta encuesta)
        {
            if (id != encuesta.EncuestaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encuesta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncuestaExists(encuesta.EncuestaID))
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
            return View(encuesta);
        }

        // GET: Encuestas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encuesta = await _context.Encuesta
                .SingleOrDefaultAsync(m => m.EncuestaID == id);
            if (encuesta == null)
            {
                return NotFound();
            }

            return View(encuesta);
        }

        // POST: Encuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var encuesta = await _context.Encuesta.SingleOrDefaultAsync(m => m.EncuestaID == id);
            _context.Encuesta.Remove(encuesta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncuestaExists(int id)
        {
            return _context.Encuesta.Any(e => e.EncuestaID == id);
        }
    }
}
