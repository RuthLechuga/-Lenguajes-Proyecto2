namespace _LPF_Proyecto2_201602975.Formas
{
    partial class GaleriaFunciones
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
            this.PanelGraficas = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cuadroInformativo = new System.Windows.Forms.RichTextBox();
            this.PanelGraficas.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelGraficas
            // 
            this.PanelGraficas.Controls.Add(this.tabPage1);
            this.PanelGraficas.Location = new System.Drawing.Point(244, 12);
            this.PanelGraficas.Name = "PanelGraficas";
            this.PanelGraficas.SelectedIndex = 0;
            this.PanelGraficas.Size = new System.Drawing.Size(588, 557);
            this.PanelGraficas.TabIndex = 5;
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
            this.tabPage1.Size = new System.Drawing.Size(580, 531);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Gráfica 1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(571, 531);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cuadroInformativo
            // 
            this.cuadroInformativo.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.cuadroInformativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuadroInformativo.ForeColor = System.Drawing.SystemColors.Info;
            this.cuadroInformativo.Location = new System.Drawing.Point(22, 113);
            this.cuadroInformativo.Name = "cuadroInformativo";
            this.cuadroInformativo.ReadOnly = true;
            this.cuadroInformativo.Size = new System.Drawing.Size(203, 342);
            this.cuadroInformativo.TabIndex = 6;
            this.cuadroInformativo.Text = "";
            // 
            // GaleriaFunciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(850, 598);
            this.Controls.Add(this.cuadroInformativo);
            this.Controls.Add(this.PanelGraficas);
            this.Name = "GaleriaFunciones";
            this.Text = "GaleriaFunciones";
            this.Load += new System.EventHandler(this.GaleriaFunciones_Load);
            this.PanelGraficas.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl PanelGraficas;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox cuadroInformativo;
    }
}