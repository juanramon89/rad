using System;
using Gtk;
using System.Data;
using System.Collections.Generic;

namespace PGtkArticulo
{
	public class TreeViewFiller
	{
		private TreeView treeView;
		private ListStore listStore;
		
		public void Fill(TreeView treeView,IDbConnection dbConnection,string selectText){
			this.treeView = treeView;
			IDbCommand selectCommand = dbConnection.CreateCommand (); 
			selectCommand.CommandText = selectText;
			IDataReader dataReader = selectCommand.ExecuteReader ();
			
			addColumns(dataReader);
			listStore = createListStore(dataReader.FieldCount);
			fillListStore(listStore,dataReader);
			dataReader.Close();
			treeView.Model = listStore;
		}
		
		
		private ListStore createListStore (int fieldCount){

			Type[] types = new Type[fieldCount];

			for (int index = 0; index < fieldCount; index++)
				types [index] = typeof(string);
			return new ListStore (types);
		}
		
		private void addColumns (IDataReader dataReader){
			for (int index = 0; index < dataReader.FieldCount; index++)
				treeView.AppendColumn (dataReader.GetName (index), new CellRendererText (), "text", index);
		}
		
		private void fillListStore (ListStore listStore, IDataReader dataReader){
			while (dataReader.Read ()) {
				List<string> values = new List<string> ();
					for (int index = 0; index < dataReader.FieldCount; index++)
						values.Add (dataReader.GetValue (index).ToString ());
				listStore.AppendValues (values.ToArray ());
			}
		}
		
		public ListStore getListStore{
			get {return this.listStore;}
		}
	}
}

