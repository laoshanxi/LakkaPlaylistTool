namespace LakkaPlaylistTool
{
    partial class FrmLakka
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbxCrc32 = new System.Windows.Forms.CheckBox();
            this.btnLoadRomDir = new System.Windows.Forms.Button();
            this.btnRetroImageDir = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.cbxCopyRoms = new System.Windows.Forms.CheckBox();
            this.cbxUseFbaCnName = new System.Windows.Forms.CheckBox();
            this.cbxUseFcCnName = new System.Windows.Forms.CheckBox();
            this.cbxUseMdCnName = new System.Windows.Forms.CheckBox();
            this.cbxUseSfcCnName = new System.Windows.Forms.CheckBox();
            this.cbxUsePceCnName = new System.Windows.Forms.CheckBox();
            this.btnLoadLakkaList = new System.Windows.Forms.Button();
            this.txtLakkaRom = new System.Windows.Forms.TextBox();
            this.txtRetroImage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLakkaList = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxCrc32
            // 
            this.cbxCrc32.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxCrc32.AutoSize = true;
            this.cbxCrc32.Location = new System.Drawing.Point(295, 376);
            this.cbxCrc32.Name = "cbxCrc32";
            this.cbxCrc32.Size = new System.Drawing.Size(99, 19);
            this.cbxCrc32.TabIndex = 12;
            this.cbxCrc32.Text = "读取CRC32";
            this.toolTip1.SetToolTip(this.cbxCrc32, "生成CRC32会耗费比较长的时间");
            this.cbxCrc32.UseVisualStyleBackColor = true;
            // 
            // btnLoadRomDir
            // 
            this.btnLoadRomDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadRomDir.Location = new System.Drawing.Point(5, 159);
            this.btnLoadRomDir.Name = "btnLoadRomDir";
            this.btnLoadRomDir.Size = new System.Drawing.Size(282, 69);
            this.btnLoadRomDir.TabIndex = 2;
            this.btnLoadRomDir.Text = "3. 选择游戏ROM目录";
            this.btnLoadRomDir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnLoadRomDir, "将根据此目录下的rom生成的Lakka游戏列表（比如：\\\\LAKKA\\ROMs\\fba）");
            this.btnLoadRomDir.UseVisualStyleBackColor = true;
            this.btnLoadRomDir.Click += new System.EventHandler(this.btnLoadRomDir_Click);
            // 
            // btnRetroImageDir
            // 
            this.btnRetroImageDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRetroImageDir.Location = new System.Drawing.Point(5, 82);
            this.btnRetroImageDir.Name = "btnRetroImageDir";
            this.btnRetroImageDir.Size = new System.Drawing.Size(282, 69);
            this.btnRetroImageDir.TabIndex = 10;
            this.btnRetroImageDir.Text = "2. 选择图片目录";
            this.btnRetroImageDir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnRetroImageDir, "选择了图片目录, 在生成列表的同时会生成一个Lakka格式的图片目录");
            this.btnRetroImageDir.UseVisualStyleBackColor = true;
            this.btnRetroImageDir.Click += new System.EventHandler(this.btnRetroImageDir_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.Location = new System.Drawing.Point(5, 236);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(282, 107);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "4. 编辑Lakka列表";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnEdit, "如果选择了Retro图片目录，那么生成列表的同时会在相同目录下生成图片目录");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // cbxCopyRoms
            // 
            this.cbxCopyRoms.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxCopyRoms.AutoSize = true;
            this.cbxCopyRoms.Location = new System.Drawing.Point(579, 376);
            this.cbxCopyRoms.Name = "cbxCopyRoms";
            this.cbxCopyRoms.Size = new System.Drawing.Size(109, 19);
            this.cbxCopyRoms.TabIndex = 13;
            this.cbxCopyRoms.Text = "重新拷贝ROM";
            this.toolTip1.SetToolTip(this.cbxCopyRoms, "重新拷贝整理后的ROM,如果对ROM有删减，可以重新拷贝一个干净的ROM目录");
            this.cbxCopyRoms.UseVisualStyleBackColor = true;
            // 
            // cbxUseFbaCnName
            // 
            this.cbxUseFbaCnName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxUseFbaCnName.AutoSize = true;
            this.cbxUseFbaCnName.Location = new System.Drawing.Point(3, 3);
            this.cbxUseFbaCnName.Name = "cbxUseFbaCnName";
            this.cbxUseFbaCnName.Size = new System.Drawing.Size(128, 19);
            this.cbxUseFbaCnName.TabIndex = 19;
            this.cbxUseFbaCnName.Text = "使用FBA中文名";
            this.toolTip1.SetToolTip(this.cbxUseFbaCnName, "使用FBA数据库中的中文名称作为ROM名称");
            this.cbxUseFbaCnName.UseVisualStyleBackColor = true;
            // 
            // cbxUseFcCnName
            // 
            this.cbxUseFcCnName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxUseFcCnName.AutoSize = true;
            this.cbxUseFcCnName.Location = new System.Drawing.Point(137, 3);
            this.cbxUseFcCnName.Name = "cbxUseFcCnName";
            this.cbxUseFcCnName.Size = new System.Drawing.Size(120, 19);
            this.cbxUseFcCnName.TabIndex = 21;
            this.cbxUseFcCnName.Text = "使用FC中文名";
            this.toolTip1.SetToolTip(this.cbxUseFcCnName, "使用FC数据库中的中文名称作为ROM名称");
            this.cbxUseFcCnName.UseVisualStyleBackColor = true;
            // 
            // cbxUseMdCnName
            // 
            this.cbxUseMdCnName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxUseMdCnName.AutoSize = true;
            this.cbxUseMdCnName.Location = new System.Drawing.Point(3, 28);
            this.cbxUseMdCnName.Name = "cbxUseMdCnName";
            this.cbxUseMdCnName.Size = new System.Drawing.Size(120, 19);
            this.cbxUseMdCnName.TabIndex = 22;
            this.cbxUseMdCnName.Text = "使用MD中文名";
            this.toolTip1.SetToolTip(this.cbxUseMdCnName, "使用MD数据库中的中文名称作为ROM名称");
            this.cbxUseMdCnName.UseVisualStyleBackColor = true;
            // 
            // cbxUseSfcCnName
            // 
            this.cbxUseSfcCnName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxUseSfcCnName.AutoSize = true;
            this.cbxUseSfcCnName.Location = new System.Drawing.Point(129, 28);
            this.cbxUseSfcCnName.Name = "cbxUseSfcCnName";
            this.cbxUseSfcCnName.Size = new System.Drawing.Size(128, 19);
            this.cbxUseSfcCnName.TabIndex = 23;
            this.cbxUseSfcCnName.Text = "使用SFC中文名";
            this.toolTip1.SetToolTip(this.cbxUseSfcCnName, "使用SFC数据库中的中文名称作为ROM名称");
            this.cbxUseSfcCnName.UseVisualStyleBackColor = true;
            // 
            // cbxUsePceCnName
            // 
            this.cbxUsePceCnName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxUsePceCnName.AutoSize = true;
            this.cbxUsePceCnName.Location = new System.Drawing.Point(3, 53);
            this.cbxUsePceCnName.Name = "cbxUsePceCnName";
            this.cbxUsePceCnName.Size = new System.Drawing.Size(128, 19);
            this.cbxUsePceCnName.TabIndex = 24;
            this.cbxUsePceCnName.Text = "使用PCE中文名";
            this.toolTip1.SetToolTip(this.cbxUsePceCnName, "使用PCE数据库中的中文名称作为ROM名称");
            this.cbxUsePceCnName.UseVisualStyleBackColor = true;
            // 
            // btnLoadLakkaList
            // 
            this.btnLoadLakkaList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadLakkaList.Location = new System.Drawing.Point(5, 5);
            this.btnLoadLakkaList.Name = "btnLoadLakkaList";
            this.btnLoadLakkaList.Size = new System.Drawing.Size(282, 69);
            this.btnLoadLakkaList.TabIndex = 0;
            this.btnLoadLakkaList.Text = "1. 加载Lakka列表文件(lpl文件)";
            this.btnLoadLakkaList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadLakkaList.UseVisualStyleBackColor = true;
            this.btnLoadLakkaList.Click += new System.EventHandler(this.btnLoadLakkaList_Click);
            // 
            // txtLakkaRom
            // 
            this.txtLakkaRom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLakkaRom.Location = new System.Drawing.Point(295, 159);
            this.txtLakkaRom.Multiline = true;
            this.txtLakkaRom.Name = "txtLakkaRom";
            this.txtLakkaRom.ReadOnly = true;
            this.txtLakkaRom.Size = new System.Drawing.Size(276, 69);
            this.txtLakkaRom.TabIndex = 3;
            // 
            // txtRetroImage
            // 
            this.txtRetroImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRetroImage.Location = new System.Drawing.Point(295, 82);
            this.txtRetroImage.Multiline = true;
            this.txtRetroImage.Name = "txtRetroImage";
            this.txtRetroImage.ReadOnly = true;
            this.txtRetroImage.Size = new System.Drawing.Size(276, 69);
            this.txtRetroImage.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Location = new System.Drawing.Point(5, 425);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "编辑Lakka游戏列表和图片";
            // 
            // txtLakkaList
            // 
            this.txtLakkaList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLakkaList.Location = new System.Drawing.Point(295, 5);
            this.txtLakkaList.Multiline = true;
            this.txtLakkaList.Name = "txtLakkaList";
            this.txtLakkaList.ReadOnly = true;
            this.txtLakkaList.Size = new System.Drawing.Size(276, 69);
            this.txtLakkaList.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.46041F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.53959F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel1.Controls.Add(this.cbxCrc32, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtLakkaList, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLoadLakkaList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEdit, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtRetroImage, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtLakkaRom, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnRetroImageDir, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnLoadRomDir, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxCopyRoms, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(693, 450);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(579, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "*必选";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(579, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "*必选";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(579, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "可选";
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(5, 351);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(282, 69);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "5. 保存";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(579, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "可选";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cbxUseFbaCnName);
            this.flowLayoutPanel1.Controls.Add(this.cbxUseFcCnName);
            this.flowLayoutPanel1.Controls.Add(this.cbxUseMdCnName);
            this.flowLayoutPanel1.Controls.Add(this.cbxUseSfcCnName);
            this.flowLayoutPanel1.Controls.Add(this.cbxUsePceCnName);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(295, 236);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(276, 107);
            this.flowLayoutPanel1.TabIndex = 20;
            // 
            // FrmLakka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmLakka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lakka游戏列表维护";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox cbxCrc32;
        private System.Windows.Forms.Button btnLoadRomDir;
        private System.Windows.Forms.Button btnRetroImageDir;
        private System.Windows.Forms.TextBox txtLakkaRom;
        private System.Windows.Forms.TextBox txtRetroImage;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnLoadLakkaList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLakkaList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cbxCopyRoms;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbxUseFbaCnName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox cbxUseFcCnName;
        private System.Windows.Forms.CheckBox cbxUseMdCnName;
        private System.Windows.Forms.CheckBox cbxUseSfcCnName;
        private System.Windows.Forms.CheckBox cbxUsePceCnName;
    }
}

