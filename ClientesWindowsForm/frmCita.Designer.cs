namespace CitaWindowsForm
{
    partial class frmCita
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
            dtgCita = new DataGridView();
            btnConsultar = new Button();
            btnActualizar = new Button();
            btnNuevo = new Button();
            btnEliminar = new Button();
            btnRecargar = new Button();
            txtFiltroPaciente = new TextBox();
            dtpFecha = new DateTimePicker();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgCita).BeginInit();
            SuspendLayout();
            // 
            // dtgCita
            // 
            dtgCita.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgCita.Location = new Point(61, 69);
            dtgCita.Margin = new Padding(3, 2, 3, 2);
            dtgCita.Name = "dtgCita";
            dtgCita.ReadOnly = true;
            dtgCita.RowHeadersWidth = 51;
            dtgCita.RowTemplate.Height = 29;
            dtgCita.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgCita.Size = new Size(725, 307);
            dtgCita.TabIndex = 0;
            dtgCita.CellContentClick += dtgCita_CellContentClick;
            dtgCita.CellFormatting += dtgCita_CellFormatting;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(508, 415);
            btnConsultar.Margin = new Padding(3, 2, 3, 2);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(82, 22);
            btnConsultar.TabIndex = 1;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(595, 415);
            btnActualizar.Margin = new Padding(3, 2, 3, 2);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(82, 22);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(61, 415);
            btnNuevo.Margin = new Padding(3, 2, 3, 2);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(82, 22);
            btnNuevo.TabIndex = 3;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(683, 415);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(82, 22);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnRecargar
            // 
            btnRecargar.Location = new Point(682, 36);
            btnRecargar.Margin = new Padding(3, 2, 3, 2);
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Size = new Size(104, 22);
            btnRecargar.TabIndex = 5;
            btnRecargar.Text = "Recargar Lista";
            btnRecargar.UseVisualStyleBackColor = true;
            btnRecargar.Click += btnRecargar_Click;
            // 
            // txtFiltroPaciente
            // 
            txtFiltroPaciente.Location = new Point(130, 36);
            txtFiltroPaciente.Name = "txtFiltroPaciente";
            txtFiltroPaciente.Size = new Size(286, 23);
            txtFiltroPaciente.TabIndex = 6;
            txtFiltroPaciente.Tag = "";
            txtFiltroPaciente.TextChanged += txtFiltroPaciente_TextChanged;
            // 
            // dtpFecha
            // 
            dtpFecha.Checked = false;
            dtpFecha.Location = new Point(438, 36);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(211, 23);
            dtpFecha.TabIndex = 7;
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic);
            label1.Location = new Point(61, 36);
            label1.Name = "label1";
            label1.Size = new Size(63, 19);
            label1.TabIndex = 8;
            label1.Text = "Paciente";
            // 
            // frmCita
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = ClientesWindowsForm.Properties.Resources.citas_form;
            ClientSize = new Size(847, 476);
            Controls.Add(label1);
            Controls.Add(dtpFecha);
            Controls.Add(txtFiltroPaciente);
            Controls.Add(btnRecargar);
            Controls.Add(btnEliminar);
            Controls.Add(btnNuevo);
            Controls.Add(btnActualizar);
            Controls.Add(btnConsultar);
            Controls.Add(dtgCita);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmCita";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCita";
            Load += frmCita_Load;
            ((System.ComponentModel.ISupportInitialize)dtgCita).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtgCita;
        private Button btnConsultar;
        private Button btnActualizar;
        private Button btnNuevo;
        private Button btnEliminar;
        private Button btnRecargar;
        private TextBox txtFiltroPaciente;
        private DateTimePicker dtpFecha;
        private Label label1;
    }
}