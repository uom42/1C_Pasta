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
		private void InitializeComponent ()
		{
			components = new Container ();
			ComponentResourceManager resources = new ComponentResourceManager (typeof (frmMain));
			tlbMain = new ToolStrip ();
			btnReadClipboard = new ToolStripButton ();
			toolStripSeparator1 = new ToolStripSeparator ();
			chkSort = new ToolStripCheckBox ();
			chkGroupByfirstColumn = new ToolStripCheckBox ();
			toolStripSeparator2 = new ToolStripSeparator ();
			lbl1CProcessName = new ToolStripLabel ();
			cbo1CProcess = new ToolStripComboBox ();
			btnRefreshProcessList = new ToolStripButton ();
			chkFirstColumnFromDictionary = new ToolStripCheckBox ();
			btnPasteTo1CTable = new ToolStripButton ();
			panel1 = new Panel ();
			tcMain = new TabControl ();
			tp1CPaste = new TabPage ();
			tableLayoutPanel1 = new TableLayoutPanel ();
			pbPaste1C = new ProgressBar ();
			grdTable = new DataGridViewEx ();
			tpChecks = new TabPage ();
			pbCheck = new PictureBox ();
			statusStrip1 = new StatusStrip ();
			toolStripStatusLabel1 = new ToolStripStatusLabel ();
			labelClickHandler1 = new UrlClickHandler (components);
			cueBannerManager1 = new CueBannerManager (components);
			chkSkipEmptyColumns = new ToolStripCheckBox ();
			tlbMain.SuspendLayout ();
			panel1.SuspendLayout ();
			tcMain.SuspendLayout ();
			tp1CPaste.SuspendLayout ();
			tableLayoutPanel1.SuspendLayout ();
			( (ISupportInitialize) grdTable ).BeginInit ();
			tpChecks.SuspendLayout ();
			( (ISupportInitialize) pbCheck ).BeginInit ();
			statusStrip1.SuspendLayout ();
			( (ISupportInitialize) labelClickHandler1 ).BeginInit ();
			( (ISupportInitialize) cueBannerManager1 ).BeginInit ();
			SuspendLayout ();
			// 
			// tlbMain
			// 
			tlbMain.ImageScalingSize = new Size (24, 24);
			tlbMain.Items.AddRange (new ToolStripItem[] { btnReadClipboard, toolStripSeparator1, chkSort, chkGroupByfirstColumn, toolStripSeparator2, lbl1CProcessName, cbo1CProcess, btnRefreshProcessList, chkFirstColumnFromDictionary, chkSkipEmptyColumns, btnPasteTo1CTable });
			tlbMain.Location = new Point (3, 3);
			tlbMain.Name = "tlbMain";
			tlbMain.Padding = new Padding (0, 0, 3, 0);
			tlbMain.Size = new Size (1889, 41);
			tlbMain.TabIndex = 1;
			tlbMain.Text = "toolStrip1";
			// 
			// btnReadClipboard
			// 
			btnReadClipboard.Image = Properties.Resources.Read_Clipboard_32;
			btnReadClipboard.ImageScaling = ToolStripItemImageScaling.None;
			btnReadClipboard.ImageTransparentColor = Color.Magenta;
			btnReadClipboard.Name = "btnReadClipboard";
			btnReadClipboard.Size = new Size (135, 36);
			btnReadClipboard.Text = "Прочитать";
			btnReadClipboard.ToolTipText = "Прочитать табличные данные из буфера обмена.\r\n\r\nФотмат таблицы в буфете обмена такой же как у MS Excel, т.е. значения в строке разделены символом табуляции, строки разделены переводом строки.";
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size (6, 41);
			// 
			// chkSort
			// 
			chkSort.ImageTransparentColor = Color.Magenta;
			chkSort.Name = "chkSort";
			chkSort.Size = new Size (81, 36);
			chkSort.Text = "Sort";
			// 
			// chkGroupByfirstColumn
			// 
			chkGroupByfirstColumn.Checked = true;
			chkGroupByfirstColumn.CheckState = CheckState.Checked;
			chkGroupByfirstColumn.ImageTransparentColor = Color.Magenta;
			chkGroupByfirstColumn.Name = "chkGroupByfirstColumn";
			chkGroupByfirstColumn.Size = new Size (212, 36);
			chkGroupByfirstColumn.Text = "GroupByFirstColumn";
			chkGroupByfirstColumn.ToolTipText = "Group By First Column";
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size (6, 41);
			// 
			// lbl1CProcessName
			// 
			lbl1CProcessName.Name = "lbl1CProcessName";
			lbl1CProcessName.Size = new Size (113, 36);
			lbl1CProcessName.Text = "Процесс 1С:";
			// 
			// cbo1CProcess
			// 
			cbo1CProcess.AutoSize = false;
			cbo1CProcess.DropDownStyle = ComboBoxStyle.DropDownList;
			cbo1CProcess.MaxDropDownItems = 20;
			cbo1CProcess.Name = "cbo1CProcess";
			cbo1CProcess.Size = new Size (333, 33);
			// 
			// btnRefreshProcessList
			// 
			btnRefreshProcessList.DisplayStyle = ToolStripItemDisplayStyle.Image;
			btnRefreshProcessList.Image = Properties.Resources.Refresh_32;
			btnRefreshProcessList.Name = "btnRefreshProcessList";
			btnRefreshProcessList.Size = new Size (34, 36);
			btnRefreshProcessList.Text = "Обновить список процессов";
			// 
			// chkFirstColumnFromDictionary
			// 
			chkFirstColumnFromDictionary.Checked = true;
			chkFirstColumnFromDictionary.CheckState = CheckState.Checked;
			chkFirstColumnFromDictionary.Name = "chkFirstColumnFromDictionary";
			chkFirstColumnFromDictionary.Size = new Size (316, 36);
			chkFirstColumnFromDictionary.Text = "Первая колонка это справочник";
			// 
			// btnPasteTo1CTable
			// 
			btnPasteTo1CTable.Image = Properties.Resources.PasteTable_32_2;
			btnPasteTo1CTable.ImageScaling = ToolStripItemImageScaling.None;
			btnPasteTo1CTable.ImageTransparentColor = Color.Magenta;
			btnPasteTo1CTable.Name = "btnPasteTo1CTable";
			btnPasteTo1CTable.Size = new Size (159, 36);
			btnPasteTo1CTable.Text = "Вставить в 1С";
			btnPasteTo1CTable.ToolTipText = "Вставить табличные данные в активный табличный документ имитируя набот с клавиатуры.\r\n\r\n!!! В 1С в активном табличном документе ФОКУС ВВОДА ДОЛЖЕН СТОЯТЬ НА ТАБЛИЧНОЙ ЧАСТИ !!!";
			// 
			// panel1
			// 
			panel1.Controls.Add (tcMain);
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point (0, 0);
			panel1.Margin = new Padding (4, 6, 4, 6);
			panel1.Name = "panel1";
			panel1.Padding = new Padding (8);
			panel1.Size = new Size (1919, 1036);
			panel1.TabIndex = 3;
			// 
			// tcMain
			// 
			tcMain.Controls.Add (tp1CPaste);
			tcMain.Controls.Add (tpChecks);
			tcMain.Dock = DockStyle.Fill;
			tcMain.Location = new Point (8, 8);
			tcMain.Name = "tcMain";
			tcMain.SelectedIndex = 0;
			tcMain.Size = new Size (1903, 1020);
			tcMain.TabIndex = 3;
			// 
			// tp1CPaste
			// 
			tp1CPaste.Controls.Add (tableLayoutPanel1);
			tp1CPaste.Controls.Add (tlbMain);
			tp1CPaste.Location = new Point (4, 34);
			tp1CPaste.Name = "tp1CPaste";
			tp1CPaste.Padding = new Padding (3);
			tp1CPaste.Size = new Size (1895, 982);
			tp1CPaste.TabIndex = 0;
			tp1CPaste.Text = "Вставка в 1С";
			tp1CPaste.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add (new ColumnStyle (SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add (pbPaste1C, 0, 2);
			tableLayoutPanel1.Controls.Add (grdTable, 0, 0);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point (3, 44);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add (new RowStyle (SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add (new RowStyle (SizeType.Absolute, 8F));
			tableLayoutPanel1.RowStyles.Add (new RowStyle ());
			tableLayoutPanel1.Size = new Size (1889, 935);
			tableLayoutPanel1.TabIndex = 3;
			// 
			// pbPaste1C
			// 
			pbPaste1C.Dock = DockStyle.Top;
			pbPaste1C.Location = new Point (3, 898);
			pbPaste1C.Name = "pbPaste1C";
			pbPaste1C.Size = new Size (1883, 34);
			pbPaste1C.TabIndex = 3;
			// 
			// grdTable
			// 
			grdTable.AllowUserToOrderColumns = true;
			grdTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			grdTable.Dock = DockStyle.Fill;
			grdTable.Location = new Point (3, 3);
			grdTable.Name = "grdTable";
			grdTable.RowHeadersWidth = 62;
			grdTable.Size = new Size (1883, 881);
			grdTable.TabIndex = 4;
			// 
			// tpChecks
			// 
			tpChecks.Controls.Add (pbCheck);
			tpChecks.Location = new Point (4, 34);
			tpChecks.Name = "tpChecks";
			tpChecks.Padding = new Padding (16);
			tpChecks.Size = new Size (1895, 982);
			tpChecks.TabIndex = 1;
			tpChecks.Text = "Чеки";
			tpChecks.UseVisualStyleBackColor = true;
			// 
			// pbCheck
			// 
			pbCheck.Dock = DockStyle.Fill;
			pbCheck.Location = new Point (16, 16);
			pbCheck.Name = "pbCheck";
			pbCheck.Size = new Size (1863, 950);
			pbCheck.TabIndex = 0;
			pbCheck.TabStop = false;
			// 
			// statusStrip1
			// 
			statusStrip1.ImageScalingSize = new Size (24, 24);
			statusStrip1.Items.AddRange (new ToolStripItem[] { toolStripStatusLabel1 });
			statusStrip1.Location = new Point (0, 1036);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Padding = new Padding (1, 0, 16, 0);
			statusStrip1.Size = new Size (1919, 32);
			statusStrip1.TabIndex = 4;
			statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			labelClickHandler1.SetClickAction (toolStripStatusLabel1, UrlClickHandler.ClickActionModes.OpenUrlInBrowser);
			labelClickHandler1.SetClickActionUrl (toolStripStatusLabel1, "www.flaticon.com");
			toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			toolStripStatusLabel1.Size = new Size (350, 25);
			toolStripStatusLabel1.Text = "Toolbar icons created by www.flaticon.com";
			// 
			// chkSkipEmptyColumns
			// 
			chkSkipEmptyColumns.DisplayStyle = ToolStripItemDisplayStyle.Image;
			chkSkipEmptyColumns.Image = (Image) resources.GetObject ("chkSkipEmptyColumns.Image");
			chkSkipEmptyColumns.ImageTransparentColor = Color.Magenta;
			chkSkipEmptyColumns.Name = "chkSkipEmptyColumns";
			chkSkipEmptyColumns.Size = new Size (34, 36);
			chkSkipEmptyColumns.Text = "toolStripButton1";
			// 
			// frmMain
			// 
			AutoScaleDimensions = new SizeF (10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size (1919, 1068);
			Controls.Add (panel1);
			Controls.Add (statusStrip1);
			Margin = new Padding (4, 6, 4, 6);
			Name = "frmMain";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Pasta";
			tlbMain.ResumeLayout (false);
			tlbMain.PerformLayout ();
			panel1.ResumeLayout (false);
			tcMain.ResumeLayout (false);
			tp1CPaste.ResumeLayout (false);
			tp1CPaste.PerformLayout ();
			tableLayoutPanel1.ResumeLayout (false);
			( (ISupportInitialize) grdTable ).EndInit ();
			tpChecks.ResumeLayout (false);
			( (ISupportInitialize) pbCheck ).EndInit ();
			statusStrip1.ResumeLayout (false);
			statusStrip1.PerformLayout ();
			( (ISupportInitialize) labelClickHandler1 ).EndInit ();
			( (ISupportInitialize) cueBannerManager1 ).EndInit ();
			ResumeLayout (false);
			PerformLayout ();
		}

		#endregion

		internal System.Windows.Forms.ToolStrip tlbMain;
		internal System.Windows.Forms.ToolStripButton btnReadClipboard;
		internal System.Windows.Forms.ToolStripButton btnPasteTo1CTable;
		internal ToolStripCheckBox chkFirstColumnFromDictionary;
		internal System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		internal System.Windows.Forms.Panel panel1;
		internal ToolStripSeparator toolStripSeparator2;
		internal ToolStripLabel lbl1CProcessName;
		internal ToolStripComboBox cbo1CProcess;
		internal ToolStripButton btnRefreshProcessList;
		internal StatusStrip statusStrip1;
		internal ToolStripStatusLabel toolStripStatusLabel1;
		internal UrlClickHandler labelClickHandler1;
		internal CueBannerManager cueBannerManager1;
		internal TabControl tcMain;
		internal TabPage tp1CPaste;
		internal TabPage tpChecks;
		internal TableLayoutPanel tableLayoutPanel1;
		internal ProgressBar pbPaste1C;
		internal PictureBox pbCheck;
		internal DataGridViewEx grdTable;
		internal ToolStripCheckBox chkGroupByfirstColumn;
		internal ToolStripCheckBox chkSort;
		internal ToolStripCheckBox chkSkipEmptyColumns;
	}
}

