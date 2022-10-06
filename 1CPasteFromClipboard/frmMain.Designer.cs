using System.Windows.Forms;

using uom.controls.Extenders;

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
			this.components = new System.ComponentModel.Container();
			this.tlbMain = new System.Windows.Forms.ToolStrip();
			this.btnReadClipboard = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.chkFirstColumnFromDictionary = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.lbl1CProcessName = new System.Windows.Forms.ToolStripLabel();
			this.cbo1CProcess = new System.Windows.Forms.ToolStripComboBox();
			this.btnRefreshProcessList = new System.Windows.Forms.ToolStripButton();
			this.btnPasteTo1CTable = new System.Windows.Forms.ToolStripButton();
			this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
			this.lvwData = new System.Windows.Forms.ListView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.labelClickHandler1 = new uom.controls.Extenders.UrlClickHandler(this.components);
			this.cueBannerManager1 = new uom.controls.Extenders.CueBannerManager(this.components);
			this.tlbMain.SuspendLayout();
			this.panel1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.labelClickHandler1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cueBannerManager1)).BeginInit();
			this.SuspendLayout();
			// 
			// tlbMain
			// 
			this.tlbMain.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.tlbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReadClipboard,
            this.toolStripSeparator1,
            this.chkFirstColumnFromDictionary,
            this.toolStripSeparator2,
            this.lbl1CProcessName,
            this.cbo1CProcess,
            this.btnRefreshProcessList,
            this.btnPasteTo1CTable,
            this.toolStripTextBox1});
			this.tlbMain.Location = new System.Drawing.Point(0, 0);
			this.tlbMain.Name = "tlbMain";
			this.tlbMain.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
			this.tlbMain.Size = new System.Drawing.Size(1357, 41);
			this.tlbMain.TabIndex = 1;
			this.tlbMain.Text = "toolStrip1";
			// 
			// btnReadClipboard
			// 
			this.btnReadClipboard.Image = global::Pasta.Properties.Resources.Read_Clipboard_32;
			this.btnReadClipboard.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnReadClipboard.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnReadClipboard.Name = "btnReadClipboard";
			this.btnReadClipboard.Size = new System.Drawing.Size(135, 36);
			this.btnReadClipboard.Text = "Прочитать";
			this.btnReadClipboard.ToolTipText = "Прочитать табличные данные из буфера обмена.\r\n\r\nФотмат таблицы в буфете обмена та" +
    "кой же как у MS Excel, т.е. значения в строке разделены символом табуляции, стро" +
    "ки разделены переводом строки.";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 41);
			// 
			// chkFirstColumnFromDictionary
			// 
			this.chkFirstColumnFromDictionary.Checked = true;
			this.chkFirstColumnFromDictionary.CheckOnClick = true;
			this.chkFirstColumnFromDictionary.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkFirstColumnFromDictionary.Name = "chkFirstColumnFromDictionary";
			this.chkFirstColumnFromDictionary.Size = new System.Drawing.Size(284, 36);
			this.chkFirstColumnFromDictionary.Text = "Первая колонка это справочник";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 41);
			// 
			// lbl1CProcessName
			// 
			this.lbl1CProcessName.Name = "lbl1CProcessName";
			this.lbl1CProcessName.Size = new System.Drawing.Size(113, 36);
			this.lbl1CProcessName.Text = "Процесс 1С:";
			// 
			// cbo1CProcess
			// 
			this.cbo1CProcess.AutoSize = false;
			this.cbo1CProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo1CProcess.MaxDropDownItems = 20;
			this.cbo1CProcess.Name = "cbo1CProcess";
			this.cbo1CProcess.Size = new System.Drawing.Size(300, 33);
			// 
			// btnRefreshProcessList
			// 
			this.btnRefreshProcessList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnRefreshProcessList.Image = global::Pasta.Properties.Resources.Refresh_32;
			this.btnRefreshProcessList.Name = "btnRefreshProcessList";
			this.btnRefreshProcessList.Size = new System.Drawing.Size(34, 36);
			this.btnRefreshProcessList.Text = "Обновить список процессов";
			// 
			// btnPasteTo1CTable
			// 
			this.btnPasteTo1CTable.Image = global::Pasta.Properties.Resources.PasteTable_32_2;
			this.btnPasteTo1CTable.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.btnPasteTo1CTable.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPasteTo1CTable.Name = "btnPasteTo1CTable";
			this.btnPasteTo1CTable.Size = new System.Drawing.Size(159, 36);
			this.btnPasteTo1CTable.Text = "Вставить в 1С";
			this.btnPasteTo1CTable.ToolTipText = "Вставить табличные данные в активный табличный документ имитируя набот с клавиату" +
    "ры.\r\n\r\n!!! В 1С в активном табличном документе ФОКУС ВВОДА ДОЛЖЕН СТОЯТЬ НА ТАБЛ" +
    "ИЧНОЙ ЧАСТИ !!!";
			// 
			// toolStripTextBox1
			// 
			this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.toolStripTextBox1.Name = "toolStripTextBox1";
			this.toolStripTextBox1.Size = new System.Drawing.Size(100, 41);
			// 
			// lvwData
			// 
			this.lvwData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwData.HideSelection = false;
			this.lvwData.Location = new System.Drawing.Point(12, 12);
			this.lvwData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.lvwData.Name = "lvwData";
			this.lvwData.Size = new System.Drawing.Size(1333, 571);
			this.lvwData.TabIndex = 2;
			this.lvwData.UseCompatibleStateImageBehavior = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lvwData);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 41);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(12);
			this.panel1.Size = new System.Drawing.Size(1357, 595);
			this.panel1.TabIndex = 3;
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 636);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1357, 32);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.labelClickHandler1.SetClickAction(this.toolStripStatusLabel1, uom.controls.Extenders.UrlClickHandler.ClickActionModes.OpenUrlInBrowser);
			this.labelClickHandler1.SetClickActionUrl(this.toolStripStatusLabel1, "www.flaticon.com");
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(350, 25);
			this.toolStripStatusLabel1.Text = "Toolbar icons created by www.flaticon.com";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1357, 668);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.tlbMain);
			this.Controls.Add(this.statusStrip1);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pasta";
			this.tlbMain.ResumeLayout(false);
			this.tlbMain.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.labelClickHandler1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cueBannerManager1)).EndInit();
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
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripLabel lbl1CProcessName;
		private ToolStripComboBox cbo1CProcess;
		private ToolStripButton btnRefreshProcessList;
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel toolStripStatusLabel1;
		private UrlClickHandler labelClickHandler1;
		private CueBannerManager cueBannerManager1;
		private ToolStripTextBox toolStripTextBox1;
	}
}

