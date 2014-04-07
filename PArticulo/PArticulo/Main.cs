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
<<<<<<< HEAD
			string hora = DateTime.Now.ToString();
			updateMySqlCommand.CommandText = "update articulo set nombre = '"+hora+"' where id=1";
			updateMySqlCommand.ExecuteNonQuery();

=======
			updateMySqlCommand.CommandText = "update articulo set nombre=:nombre where id=1";
>>>>>>> 47c715e83b255b8db9b832499807eea5ba2a296c
			
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
			
			mySqlCommand.CommandText = "SELECT * FROM articulo";
			
			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
			
			
			while(mySqlDataReader.Read()){
<<<<<<< HEAD
				Console.WriteLine("id={0} \n nombre{1}", mySqlDataReader["id"], mySqlDataReader["nombre"]);
			}
			
			
			
			mySqlDataReader.Close();
			mySqlConnection.Close();
			
			
=======
				Console.WriteLine("id={0} nombre{1}", mySqlDataReader["id"], mySqlDataReader["nombre"]);
			}
			
			mySqlDataReader.Close();
			mySqlConnection.Close();
			
			//string hora = DateTime.Now.ToString();
>>>>>>> 47c715e83b255b8db9b832499807eea5ba2a296c
			

		}
	}
}
