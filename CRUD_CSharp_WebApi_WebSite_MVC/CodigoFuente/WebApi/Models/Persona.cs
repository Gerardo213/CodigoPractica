using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
	/// <summary>
	/// Modelo Persona utilizado en la lógica de negocio de las vistas y también en la base de datos.
	/// </summary>
	public class Persona
	{
		public int Id { get; set; }

		[Required]
		[StringLength(100)]
		public string Identificacion { get; set; }

		[Required]
		[StringLength(100)]
		public string Nombre { get; set; }

		[Required]
		[StringLength(100)]
		public string Apellido { get; set; }

		[Range(0, 120)]
		public int Edad { get; set; }

		public string Direccion { get; set; }

		public string OtrosDatos { get; set; }
	}
}