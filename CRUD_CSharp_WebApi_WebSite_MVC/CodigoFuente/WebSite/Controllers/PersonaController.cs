using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace WebSite.Controllers
{
	/// <summary>
	/// Controlador del modelo Persona
	/// </summary>
	public class PersonaController : Controller
	{
		#region GET: Index
		// GET: Persona
		public ActionResult Index()
		{
			ViewBag.ShowDialog = "true";
			return View(Cls_Api.Cls_Api_Persona.SpObtenerListaPersonas());
		}
		#endregion

		#region GET: Persona/Details
		// GET: Persona/Details/5
		public ActionResult Details(int id)
		{
			ViewBag.ShowDialog = "true";
			return View(Cls_Api.Cls_Api_Persona.SpObtenerPersona(id));
		}
		#endregion

		#region GET: Persona/Create
		// GET: Persona/Create
		public ActionResult Create()
		{
			ViewBag.ShowDialog = "true";
			return View(new Persona());
		}
		#endregion

		#region POST: Persona/Create
		// POST: Persona/Create
		[HttpPost]
		public ActionResult Create(Persona persona)
		{
			try
			{
				string retorno;

				retorno = Cls_Api.Cls_Api_Persona.SpCrearPersona(persona);

				if (retorno == "true")
				{
					return RedirectToAction("Index");
				}
				else
				{
					ViewBag.ShowDialog = retorno;
				}

				return View(persona);
			}
			catch
			{
				return View(persona);
			}
		}
		#endregion

		#region GET: Persona/Edit
		// GET: Persona/Edit/5
		public ActionResult Edit(int id)
		{
			ViewBag.ShowDialog = "true";
			return View(Cls_Api.Cls_Api_Persona.SpObtenerPersona(id));
		}
		#endregion

		#region POST: Persona/Edit
		// POST: Persona/Edit/5
		[HttpPost]
		public ActionResult Edit(Persona persona)
		{
			try
			{
				string retorno;

				retorno = Cls_Api.Cls_Api_Persona.SpModificarPersona(persona);

				if (retorno == "true")
				{
					return RedirectToAction("Index");
				}
				else
				{
					ViewBag.ShowDialog = retorno;
				}

				return View(persona);
			}
			catch
			{
				return View(persona);
			}
		}
		#endregion

		#region GET: Persona/Delete
		// GET: Persona/Delete/5
		public ActionResult Delete(int id)
		{
			ViewBag.ShowDialog = "true";
			return View(Cls_Api.Cls_Api_Persona.SpObtenerPersona(id));
		}
		#endregion

		#region POST: Persona/Delete
		// POST: Persona/Delete/5
		[HttpPost]
		public ActionResult Delete(Persona persona)
		{
			try
			{
				string retorno;

				retorno = Cls_Api.Cls_Api_Persona.SpEliminarPersona(persona.Id);

				if (retorno == "true")
				{
					return RedirectToAction("Index");
				}
				else
				{
					ViewBag.ShowDialog = retorno;
				}

				return View(persona);
			}
			catch
			{
				return View(persona);
			}
		}
		#endregion

	}
}
