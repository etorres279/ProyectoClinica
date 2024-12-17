namespace CitaWindowsForm
{
    partial class frmNuevoPsicologo
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
            btnCrear = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtNomApe = new TextBox();
            txtEspecialidad = new TextBox();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            cboDepartamento = new ComboBox();
            cboProvincia = new ComboBox();
            cboDistrito = new ComboBox();
            SuspendLayout();
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(232, 285);
            btnCrear.Margin = new Padding(3, 2, 3, 2);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(82, 22);
            btnCrear.TabIndex = 49;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.Location = new Point(48, 147);
            label4.Name = "label4";
            label4.Size = new Size(49, 17);
            label4.TabIndex = 59;
            label4.Text = "Correo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.Location = new Point(48, 117);
            label3.Name = "label3";
            label3.Size = new Size(59, 17);
            label3.TabIndex = 57;
            label3.Text = "Telefono";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.Location = new Point(48, 81);
            label2.Name = "label2";
            label2.Size = new Size(81, 17);
            label2.TabIndex = 55;
            label2.Text = "Especialidad";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.Location = new Point(48, 47);
            label1.Name = "label1";
            label1.Size = new Size(122, 17);
            label1.TabIndex = 53;
            label1.Text = "Nombre y Apellido";
            // 
            // txtNomApe
            // 
            txtNomApe.Location = new Point(176, 46);
            txtNomApe.Margin = new Padding(3, 2, 3, 2);
            txtNomApe.Name = "txtNomApe";
            txtNomApe.Size = new Size(268, 23);
            txtNomApe.TabIndex = 75;
            txtNomApe.KeyPress += TextBox_Letra_KeyPress;
            // 
            // txtEspecialidad
            // 
            txtEspecialidad.Location = new Point(135, 80);
            txtEspecialidad.Margin = new Padding(3, 2, 3, 2);
            txtEspecialidad.Name = "txtEspecialidad";
            txtEspecialidad.Size = new Size(154, 23);
            txtEspecialidad.TabIndex = 76;
            txtEspecialidad.KeyPress += TextBox_Letra_KeyPress;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(113, 116);
            txtTelefono.Margin = new Padding(3, 2, 3, 2);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(152, 23);
            txtTelefono.TabIndex = 78;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(113, 147);
            txtCorreo.Margin = new Padding(3, 2, 3, 2);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(152, 23);
            txtCorreo.TabIndex = 79;
            // 
            // cboDepartamento
            // 
            cboDepartamento.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDepartamento.FormattingEnabled = true;
            cboDepartamento.Location = new Point(317, 116);
            cboDepartamento.Name = "cboDepartamento";
            cboDepartamento.Size = new Size(200, 23);
            cboDepartamento.TabIndex = 80;
            // 
            // cboProvincia
            // 
            cboProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProvincia.FormattingEnabled = true;
            cboProvincia.Location = new Point(317, 153);
            cboProvincia.Name = "cboProvincia";
            cboProvincia.Size = new Size(200, 23);
            cboProvincia.TabIndex = 81;
            // 
            // cboDistrito
            // 
            cboDistrito.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistrito.FormattingEnabled = true;
            cboDistrito.Location = new Point(317, 199);
            cboDistrito.Name = "cboDistrito";
            cboDistrito.Size = new Size(200, 23);
            cboDistrito.TabIndex = 82;
            // 
            // frmNuevoPsicologo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 345);
            Controls.Add(cboDistrito);
            Controls.Add(cboProvincia);
            Controls.Add(cboDepartamento);
            Controls.Add(txtCorreo);
            Controls.Add(txtTelefono);
            Controls.Add(txtEspecialidad);
            Controls.Add(txtNomApe);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCrear);
            Name = "frmNuevoPsicologo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmNuevoPsicologo";
            Load += frmNuevoPsicologo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCrear;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtNomApe;
        private TextBox txtEspecialidad;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private ComboBox cboDepartamento;
        private ComboBox cboProvincia;
        private ComboBox cboDistrito;
    }
}