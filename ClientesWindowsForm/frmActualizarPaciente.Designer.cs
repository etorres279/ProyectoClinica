namespace ClientesWindowsForm
{
    partial class frmActualizarPaciente
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
            label12 = new Label();
            txtApe = new TextBox();
            label4 = new Label();
            txtCorreo = new TextBox();
            label3 = new Label();
            txtTelefono = new TextBox();
            label1 = new Label();
            txtNom = new TextBox();
            lblId = new Label();
            txtId = new TextBox();
            checkActivo = new CheckBox();
            btnActualizar = new Button();
            Genero = new GroupBox();
            rbF = new RadioButton();
            rbM = new RadioButton();
            label6 = new Label();
            pbFoto = new PictureBox();
            btnFoto = new Button();
            cboDistrito = new ComboBox();
            cboProvincia = new ComboBox();
            cboDepartamento = new ComboBox();
            Genero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFoto).BeginInit();
            SuspendLayout();
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label12.Location = new Point(27, 120);
            label12.Name = "label12";
            label12.Size = new Size(63, 17);
            label12.TabIndex = 81;
            label12.Text = "Apellidos";
            // 
            // txtApe
            // 
            txtApe.Location = new Point(97, 119);
            txtApe.Margin = new Padding(3, 2, 3, 2);
            txtApe.Name = "txtApe";
            txtApe.Size = new Size(194, 23);
            txtApe.TabIndex = 80;
            txtApe.KeyPress += TextBox_Letra_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.Location = new Point(40, 268);
            label4.Name = "label4";
            label4.Size = new Size(49, 17);
            label4.TabIndex = 75;
            label4.Text = "Correo";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(95, 268);
            txtCorreo.Margin = new Padding(3, 2, 3, 2);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(155, 23);
            txtCorreo.TabIndex = 74;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.Location = new Point(30, 235);
            label3.Name = "label3";
            label3.Size = new Size(59, 17);
            label3.TabIndex = 73;
            label3.Text = "Telefono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(95, 232);
            txtTelefono.Margin = new Padding(3, 2, 3, 2);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(157, 23);
            txtTelefono.TabIndex = 72;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.Location = new Point(25, 82);
            label1.Name = "label1";
            label1.Size = new Size(64, 17);
            label1.TabIndex = 69;
            label1.Text = "Nombres";
            // 
            // txtNom
            // 
            txtNom.Location = new Point(95, 81);
            txtNom.Margin = new Padding(3, 2, 3, 2);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(194, 23);
            txtNom.TabIndex = 68;
            txtNom.KeyPress += TextBox_Letra_KeyPress;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblId.Location = new Point(25, 39);
            lblId.Name = "lblId";
            lblId.Size = new Size(76, 17);
            lblId.TabIndex = 67;
            lblId.Text = "Id_Paciente";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(107, 33);
            txtId.Margin = new Padding(3, 2, 3, 2);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(66, 23);
            txtId.TabIndex = 66;
            // 
            // checkActivo
            // 
            checkActivo.AutoSize = true;
            checkActivo.Location = new Point(229, 37);
            checkActivo.Name = "checkActivo";
            checkActivo.Size = new Size(60, 19);
            checkActivo.TabIndex = 99;
            checkActivo.Text = "Activo";
            checkActivo.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(27, 336);
            btnActualizar.Margin = new Padding(3, 2, 3, 2);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(96, 29);
            btnActualizar.TabIndex = 102;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // Genero
            // 
            Genero.Controls.Add(rbF);
            Genero.Controls.Add(rbM);
            Genero.Location = new Point(34, 158);
            Genero.Name = "Genero";
            Genero.Size = new Size(257, 57);
            Genero.TabIndex = 120;
            Genero.TabStop = false;
            Genero.Text = "Genero";
            // 
            // rbF
            // 
            rbF.AutoSize = true;
            rbF.Location = new Point(101, 25);
            rbF.Name = "rbF";
            rbF.Size = new Size(78, 19);
            rbF.TabIndex = 1;
            rbF.Text = "Femenino";
            rbF.UseVisualStyleBackColor = true;
            // 
            // rbM
            // 
            rbM.AutoSize = true;
            rbM.Location = new Point(15, 25);
            rbM.Name = "rbM";
            rbM.Size = new Size(80, 19);
            rbM.TabIndex = 0;
            rbM.Text = "Masculino";
            rbM.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label6.Location = new Point(311, 37);
            label6.Name = "label6";
            label6.Size = new Size(36, 17);
            label6.TabIndex = 122;
            label6.Text = "Foto";
            // 
            // pbFoto
            // 
            pbFoto.Location = new Point(364, 37);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new Size(111, 116);
            pbFoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbFoto.TabIndex = 121;
            pbFoto.TabStop = false;
            // 
            // btnFoto
            // 
            btnFoto.BackColor = Color.FloralWhite;
            btnFoto.Location = new Point(343, 179);
            btnFoto.Name = "btnFoto";
            btnFoto.Size = new Size(132, 23);
            btnFoto.TabIndex = 123;
            btnFoto.Text = "Subir Foto";
            btnFoto.UseVisualStyleBackColor = false;
            btnFoto.Click += btnFoto_Click;
            // 
            // cboDistrito
            // 
            cboDistrito.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistrito.FormattingEnabled = true;
            cboDistrito.Location = new Point(293, 318);
            cboDistrito.Name = "cboDistrito";
            cboDistrito.Size = new Size(200, 23);
            cboDistrito.TabIndex = 126;
            cboDistrito.SelectedIndexChanged += cboDistrito_SelectedIndexChanged;
            // 
            // cboProvincia
            // 
            cboProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProvincia.FormattingEnabled = true;
            cboProvincia.Location = new Point(293, 272);
            cboProvincia.Name = "cboProvincia";
            cboProvincia.Size = new Size(200, 23);
            cboProvincia.TabIndex = 125;
            cboProvincia.SelectedIndexChanged += cboProvincia_SelectedIndexChanged;
            // 
            // cboDepartamento
            // 
            cboDepartamento.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDepartamento.FormattingEnabled = true;
            cboDepartamento.Location = new Point(293, 235);
            cboDepartamento.Name = "cboDepartamento";
            cboDepartamento.Size = new Size(200, 23);
            cboDepartamento.TabIndex = 124;
            cboDepartamento.SelectedIndexChanged += cboDepartamento_SelectedIndexChanged;
            // 
            // frmActualizarPaciente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(516, 400);
            Controls.Add(cboDistrito);
            Controls.Add(cboProvincia);
            Controls.Add(cboDepartamento);
            Controls.Add(btnFoto);
            Controls.Add(label6);
            Controls.Add(pbFoto);
            Controls.Add(Genero);
            Controls.Add(btnActualizar);
            Controls.Add(checkActivo);
            Controls.Add(label12);
            Controls.Add(txtApe);
            Controls.Add(label4);
            Controls.Add(txtCorreo);
            Controls.Add(label3);
            Controls.Add(txtTelefono);
            Controls.Add(label1);
            Controls.Add(txtNom);
            Controls.Add(lblId);
            Controls.Add(txtId);
            Name = "frmActualizarPaciente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmActualizarPaciente";
            Genero.ResumeLayout(false);
            Genero.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label12;
        private TextBox txtApe;
        private Label label4;
        private TextBox txtCorreo;
        private Label label3;
        private TextBox txtTelefono;
        private Label label1;
        private TextBox txtNom;
        private Label lblId;
        private TextBox txtId;
        private CheckBox checkActivo;
        private Button btnActualizar;
        private GroupBox Genero;
        private RadioButton rbF;
        private RadioButton rbM;
        private Label label6;
        private PictureBox pbFoto;
        private Button btnFoto;
        private ComboBox cboDistrito;
        private ComboBox cboProvincia;
        private ComboBox cboDepartamento;
    }
}