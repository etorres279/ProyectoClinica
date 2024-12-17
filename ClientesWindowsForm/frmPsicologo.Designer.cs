namespace CitaWindowsForm
{
    partial class frmPsicologo
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
            btnRecargar = new Button();
            btnEliminar = new Button();
            btnNuevo = new Button();
            btnActualizar = new Button();
            btnConsultar = new Button();
            dtgPsicologo = new DataGridView();
            txtFiltroNombre = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgPsicologo).BeginInit();
            SuspendLayout();
            // 
            // btnRecargar
            // 
            btnRecargar.Location = new Point(659, 25);
            btnRecargar.Margin = new Padding(3, 2, 3, 2);
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Size = new Size(104, 22);
            btnRecargar.TabIndex = 11;
            btnRecargar.Text = "Recargar Lista";
            btnRecargar.UseVisualStyleBackColor = true;
            btnRecargar.Click += btnRecargar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(660, 404);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(82, 22);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(38, 404);
            btnNuevo.Margin = new Padding(3, 2, 3, 2);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(82, 22);
            btnNuevo.TabIndex = 9;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(572, 404);
            btnActualizar.Margin = new Padding(3, 2, 3, 2);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(82, 22);
            btnActualizar.TabIndex = 8;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(485, 404);
            btnConsultar.Margin = new Padding(3, 2, 3, 2);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(82, 22);
            btnConsultar.TabIndex = 7;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // dtgPsicologo
            // 
            dtgPsicologo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgPsicologo.Location = new Point(38, 58);
            dtgPsicologo.Margin = new Padding(3, 2, 3, 2);
            dtgPsicologo.Name = "dtgPsicologo";
            dtgPsicologo.ReadOnly = true;
            dtgPsicologo.RowHeadersWidth = 51;
            dtgPsicologo.RowTemplate.Height = 29;
            dtgPsicologo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgPsicologo.Size = new Size(725, 307);
            dtgPsicologo.TabIndex = 6;
            // 
            // txtFiltroNombre
            // 
            txtFiltroNombre.Location = new Point(133, 27);
            txtFiltroNombre.Name = "txtFiltroNombre";
            txtFiltroNombre.Size = new Size(226, 23);
            txtFiltroNombre.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic);
            label1.Location = new Point(57, 28);
            label1.Name = "label1";
            label1.Size = new Size(70, 19);
            label1.TabIndex = 13;
            label1.Text = "Psicologo";
            // 
            // frmPsicologo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = ClientesWindowsForm.Properties.Resources.psicologos_form;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(txtFiltroNombre);
            Controls.Add(btnRecargar);
            Controls.Add(btnEliminar);
            Controls.Add(btnNuevo);
            Controls.Add(btnActualizar);
            Controls.Add(btnConsultar);
            Controls.Add(dtgPsicologo);
            Name = "frmPsicologo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPsicologo";
            Load += frmPsicologo_Load;
            ((System.ComponentModel.ISupportInitialize)dtgPsicologo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRecargar;
        private Button btnEliminar;
        private Button btnNuevo;
        private Button btnActualizar;
        private Button btnConsultar;
        private DataGridView dtgPsicologo;
        private TextBox txtFiltroNombre;
        private Label label1;
    }
}