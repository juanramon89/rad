using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace PUdpConexion
{
	class MainClass
	{
		public static void Main (string[] args){
			
			string connectionString =
				"Server=localhost;" +
				"Database=dbrepaso;" +
				"User Id=root;" +
				"Password=sistemas";
			
			MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
			
			mySqlConnection.Open();
			
			if(mySqlConnection.State == ConnectionState.Open){
				Console.WriteLine ("OK");
			}else{
					Console.Write ("Error al conectar");
			}
			
			mySqlConnection.Close ();
			
			Console.Write (mySqlConnection.State.ToString());
			
		}
	}
}