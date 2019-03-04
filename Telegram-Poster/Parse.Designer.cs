namespace Telegram_Poster
{
    partial class Parse
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Parse));
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.infoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.parsedInfoDataSet = new Telegram_Poster.ParsedInfoDataSet();
            this.infoTableAdapter = new Telegram_Poster.ParsedInfoDataSetTableAdapters.InfoTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.demandsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parsedInfoDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.ButtonText = "Начать";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton1.Iconimage")));
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 90D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(793, 442);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(119, 46);
            this.bunifuFlatButton1.TabIndex = 0;
            this.bunifuFlatButton1.Text = "Начать";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton1.Visible = false;
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.demandsDataGridViewTextBoxColumn,
            this.imageDataGridViewTextBoxColumn,
            this.urlDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.infoBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(967, 503);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // infoBindingSource
            // 
            this.infoBindingSource.DataMember = "Info";
            this.infoBindingSource.DataSource = this.parsedInfoDataSet;
            // 
            // parsedInfoDataSet
            // 
            this.parsedInfoDataSet.DataSetName = "ParsedInfoDataSet";
            this.parsedInfoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // infoTableAdapter
            // 
            this.infoTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 80;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 150;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description ";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description ";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 200;
            // 
            // demandsDataGridViewTextBoxColumn
            // 
            this.demandsDataGridViewTextBoxColumn.DataPropertyName = "Demands";
            this.demandsDataGridViewTextBoxColumn.HeaderText = "Demands";
            this.demandsDataGridViewTextBoxColumn.Name = "demandsDataGridViewTextBoxColumn";
            this.demandsDataGridViewTextBoxColumn.ReadOnly = true;
            this.demandsDataGridViewTextBoxColumn.Width = 80;
            // 
            // imageDataGridViewTextBoxColumn
            // 
            this.imageDataGridViewTextBoxColumn.DataPropertyName = "Image";
            this.imageDataGridViewTextBoxColumn.HeaderText = "Image";
            this.imageDataGridViewTextBoxColumn.Name = "imageDataGridViewTextBoxColumn";
            this.imageDataGridViewTextBoxColumn.ReadOnly = true;
            this.imageDataGridViewTextBoxColumn.Width = 200;
            // 
            // urlDataGridViewTextBoxColumn
            // 
            this.urlDataGridViewTextBoxColumn.DataPropertyName = "Url";
            this.urlDataGridViewTextBoxColumn.HeaderText = "Url";
            this.urlDataGridViewTextBoxColumn.Name = "urlDataGridViewTextBoxColumn";
            this.urlDataGridViewTextBoxColumn.ReadOnly = true;
            this.urlDataGridViewTextBoxColumn.Width = 150;
            // 
            // Parse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bunifuFlatButton1);
            this.Name = "Parse";
            this.Size = new System.Drawing.Size(967, 503);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parsedInfoDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource infoBindingSource;
        private ParsedInfoDataSet parsedInfoDataSet;
        private ParsedInfoDataSetTableAdapters.InfoTableAdapter infoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn demandsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlDataGridViewTextBoxColumn;
    }
}
