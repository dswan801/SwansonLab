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


    public partial class SelectionUI : System.Windows.Forms.Form
    {
        public static IList<string> cat;
        public static bool cancel_form = false;


        protected
        SelectionUI()
        {
            InitializeComponent();
        }

        public
        SelectionUI(System.Object obj)
        {
            InitializeComponent();

            // get in array form so we can call normal processing code.
            ArrayList objs = new ArrayList();
            objs.Add(obj);
            CommonInit(objs);
        }

        public
        SelectionUI(ArrayList objs)
        {
            InitializeComponent();
            CommonInit(objs);
        }

        public
        SelectionUI(Document doc, ICollection<ElementId> ids)
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
            treeView1.BeginUpdate();

            AddObjectsToTree(objs);

            // if the tree isn't well populated, expand it and select the first item
            // so its not a pain for the user when there is only one relevant item in the tree
            if (treeView1.Nodes.Count == 1)
            {
                treeView1.Nodes[0].Expand();
                if (treeView1.Nodes[0].Nodes.Count == 0)
                    treeView1.SelectedNode = treeView1.Nodes[0];
                else
                    treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0];
            }

            treeView1.EndUpdate();
        }

        protected void
        AddObjectsToTree(IEnumerable objs)
        {
            treeView1.Sorted = true;

            // initialize the tree control
            foreach (Object tmpObj in objs)
            {
                // hook this up to the correct spot in the tree based on the object's type
                TreeNode parentNode = GetExistingNodeForType(tmpObj.GetType());
                if (parentNode == null)
                {
                    parentNode = new TreeNode(tmpObj.GetType().Name);
                    treeView1.Nodes.Add(parentNode);

                    // record that we've seen this one
                    m_treeTypeNodes.Add(parentNode);
                    m_types.Add(tmpObj.GetType());
                }

                // add the new node for this element
                TreeNode tmpNode = new TreeNode(Snoop.Utils.ObjToLabelStr(tmpObj));
                tmpNode.Tag = tmpObj;
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


        #region buttons

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            
        
        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
            cancel_form = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //checkallbutton
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //uncheckallbutton
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //extrabutton
        }

        private void filterbutton1_Click(object sender, EventArgs e)
        {
            //Filterbutton
        }

        private void searchbutton1_Click(object sender, EventArgs e)
        {
            //searchselection
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //selectionbutton
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //inviewbutton
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //projectbutton
        }
        #endregion

       
    }
}
