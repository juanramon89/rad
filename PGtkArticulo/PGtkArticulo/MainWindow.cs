using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using PGtkArticulo;

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
		
		//App.Instance.DbConnection = new MySqlConnection(connectionString);
		//IDbCommand selectCommand = App.Instance.DbConnection.CreateCommand();
		
		dbConnection = new MySqlConnection (connectionString);
			
		dbConnection.Open ();
		
		string selectSql = "SELECT * FROM articulo";
		
		TreeViewFiller treeViewFiller = new TreeViewFiller();
		treeViewFiller.Fill(treeView,dbConnection,selectSql);
		
		ListStore listStore = treeViewFiller.getListStore;
			
		
		
		editAction.Sensitive = false;
		deleteAction.Sensitive = false;
		
		editAction.Activated += delegate {
			if (treeView.Selection.CountSelectedRows () == 0)
				return;
			TreeIter treeIter;
			treeView.Selection.GetSelected (out treeIter);
			object id = listStore.GetValue (treeIter, 0);
			object nombre = listStore.GetValue (treeIter, 1);
			Console.WriteLine();
			
			MessageDialog messageDialog = new MessageDialog (this,
                DialogFlags.DestroyWithParent,
                MessageType.Info,
                ButtonsType.Ok,
                "Seleccionado Id={0} Nombre={1}", id, nombre);
			messageDialog.Title = "Este es el título del mensaje";
			messageDialog.Run ();
			messageDialog.Destroy ();
		};
		
		deleteAction.Activated += delegate {
			if (treeView.Selection.CountSelectedRows () == 0)
				return;
			TreeIter treeIter;
			treeView.Selection.GetSelected (out treeIter);
			object id = listStore.GetValue (treeIter, 0);
			
			MessageDialog messageDialog = new MessageDialog (this,
                DialogFlags.DestroyWithParent,
                MessageType.Question,
                ButtonsType.YesNo,
                "¿Quieres eliminar el elemento seleccionado?");
			messageDialog.Title = "Eliminar elemento";
			ResponseType response = (ResponseType)messageDialog.Run ();
			messageDialog.Destroy ();
			if (response == ResponseType.Yes) {
				IDbCommand deleteMySqlCommand = dbConnection.CreateCommand ();
				deleteMySqlCommand.CommandText = "delete from articulo where id=" + id;
				deleteMySqlCommand.ExecuteNonQuery ();
			}
		};
		
		treeView.Selection.Changed += delegate {
			bool hasSelectedRows = treeView.Selection.CountSelectedRows () > 0;
			editAction.Sensitive = hasSelectedRows;
			deleteAction.Sensitive = hasSelectedRows;
		};
		/*
		refreshAction.Activated += delegate {
			
			selectCommand = dbConnection.CreateCommand (); 
			selectCommand.CommandText = "SELECT * FROM articulo";
			dataReader = selectCommand.ExecuteReader ();

			listStore.Clear ();
			fillListStore (listStore, dataReader);
			dataReader.Close ();
		};*/
	}
	/*
	private ListStore createListStore (int fieldCount)
	{

		Type[] types = new Type[fieldCount];

		for (int index = 0; index < fieldCount; index++)

			types [index] = typeof(string);

		return new ListStore (types);

	}
	
	private void addColumns (IDataReader dataReader)
	{
		for (int index = 0; index < dataReader.FieldCount; index++)
			treeView.AppendColumn (dataReader.GetName (index), new CellRendererText (), "text", index);
	}
	
	private void fillListStore (ListStore listStore, IDataReader dataReader)
	{
		while (dataReader.Read ()) {
			List<string> values = new List<string> ();
			for (int index = 0; index < dataReader.FieldCount; index++)
				values.Add (dataReader.GetValue (index).ToString ());
			listStore.AppendValues (values.ToArray ());
		}

	}*/

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;

		dbConnection.Close ();
	}
	
}