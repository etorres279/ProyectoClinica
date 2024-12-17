namespace CitaWindowsForm
{
    partial class frmActualizarPsicologo
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
            txtCorreo = new TextBox();
            txtTelefono = new TextBox();
            txtEspecialidad = new TextBox();
            txtNomApe = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblIdCita = new Label();
            txtIdPsico = new TextBox();
            checkActivo = new CheckBox();
            btnActualizar = new Button();
            cboDistrito = new ComboBox();
            cboProvincia = new ComboBox();
            cboDepartamento = new ComboBox();
            SuspendLayout();
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(132, 194);
            txtCorreo.Margin = new Padding(3, 2, 3, 2);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(152, 23);
            txtCorreo.TabIndex = 93;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(142, 163);
            txtTelefono.Margin = new Padding(3, 2, 3, 2);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(130, 23);
            txtTelefono.TabIndex = 92;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // txtEspecialidad
            // 
            txtEspecialidad.Location = new Point(164, 125);
            txtEspecialidad.Margin = new Padding(3, 2, 3, 2);
            txtEspecialidad.Name = "txtEspecialidad";
            txtEspecialidad.Size = new Size(154, 23);
            txtEspecialidad.TabIndex = 90;
            txtEspecialidad.KeyPress += TextBox_Letra_KeyPress;
            // 
            // txtNomApe
            // 
            txtNomApe.Location = new Point(205, 90);
            txtNomApe.Margin = new Padding(3, 2, 3, 2);
            txtNomApe.Name = "txtNomApe";
            txtNomApe.Size = new Size(268, 23);
            txtNomApe.TabIndex = 89;
            txtNomApe.KeyPress += TextBox_Letra_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.Location = new Point(77, 195);
            label4.Name = "label4";
            label4.Size = new Size(49, 17);
            label4.TabIndex = 85;
            label4.Text = "Correo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.Location = new Point(77, 163);
            label3.Name = "label3";
            label3.Size = new Size(59, 17);
            label3.TabIndex = 84;
            label3.Text = "Telefono";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.Location = new Point(77, 126);
            label2.Name = "label2";
            label2.Size = new Size(81, 17);
            label2.TabIndex = 83;
            label2.Text = "Especialidad";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.Location = new Point(77, 91);
            label1.Name = "label1";
            label1.Size = new Size(122, 17);
            label1.TabIndex = 82;
            label1.Text = "Nombre y Apellido";
            // 
            // lblIdCita
            // 
            lblIdCita.AutoSize = true;
            lblIdCita.Location = new Point(78, 52);
            lblIdCita.Name = "lblIdCita";
            lblIdCita.Size = new Size(73, 15);
            lblIdCita.TabIndex = 97;
            lblIdCita.Text = "ID Psicologo";
            // 
            // txtIdPsico
            // 
            txtIdPsico.Enabled = false;
            txtIdPsico.Location = new Point(157, 49);
            txtIdPsico.Margin = new Padding(3, 2, 3, 2);
            txtIdPsico.Name = "txtIdPsico";
            txtIdPsico.ReadOnly = true;
            txtIdPsico.Size = new Size(110, 23);
            txtIdPsico.TabIndex = 96;
            // 
            // checkActivo
            // 
            checkActivo.AutoSize = true;
            checkActivo.Location = new Point(53, 236);
            checkActivo.Name = "checkActivo";
            checkActivo.Size = new Size(60, 19);
            checkActivo.TabIndex = 98;
            checkActivo.Text = "Activo";
            checkActivo.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(236, 286);
            btnActualizar.Margin = new Padding(3, 2, 3, 2);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(82, 22);
            btnActualizar.TabIndex = 99;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // cboDistrito
            // 
            cboDistrito.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistrito.FormattingEnabled = true;
            cboDistrito.Location = new Point(338, 240);
            cboDistrito.Name = "cboDistrito";
            cboDistrito.Size = new Size(200, 23);
            cboDistrito.TabIndex = 102;
            cboDistrito.SelectedIndexChanged += cboDistrito_SelectedIndexChanged;
            // 
            // cboProvincia
            // 
            cboProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProvincia.FormattingEnabled = true;
            cboProvincia.Location = new Point(338, 194);
            cboProvincia.Name = "cboProvincia";
            cboProvincia.Size = new Size(200, 23);
            cboProvincia.TabIndex = 101;
            cboProvincia.SelectedIndexChanged += cboProvincia_SelectedIndexChanged;
            // 
            // cboDepartamento
            // 
            cboDepartamento.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDepartamento.FormattingEnabled = true;
            cboDepartamento.Location = new Point(338, 157);
            cboDepartamento.Name = "cboDepartamento";
            cboDepartamento.Size = new Size(200, 23);
            cboDepartamento.TabIndex = 100;
            cboDepartamento.SelectedIndexChanged += cboDepartamento_SelectedIndexChanged;
            // 
            // frmActualizarPsicologo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 387);
            Controls.Add(cboDistrito);
            Controls.Add(cboProvincia);
            Controls.Add(cboDepartamento);
            Controls.Add(btnActualizar);
            Controls.Add(checkActivo);
            Controls.Add(lblIdCita);
            Controls.Add(txtIdPsico);
            Controls.Add(txtCorreo);
            Controls.Add(txtTelefono);
            Controls.Add(txtEspecialidad);
            Controls.Add(txtNomApe);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmActualizarPsicologo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmActualizarPsicologo";
            Load += frmActualizarPsicologo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtCorreo;
        private TextBox txtTelefono;
        private TextBox txtEspecialidad;
        private TextBox txtNomApe;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lblIdCita;
        private TextBox txtIdPsico;
        private CheckBox checkActivo;
        private Button btnActualizar;
        private ComboBox cboDistrito;
        private ComboBox cboProvincia;
        private ComboBox cboDepartamento;
    }
}