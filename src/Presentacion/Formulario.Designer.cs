
namespace Proyecto1_01.src.Presentacion
{
    partial class Formulario
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
            this.comboSeleccionar = new System.Windows.Forms.ComboBox();
            this.comboSeleccionarCaras = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTraslacion = new System.Windows.Forms.TabPage();
            this.trackBarTraslacionZ = new System.Windows.Forms.TrackBar();
            this.trackBarTraslacionY = new System.Windows.Forms.TrackBar();
            this.trackBarTraslacionX = new System.Windows.Forms.TrackBar();
            this.tabRotacion = new System.Windows.Forms.TabPage();
            this.trackBarRotacionX = new System.Windows.Forms.TrackBar();
            this.trackBarRotacionY = new System.Windows.Forms.TrackBar();
            this.trackBarRotacionZ = new System.Windows.Forms.TrackBar();
            this.tabEscalacion = new System.Windows.Forms.TabPage();
            this.trackBarEscalacionX = new System.Windows.Forms.TrackBar();
            this.trackBarEscalacionY = new System.Windows.Forms.TrackBar();
            this.trackBarEscalacionZ = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabTraslacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTraslacionZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTraslacionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTraslacionX)).BeginInit();
            this.tabRotacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotacionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotacionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotacionZ)).BeginInit();
            this.tabEscalacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEscalacionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEscalacionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEscalacionZ)).BeginInit();
            this.SuspendLayout();
            // 
            // comboSeleccionar
            // 
            this.comboSeleccionar.FormattingEnabled = true;
            this.comboSeleccionar.Location = new System.Drawing.Point(52, 24);
            this.comboSeleccionar.Name = "comboSeleccionar";
            this.comboSeleccionar.Size = new System.Drawing.Size(146, 21);
            this.comboSeleccionar.TabIndex = 1;
            this.comboSeleccionar.Text = "Seleccionar Objeto";
            this.comboSeleccionar.SelectedIndexChanged += new System.EventHandler(this.comboSeleccionar_SelectedIndexChanged);
            // 
            // comboSeleccionarCaras
            // 
            this.comboSeleccionarCaras.FormattingEnabled = true;
            this.comboSeleccionarCaras.Location = new System.Drawing.Point(52, 72);
            this.comboSeleccionarCaras.Name = "comboSeleccionarCaras";
            this.comboSeleccionarCaras.Size = new System.Drawing.Size(146, 21);
            this.comboSeleccionarCaras.TabIndex = 2;
            this.comboSeleccionarCaras.Text = "Seleccionar Cara";
            this.comboSeleccionarCaras.SelectedIndexChanged += new System.EventHandler(this.comboSeleccionarCaras_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTraslacion);
            this.tabControl1.Controls.Add(this.tabRotacion);
            this.tabControl1.Controls.Add(this.tabEscalacion);
            this.tabControl1.Location = new System.Drawing.Point(12, 135);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(392, 253);
            this.tabControl1.TabIndex = 3;
            // 
            // tabTraslacion
            // 
            this.tabTraslacion.Controls.Add(this.trackBarTraslacionZ);
            this.tabTraslacion.Controls.Add(this.trackBarTraslacionY);
            this.tabTraslacion.Controls.Add(this.trackBarTraslacionX);
            this.tabTraslacion.Location = new System.Drawing.Point(4, 22);
            this.tabTraslacion.Name = "tabTraslacion";
            this.tabTraslacion.Padding = new System.Windows.Forms.Padding(3);
            this.tabTraslacion.Size = new System.Drawing.Size(384, 227);
            this.tabTraslacion.TabIndex = 0;
            this.tabTraslacion.Text = "Traslacion";
            this.tabTraslacion.UseVisualStyleBackColor = true;
            // 
            // trackBarTraslacionZ
            // 
            this.trackBarTraslacionZ.Location = new System.Drawing.Point(15, 159);
            this.trackBarTraslacionZ.Maximum = 50;
            this.trackBarTraslacionZ.Minimum = -50;
            this.trackBarTraslacionZ.Name = "trackBarTraslacionZ";
            this.trackBarTraslacionZ.Size = new System.Drawing.Size(350, 45);
            this.trackBarTraslacionZ.TabIndex = 2;
            this.trackBarTraslacionZ.Scroll += new System.EventHandler(this.trackBarTraslacionZ_Scroll);
            // 
            // trackBarTraslacionY
            // 
            this.trackBarTraslacionY.Location = new System.Drawing.Point(15, 86);
            this.trackBarTraslacionY.Maximum = 50;
            this.trackBarTraslacionY.Minimum = -50;
            this.trackBarTraslacionY.Name = "trackBarTraslacionY";
            this.trackBarTraslacionY.Size = new System.Drawing.Size(350, 45);
            this.trackBarTraslacionY.TabIndex = 1;
            this.trackBarTraslacionY.Scroll += new System.EventHandler(this.trackBarTraslacionY_Scroll);
            // 
            // trackBarTraslacionX
            // 
            this.trackBarTraslacionX.Location = new System.Drawing.Point(15, 25);
            this.trackBarTraslacionX.Maximum = 50;
            this.trackBarTraslacionX.Minimum = -50;
            this.trackBarTraslacionX.Name = "trackBarTraslacionX";
            this.trackBarTraslacionX.Size = new System.Drawing.Size(350, 45);
            this.trackBarTraslacionX.TabIndex = 0;
            this.trackBarTraslacionX.Scroll += new System.EventHandler(this.trackBarTraslacionX_Scroll);
            // 
            // tabRotacion
            // 
            this.tabRotacion.Controls.Add(this.trackBarRotacionX);
            this.tabRotacion.Controls.Add(this.trackBarRotacionY);
            this.tabRotacion.Controls.Add(this.trackBarRotacionZ);
            this.tabRotacion.Location = new System.Drawing.Point(4, 22);
            this.tabRotacion.Name = "tabRotacion";
            this.tabRotacion.Padding = new System.Windows.Forms.Padding(3);
            this.tabRotacion.Size = new System.Drawing.Size(384, 227);
            this.tabRotacion.TabIndex = 1;
            this.tabRotacion.Text = "Rotacion";
            this.tabRotacion.UseVisualStyleBackColor = true;
            // 
            // trackBarRotacionX
            // 
            this.trackBarRotacionX.Location = new System.Drawing.Point(16, 24);
            this.trackBarRotacionX.Maximum = 50;
            this.trackBarRotacionX.Minimum = -50;
            this.trackBarRotacionX.Name = "trackBarRotacionX";
            this.trackBarRotacionX.Size = new System.Drawing.Size(353, 45);
            this.trackBarRotacionX.TabIndex = 3;
            this.trackBarRotacionX.Scroll += new System.EventHandler(this.trackBarRotacionX_Scroll);
            // 
            // trackBarRotacionY
            // 
            this.trackBarRotacionY.Location = new System.Drawing.Point(16, 91);
            this.trackBarRotacionY.Maximum = 50;
            this.trackBarRotacionY.Minimum = -50;
            this.trackBarRotacionY.Name = "trackBarRotacionY";
            this.trackBarRotacionY.Size = new System.Drawing.Size(353, 45);
            this.trackBarRotacionY.TabIndex = 3;
            this.trackBarRotacionY.Scroll += new System.EventHandler(this.trackBarRotacionY_Scroll);
            // 
            // trackBarRotacionZ
            // 
            this.trackBarRotacionZ.Location = new System.Drawing.Point(16, 158);
            this.trackBarRotacionZ.Maximum = 50;
            this.trackBarRotacionZ.Minimum = -50;
            this.trackBarRotacionZ.Name = "trackBarRotacionZ";
            this.trackBarRotacionZ.Size = new System.Drawing.Size(353, 45);
            this.trackBarRotacionZ.TabIndex = 4;
            this.trackBarRotacionZ.Scroll += new System.EventHandler(this.trackBarRotacionZ_Scroll);
            // 
            // tabEscalacion
            // 
            this.tabEscalacion.Controls.Add(this.trackBarEscalacionX);
            this.tabEscalacion.Controls.Add(this.trackBarEscalacionY);
            this.tabEscalacion.Controls.Add(this.trackBarEscalacionZ);
            this.tabEscalacion.Location = new System.Drawing.Point(4, 22);
            this.tabEscalacion.Name = "tabEscalacion";
            this.tabEscalacion.Size = new System.Drawing.Size(384, 227);
            this.tabEscalacion.TabIndex = 2;
            this.tabEscalacion.Text = "Escalacion";
            this.tabEscalacion.UseVisualStyleBackColor = true;
            // 
            // trackBarEscalacionX
            // 
            this.trackBarEscalacionX.Location = new System.Drawing.Point(16, 26);
            this.trackBarEscalacionX.Maximum = 50;
            this.trackBarEscalacionX.Minimum = -50;
            this.trackBarEscalacionX.Name = "trackBarEscalacionX";
            this.trackBarEscalacionX.Size = new System.Drawing.Size(353, 45);
            this.trackBarEscalacionX.TabIndex = 5;
            this.trackBarEscalacionX.Scroll += new System.EventHandler(this.trackBarEscalacionX_Scroll);
            // 
            // trackBarEscalacionY
            // 
            this.trackBarEscalacionY.Location = new System.Drawing.Point(16, 93);
            this.trackBarEscalacionY.Maximum = 50;
            this.trackBarEscalacionY.Minimum = -50;
            this.trackBarEscalacionY.Name = "trackBarEscalacionY";
            this.trackBarEscalacionY.Size = new System.Drawing.Size(353, 45);
            this.trackBarEscalacionY.TabIndex = 6;
            this.trackBarEscalacionY.Scroll += new System.EventHandler(this.trackBarEscalacionY_Scroll);
            // 
            // trackBarEscalacionZ
            // 
            this.trackBarEscalacionZ.Location = new System.Drawing.Point(16, 160);
            this.trackBarEscalacionZ.Maximum = 50;
            this.trackBarEscalacionZ.Minimum = -50;
            this.trackBarEscalacionZ.Name = "trackBarEscalacionZ";
            this.trackBarEscalacionZ.Size = new System.Drawing.Size(353, 45);
            this.trackBarEscalacionZ.TabIndex = 7;
            this.trackBarEscalacionZ.Scroll += new System.EventHandler(this.trackBarEscalacionZ_Scroll);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(280, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 49);
            this.button1.TabIndex = 4;
            this.button1.Text = "Animacion";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(306, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Formulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1534, 711);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.comboSeleccionarCaras);
            this.Controls.Add(this.comboSeleccionar);
            this.Name = "Formulario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario";
            this.Load += new System.EventHandler(this.Formulario_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabTraslacion.ResumeLayout(false);
            this.tabTraslacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTraslacionZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTraslacionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTraslacionX)).EndInit();
            this.tabRotacion.ResumeLayout(false);
            this.tabRotacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotacionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotacionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotacionZ)).EndInit();
            this.tabEscalacion.ResumeLayout(false);
            this.tabEscalacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEscalacionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEscalacionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEscalacionZ)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox comboSeleccionar;
        public System.Windows.Forms.ComboBox comboSeleccionarCaras;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabTraslacion;
        public System.Windows.Forms.TrackBar trackBarTraslacionZ;
        public System.Windows.Forms.TrackBar trackBarTraslacionY;
        public System.Windows.Forms.TrackBar trackBarTraslacionX;
        public System.Windows.Forms.TabPage tabRotacion;
        public System.Windows.Forms.TrackBar trackBarRotacionX;
        public System.Windows.Forms.TrackBar trackBarRotacionY;
        public System.Windows.Forms.TrackBar trackBarRotacionZ;
        public System.Windows.Forms.TabPage tabEscalacion;
        public System.Windows.Forms.TrackBar trackBarEscalacionX;
        public System.Windows.Forms.TrackBar trackBarEscalacionY;
        public System.Windows.Forms.TrackBar trackBarEscalacionZ;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}