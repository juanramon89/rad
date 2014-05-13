using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window
{	
	IDbConnection dbConnection;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		string connectionString =
				"Server=localhost;" +
				"Database=dbrepaso;" +
				"User Id=root;" +
				"Password=sistemas";
		
		//IDbCommand selectCommand = App.Instance.DbConnection.CreateCommand();
		dbConnection = new MySqlConnection(connectionString);
			
			dbConnection.Open();
		
		IDbCommand selectCommand = dbConnection.CreateCommand(); 
		selectCommand.CommandText = "SELECT * FROM articulo";
		IDataReader dataReader = selectCommand.ExecuteReader();
		
		addColumns(dataReader);
		
		ListStore listStore =  createListStore(dataReader.FieldCount);
		treeView.Model = listStore;
		fillListStore(listStore, dataReader);
		dataReader.Close();

	}
	
	private ListStore createListStore(int fieldCount) {

		Type[] types = new Type[fieldCount];

		for (int index = 0; index < fieldCount; index++)

			types[index] = typeof(string);

		return new ListStore(types);

	}
	
	private void addColumns (IDataReader dataReader){
		for (int index = 0; index < dataReader.FieldCount; index++)
			treeView.AppendColumn(dataReader.GetName(index), new CellRendererText(),"text", index);
	}
	
	private void fillListStore (ListStore listStore, IDataReader dataReader){
		while(dataReader.Read ()){
			List<string> values = new List<string>();
				for (int index = 0; index < dataReader.FieldCount; index++)
					values.Add ( dataReader.GetValue (index).ToString() );
				listStore.AppendValues(values.ToArray());
		}

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;

		dbConnection.Close();
	}
}
