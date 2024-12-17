namespace ClientesWindowsForm
{
    partial class frmPaciente
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
            dtgPaciente = new DataGridView();
            label1 = new Label();
            txtFiltroApellido = new TextBox();
            label2 = new Label();
            txtFiltroNombre = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dtgPaciente).BeginInit();
            SuspendLayout();
            // 
            // btnRecargar
            // 
            btnRecargar.Location = new Point(659, 25);
            btnRecargar.Margin = new Padding(3, 2, 3, 2);
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Size = new Size(104, 22);
            btnRecargar.TabIndex = 17;
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
            btnEliminar.TabIndex = 16;
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
            btnNuevo.TabIndex = 15;
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
            btnActualizar.TabIndex = 14;
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
            btnConsultar.TabIndex = 13;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // dtgPaciente
            // 
            dtgPaciente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgPaciente.Location = new Point(38, 58);
            dtgPaciente.Margin = new Padding(3, 2, 3, 2);
            dtgPaciente.Name = "dtgPaciente";
            dtgPaciente.ReadOnly = true;
            dtgPaciente.RowHeadersWidth = 51;
            dtgPaciente.RowTemplate.Height = 29;
            dtgPaciente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgPaciente.Size = new Size(725, 307);
            dtgPaciente.TabIndex = 12;
            dtgPaciente.CellFormatting += dtgCita_CellFormatting;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic);
            label1.Location = new Point(57, 27);
            label1.Name = "label1";
            label1.Size = new Size(62, 19);
            label1.TabIndex = 19;
            label1.Text = "Nombre";
            // 
            // txtFiltroApellido
            // 
            txtFiltroApellido.Location = new Point(399, 26);
            txtFiltroApellido.Name = "txtFiltroApellido";
            txtFiltroApellido.Size = new Size(168, 23);
            txtFiltroApellido.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic);
            label2.Location = new Point(330, 29);
            label2.Name = "label2";
            label2.Size = new Size(62, 19);
            label2.TabIndex = 21;
            label2.Text = "Apellido";
            // 
            // txtFiltroNombre
            // 
            txtFiltroNombre.Location = new Point(126, 25);
            txtFiltroNombre.Name = "txtFiltroNombre";
            txtFiltroNombre.Size = new Size(168, 23);
            txtFiltroNombre.TabIndex = 20;
            // 
            // frmPaciente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.pacientes_form;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(txtFiltroNombre);
            Controls.Add(label1);
            Controls.Add(txtFiltroApellido);
            Controls.Add(btnRecargar);
            Controls.Add(btnEliminar);
            Controls.Add(btnNuevo);
            Controls.Add(btnActualizar);
            Controls.Add(btnConsultar);
            Controls.Add(dtgPaciente);
            Name = "frmPaciente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPaciente";
            ((System.ComponentModel.ISupportInitialize)dtgPaciente).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRecargar;
        private Button btnEliminar;
        private Button btnNuevo;
        private Button btnActualizar;
        private Button btnConsultar;
        private DataGridView dtgPaciente;
        private Label label1;
        private TextBox txtFiltroApellido;
        private Label label2;
        private TextBox txtFiltroNombre;
    }
}