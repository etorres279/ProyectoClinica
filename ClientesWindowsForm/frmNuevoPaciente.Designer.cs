namespace ClientesWindowsForm
{
    partial class frmNuevoPaciente
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
            btnActualizar = new Button();
            label12 = new Label();
            txtApe = new TextBox();
            label4 = new Label();
            txtCorreo = new TextBox();
            label3 = new Label();
            txtTelefono = new TextBox();
            label1 = new Label();
            txtNom = new TextBox();
            Genero = new GroupBox();
            rbF = new RadioButton();
            rbM = new RadioButton();
            label2 = new Label();
            pbFoto = new PictureBox();
            btnFoto = new Button();
            label5 = new Label();
            cboDistrito = new ComboBox();
            cboProvincia = new ComboBox();
            cboDepartamento = new ComboBox();
            dtpFechNaci = new DateTimePicker();
            Genero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFoto).BeginInit();
            SuspendLayout();
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(351, 357);
            btnActualizar.Margin = new Padding(3, 2, 3, 2);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(96, 29);
            btnActualizar.TabIndex = 118;
            btnActualizar.Text = "Guardar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnCrear_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label12.Location = new Point(27, 87);
            label12.Name = "label12";
            label12.Size = new Size(63, 17);
            label12.TabIndex = 114;
            label12.Text = "Apellidos";
            // 
            // txtApe
            // 
            txtApe.Location = new Point(97, 86);
            txtApe.Margin = new Padding(3, 2, 3, 2);
            txtApe.Name = "txtApe";
            txtApe.Size = new Size(194, 23);
            txtApe.TabIndex = 113;
            txtApe.KeyPress += TextBox_Letra_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.Location = new Point(42, 315);
            label4.Name = "label4";
            label4.Size = new Size(49, 17);
            label4.TabIndex = 112;
            label4.Text = "Correo";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(97, 315);
            txtCorreo.Margin = new Padding(3, 2, 3, 2);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(155, 23);
            txtCorreo.TabIndex = 111;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.Location = new Point(33, 278);
            label3.Name = "label3";
            label3.Size = new Size(59, 17);
            label3.TabIndex = 110;
            label3.Text = "Telefono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(98, 275);
            txtTelefono.Margin = new Padding(3, 2, 3, 2);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(154, 23);
            txtTelefono.TabIndex = 109;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.Location = new Point(25, 49);
            label1.Name = "label1";
            label1.Size = new Size(64, 17);
            label1.TabIndex = 106;
            label1.Text = "Nombres";
            // 
            // txtNom
            // 
            txtNom.Location = new Point(95, 48);
            txtNom.Margin = new Padding(3, 2, 3, 2);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(194, 23);
            txtNom.TabIndex = 105;
            txtNom.KeyPress += TextBox_Letra_KeyPress;
            // 
            // Genero
            // 
            Genero.Controls.Add(rbF);
            Genero.Controls.Add(rbM);
            Genero.Location = new Point(27, 136);
            Genero.Name = "Genero";
            Genero.Size = new Size(257, 57);
            Genero.TabIndex = 119;
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
            rbM.Checked = true;
            rbM.Location = new Point(15, 25);
            rbM.Name = "rbM";
            rbM.Size = new Size(80, 19);
            rbM.TabIndex = 0;
            rbM.TabStop = true;
            rbM.Text = "Masculino";
            rbM.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.Location = new Point(333, 49);
            label2.Name = "label2";
            label2.Size = new Size(36, 17);
            label2.TabIndex = 120;
            label2.Text = "Foto";
            // 
            // pbFoto
            // 
            pbFoto.Location = new Point(387, 49);
            pbFoto.Name = "pbFoto";
            pbFoto.Size = new Size(89, 96);
            pbFoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbFoto.TabIndex = 121;
            pbFoto.TabStop = false;
            // 
            // btnFoto
            // 
            btnFoto.BackColor = Color.FloralWhite;
            btnFoto.Location = new Point(333, 159);
            btnFoto.Name = "btnFoto";
            btnFoto.Size = new Size(132, 23);
            btnFoto.TabIndex = 122;
            btnFoto.Text = "Subir Foto";
            btnFoto.UseVisualStyleBackColor = false;
            btnFoto.Click += btnFoto_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label5.Location = new Point(33, 222);
            label5.Name = "label5";
            label5.Size = new Size(135, 17);
            label5.TabIndex = 124;
            label5.Text = "Fecha de Nacimiento";
            // 
            // cboDistrito
            // 
            cboDistrito.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDistrito.FormattingEnabled = true;
            cboDistrito.Location = new Point(276, 315);
            cboDistrito.Name = "cboDistrito";
            cboDistrito.Size = new Size(200, 23);
            cboDistrito.TabIndex = 127;
            // 
            // cboProvincia
            // 
            cboProvincia.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProvincia.FormattingEnabled = true;
            cboProvincia.Location = new Point(276, 269);
            cboProvincia.Name = "cboProvincia";
            cboProvincia.Size = new Size(200, 23);
            cboProvincia.TabIndex = 126;
            // 
            // cboDepartamento
            // 
            cboDepartamento.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDepartamento.FormattingEnabled = true;
            cboDepartamento.Location = new Point(276, 232);
            cboDepartamento.Name = "cboDepartamento";
            cboDepartamento.Size = new Size(200, 23);
            cboDepartamento.TabIndex = 125;
            // 
            // dtpFechNaci
            // 
            dtpFechNaci.Font = new Font("Segoe UI", 9F);
            dtpFechNaci.Format = DateTimePickerFormat.Short;
            dtpFechNaci.Location = new Point(97, 242);
            dtpFechNaci.Name = "dtpFechNaci";
            dtpFechNaci.Size = new Size(155, 23);
            dtpFechNaci.TabIndex = 128;
            // 
            // frmNuevoPaciente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 409);
            Controls.Add(dtpFechNaci);
            Controls.Add(cboDistrito);
            Controls.Add(cboProvincia);
            Controls.Add(cboDepartamento);
            Controls.Add(label5);
            Controls.Add(btnFoto);
            Controls.Add(pbFoto);
            Controls.Add(label2);
            Controls.Add(Genero);
            Controls.Add(btnActualizar);
            Controls.Add(label12);
            Controls.Add(txtApe);
            Controls.Add(label4);
            Controls.Add(txtCorreo);
            Controls.Add(label3);
            Controls.Add(txtTelefono);
            Controls.Add(label1);
            Controls.Add(txtNom);
            Name = "frmNuevoPaciente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmNuevoPaciente";
            Load += frmNuevoPaciente_Load;
            Genero.ResumeLayout(false);
            Genero.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnActualizar;
        private Label label12;
        private TextBox txtApe;
        private Label label4;
        private TextBox txtCorreo;
        private Label label3;
        private TextBox txtTelefono;
        private Label label1;
        private TextBox txtNom;
        private GroupBox Genero;
        private RadioButton rbF;
        private RadioButton rbM;
        private Label label2;
        private PictureBox pbFoto;
        private Button btnFoto;
        private Label label5;
        private ComboBox cboDistrito;
        private ComboBox cboProvincia;
        private ComboBox cboDepartamento;
        private DateTimePicker dtpFechNaci;
    }
}