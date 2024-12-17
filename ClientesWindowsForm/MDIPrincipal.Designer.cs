namespace CitaWindowsForm
{
    partial class MDIPrincipal
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
            statusStrip1 = new StatusStrip();
            lbl1 = new ToolStripStatusLabel();
            lblUsuario = new ToolStripStatusLabel();
            btnPsicologos = new Button();
            btnPacientes = new Button();
            btnCitas = new Button();
            btnClose = new Button();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lbl1, lblUsuario });
            statusStrip1.Location = new Point(0, 639);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(884, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lbl1
            // 
            lbl1.BackColor = SystemColors.HotTrack;
            lbl1.ForeColor = SystemColors.ButtonHighlight;
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(50, 17);
            lbl1.Text = "Usuario:";
            lbl1.Click += toolStripStatusLabel1_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.BackColor = SystemColors.ActiveCaption;
            lblUsuario.ForeColor = SystemColors.ButtonHighlight;
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(16, 17);
            lblUsuario.Text = "...";
            // 
            // btnPsicologos
            // 
            btnPsicologos.BackgroundImageLayout = ImageLayout.None;
            btnPsicologos.Image = ClientesWindowsForm.Properties.Resources.psicologo;
            btnPsicologos.ImageAlign = ContentAlignment.TopCenter;
            btnPsicologos.Location = new Point(249, 121);
            btnPsicologos.Name = "btnPsicologos";
            btnPsicologos.Size = new Size(160, 160);
            btnPsicologos.TabIndex = 3;
            btnPsicologos.Text = "PSICOLOGOS";
            btnPsicologos.TextAlign = ContentAlignment.BottomCenter;
            btnPsicologos.UseVisualStyleBackColor = true;
            btnPsicologos.Click += btnPsicologos_Click;
            // 
            // btnPacientes
            // 
            btnPacientes.Image = ClientesWindowsForm.Properties.Resources.paciente;
            btnPacientes.ImageAlign = ContentAlignment.TopCenter;
            btnPacientes.Location = new Point(249, 330);
            btnPacientes.Name = "btnPacientes";
            btnPacientes.Size = new Size(160, 160);
            btnPacientes.TabIndex = 4;
            btnPacientes.Text = "PACIENTES";
            btnPacientes.TextAlign = ContentAlignment.BottomCenter;
            btnPacientes.UseVisualStyleBackColor = true;
            btnPacientes.Click += btnPacientes_Click;
            // 
            // btnCitas
            // 
            btnCitas.Image = ClientesWindowsForm.Properties.Resources.citas;
            btnCitas.ImageAlign = ContentAlignment.TopCenter;
            btnCitas.Location = new Point(470, 121);
            btnCitas.Name = "btnCitas";
            btnCitas.Size = new Size(160, 160);
            btnCitas.TabIndex = 5;
            btnCitas.Text = "CITAS";
            btnCitas.TextAlign = ContentAlignment.BottomCenter;
            btnCitas.UseVisualStyleBackColor = true;
            btnCitas.Click += btnCitas_Click;
            // 
            // btnClose
            // 
            btnClose.Image = ClientesWindowsForm.Properties.Resources.cerrar_sesion;
            btnClose.ImageAlign = ContentAlignment.TopCenter;
            btnClose.Location = new Point(470, 330);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(160, 160);
            btnClose.TabIndex = 6;
            btnClose.Text = "CERRAR SESION";
            btnClose.TextAlign = ContentAlignment.BottomCenter;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // MDIPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            BackgroundImage = ClientesWindowsForm.Properties.Resources.mdi;
            ClientSize = new Size(884, 661);
            Controls.Add(btnClose);
            Controls.Add(btnCitas);
            Controls.Add(btnPacientes);
            Controls.Add(btnPsicologos);
            Controls.Add(statusStrip1);
            IsMdiContainer = true;
            Name = "MDIPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu Principal";
            FormClosing += MDIPrincipal_FormClosing;
            FormClosed += MDIPrincipal_FormClosed;
            Load += MDIPrincipal_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lbl1;
        private ToolStripStatusLabel lblUsuario;
        private Button btnPsicologos;
        private Button btnPacientes;
        private Button btnCitas;
        private Button btnClose;
    }
}