
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	private global::Gtk.Action newAction;
	private global::Gtk.Action editAction;
	private global::Gtk.Action deleteAction;
	private global::Gtk.Action refreshAction;
	private global::Gtk.Action Action;
	private global::Gtk.VBox vbox1;
	private global::Gtk.Toolbar toolbar1;
	private global::Gtk.Notebook notebook3;
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	private global::Gtk.TreeView treeViewA;
	private global::Gtk.Label label3;
	private global::Gtk.ScrolledWindow GtkScrolledWindow1;
	private global::Gtk.TreeView treeViewC;
	private global::Gtk.Label label4;
	
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.newAction = new global::Gtk.Action ("newAction", null, null, "gtk-new");
		w1.Add (this.newAction, null);
		this.editAction = new global::Gtk.Action ("editAction", null, null, "gtk-edit");
		w1.Add (this.editAction, null);
		this.deleteAction = new global::Gtk.Action ("deleteAction", null, null, "gtk-delete");
		w1.Add (this.deleteAction, null);
		this.refreshAction = new global::Gtk.Action ("refreshAction", null, null, "gtk-refresh");
		w1.Add (this.refreshAction, null);
		this.Action = new global::Gtk.Action ("Action", null, null, null);
		w1.Add (this.Action, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar1'><toolitem name='newAction' action='newAction'/><toolitem name='editAction' action='editAction'/><toolitem name='deleteAction' action='deleteAction'/><toolitem name='refreshAction' action='refreshAction'/><toolitem name='Action' action='Action'/></toolbar></ui>");
		this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar1")));
		this.toolbar1.Name = "toolbar1";
		this.toolbar1.ShowArrow = false;
		this.vbox1.Add (this.toolbar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.toolbar1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.notebook3 = new global::Gtk.Notebook ();
		this.notebook3.CanFocus = true;
		this.notebook3.Name = "notebook3";
		this.notebook3.CurrentPage = 1;
		// Container child notebook3.Gtk.Notebook+NotebookChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.treeViewA = new global::Gtk.TreeView ();
		this.treeViewA.CanFocus = true;
		this.treeViewA.Name = "treeViewA";
		this.GtkScrolledWindow.Add (this.treeViewA);
		this.notebook3.Add (this.GtkScrolledWindow);
		// Notebook tab
		this.label3 = new global::Gtk.Label ();
		this.label3.Name = "label3";
		this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Articulo");
		this.notebook3.SetTabLabel (this.GtkScrolledWindow, this.label3);
		this.label3.ShowAll ();
		// Container child notebook3.Gtk.Notebook+NotebookChild
		this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
		this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
		this.treeViewC = new global::Gtk.TreeView ();
		this.treeViewC.CanFocus = true;
		this.treeViewC.Name = "treeViewC";
		this.GtkScrolledWindow1.Add (this.treeViewC);
		this.notebook3.Add (this.GtkScrolledWindow1);
		global::Gtk.Notebook.NotebookChild w6 = ((global::Gtk.Notebook.NotebookChild)(this.notebook3 [this.GtkScrolledWindow1]));
		w6.Position = 1;
		// Notebook tab
		this.label4 = new global::Gtk.Label ();
		this.label4.Name = "label4";
		this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Categoria");
		this.notebook3.SetTabLabel (this.GtkScrolledWindow1, this.label4);
		this.label4.ShowAll ();
		this.vbox1.Add (this.notebook3);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.notebook3]));
		w7.Position = 1;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 400;
		this.DefaultHeight = 300;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
	}
}
