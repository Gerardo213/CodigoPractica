using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data
{
	/// <summary>
	/// Clase que permite conectar a la base de datos y permite realizar diferentes transacciones a la tabla tb_Personas
	/// </summary>
	public class Cls_Datos
	{
		#region Obtener Lista Persona desde Base de datos

		/// <summary>
		/// Consulta todos los datos en base de datos en la tabla tb_Personas 
		/// </summary>
		/// <returns> Lista de objetos de tipo modelo Persona</returns>

		public static List<Persona> SpObtenerListaPersonas()
		{
			List<Persona> listaPersonas = new List<Persona>();
			using (SqlConnection sqlconn = new SqlConnection(Cls_Conexion.connectionString))
			{
				var sql = "SELECT Id,Identificacion,Nombre,Apellido,Edad,Direccion,OtrosDatos  FROM tb_Personas";
				SqlCommand cmd = new SqlCommand(sql, sqlconn);
				try
				{
					sqlconn.Open();
					cmd.ExecuteNonQuery();

					using (SqlDataReader dr = cmd.ExecuteReader())
					{

						while (dr.Read())
						{
							listaPersonas.Add(new Persona()
							{
								Id = Convert.ToInt32(dr["Id"]),
								Identificacion = dr["Identificacion"].ToString(),
								Nombre = dr["Nombre"].ToString(),
								Apellido = dr["Apellido"].ToString(),
								Edad = Convert.ToInt32(dr["Edad"]),
								Direccion = dr["Direccion"].ToString(),
								OtrosDatos = dr["OtrosDatos"].ToString()
							});
						}

					}
					return listaPersonas;
				}
				catch (Exception ex)
				{
					return listaPersonas;
				}
			}
		}
		#endregion

		#region Obterner Persona desde Base de datos

		/// <summary>
		/// Consulta registro en base de datos en la tabla tb_Personas aplicando un filtro en campo Id.
		/// </summary>
		/// <param name="id"> Recibe parametro id de tipo entero en el metodo.</param>
		/// <returns> Un objeto persona de tipo modelo Persona</returns>

		public static Persona SpObtenerPersona(int id)
		{
			Persona _Persona = new Persona();
			using (SqlConnection sqlconn = new SqlConnection(Cls_Conexion.connectionString))
			{
				var sql = "SELECT Id,Identificacion,Nombre,Apellido,Edad,Direccion,OtrosDatos  FROM tb_Personas where Id = " + id;
				SqlCommand cmd = new SqlCommand(sql, sqlconn);
				try
				{
					sqlconn.Open();
					cmd.ExecuteNonQuery();

					using (SqlDataReader dr = cmd.ExecuteReader())
					{

						while (dr.Read())
						{
							_Persona = (new Persona()
							{
								Id = Convert.ToInt32(dr["Id"]),
								Identificacion = dr["Identificacion"].ToString(),
								Nombre = dr["Nombre"].ToString(),
								Apellido = dr["Apellido"].ToString(),
								Edad = Convert.ToInt32(dr["Edad"]),
								Direccion = dr["Direccion"].ToString(),
								OtrosDatos = dr["OtrosDatos"].ToString()
							});
						}

					}
					return _Persona;
				}
				catch (Exception ex)
				{
					return _Persona;
				}
			}
		}
		#endregion

		#region Crear Persona desde Base de datos

		/// <summary>
		/// Permite ingresar registro en base de datos en la tabla tb_Personas
		/// </summary>
		/// <param name="_Persona"> Recibe un objeto _Persona de tipo modelo Persona</param>
		/// <returns> true = Si la transacción fue exitosa, si es diferente de true el string devuelto es el mensaje de error.</returns>

		public static string SpCrearPersona(Persona _Persona)
		{
			using (SqlConnection sqlconn = new SqlConnection(Cls_Conexion.connectionString))
			{
				sqlconn.Open();

				SqlCommand cmd = sqlconn.CreateCommand();
				SqlTransaction transaction;

				transaction = sqlconn.BeginTransaction("trans");

				cmd.Connection = sqlconn;
				cmd.Transaction = transaction;

				cmd.CommandText = "INSERT INTO tb_Personas (Identificacion,Nombre,Apellido,Edad,Direccion,OtrosDatos) VALUES (@Identificacion,@Nombre,@Apellido,@Edad,@Direccion,@OtrosDatos)";

				cmd.Parameters.AddWithValue("@Identificacion", _Persona.Identificacion);
				cmd.Parameters.AddWithValue("@Nombre", _Persona.Nombre);
				cmd.Parameters.AddWithValue("@Apellido", _Persona.Apellido);
				cmd.Parameters.AddWithValue("@Edad", _Persona.Edad);
				cmd.Parameters.AddWithValue("@Direccion", _Persona.Direccion == null ? "" : _Persona.Direccion);
				cmd.Parameters.AddWithValue("@OtrosDatos", _Persona.OtrosDatos == null ? "" : _Persona.OtrosDatos);

				try
				{
					cmd.ExecuteNonQuery();
					transaction.Commit();
					return "true";
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					return ex.Message;
				}
			}
		}
		#endregion

		#region Modificar Persona desde Base de datos

		/// <summary>
		/// Permite modificar un registro de tipo modelo Persona en base de datos, se toma con criterio de filtro el atributo Id del modelo Persona
		/// </summary>
		/// <param name="_persona"> Recibe un objeto _persona de tipo modelo Persona</param>
		/// <returns> true = Si la transacción fue exitosa, si es diferente de true el string devuelto es el mensaje de error.</returns>

		public static string SpModificarPersona(Persona _persona)
		{
			using (SqlConnection sqlconn = new SqlConnection(Cls_Conexion.connectionString))
			{

				sqlconn.Open();

				SqlCommand cmd = sqlconn.CreateCommand();
				SqlTransaction transaction;

				transaction = sqlconn.BeginTransaction("trans");

				cmd.Connection = sqlconn;
				cmd.Transaction = transaction;

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "sp_Update_Persona";

				cmd.Parameters.AddWithValue("@Id", _persona.Id);
				cmd.Parameters.AddWithValue("@Identificacion", _persona.Identificacion);
				cmd.Parameters.AddWithValue("@Nombre", _persona.Nombre);
				cmd.Parameters.AddWithValue("@Apellido", _persona.Apellido);
				cmd.Parameters.AddWithValue("@Edad", _persona.Edad);
				cmd.Parameters.AddWithValue("@Direccion", _persona.Direccion == null ? "" : _persona.Direccion);
				cmd.Parameters.AddWithValue("@OtrosDatos", _persona.OtrosDatos == null ? "" : _persona.OtrosDatos);
				try
				{

					cmd.ExecuteNonQuery();
					transaction.Commit();
					return "true";
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					return ex.Message;
				}
			}
		}
		#endregion

		#region Eliminar Persona desde Base de datos

		/// <summary>
		/// Permite eliminar un registro de tipo modelo Persona en base de datos, se toma con criterio de filtro el parametro Id recibido en el metodo.
		/// </summary>
		/// <param name="id"> Recibe un parametro Id de tipo entero para filtra el registro a eliminar</param>
		/// <returns> true = Si la transacción fue exitosa, si es diferente de true el string devuelto es el mensaje de error.</returns>

		public static string SpEliminarPersona(int id)
		{
			using (SqlConnection sqlconn = new SqlConnection(Cls_Conexion.connectionString))
			{
				sqlconn.Open();

				SqlCommand cmd = sqlconn.CreateCommand();
				SqlTransaction transaction;

				transaction = sqlconn.BeginTransaction("trans");

				cmd.Connection = sqlconn;
				cmd.Transaction = transaction;

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "sp_Delete_Persona";

				cmd.Parameters.AddWithValue("@Id", id);

				try
				{
					cmd.ExecuteNonQuery();
					transaction.Commit();
					return "true";
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					return ex.Message;
				}
			}
		}
		#endregion
	}
}