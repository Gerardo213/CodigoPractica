using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using WebApi.Models;
using System.Net.Http.Formatting;

namespace WebSite.Cls_Api
{
	/// <summary>
	/// Clase que contiene los métodos necesarios para consumir la Api y conectar con el controlador del modelo Persona
	/// </summary>
	public class Cls_Api_Persona
	{
		#region Variables Staticas
		/// <summary>
		/// Variable con la cadena url de la Api 
		/// </summary>
		private static readonly string _uri = "http://localhost/WebApi/";
		#endregion

		#region Obtener Lista Persona desde Api

		/// <summary>
		/// Consulta el Método GET de la Api, sin enviarle parametros.
		/// </summary>
		/// <returns> Retorna una lista del Modelo Persona</returns>

		public static List<Persona> SpObtenerListaPersonas()
		{
			List<Persona> personas = new List<Persona>();

			HttpClient cliente = new HttpClient();
			cliente.BaseAddress = new Uri(_uri);
			var result = cliente.GetAsync("api/Persona").Result;

			if (result.IsSuccessStatusCode)
			{
				var resultString = result.Content.ReadAsStringAsync().Result;
				personas = JsonConvert.DeserializeObject<List<Persona>>(resultString);
				return personas;
			}
			return new List<Persona>();
		}
		#endregion

		#region Obterner Persona desde Api

		/// <summary>
		/// Consulta el Método GET de la Api, envia el parámetro id de tipo entero para aplicar el filtro en la consulta.
		/// </summary>
		/// <param name="id"> Recibe parámetro id de tipo entero</param>
		/// <returns> Retorna un objeto del Modelo Persona</returns>

		public static Persona SpObtenerPersona(int id)
		{
			Persona persona = new Persona();

			HttpClient cliente = new HttpClient();
			cliente.BaseAddress = new Uri(_uri);
			var result = cliente.GetAsync("api/Persona?Id=" + id).Result;

			if (result.IsSuccessStatusCode)
			{
				var resultString = result.Content.ReadAsStringAsync().Result;
				persona = JsonConvert.DeserializeObject<Persona>(resultString);
			}
			return persona;
		}
		#endregion

		#region Crear Persona desde Api

		/// <summary>
		/// Permite enviar el objeto del Modelo Persona para su insercción en base de datos
		/// </summary>
		/// <param name="persona"> Recibe parámetro de tipo modelo Persona</param>
		/// <returns> true = Si la transacción fue exitosa, si es diferente de true el string devuelto es el mensaje de error.</returns>

		public static string SpCrearPersona(Persona persona)
		{
			HttpClient cliente = new HttpClient();
			cliente.BaseAddress = new Uri(_uri);
			var result = cliente.PostAsync("api/Persona", persona, new JsonMediaTypeFormatter()).Result;
			string retorno;

			if (result.IsSuccessStatusCode)
			{
				var resultString = result.Content.ReadAsStringAsync().Result;
				retorno = JsonConvert.DeserializeObject<string>(resultString);
				return retorno;
			}
			return "Error de conexión";
		}
		#endregion

		#region Modificar Persona desde Api

		/// <summary>
		/// Permite enviar un objeto de tipo modelo Persona para su modificación en base de datos, se toma con criterio de filtro el atributo Id del modelo Persona
		/// </summary>
		/// <param name="persona"> Recibe un objeto persona de tipo modelo Persona</param>
		/// <returns> true = Si la transacción fue exitosa, si es diferente de true el string devuelto es el mensaje de error.</returns>

		public static string SpModificarPersona(Persona persona)
		{
			HttpClient cliente = new HttpClient();
			cliente.BaseAddress = new Uri(_uri);
			var result = cliente.PutAsync("api/Persona", persona, new JsonMediaTypeFormatter()).Result;
			string retorno;

			if (result.IsSuccessStatusCode)
			{
				var resultString = result.Content.ReadAsStringAsync().Result;
				retorno = JsonConvert.DeserializeObject<string>(resultString);
				return retorno;
			}
			return "Error de conexión";
		}
		#endregion

		#region Eliminar Persona desde Api

		/// <summary>
		/// Permite enviar la solicitud de eliminar un registro de tipo modelo Persona en base de datos, se toma con criterio de filtro el parametro Id recibido en el metodo.
		/// </summary>
		/// <param name="id"> Recibe un parametro Id de tipo entero para filtra el registro a eliminar</param>
		/// <returns> true = Si la transacción fue exitosa, si es diferente de true el string devuelto es el mensaje de error.</returns>

		public static string SpEliminarPersona(int id)
		{
			HttpClient cliente = new HttpClient();
			cliente.BaseAddress = new Uri(_uri);
			var result = cliente.DeleteAsync("api/Persona?Id=" + id).Result;
			string retorno;

			if (result.IsSuccessStatusCode)
			{
				var resultString = result.Content.ReadAsStringAsync().Result;
				retorno = JsonConvert.DeserializeObject<string>(resultString);
				return retorno;
			}
			return "Error de conexión";
		}
		#endregion

	}
}