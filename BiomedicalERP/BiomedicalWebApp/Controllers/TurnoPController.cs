using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BiomedicalWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace BiomedicalWebApp.Controllers
{
    [Authorize]
    public class TurnoPController : Controller
    {
        private readonly BiomedicalCenterContext _context;

        public TurnoPController(BiomedicalCenterContext context)
        {
            _context = context;
        }

        // GET: TurnoP
        public async Task<IActionResult> Index()
        {
            var biomedicalCenterContext = _context.TurnoPacientes.Include(t => t.IdMedicoNavigation).Include(t => t.IdPacienteNavigation).Include(t => t.IdTurnoNavigation);
            return View(await biomedicalCenterContext.ToListAsync());
        }

        // GET: TurnoP/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TurnoPacientes == null)
            {
                return NotFound();
            }

            var turnoPaciente = await _context.TurnoPacientes
                .Include(t => t.IdMedicoNavigation)
                .Include(t => t.IdPacienteNavigation)
                .Include(t => t.IdTurnoNavigation)
                .FirstOrDefaultAsync(m => m.IdTurno == id);
            if (turnoPaciente == null)
            {
                return NotFound();
            }

            return View(turnoPaciente);
        }

        // GET: TurnoP/Create
        public IActionResult Create()
        {
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "Nombre");
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "Nombre");
            ViewData["IdTurno"] = new SelectList(_context.Turnos, "IdTurno", "Observacion");
            return View();
        }

        // POST: TurnoP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTurno,IdPaciente,IdMedico")] TurnoPaciente turnoPaciente)
        {
            ModelState.Remove("IdTurnoNavigation");
            ModelState.Remove("IdPacienteNavigation");
            ModelState.Remove("IdMedicoNavigation");
            if (ModelState.IsValid)
            {
                _context.Add(turnoPaciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", turnoPaciente.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente", turnoPaciente.IdPaciente);
            ViewData["IdTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", turnoPaciente.IdTurno);
            return View(turnoPaciente);
        }

        // GET: TurnoP/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TurnoPacientes == null)
            {
                return NotFound();
            }

            var turnoPaciente = await _context.TurnoPacientes.FindAsync(id);
            if (turnoPaciente == null)
            {
                return NotFound();
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", turnoPaciente.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente", turnoPaciente.IdPaciente);
            ViewData["IdTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", turnoPaciente.IdTurno);
            return View(turnoPaciente);
        }

        // POST: TurnoP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTurno,IdPaciente,IdMedico")] TurnoPaciente turnoPaciente)
        {
            if (id != turnoPaciente.IdTurno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turnoPaciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnoPacienteExists(turnoPaciente.IdTurno))
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
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "IdMedico", turnoPaciente.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente", turnoPaciente.IdPaciente);
            ViewData["IdTurno"] = new SelectList(_context.Turnos, "IdTurno", "IdTurno", turnoPaciente.IdTurno);
            return View(turnoPaciente);
        }

        // GET: TurnoP/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TurnoPacientes == null)
            {
                return NotFound();
            }

            var turnoPaciente = await _context.TurnoPacientes
                .Include(t => t.IdMedicoNavigation)
                .Include(t => t.IdPacienteNavigation)
                .Include(t => t.IdTurnoNavigation)
                .FirstOrDefaultAsync(m => m.IdTurno == id);
            if (turnoPaciente == null)
            {
                return NotFound();
            }
            List<Turno> turnos = await _context.Turnos.Where(d => d.IdTurno.Equals(id)).ToListAsync();
            ViewBag.AllowDelete = !turnos.Any();

            return View(turnoPaciente);
        }

        // POST: TurnoP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TurnoPacientes == null)
            {
                return Problem("Entity set 'BiomedicalCenterContext.TurnoPacientes'  is null.");
            }
            var turnoPaciente = await _context.TurnoPacientes.FindAsync(id);
            if (turnoPaciente != null)
            {
                _context.TurnoPacientes.Remove(turnoPaciente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurnoPacienteExists(int id)
        {
          return _context.TurnoPacientes.Any(e => e.IdTurno == id);
        }
    }
}
