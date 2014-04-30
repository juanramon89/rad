using System;
using MySql.Data.MySqlClient;

namespace Pserpis
{
	public class MyClass
	{
		public MyClass ()
		{
		}
		
		public static void introduccionParametro(string nombre,string valor,MySqlCommand mySqlCommand){
			MySqlParameter mySqlParameter = updateMySqlCommand.CreateParameter();
			mySqlParameter.ParameterName = nombre;
			mySqlParameter.Value = valor;
			mySqlCommand.Parameters.Add(mySqlParameter);
			mySqlCommand.ExecuteNonQuery();
		}
	}
}
