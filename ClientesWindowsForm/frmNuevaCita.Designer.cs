﻿namespace CitaWindowsForm
{
    partial class frmNuevaCita
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
            cboConfiAsis = new ComboBox();
            label6 = new Label();
            cboEstPago = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            txtPrecio = new TextBox();
            label3 = new Label();
            txtMotivo = new TextBox();
            cboDuracion = new ComboBox();
            label2 = new Label();
            cboTipo = new ComboBox();
            label1 = new Label();
            cboPaciente = new ComboBox();
            cboPsicologo = new ComboBox();
            lblPsicologo = new Label();
            lblPaciente = new Label();
            dtpHora = new DateTimePicker();
            dtpFecha = new DateTimePicker();
            btnCrear = new Button();
            lblHora = new Label();
            lblHistorial = new Label();
            lblConsultorio = new Label();
            lblFecha = new Label();
            txtHistorial = new TextBox();
            txtConsultorio = new TextBox();
            SuspendLayout();
            // 
            // cboConfiAsis
            // 
            cboConfiAsis.DropDownStyle = ComboBoxStyle.DropDownList;
            cboConfiAsis.FormattingEnabled = true;
            cboConfiAsis.Items.AddRange(new object[] { "Terapia individual" });
            cboConfiAsis.Location = new Point(373, 226);
            cboConfiAsis.Name = "cboConfiAsis";
            cboConfiAsis.Size = new Size(102, 23);
            cboConfiAsis.TabIndex = 81;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(215, 229);
            label6.Name = "label6";
            label6.Size = new Size(152, 15);
            label6.TabIndex = 80;
            label6.Text = "Confirmacion de Asistencia";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // cboEstPago
            // 
            cboEstPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstPago.FormattingEnabled = true;
            cboEstPago.Items.AddRange(new object[] { "Terapia individual" });
            cboEstPago.Location = new Point(373, 186);
            cboEstPago.Name = "cboEstPago";
            cboEstPago.Size = new Size(102, 23);
            cboEstPago.TabIndex = 79;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(279, 189);
            label5.Name = "label5";
            label5.Size = new Size(88, 15);
            label5.TabIndex = 78;
            label5.Text = "Estado de Pago";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 186);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 77;
            label4.Text = "Precio";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(89, 183);
            txtPrecio.Margin = new Padding(3, 2, 3, 2);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(110, 23);
            txtPrecio.TabIndex = 76;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 147);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 75;
            label3.Text = "Motivo";
            // 
            // txtMotivo
            // 
            txtMotivo.Location = new Point(89, 145);
            txtMotivo.Margin = new Padding(3, 2, 3, 2);
            txtMotivo.Multiline = true;
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new Size(200, 23);
            txtMotivo.TabIndex = 74;
            // 
            // cboDuracion
            // 
            cboDuracion.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDuracion.FormattingEnabled = true;
            cboDuracion.Items.AddRange(new object[] { "Terapia individual" });
            cboDuracion.Location = new Point(373, 111);
            cboDuracion.Name = "cboDuracion";
            cboDuracion.Size = new Size(102, 23);
            cboDuracion.TabIndex = 73;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(315, 114);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 72;
            label2.Text = "Duracion";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // cboTipo
            // 
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.FormattingEnabled = true;
            cboTipo.Items.AddRange(new object[] { "Terapia individual" });
            cboTipo.Location = new Point(89, 108);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(200, 23);
            cboTipo.TabIndex = 71;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 111);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 70;
            label1.Text = "Tipo";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // cboPaciente
            // 
            cboPaciente.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaciente.FormattingEnabled = true;
            cboPaciente.Location = new Point(89, 32);
            cboPaciente.Name = "cboPaciente";
            cboPaciente.Size = new Size(200, 23);
            cboPaciente.TabIndex = 69;
            // 
            // cboPsicologo
            // 
            cboPsicologo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPsicologo.FormattingEnabled = true;
            cboPsicologo.Location = new Point(89, 70);
            cboPsicologo.Name = "cboPsicologo";
            cboPsicologo.Size = new Size(200, 23);
            cboPsicologo.TabIndex = 68;
            // 
            // lblPsicologo
            // 
            lblPsicologo.AutoSize = true;
            lblPsicologo.Location = new Point(24, 73);
            lblPsicologo.Name = "lblPsicologo";
            lblPsicologo.Size = new Size(59, 15);
            lblPsicologo.TabIndex = 66;
            lblPsicologo.Text = "Psicologo";
            lblPsicologo.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblPaciente
            // 
            lblPaciente.AutoSize = true;
            lblPaciente.Location = new Point(31, 35);
            lblPaciente.Name = "lblPaciente";
            lblPaciente.Size = new Size(52, 15);
            lblPaciente.TabIndex = 67;
            lblPaciente.Text = "Paciente";
            lblPaciente.TextAlign = ContentAlignment.TopCenter;
            // 
            // dtpHora
            // 
            dtpHora.Format = DateTimePickerFormat.Time;
            dtpHora.Location = new Point(373, 70);
            dtpHora.Margin = new Padding(3, 2, 3, 2);
            dtpHora.Name = "dtpHora";
            dtpHora.ShowUpDown = true;
            dtpHora.Size = new Size(102, 23);
            dtpHora.TabIndex = 65;
            dtpHora.TabStop = false;
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(373, 32);
            dtpFecha.Margin = new Padding(3, 2, 3, 2);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(162, 23);
            dtpFecha.TabIndex = 64;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(399, 282);
            btnCrear.Margin = new Padding(3, 2, 3, 2);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(93, 30);
            btnCrear.TabIndex = 63;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Location = new Point(329, 73);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(33, 15);
            lblHora.TabIndex = 59;
            lblHora.Text = "Hora";
            // 
            // lblHistorial
            // 
            lblHistorial.AutoSize = true;
            lblHistorial.Location = new Point(311, 153);
            lblHistorial.Name = "lblHistorial";
            lblHistorial.Size = new Size(51, 15);
            lblHistorial.TabIndex = 60;
            lblHistorial.Text = "Historial";
            // 
            // lblConsultorio
            // 
            lblConsultorio.AutoSize = true;
            lblConsultorio.Location = new Point(45, 226);
            lblConsultorio.Name = "lblConsultorio";
            lblConsultorio.Size = new Size(92, 15);
            lblConsultorio.TabIndex = 61;
            lblConsultorio.Text = "Nro Consultorio";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(329, 35);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(38, 15);
            lblFecha.TabIndex = 62;
            lblFecha.Text = "Fecha";
            // 
            // txtHistorial
            // 
            txtHistorial.Location = new Point(373, 148);
            txtHistorial.Margin = new Padding(3, 2, 3, 2);
            txtHistorial.Name = "txtHistorial";
            txtHistorial.Size = new Size(110, 23);
            txtHistorial.TabIndex = 57;
            // 
            // txtConsultorio
            // 
            txtConsultorio.Location = new Point(151, 224);
            txtConsultorio.Margin = new Padding(3, 2, 3, 2);
            txtConsultorio.Name = "txtConsultorio";
            txtConsultorio.Size = new Size(48, 23);
            txtConsultorio.TabIndex = 58;
            // 
            // frmNuevaCita
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 345);
            Controls.Add(cboConfiAsis);
            Controls.Add(label6);
            Controls.Add(cboEstPago);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtPrecio);
            Controls.Add(label3);
            Controls.Add(txtMotivo);
            Controls.Add(cboDuracion);
            Controls.Add(label2);
            Controls.Add(cboTipo);
            Controls.Add(label1);
            Controls.Add(cboPaciente);
            Controls.Add(cboPsicologo);
            Controls.Add(lblPsicologo);
            Controls.Add(lblPaciente);
            Controls.Add(dtpHora);
            Controls.Add(dtpFecha);
            Controls.Add(btnCrear);
            Controls.Add(lblHora);
            Controls.Add(lblHistorial);
            Controls.Add(lblConsultorio);
            Controls.Add(lblFecha);
            Controls.Add(txtHistorial);
            Controls.Add(txtConsultorio);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmNuevaCita";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmNuevaCita";
            Load += frmNuevaCita_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboConfiAsis;
        private Label label6;
        private ComboBox cboEstPago;
        private Label label5;
        private Label label4;
        private TextBox txtPrecio;
        private Label label3;
        private TextBox txtMotivo;
        private ComboBox cboDuracion;
        private Label label2;
        private ComboBox cboTipo;
        private Label label1;
        private ComboBox cboPaciente;
        private ComboBox cboPsicologo;
        private Label lblPsicologo;
        private Label lblPaciente;
        private DateTimePicker dtpHora;
        private DateTimePicker dtpFecha;
        private Button btnCrear;
        private Label lblHora;
        private Label lblHistorial;
        private Label lblConsultorio;
        private Label lblFecha;
        private TextBox txtHistorial;
        private TextBox txtConsultorio;
    }
}