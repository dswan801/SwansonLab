using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;

using Autodesk.Revit.DB;

namespace swanson.FilterLab
{
    public partial class SelectionUI2 : System.Windows.Forms.Form
    {
        public SelectionUI2()
        {
            InitializeComponent();
        }


        public
        SelectionUI2(System.Object obj)
        {
            InitializeComponent();

            // get in array form so we can call normal processing code.
            ArrayList objs = new ArrayList();
            objs.Add(obj);
            CommonInit(objs);
        }

        public
        SelectionUI2(ArrayList objs)
        {
            InitializeComponent();
            CommonInit(objs);
        }

        public
        SelectionUI2(Document doc, ICollection<ElementId> ids)
        {
            InitializeComponent();

            ICollection<Element> elemSet
              = new List<Element>(ids.Select<ElementId, Element>(
                id => doc.GetElement(id)));

            CommonInit(elemSet);
        }


        protected void
        CommonInit(IEnumerable objs)
        {
            treeView2.BeginUpdate();

            AddObjectsToTree(objs);

            // if the tree isn't well populated, expand it and select the first item
            // so its not a pain for the user when there is only one relevant item in the tree
            if (treeView2.Nodes.Count == 1)
            {
                treeView2.Nodes[0].Expand();
                if (treeView2.Nodes[0].Nodes.Count == 0)
                    treeView2.SelectedNode = treeView2.Nodes[0];
                else
                    treeView2.SelectedNode = treeView2.Nodes[0].Nodes[0];
            }

            treeView2.EndUpdate();
        }
        protected void
        AddObjectsToTree(IEnumerable objs)
        {
            treeView2.Sorted = true;

            // initialize the tree control
            foreach (Object tmpObj in objs)
            {
                // hook this up to the correct spot in the tree based on the object's type
                
                TreeNode parentNode = GetExistingNodeForType(tmpObj.GetType());
                if (parentNode == null)
                {
                    parentNode = new TreeNode(tmpObj.GetType().Name);
                    parentNode.Checked = true; 
                    
                    treeView2.Nodes.Add(parentNode);

                    // record that we've seen this one
                    m_treeTypeNodes.Add(parentNode);
                    m_types.Add(tmpObj.GetType());
                }

                // add the new node for this element
                TreeNode tmpNode = new TreeNode(Treefort.Utilities.ObjToLabelStr(tmpObj));
                tmpNode.Tag = tmpObj;
                tmpNode.Checked = true;
                parentNode.Nodes.Add(tmpNode);
            }
        }

        /// <summary>
        /// If we've already seen this type before, return the existing TreeNode object
        /// </summary>
        /// <param name="objType">System.Type we're looking to find</param>
        /// <returns>The existing TreeNode or NULL</returns>
        protected TreeNode
        GetExistingNodeForType(System.Type objType)
        {
            int len = m_types.Count;
            for (int i = 0; i < len; i++)
            {
                if ((System.Type)m_types[i] == objType)
                    return (TreeNode)m_treeTypeNodes[i];
            }

            return null;
        }


        /// <summary>
        /// If we've already seen this type before, return the existing TreeNode object
        /// </summary>
        /// <param name="objCat">System.Type we're looking to find</param>
        /// <returns>The existing TreeNode or NULL</returns>
        protected TreeNode
        GetExistingNodeForCat(Category objCat)
        {
            int len = m_Cats.Count;
            for (int i = 0; i < len; i++)
            {
                if ((Category)m_Cats[i] == objCat)
                    return (TreeNode)m_treeCatNodes[i];
            }

            return null;
        }

        #region buttons

        private void treeView2_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (treeView2.SelectedNode.Nodes.Count == 0)
            {
                treeView2.SelectedNode.Checked = false;
            }
            else
            { 
                // TreeNodeCollection nodeOne = treeView2.SelectedNode.Nodes;
            }
        }

#endregion //buttons
    }
}
