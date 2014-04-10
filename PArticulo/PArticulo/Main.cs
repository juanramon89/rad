using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace PArticulo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string connectionString =
				"Server=localhost;" +
				"Database=dbprueba;" +
				"User Id=root;" +
				"Password=sistemas";
			
			MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
			
			mySqlConnection.Open();
			
			
			MySqlCommand updateMySqlCommand = mySqlConnection.CreateCommand();

			//string hora = DateTime.Now.ToString();
			
			updateMySqlCommand.CommandText = "update articulo set nombre =@nombre where id=1";
			
			// Pasar como parametro:
			MySqlParameter mySqlParameter = updateMySqlCommand.CreateParameter();
			mySqlParameter.ParameterName = "nombre";
			mySqlParameter.Value = DateTime.Now.ToString();
			updateMySqlCommand.Parameters.Add(mySqlParameter);
			
			//Ejecutar update:
			updateMySqlCommand.ExecuteNonQuery();
			
			//Borrado de datos:
			MySqlCommand deleteMySqlCommand = mySqlConnection.CreateCommand();
			
			deleteMySqlCommand.CommandText = "DELETE FROM articulo WHERE id=@numero";
			
			MySqlParameter delMySqlParameter = deleteMySqlCommand.CreateParameter();
			delMySqlParameter.ParameterName = "numero";
			delMySqlParameter.Value = "5";
			deleteMySqlCommand.Parameters.Add(delMySqlParameter);
			
			deleteMySqlCommand.ExecuteNonQuery();
			
			mostrar(mySqlConnection);
			
			//Insertar datos:
			MySqlCommand insertMySqlCommand = mySqlConnection.CreateCommand();
			
			insertMySqlCommand.CommandText = "INSERT INTO articulo (id, nombre, categoria, precio)"+
											 "VALUES('5','articulo 5','null','null')";
			
			insertMySqlCommand.ExecuteNonQuery();
			
			
			
			mostrar(mySqlConnection);
				
			
			mySqlConnection.Close();
			
			
			
			
			/*
			//Conectamos y abrimos la BD:
			IDbConnection dbConnection = new MySqlConnection(connectionString);
			
			dbConnection.Open();
			
			//Creamos el comando para hacer un update en la BD:
			IDbCommand updateDbCommand = dbConnection.CreateCommand();
			
			updateDbCommand.CommandText = "update articulo set nombre =@nombre where id=1";
			
			//Creamos el parametro que introduciremos para modificar:
			IDbDataParameter dbDataParameter = updateDbCommand.CreateParameter();
			
			dbDataParameter.ParameterName = "nombre";
			
			dbDataParameter.Value = DateTime.Now.ToString();
						
			//Añadimos el parametro a la consulta:
			updateDbCommand.Parameters.Add(dbDataParameter);
			
			//Ejecutamos update:
			updateDbCommand.ExecuteNonQuery();
			
			IDbCommand dbCommand = dbConnection.CreateCommand();
			
			dbCommand.CommandText = "SELECT * FROM articulo";
			
			IDataReader dataReader = dbCommand.ExecuteReader();
			
			dataReader.Read();
			
			while(dataReader.Read()){
				Console.WriteLine("id={0} nombre{1}", dataReader["id"], dataReader["nombre"]);
			}
			
			dataReader.Close();
			dbConnection.Close();*/
		}
		
		public static void mostrar(MySqlConnection mySqlConnection){
			
			//Vemos el resultado de la tabla:
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
			
			mySqlCommand.CommandText = "SELECT * FROM articulo";
			
			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
			
			
			while(mySqlDataReader.Read()){
				Console.WriteLine("id={0} nombre{1}", mySqlDataReader["id"], mySqlDataReader["nombre"]);
			}
			
			mySqlDataReader.Close();
			 
			}
	}
}
