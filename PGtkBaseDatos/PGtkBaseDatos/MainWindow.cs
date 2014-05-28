using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using PGtkArticulo;

//Crea un programa con la interfaz gráfica Gtk# que 
//visualice las tablas de una base de datos.
//El usuario accederá a las diferentes tablas a traves de 
//pestañas.
//Aparte, el programa debe incorporar una toolbar donde 
//se almacenarán las opciones nuevo, editar, eliminar
//y refrescar la página.

//La opción nuevo insertará un nuevo registro con la fecha
//actual como nombre.

//La opción editar editará un registro seleccionado por el 
//usuario.

//La opción eliminar borrará el registro seleccionado por el
//usuario.

//La opción refrescar pagina debe actualizar las tablas y 
//sus correspondientes datos.

public partial class MainWindow: Gtk.Window
{	
	IDbConnection dbConnection;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		//CONSTRUCCION DE LAS 2 TABLAS:
		string connectionString =
				"Server=localhost;" +
				"Database=dbrepaso;" +
				"User Id=root;" +
				"Password=sistemas";
		
		dbConnection = new MySqlConnection (connectionString);
			
		dbConnection.Open ();
		
		string selectSqlArticulo = "SELECT * FROM articulo";
		string selectSqlCategoria = "SELECT * FROM categoria";
		
		TreeViewFiller treeViewFillerArticulo = new TreeViewFiller();
		treeViewFillerArticulo.Fill(treeViewA,dbConnection,selectSqlArticulo);
		
		TreeViewFiller treeViewFillerCategoria = new TreeViewFiller();
		treeViewFillerCategoria.Fill(treeViewC,dbConnection,selectSqlCategoria);

		ListStore listStoreArticulo = treeViewFillerArticulo.getListStore;
		ListStore listStoreCategoria = treeViewFillerCategoria.getListStore;	
		
		editAction.Sensitive = false;
		deleteAction.Sensitive = false;
		
		//Si se cambia de pestaña:
	/*	notebook3.SwitchPage += delegate {
			int final = notebook3.CurrentPage;
			if(final == 0){
			int total = notebook3.NPages;
			Console.WriteLine(final);
			}else{
				Console.WriteLine(final);
			}
		};*/
		
		
		//Si se pulsa el boton Nuevo:
		newAction.Activated += delegate{
			IDbCommand addMySqlCommand = dbConnection.CreateCommand();
			if(notebook3.CurrentPage == 0){
				addMySqlCommand.CommandText = string.Format("insert into articulo (nombre) values ('{0}')",DateTime.Now);
				addMySqlCommand.ExecuteNonQuery();
				
			}else if(notebook3.CurrentPage == 1){
				addMySqlCommand.CommandText = string.Format("insert into categoria (nombre) values ('{0}')",DateTime.Now);
				addMySqlCommand.ExecuteNonQuery();
			}
		};
		
		//Si se pulsa el boton editar:
		editAction.Activated += delegate {
			IDbCommand updateMySqlCommand = dbConnection.CreateCommand();
			if (treeViewA.Selection.CountSelectedRows () == 0)
				return;
			TreeIter treeIter;
			treeViewA.Selection.GetSelected (out treeIter);
			object id = listStoreArticulo.GetValue (treeIter, 0);
			object nombre = listStoreArticulo.GetValue (treeIter, 1);
			Console.WriteLine();
			
			MessageDialog messageDialog = new MessageDialog (this,
                DialogFlags.DestroyWithParent,
                MessageType.Info,
                ButtonsType.Ok,
                "Seleccionado Id={0} Nombre={1}", id, nombre);
			messageDialog.Title = "Modificar Elemento";
			messageDialog.Run ();
			updateMySqlCommand.CommandText = "update articulo set nombre = '"+DateTime.Now+"' where id ="+id;
			updateMySqlCommand.ExecuteNonQuery();
			messageDialog.Destroy ();
		};
		
		//Si se pulsa el boton eliminar:
		deleteAction.Activated += delegate {
			if(notebook3.CurrentPage == 0){
				if (treeViewA.Selection.CountSelectedRows () == 0)
					return;
				TreeIter treeIter;
				treeViewA.Selection.GetSelected (out treeIter);
				object id = listStoreArticulo.GetValue (treeIter, 0);
			
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
				
			}else if(notebook3.CurrentPage == 1){
				if (treeViewC.Selection.CountSelectedRows () == 0)
					return;
				TreeIter treeIter;
				treeViewC.Selection.GetSelected (out treeIter);
				object id = listStoreCategoria.GetValue (treeIter, 0);
			
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
					deleteMySqlCommand.CommandText = "delete from categoria where id=" + id;
					deleteMySqlCommand.ExecuteNonQuery ();
				}
			}
		};
		
		//Si se pulsa el boton refrescar pagina:
		refreshAction.Activated += delegate {
			if(notebook3.CurrentPage == 0){
				treeViewFillerArticulo.Refresh();
			}else if(notebook3.CurrentPage == 1){
				treeViewFillerCategoria.Refresh();
			}

		};
		
		
		//Activar los botones cuando se pulse sobre un elemento de la lista:
		treeViewA.Selection.Changed += delegate {
			bool hasSelectedRows = treeViewA.Selection.CountSelectedRows () > 0;
			editAction.Sensitive = hasSelectedRows;
			deleteAction.Sensitive = hasSelectedRows;
		};
		
		treeViewC.Selection.Changed += delegate {
			bool hasSelectedRows = treeViewC.Selection.CountSelectedRows () > 0;
			editAction.Sensitive = hasSelectedRows;
			deleteAction.Sensitive = hasSelectedRows;
		};
		

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;

		dbConnection.Close ();
	}

}