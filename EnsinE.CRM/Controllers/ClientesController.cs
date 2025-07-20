using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EnsinE.CRM.Data;
using EnsinE.CRM.Models;

namespace EnsinE.CRM.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Clientes.Include(c => c.Produto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.Produto)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produtos.Where(p => p.Situacao), "ProdutoId", "Nome");
            ViewBag.FormAction = "Create";
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("_FormClientePartial", new Cliente());
            return View();
        }
        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,NomeCompleto,Telefone,Email,Desconto,Vendedor,ProdutoId")] Cliente cliente)
        {
            Console.WriteLine($"ProdutoId recebido: {cliente.ProdutoId}");
            if (!ModelState.IsValid)
            {
                ViewData["ProdutoId"] = new SelectList(_context.Produtos.Where(p => p.Situacao), "ProdutoId", "Nome", cliente.ProdutoId);
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    return PartialView("_FormClientePartial", cliente);
                return View(cliente);
            }

            _context.Add(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound();

            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome", cliente.ProdutoId);
            ViewBag.FormAction = "Edit";
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("_FormClientePartial", cliente);

            return View(cliente);
        }
        //POST Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,NomeCompleto,Telefone,Email,Desconto,Vendedor,ProdutoId")] Cliente cliente)
        {
            if (id != cliente.ClienteId)
                return NotFound();

            if (!ModelState.IsValid)
            {
                ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Nome", cliente.ProdutoId);
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    return PartialView("_FormClientePartial", cliente);
                return View(cliente);
            }

            try
            {
                _context.Update(cliente);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(cliente.ClienteId))
                    return NotFound();
                else
                    throw;
            }

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return Json(new
                {
                    success = true,
                    clienteId = cliente.ClienteId,
                    nomeCompleto = cliente.NomeCompleto,
                    telefone = cliente.Telefone,
                    email = cliente.Email,
                    desconto = cliente.Desconto,
                    vendedor = cliente.Vendedor,
                    produtoNome = (await _context.Produtos.FindAsync(cliente.ProdutoId))?.Nome
                });

            return RedirectToAction(nameof(Index));
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var cliente = await _context.Clientes
                .Include(c => c.Produto)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
                return NotFound();

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("_DeleteClientePartial", cliente);

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.ClienteId == id);
        }


        public async Task<IActionResult> PorProduto(int? produtoId)
        {
            if (produtoId == null)
                return NotFound();

            var produto = await _context.Produtos.FindAsync(produtoId);
            if (produto == null)
                return NotFound();

            var clientes = await _context.Clientes
                .Include(c => c.Produto)
                .Where(c => c.ProdutoId == produtoId)
                .ToListAsync();

            ViewBag.ProdutoNome = produto.Nome;
            return View(clientes);
        }
    }
}
