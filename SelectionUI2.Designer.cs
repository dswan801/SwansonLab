using System.Collections;

namespace swanson.FilterLab
{
    partial class SelectionUI2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("All");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionUI2));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.checkedButton1 = new System.Windows.Forms.ToolStripButton();
            this.uncheckButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.filterbutton1 = new System.Windows.Forms.Button();
            this.cancelbutton1 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkedButton1,
            this.uncheckButton1,
            this.toolStripTextBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(520, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // checkedButton1
            // 
            this.checkedButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.checkedButton1.Image = global::swanson.FilterLab.Properties.Resources.check_button;
            this.checkedButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkedButton1.Name = "checkedButton1";
            this.checkedButton1.Size = new System.Drawing.Size(23, 22);
            this.checkedButton1.Text = "Check All Elements";
            this.checkedButton1.ToolTipText = "Check All Elements";
            // 
            // uncheckButton1
            // 
            this.uncheckButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uncheckButton1.Image = global::swanson.FilterLab.Properties.Resources.uncheck_button;
            this.uncheckButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uncheckButton1.Name = "uncheckButton1";
            this.uncheckButton1.Size = new System.Drawing.Size(23, 22);
            this.uncheckButton1.Text = "Uncheck All Elements";
            this.uncheckButton1.ToolTipText = "Uncheck All Elements";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(200, 25);
            this.toolStripTextBox1.Text = "Search";
            this.toolStripTextBox1.ToolTipText = "Search";
            // 
            // treeView2
            // 
            this.treeView2.CheckBoxes = true;
            this.treeView2.FullRowSelect = true;
            this.treeView2.Location = new System.Drawing.Point(13, 41);
            this.treeView2.Name = "treeView2";            
            this.treeView2.Size = new System.Drawing.Size(376, 364);
            this.treeView2.TabIndex = 1;
            this.treeView2.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterCheck);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(396, 41);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(113, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Selected Elements";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(396, 65);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(60, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "In View";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(396, 89);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(70, 17);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "In Project";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // filterbutton1
            // 
            this.filterbutton1.Location = new System.Drawing.Point(396, 381);
            this.filterbutton1.Name = "filterbutton1";
            this.filterbutton1.Size = new System.Drawing.Size(113, 23);
            this.filterbutton1.TabIndex = 5;
            this.filterbutton1.Text = "Filter";
            this.filterbutton1.UseVisualStyleBackColor = true;
            // 
            // cancelbutton1
            // 
            this.cancelbutton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelbutton1.Location = new System.Drawing.Point(396, 352);
            this.cancelbutton1.Name = "cancelbutton1";
            this.cancelbutton1.Size = new System.Drawing.Size(113, 23);
            this.cancelbutton1.TabIndex = 6;
            this.cancelbutton1.Text = "Cancel";
            this.cancelbutton1.UseVisualStyleBackColor = true;
            // 
            // SelectionUI2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.cancelbutton1;
            this.ClientSize = new System.Drawing.Size(520, 417);
            this.Controls.Add(this.cancelbutton1);
            this.Controls.Add(this.filterbutton1);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.toolStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectionUI2";
            this.Text = "Selection Filter";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton checkedButton1;
        private System.Windows.Forms.ToolStripButton uncheckButton1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button filterbutton1;
        private System.Windows.Forms.Button cancelbutton1;
        protected ArrayList m_treeTypeNodes = new ArrayList();
        protected ArrayList m_types = new ArrayList();
        protected ArrayList m_treeCatNodes = new ArrayList();
        protected ArrayList m_Cats = new ArrayList();
    }
}