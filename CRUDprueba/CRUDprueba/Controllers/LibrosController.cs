using CRUDprueba.Data;
using CRUDprueba.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDprueba.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context; //invocamos el using

        public LibrosController(ApplicationDbContext context)
        {
            _context = context; //constructor
        }

        //mappeando las get

        //http get index
        public IActionResult Index() //Agregar vista (click derecho sobre Index)
        {
            IEnumerable<Libro> ListLibros = _context.Libro;
            return View(ListLibros);
        }

        //http get create
        public IActionResult Create() //Agregar vista (click derecho sobre Index)
        {
            return View();
        }

        //http post create
        [HttpPost] //con esto indicamos que lo de abajo es post
        [ValidateAntiForgeryToken]
        public IActionResult Create(Libro libro) //no genera conflicto con el metodo de arriba ya que este recibe un parametro
        {
            if (ModelState.IsValid) // aqui valida el modelo (si tiene todo lo requerido en Libro.cs) 
            {
                _context.Libro.Add(libro);
                _context.SaveChanges();

                TempData["mensaje"] = "El libro se ha creado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        //http get Editar
        public IActionResult Edit(int? id) //le decimos que pueda ser nulo y que va recibir el id
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            //obtener libro
            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro); //retornara el libro cuando no se cumplan las condiciones de arriba
        }

        //http post Editar
        [HttpPost] //con esto indicamos que lo de abajo es post
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Libro libro) //no genera conflicto con el metodo de arriba ya que este recibe un parametro
        {
            if (ModelState.IsValid) // aqui valida el modelo (si tiene todo lo requerido en Libro.cs) 
            {
                _context.Libro.Update(libro);
                _context.SaveChanges();

                TempData["mensaje"] = "El libro se ha actualizado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        //http get Eliminar
        public IActionResult Delete(int? id) //le decimos que pueda ser nulo y que va recibir el id
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //obtener libro
            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro); //retornara el libro cuando no se cumplan las condiciones de arriba
        }

        //http post eliminar
        [HttpPost] //con esto indicamos que lo de abajo es post
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLibro(int? id) //no genera conflicto con el metodo de arriba ya que este recibe un parametro
        {
            //obtener el libro por id
            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            _context.Libro.Remove(libro);
            _context.SaveChanges();

            TempData["mensaje"] = "El libro se ha eliminado correctamente";
            return RedirectToAction("Index");
        }
    }
}
