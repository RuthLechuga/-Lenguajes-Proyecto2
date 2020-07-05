using _LPF_Proyecto2_201602975.Clases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _LPF_Proyecto2_201602975.Formas
{
    public partial class GaleriaFunciones : Form
    {
        Bitmap b;
        Pen pen;
        Graphics g;
        Calculadora calculador;
        List<Constantes> constantes;
        List<PictureBox> lienzo;
        List<TabPage> seccion;
        List<Graficas> graficas;
        int s;

        public GaleriaFunciones(List<Graficas> graficas, List<Constantes> constantes)
        {
            InitializeComponent();
            this.graficas = graficas;
            this.constantes = constantes;
            constantes = new List<Constantes>();
            calculador = new Calculadora();
            s = 0;
        }

        private void GaleriaFunciones_Load(object sender, EventArgs e)
        {
            if(graficas.Count > 0)
            {
                graficar();
                cuadroInformativo.Text = "GRAFICA: " + graficas.ElementAt(0).Nombre + "\n";
                cuadroInformativo.Text += "x_positivo =" + graficas.ElementAt(0).X_positivo.ToString() + "\n";
                cuadroInformativo.Text += "x_negativo =" + graficas.ElementAt(0).X_negativo.ToString() + "\n";
                cuadroInformativo.Text += "y_positivo =" + graficas.ElementAt(0).Y_positivo.ToString() + "\n";
                cuadroInformativo.Text += "y_negativo =" + graficas.ElementAt(0).Y_negativo.ToString() + "\n";
                cuadroInformativo.Text += "ancho =" + graficas.ElementAt(0).Ancho.ToString() + "\n";
                cuadroInformativo.Text += "largo =" + graficas.ElementAt(0).Largo.ToString() + "\n";
                cuadroInformativo.Text += "ruta =" + graficas.ElementAt(0).Ruta + "\n";
                cuadroInformativo.Text += "funcion =" + graficas.ElementAt(0).Funcion.Nombre + "\n";
            }
        }

        public void graficar()
        {
            PanelGraficas.TabPages.Clear();
            lienzo = new List<PictureBox>();
            seccion = new List<TabPage>();
            int cont = 1;

            foreach (Graficas grafica in graficas)
            {
                //Creando lienzo
                seccion.Add(new TabPage());
                lienzo.Add(new PictureBox());

                //lienzo
                lienzo.Last().Location = new Point(0, 0);
                lienzo.Last().Name = "lienzo" + cont.ToString();
                lienzo.Last().Size = new Size(grafica.Ancho, grafica.Largo);

                //tab page
                seccion.Last().BackColor = SystemColors.GradientActiveCaption;
                seccion.Last().Controls.Add(lienzo.Last());
                seccion.Last().Location = new Point(4, 22);
                seccion.Last().Name = "seccion" + cont.ToString();
                seccion.Last().Size = new Size(grafica.Ancho, grafica.Largo);
                seccion.Last().TabIndex = seccion.Count - 1;
                seccion.Last().Text = grafica.Nombre;

                PanelGraficas.Controls.Add(seccion.Last());
                PanelGraficas.SelectedIndexChanged += new EventHandler(cambio_pestaña);
                cont++;

                //CREAR ENTORNO PARA DIBUJAR
                b = new Bitmap(lienzo.Last().Width, lienzo.Last().Height);
                lienzo.Last().Image = (Image)b;
                g = Graphics.FromImage(b);

                //CREANDO LAPIZ
                pen = new Pen(Color.Blue);
                pen.Width = 3.0F;

                //HACIENDO PLANO CARTESIANO
                int xTotal = grafica.X_negativo + grafica.X_positivo;
                int yTotal = grafica.Y_negativo + grafica.Y_positivo;
                int pasox = grafica.Ancho / xTotal;
                int pasoy = grafica.Largo / yTotal;

                SolidBrush Brush = new SolidBrush(ColorTranslator.FromHtml("#b9d1ea"));
                g.FillRectangle(Brush, 0, 0, grafica.Ancho, grafica.Largo);
                g.DrawLine(pen, new Point(pasox * grafica.X_negativo, 0), new Point(pasox * grafica.X_negativo, grafica.Largo));
                g.DrawLine(pen, new Point(0, grafica.Y_positivo * pasoy), new Point(grafica.Ancho, grafica.Y_positivo * pasoy));

                for (int i = pasoy; i <= grafica.Largo; i += pasoy)
                    g.DrawLine(pen, new Point(pasox * grafica.X_negativo - 10, i), new Point(pasox * grafica.X_negativo + 10, i));

                for (int i = pasox; i <= grafica.Ancho; i += pasox)
                    g.DrawLine(pen, new Point(i, pasoy * grafica.Y_positivo - 10), new Point(i, pasoy * grafica.Y_positivo + 10));

                //DIBUJANDO CURVA
                pen = new Pen(Color.Black);
                pen.Width = 1.0F;
                double tox = -grafica.X_negativo;
                double toy = 0;
                double tfy = 0;
                double tfx = 0;
                while (tox <= grafica.X_positivo)
                {
                    tfx = tox + 0.01;
                    tfy = Convert.ToDouble(calculador.calcularFuncion(grafica.Funcion.Valor, constantes, tfx));
                    try
                    {
                        g.DrawLine(pen, new Point(pasox * grafica.X_negativo + Convert.ToInt32(tox * pasox),
                                            pasoy * grafica.Y_positivo - Convert.ToInt32(toy * pasoy)),
                                        new Point(pasox * grafica.X_negativo + Convert.ToInt32(tfx * pasox),
                                            pasoy * grafica.Y_positivo - Convert.ToInt32(tfy * pasoy)));
                    }
                    catch (Exception g)
                    {
                    }

                    tox = tfx;
                    toy = tfy;
                }
            }
        }

        private void cambio_pestaña(object sender, EventArgs e)
        {
            TabControl menu = (TabControl)sender;
            s = menu.SelectedIndex;
            cuadroInformativo.Text = "GRAFICA: " + graficas.ElementAt(s).Nombre + "\n";
            cuadroInformativo.Text += "x_positivo =" + graficas.ElementAt(s).X_positivo.ToString() + "\n";
            cuadroInformativo.Text += "x_negativo =" + graficas.ElementAt(s).X_negativo.ToString() + "\n";
            cuadroInformativo.Text += "y_positivo =" + graficas.ElementAt(s).Y_positivo.ToString() + "\n";
            cuadroInformativo.Text += "y_negativo =" + graficas.ElementAt(s).Y_negativo.ToString() + "\n";
            cuadroInformativo.Text += "ancho =" + graficas.ElementAt(s).Ancho.ToString() + "\n";
            cuadroInformativo.Text += "largo =" + graficas.ElementAt(s).Largo.ToString() + "\n";
            cuadroInformativo.Text += "ruta =" + graficas.ElementAt(s).Ruta + "\n";
            cuadroInformativo.Text += "funcion =" + graficas.ElementAt(s).Funcion.Nombre + "\n";
        }
    }
}
