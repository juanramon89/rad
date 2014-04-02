using System;
using MySql.Data.MySqlClient;

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
			updateMySqlCommand.CommandText = "update articulo set nombre=:nombre where id=1";
			
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
			
			mySqlCommand.CommandText = "SELECT * FROM articulo";
			
			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
			
			
			while(mySqlDataReader.Read()){
				Console.WriteLine("id={0} nombre{1}", mySqlDataReader["id"], mySqlDataReader["nombre"]);
			}
			
			mySqlDataReader.Close();
			mySqlConnection.Close();
			
			//string hora = DateTime.Now.ToString();
			

		}
	}
}
