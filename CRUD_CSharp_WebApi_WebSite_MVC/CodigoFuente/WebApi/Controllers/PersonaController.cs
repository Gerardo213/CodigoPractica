using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
	/// <summary>
	/// Controlador del modelo Persona
	/// </summary>
	public class PersonaController : ApiController
	{
		#region Get Obtener Lista Persona
		/// <summary>
		/// Permite consultar la información de todas las personas
		/// </summary>
		/// <returns> Lista del modelo Persona</returns>

		// GET api/Persona           
		public IEnumerable<Persona> Get()
		{
			return Cls_Datos.SpObtenerListaPersonas();
		}
		#endregion

		#region Get obtener Persona
		/// <summary>
		/// Permite consultar la información de todas las personas con filtro por id 
		/// </summary>
		/// <returns> Objeto de tipo modelo Persona</returns>

		// GET api/Persona/5
		public Persona Get(int id)
		{
			return Cls_Datos.SpObtenerPersona(id);
		}
		#endregion

		#region Post Crear Persona
		/// <summary>
		/// Permite crear un registro de tipo modelo Persona en base de datos
		/// </summary>
		/// <param name="persona"> Recibe un Json de tipo modelo Persona </param>
		/// <returns> true = Si la transacción fue exitosa, si es diferente de true el string devuelto es el mensaje de error.</returns>

		// POST api/Persona
		public string Post([FromBody] Persona persona)
		{
			return Cls_Datos.SpCrearPersona(persona);
		}
		#endregion

		#region Put Modificar Persona
		/// <summary>
		/// Permite modificar un registro de tipo modelo Persona en base de datos, se toma con criterio de filtro el atributo Id del modelo Persona
		/// </summary>
		/// <param name="persona"> Recibe un Json de tipo modelo Persona </param>
		/// <returns> true = Si la transacción fue exitosa, si es diferente de true el string devuelto es el mensaje de error.</returns>

		// PUT api/Persona/5
		public string Put([FromBody] Persona persona)
		{
			return Cls_Datos.SpModificarPersona(persona);
		}
		#endregion

		#region Delete Persona
		/// <summary>
		/// Permite eliminar un registro de tipo modelo Persona en base de datos, se toma con criterio de filtro el parametro Id recibido en el metodo.
		/// </summary>
		/// <param name="id"> Recibe un parametro Id de tipo entero para filtra el registro a eliminar</param>
		/// <returns> true = Si la transacción fue exitosa, si es diferente de true el string devuelto es el mensaje de error.</returns>

		// DELETE api/Persona/5
		public string Delete(int id)
		{
			return Cls_Datos.SpEliminarPersona(id);
		}
		#endregion

	}
}
