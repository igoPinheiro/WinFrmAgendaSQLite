namespace WinFrmAgendaSQLite
{
    partial class Agenda
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtID = new TextBox();
            lblId = new Label();
            lblNome = new Label();
            txtName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            btnIns = new Button();
            btnAlt = new Button();
            btnDel = new Button();
            btnLoc = new Button();
            gv = new DataGridView();
            lblData = new Label();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)gv).BeginInit();
            SuspendLayout();
            // 
            // txtID
            // 
            txtID.Location = new Point(67, 6);
            txtID.Name = "txtID";
            txtID.Size = new Size(100, 23);
            txtID.TabIndex = 0;
            txtID.KeyPress += txtID_KeyPress;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(12, 9);
            lblId.Name = "lblId";
            lblId.Size = new Size(21, 15);
            lblId.TabIndex = 1;
            lblId.Text = "ID:";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(12, 38);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(45, 15);
            lblNome.TabIndex = 3;
            lblNome.Text = "NOME:";
            // 
            // txtName
            // 
            txtName.Location = new Point(67, 35);
            txtName.Name = "txtName";
            txtName.Size = new Size(329, 23);
            txtName.TabIndex = 2;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(402, 38);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(44, 15);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "EMAIL:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(457, 35);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(331, 23);
            txtEmail.TabIndex = 4;
            // 
            // btnIns
            // 
            btnIns.Location = new Point(14, 64);
            btnIns.Name = "btnIns";
            btnIns.Size = new Size(85, 23);
            btnIns.TabIndex = 6;
            btnIns.Text = "INSERIR";
            btnIns.UseVisualStyleBackColor = true;
            btnIns.Click += btnIns_Click;
            // 
            // btnAlt
            // 
            btnAlt.Location = new Point(105, 64);
            btnAlt.Name = "btnAlt";
            btnAlt.Size = new Size(85, 23);
            btnAlt.TabIndex = 7;
            btnAlt.Text = "ALTERAR";
            btnAlt.UseVisualStyleBackColor = true;
            btnAlt.Click += btnAlt_Click;
            // 
            // btnDel
            // 
            btnDel.Location = new Point(196, 64);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(85, 23);
            btnDel.TabIndex = 8;
            btnDel.Text = "EXCLUIR";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // btnLoc
            // 
            btnLoc.Location = new Point(378, 64);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(85, 23);
            btnLoc.TabIndex = 9;
            btnLoc.Text = "LOCALIZAR";
            btnLoc.UseVisualStyleBackColor = true;
            btnLoc.Visible = false;
            // 
            // gv
            // 
            gv.AllowUserToAddRows = false;
            gv.AllowUserToDeleteRows = false;
            gv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gv.Location = new Point(12, 93);
            gv.MultiSelect = false;
            gv.Name = "gv";
            gv.ReadOnly = true;
            gv.RowTemplate.Height = 25;
            gv.Size = new Size(776, 315);
            gv.TabIndex = 10;
            gv.CellClick += gv_CellClick;
            // 
            // lblData
            // 
            lblData.AutoSize = true;
            lblData.Location = new Point(14, 424);
            lblData.Name = "lblData";
            lblData.Size = new Size(237, 15);
            lblData.TabIndex = 11;
            lblData.Text = "Localizar onde os dados estão armazenados";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(287, 64);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(85, 23);
            btnClear.TabIndex = 12;
            btnClear.Text = "LIMPAR";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // Agenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 451);
            Controls.Add(btnClear);
            Controls.Add(lblData);
            Controls.Add(gv);
            Controls.Add(btnLoc);
            Controls.Add(btnDel);
            Controls.Add(btnAlt);
            Controls.Add(btnIns);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblNome);
            Controls.Add(txtName);
            Controls.Add(lblId);
            Controls.Add(txtID);
            MaximizeBox = false;
            MaximumSize = new Size(815, 490);
            MinimumSize = new Size(815, 490);
            Name = "Agenda";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agenda";
            Load += Agenda_Load;
            ((System.ComponentModel.ISupportInitialize)gv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtID;
        private Label lblId;
        private Label lblNome;
        private TextBox txtName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Button btnIns;
        private Button btnAlt;
        private Button btnDel;
        private Button btnLoc;
        private DataGridView gv;
        private Label lblData;
        private Button btnClear;
    }
}