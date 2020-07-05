namespace _LPF_Proyecto2_201602975
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.editor = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.análisisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteTokensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.galeríaFuncionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarImágenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erroresLéxicosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erroresSintácticosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualTécnicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Consola = new System.Windows.Forms.RichTextBox();
            this.numeroLabel = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelGraficas = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PanelGraficas.SuspendLayout();
            this.SuspendLayout();
            // 
            // editor
            // 
            this.editor.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.editor.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editor.ForeColor = System.Drawing.SystemColors.Info;
            this.editor.Location = new System.Drawing.Point(42, 41);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(607, 415);
            this.editor.TabIndex = 0;
            this.editor.Text = "";
            this.editor.WordWrap = false;
            this.editor.VScroll += new System.EventHandler(this.editor_VScroll);
            this.editor.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.editor_PreviewKeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Desktop;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.análisisToolStripMenuItem,
            this.salidaToolStripMenuItem,
            this.galeríaFuncionesToolStripMenuItem,
            this.exportarImágenesToolStripMenuItem,
            this.reportesErroresToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1020, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "Menu";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.BackColor = System.Drawing.SystemColors.Desktop;
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem});
            this.archivoToolStripMenuItem.ForeColor = System.Drawing.Color.Aqua;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.BackColor = System.Drawing.SystemColors.Desktop;
            this.abrirToolStripMenuItem.ForeColor = System.Drawing.Color.Aqua;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.BackColor = System.Drawing.SystemColors.Desktop;
            this.guardarToolStripMenuItem.ForeColor = System.Drawing.Color.Aqua;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.BackColor = System.Drawing.SystemColors.Desktop;
            this.guardarComoToolStripMenuItem.ForeColor = System.Drawing.Color.Aqua;
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar Como";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click);
            // 
            // análisisToolStripMenuItem
            // 
            this.análisisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analizarToolStripMenuItem,
            this.reporteTokensToolStripMenuItem});
            this.análisisToolStripMenuItem.ForeColor = System.Drawing.Color.Aqua;
            this.análisisToolStripMenuItem.Name = "análisisToolStripMenuItem";
            this.análisisToolStripMenuItem.Size = new System.Drawing.Size(155, 20);
            this.análisisToolStripMenuItem.Text = "Análisis léxico y sintáctico";
            // 
            // analizarToolStripMenuItem
            // 
            this.analizarToolStripMenuItem.BackColor = System.Drawing.SystemColors.Desktop;
            this.analizarToolStripMenuItem.ForeColor = System.Drawing.Color.Aqua;
            this.analizarToolStripMenuItem.Name = "analizarToolStripMenuItem";
            this.analizarToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.analizarToolStripMenuItem.Text = "Analizar";
            this.analizarToolStripMenuItem.Click += new System.EventHandler(this.analizarToolStripMenuItem_Click);
            // 
            // reporteTokensToolStripMenuItem
            // 
            this.reporteTokensToolStripMenuItem.BackColor = System.Drawing.SystemColors.Desktop;
            this.reporteTokensToolStripMenuItem.ForeColor = System.Drawing.Color.Aqua;
            this.reporteTokensToolStripMenuItem.Name = "reporteTokensToolStripMenuItem";
            this.reporteTokensToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.reporteTokensToolStripMenuItem.Text = "Reporte Tokens";
            this.reporteTokensToolStripMenuItem.Click += new System.EventHandler(this.reporteTokensToolStripMenuItem_Click);
            // 
            // salidaToolStripMenuItem
            // 
            this.salidaToolStripMenuItem.ForeColor = System.Drawing.Color.Aqua;
            this.salidaToolStripMenuItem.Name = "salidaToolStripMenuItem";
            this.salidaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.salidaToolStripMenuItem.Text = "Salida";
            this.salidaToolStripMenuItem.Click += new System.EventHandler(this.salidaToolStripMenuItem_Click);
            // 
            // galeríaFuncionesToolStripMenuItem
            // 
            this.galeríaFuncionesToolStripMenuItem.ForeColor = System.Drawing.Color.Aqua;
            this.galeríaFuncionesToolStripMenuItem.Name = "galeríaFuncionesToolStripMenuItem";
            this.galeríaFuncionesToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.galeríaFuncionesToolStripMenuItem.Text = "Galería Funciones";
            this.galeríaFuncionesToolStripMenuItem.Click += new System.EventHandler(this.galeríaFuncionesToolStripMenuItem_Click);
            // 
            // exportarImágenesToolStripMenuItem
            // 
            this.exportarImágenesToolStripMenuItem.ForeColor = System.Drawing.Color.Aqua;
            this.exportarImágenesToolStripMenuItem.Name = "exportarImágenesToolStripMenuItem";
            this.exportarImágenesToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.exportarImágenesToolStripMenuItem.Text = "Exportar Imágenes";
            this.exportarImágenesToolStripMenuItem.Click += new System.EventHandler(this.exportarImágenesToolStripMenuItem_Click);
            // 
            // reportesErroresToolStripMenuItem
            // 
            this.reportesErroresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.erroresLéxicosToolStripMenuItem,
            this.erroresSintácticosToolStripMenuItem});
            this.reportesErroresToolStripMenuItem.ForeColor = System.Drawing.Color.Aqua;
            this.reportesErroresToolStripMenuItem.Name = "reportesErroresToolStripMenuItem";
            this.reportesErroresToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.reportesErroresToolStripMenuItem.Text = "Reportes Errores";
            // 
            // erroresLéxicosToolStripMenuItem
            // 
            this.erroresLéxicosToolStripMenuItem.BackColor = System.Drawing.SystemColors.Desktop;
            this.erroresLéxicosToolStripMenuItem.ForeColor = System.Drawing.Color.Aqua;
            this.erroresLéxicosToolStripMenuItem.Name = "erroresLéxicosToolStripMenuItem";
            this.erroresLéxicosToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.erroresLéxicosToolStripMenuItem.Text = "Errores Léxicos";
            this.erroresLéxicosToolStripMenuItem.Click += new System.EventHandler(this.erroresLéxicosToolStripMenuItem_Click);
            // 
            // erroresSintácticosToolStripMenuItem
            // 
            this.erroresSintácticosToolStripMenuItem.BackColor = System.Drawing.SystemColors.Desktop;
            this.erroresSintácticosToolStripMenuItem.ForeColor = System.Drawing.Color.Aqua;
            this.erroresSintácticosToolStripMenuItem.Name = "erroresSintácticosToolStripMenuItem";
            this.erroresSintácticosToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.erroresSintácticosToolStripMenuItem.Text = "Errores Sintácticos";
            this.erroresSintácticosToolStripMenuItem.Click += new System.EventHandler(this.erroresSintácticosToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem,
            this.manualDeUsuarioToolStripMenuItem,
            this.manualTécnicoToolStripMenuItem});
            this.ayudaToolStripMenuItem.ForeColor = System.Drawing.Color.Aqua;
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.BackColor = System.Drawing.SystemColors.Desktop;
            this.acercaDeToolStripMenuItem.ForeColor = System.Drawing.Color.Aqua;
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca De";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // manualDeUsuarioToolStripMenuItem
            // 
            this.manualDeUsuarioToolStripMenuItem.BackColor = System.Drawing.SystemColors.Desktop;
            this.manualDeUsuarioToolStripMenuItem.ForeColor = System.Drawing.Color.Aqua;
            this.manualDeUsuarioToolStripMenuItem.Name = "manualDeUsuarioToolStripMenuItem";
            this.manualDeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.manualDeUsuarioToolStripMenuItem.Text = "Manual de Usuario";
            this.manualDeUsuarioToolStripMenuItem.Click += new System.EventHandler(this.manualDeUsuarioToolStripMenuItem_Click);
            // 
            // manualTécnicoToolStripMenuItem
            // 
            this.manualTécnicoToolStripMenuItem.BackColor = System.Drawing.SystemColors.Desktop;
            this.manualTécnicoToolStripMenuItem.ForeColor = System.Drawing.Color.Aqua;
            this.manualTécnicoToolStripMenuItem.Name = "manualTécnicoToolStripMenuItem";
            this.manualTécnicoToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.manualTécnicoToolStripMenuItem.Text = "Manual técnico";
            this.manualTécnicoToolStripMenuItem.Click += new System.EventHandler(this.manualTécnicoToolStripMenuItem_Click);
            // 
            // Consola
            // 
            this.Consola.BackColor = System.Drawing.Color.PowderBlue;
            this.Consola.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Consola.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Consola.Location = new System.Drawing.Point(23, 462);
            this.Consola.Name = "Consola";
            this.Consola.ReadOnly = true;
            this.Consola.Size = new System.Drawing.Size(626, 123);
            this.Consola.TabIndex = 2;
            this.Consola.Text = "";
            // 
            // numeroLabel
            // 
            this.numeroLabel.AutoSize = true;
            this.numeroLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.numeroLabel.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroLabel.ForeColor = System.Drawing.Color.Aqua;
            this.numeroLabel.Location = new System.Drawing.Point(12, 41);
            this.numeroLabel.Name = "numeroLabel";
            this.numeroLabel.Size = new System.Drawing.Size(16, 18);
            this.numeroLabel.TabIndex = 3;
            this.numeroLabel.Text = "1";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(592, 531);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Gráfica 1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(592, 531);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PanelGraficas
            // 
            this.PanelGraficas.Controls.Add(this.tabPage1);
            this.PanelGraficas.Location = new System.Drawing.Point(672, 27);
            this.PanelGraficas.Name = "PanelGraficas";
            this.PanelGraficas.SelectedIndex = 0;
            this.PanelGraficas.Size = new System.Drawing.Size(600, 557);
            this.PanelGraficas.TabIndex = 4;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1020, 596);
            this.Controls.Add(this.PanelGraficas);
            this.Controls.Add(this.numeroLabel);
            this.Controls.Add(this.Consola);
            this.Controls.Add(this.editor);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Text = "DrawMathque";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PanelGraficas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox editor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem análisisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem galeríaFuncionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarImágenesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesErroresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erroresLéxicosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erroresSintácticosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualDeUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualTécnicoToolStripMenuItem;
        private System.Windows.Forms.RichTextBox Consola;
        private System.Windows.Forms.ToolStripMenuItem salidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteTokensToolStripMenuItem;
        private System.Windows.Forms.Label numeroLabel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl PanelGraficas;
    }
}

