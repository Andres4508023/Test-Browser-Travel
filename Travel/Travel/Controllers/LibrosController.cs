using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    public class LibrosController : Controller
    {
        private TraveEntities db = new TraveEntities();
        // GET: Libros mryg 

        public ActionResult Index()
        {
            var libros = db.Libros;
            return View(libros.ToList());
        }

        public ActionResult IndexLibros()
        {
            
            List<LibrosViewModel> listLibros = db.Libros.Where(x => x.IdEditorial > 0).Select(x => new LibrosViewModel
            { Titulo = x.Titulo, Sinopsis = x.Sinopsis, NPaginas = x.NPaginas }).ToList();
            ViewBag.listLibros = listLibros;

            return View();
        }

        public ActionResult AddEditLibros(int IdLibro)
        {
            List<Editoriales> list = db.Editoriales.ToList();
            ViewBag.IdEditorial = new SelectList(list, "IdEditorial", "nombre");
            
            List<autores> listAutores = db.autores.ToList();
            ViewBag.AutorList = new SelectList(listAutores, "IdAutor", "nombres");

            LibrosViewModel model = new LibrosViewModel();

            if (IdLibro > 0)
            {
                Libros lib = db.Libros.SingleOrDefault(x => x.IdLibro == IdLibro);
                model.IdLibro = lib.IdLibro;
                model.IdEditorial = lib.IdEditorial;
                model.Titulo = lib.Titulo;
                model.Sinopsis = lib.Sinopsis;
                model.NPaginas = lib.NPaginas;
            }

            return PartialView("Partial2", model);
        }

        [HttpPost]
        public ActionResult SaveEditLibros(LibrosViewModel model)
        {
            try
            {
                TraveEntities db = new TraveEntities();
                List<Editoriales> list = db.Editoriales.ToList();

                if (model.IdLibro > 0)
                {
                    //  Update
                    Libros lib = db.Libros.SingleOrDefault(x => x.IdLibro == model.IdLibro);
                    lib.IdEditorial = model.IdEditorial;
                    lib.Titulo = model.Titulo;
                    lib.Sinopsis = model.Sinopsis;
                    db.SaveChanges();
                }
                else
                {
                    // Insert
                    Libros lib = new Libros();
                    lib.IdEditorial = model.IdEditorial;
                    lib.Titulo = model.Titulo;
                    lib.Sinopsis = model.Sinopsis;
                    lib.NPaginas = model.NPaginas;

                    db.Libros.Add(lib);
                    db.SaveChanges();
                }

                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult DeleteLibro(int id)
        {
            Libros libros = db.Libros.Find(id);
            db.Libros.Remove(libros);
            db.SaveChanges();
            return RedirectToAction("IndexLibros");
        }

        [HttpPost]
        public ActionResult postLibros(LibrosViewModel model)
        {
            try
            {
                Libros lib = new Libros();
                lib.IdEditorial = model.IdEditorial;
                lib.Titulo = model.Titulo;
                lib.Sinopsis = model.Sinopsis;
                lib.NPaginas = model.NPaginas;
                db.Libros.Add(lib);
                db.SaveChanges();

                return RedirectToAction("IndexLibros");
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult EditLibro(int? id)
        {
            Libros libros = db.Libros.Find(id);
            List<Editoriales> list = db.Editoriales.ToList();
            ViewBag.IdEditorial = new SelectList(list, "IdEditorial", "nombre");
            return View(libros);
        }

        //[HttpPost]
       

        public ActionResult IndexConsulta()
        {
            var libros = from li in db.Libros
                         join edi in db.Editoriales on li.IdEditorial equals edi.IdEditorial
                         join Al in db.Autores_Has_Libros on li.IdLibro equals Al.Id_Libro
                         join aut in db.autores on Al.Id_Autor equals aut.IdAutor

                         //   select new { li.Titulo, li.Sinopsis, edi.Nombre, aut.nombres, aut.Apellidos };
                         select new
                         {
                             Titulo = li.Titulo,
                             Sinopsis = li.Sinopsis,
                             Nombre = edi.Nombre,
                             nombres = aut.nombres,
                             Apellidos = aut.Apellidos
                         };

            return View(libros.ToList());
        }


    }
}



