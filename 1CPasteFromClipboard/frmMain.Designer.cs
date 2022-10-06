namespace Pasta
{
	partial class frmMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.tlbMain = new System.Windows.Forms.ToolStrip();
			this.btnReadClipboard = new System.Windows.Forms.ToolStripButton();
			this.btnPasteTo1CTable = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.chkFirstColumnFromDictionary = new System.Windows.Forms.ToolStripButton();
			this.lvwData = new System.Windows.Forms.ListView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tlbMain.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlbMain
			// 
			this.tlbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReadClipboard,
            this.btnPasteTo1CTable,
            this.toolStripSeparator1,
            this.chkFirstColumnFromDictionary});
			this.tlbMain.Location = new System.Drawing.Point(0, 0);
			this.tlbMain.Name = "tlbMain";
			this.tlbMain.Size = new System.Drawing.Size(800, 39);
			this.tlbMain.TabIndex = 1;
			this.tlbMain.Text = "toolStrip1";
			// 
			// btnReadClipboard
			// 
			this.btnReadClipboard.Image = ((System.Drawing.Image)(resources.GetObject("btnReadClipboard.Image")));
			this.btnReadClipboard.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnReadClipboard.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnReadClipboard.Name = "btnReadClipboard";
			this.btnReadClipboard.Size = new System.Drawing.Size(102, 36);
			this.btnReadClipboard.Text = "Прочитать";
			this.btnReadClipboard.ToolTipText = "Прочитать табличные данные из буфера обмена.\r\n\r\nФотмат таблицы в буфете обмена та" +
    "кой же как у MS Excel, т.е. значения в строке разделены символом табуляции, стро" +
    "ки разделены переводом строки.";
			// 
			// btnPasteTo1CTable
			// 
			this.btnPasteTo1CTable.Image = ((System.Drawing.Image)(resources.GetObject("btnPasteTo1CTable.Image")));
			this.btnPasteTo1CTable.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnPasteTo1CTable.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPasteTo1CTable.Name = "btnPasteTo1CTable";
			this.btnPasteTo1CTable.Size = new System.Drawing.Size(117, 36);
			this.btnPasteTo1CTable.Text = "Вставить в 1С";
			this.btnPasteTo1CTable.ToolTipText = "Вставить табличные данные в активный табличный документ имитируя набот с клавиату" +
    "ры.\r\n\r\n!!! В 1С в активном табличном документе ФОКУС ВВОДА ДОЛЖЕН СТОЯТЬ НА ТАБЛ" +
    "ИЧНОЙ ЧАСТИ !!!";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
			// 
			// chkFirstColumnFromDictionary
			// 
			this.chkFirstColumnFromDictionary.Checked = true;
			this.chkFirstColumnFromDictionary.CheckOnClick = true;
			this.chkFirstColumnFromDictionary.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkFirstColumnFromDictionary.Name = "chkFirstColumnFromDictionary";
			this.chkFirstColumnFromDictionary.Size = new System.Drawing.Size(190, 36);
			this.chkFirstColumnFromDictionary.Text = "Первая колонка это справочник";
			this.chkFirstColumnFromDictionary.ToolTipText = resources.GetString("chkFirstColumnFromDictionary.ToolTipText");
			// 
			// lvwData
			// 
			this.lvwData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwData.HideSelection = false;
			this.lvwData.Location = new System.Drawing.Point(8, 8);
			this.lvwData.Name = "lvwData";
			this.lvwData.Size = new System.Drawing.Size(784, 395);
			this.lvwData.TabIndex = 2;
			this.lvwData.UseCompatibleStateImageBehavior = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lvwData);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 39);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(8);
			this.panel1.Size = new System.Drawing.Size(800, 411);
			this.panel1.TabIndex = 3;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.tlbMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMain";
			this.Text = "Pasta";
			this.tlbMain.ResumeLayout(false);
			this.tlbMain.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tlbMain;
		private System.Windows.Forms.ListView lvwData;
		private System.Windows.Forms.ToolStripButton btnReadClipboard;
		private System.Windows.Forms.ToolStripButton btnPasteTo1CTable;
		private System.Windows.Forms.ToolStripButton chkFirstColumnFromDictionary;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.Panel panel1;
	}
}

