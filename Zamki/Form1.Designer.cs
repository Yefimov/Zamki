namespace Zamki
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnTable = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.picNextPage = new System.Windows.Forms.PictureBox();
            this.btnArrowLeft = new System.Windows.Forms.Button();
            this.btnArrowRight = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picNextPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnNew.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNew.Location = new System.Drawing.Point(623, 184);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(124, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "К следующему замку";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Location = new System.Drawing.Point(623, 28);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGame.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNewGame.Image = global::Zamki.Properties.Resources.btnNewGame;
            this.btnNewGame.Location = new System.Drawing.Point(160, 231);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(465, 41);
            this.btnNewGame.TabIndex = 5;
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnTable
            // 
            this.btnTable.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTable.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTable.Image = global::Zamki.Properties.Resources.btnTable;
            this.btnTable.Location = new System.Drawing.Point(160, 381);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(465, 41);
            this.btnTable.TabIndex = 7;
            this.btnTable.UseVisualStyleBackColor = false;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnAbout.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAbout.Image = global::Zamki.Properties.Resources.btnAbout;
            this.btnAbout.Location = new System.Drawing.Point(160, 459);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(465, 41);
            this.btnAbout.TabIndex = 8;
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // picNextPage
            // 
            this.picNextPage.Location = new System.Drawing.Point(589, 431);
            this.picNextPage.Name = "picNextPage";
            this.picNextPage.Size = new System.Drawing.Size(175, 84);
            this.picNextPage.TabIndex = 11;
            this.picNextPage.TabStop = false;
            this.picNextPage.Click += new System.EventHandler(this.picNextPage_Click);
            // 
            // btnArrowLeft
            // 
            this.btnArrowLeft.BackColor = System.Drawing.Color.Black;
            this.btnArrowLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArrowLeft.ForeColor = System.Drawing.Color.Black;
            this.btnArrowLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnArrowLeft.Image")));
            this.btnArrowLeft.Location = new System.Drawing.Point(201, 228);
            this.btnArrowLeft.Name = "btnArrowLeft";
            this.btnArrowLeft.Size = new System.Drawing.Size(30, 43);
            this.btnArrowLeft.TabIndex = 12;
            this.btnArrowLeft.UseVisualStyleBackColor = false;
            this.btnArrowLeft.Visible = false;
            this.btnArrowLeft.Click += new System.EventHandler(this.btnArrowLeft_Click);
            // 
            // btnArrowRight
            // 
            this.btnArrowRight.BackColor = System.Drawing.Color.Black;
            this.btnArrowRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArrowRight.ForeColor = System.Drawing.Color.Black;
            this.btnArrowRight.Image = ((System.Drawing.Image)(resources.GetObject("btnArrowRight.Image")));
            this.btnArrowRight.Location = new System.Drawing.Point(240, 228);
            this.btnArrowRight.Name = "btnArrowRight";
            this.btnArrowRight.Size = new System.Drawing.Size(30, 43);
            this.btnArrowRight.TabIndex = 13;
            this.btnArrowRight.UseVisualStyleBackColor = false;
            this.btnArrowRight.Visible = false;
            this.btnArrowRight.Click += new System.EventHandler(this.btnArrowRight_Click);
            // 
            // tbName
            // 
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbName.Location = new System.Drawing.Point(156, 121);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 20);
            this.tbName.TabIndex = 14;
            this.tbName.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(183, 172);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(457, 300);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.Visible = false;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLoad.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLoad.Location = new System.Drawing.Point(623, 57);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(124, 23);
            this.btnLoad.TabIndex = 19;
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Visible = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDownload.Image = global::Zamki.Properties.Resources.btnDownload;
            this.btnDownload.Location = new System.Drawing.Point(160, 311);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(465, 41);
            this.btnDownload.TabIndex = 20;
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::Zamki.Properties.Resources.mainMenu;
            this.ClientSize = new System.Drawing.Size(759, 512);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnArrowRight);
            this.Controls.Add(this.btnArrowLeft);
            this.Controls.Add(this.picNextPage);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnTable);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dataGridView1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Замки";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picNextPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.PictureBox picNextPage;
        private System.Windows.Forms.Button btnArrowLeft;
        private System.Windows.Forms.Button btnArrowRight;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnDownload;
    }
}

