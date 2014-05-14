using System;
using Gtk;
using System.Data;
using System.Collections.Generic;

namespace PGtkArticulo
{
	public class TreeViewFiller
	{
		public static void Fill(TreeView treeView,IDbConnection dbConnection,string selectText){
			IDbCommand selectCommand = dbConnection.CreateCommand (); 
			selectCommand.CommandText = selectText;
			IDataReader dataReader = selectCommand.ExecuteReader ();
			
			for (int index = 0; index < dataReader.FieldCount; index++)
				treeView.AppendColumn (dataReader.GetName (index), new CellRendererText (), "text", index);
			
			Type[] types = new Type[dataReader.FieldCount];
			for (int index = 0; index < dataReader.FieldCount; index++){
				types [index] = typeof(string);
			}
			ListStore listStore = new ListStore(types);
			
			treeView.Model = listStore;
			
			while (dataReader.Read ()) {
				List<string> values = new List<string> ();
				for (int index = 0; index < dataReader.FieldCount; index++)
					values.Add (dataReader.GetValue (index).ToString ());
				listStore.AppendValues (values.ToArray ());
			}
			dataReader.Close();
		}
	}
}

