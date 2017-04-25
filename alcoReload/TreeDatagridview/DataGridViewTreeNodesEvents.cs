
using System;
using System.Collections.Generic;
using System.Text;

namespace DatagridTreeView
{
	public class DataGridViewTreeNodesEvents
	{
		private DataGridViewTreeNode _node;

		public DataGridViewTreeNodesEvents(DataGridViewTreeNode node)
		{
			this._node = node;
		}

		public DataGridViewTreeNode Node
		{
			get { return _node; }
		}
	}

	public class CollapsingEventArgs : System.ComponentModel.CancelEventArgs
	{
		private DataGridViewTreeNode _node;

		private CollapsingEventArgs() { }
		public CollapsingEventArgs(DataGridViewTreeNode node)
			: base()
		{
			this._node = node;
		}
		public DataGridViewTreeNode Node
		{
			get { return _node; }
		}

	}
	public class CollapsedEventArgs : DataGridViewTreeNodesEvents
	{
		public CollapsedEventArgs(DataGridViewTreeNode node)
			: base(node)
		{
		}
	}

	public class ExpandingEventArgs:System.ComponentModel.CancelEventArgs
	{
		private DataGridViewTreeNode _node;

		private ExpandingEventArgs() { }
		public ExpandingEventArgs(DataGridViewTreeNode node):base()
		{
			this._node = node;
		}
		public DataGridViewTreeNode Node
		{
			get { return _node; }
		}

	}
	public class ExpandedEventArgs : DataGridViewTreeNodesEvents
	{
		public ExpandedEventArgs(DataGridViewTreeNode node):base(node)
		{
		}
	}

	public delegate void ExpandingEventHandler(object sender, ExpandingEventArgs e);
	public delegate void ExpandedEventHandler(object sender, ExpandedEventArgs e);

	public delegate void CollapsingEventHandler(object sender, CollapsingEventArgs e);
	public delegate void CollapsedEventHandler(object sender, CollapsedEventArgs e);

}
