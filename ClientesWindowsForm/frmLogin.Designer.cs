namespace ClientesWindowsForm
{
    partial class frmLogin
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
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnIngresar = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = SystemColors.WindowText;
            txtUsuario.ForeColor = SystemColors.Window;
            txtUsuario.Location = new Point(196, 76);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(100, 23);
            txtUsuario.TabIndex = 0;
            // 
            // txtContraseña
            // 
            txtContraseña.BackColor = SystemColors.WindowText;
            txtContraseña.ForeColor = SystemColors.Window;
            txtContraseña.Location = new Point(196, 126);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(100, 23);
            txtContraseña.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(111, 79);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 2;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(102, 129);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 3;
            label2.Text = "Contraseña";
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = SystemColors.GradientInactiveCaption;
            btnIngresar.ForeColor = SystemColors.ControlText;
            btnIngresar.Location = new Point(327, 76);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(75, 23);
            btnIngresar.TabIndex = 4;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.GradientInactiveCaption;
            button2.Location = new Point(327, 126);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += btnCancelar_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.login;
            ClientSize = new Size(512, 260);
            Controls.Add(button2);
            Controls.Add(btnIngresar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuario);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ingresa tu usuario y contraseña";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private Label label1;
        private Label label2;
        private Button btnIngresar;
        private Button button2;
    }
}