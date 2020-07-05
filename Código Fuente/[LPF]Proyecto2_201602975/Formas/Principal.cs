using _LPF_Proyecto2_201602975.Clases;
using _LPF_Proyecto2_201602975.Formas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace _LPF_Proyecto2_201602975
{
    public partial class Principal : Form
    {
        //HERRAMIENTAS DE DIBUJO
        Bitmap b;
        Pen pen;
        Graphics g;

        String ruta;
        List<Token> tokens;
        Analisis analizador;
        List<ErroresLexicos> erroresLexicos;
        List<ErroresSintacticos> erroresSintacticos;
        Calculadora calculador;
        List<Constantes> constantes;
        List<Funciones> funciones;
        List<Graficas> graficas;
        List<PictureBox> lienzo;
        List<TabPage> seccion;
        Boolean errores;

        public Principal()
        {
            InitializeComponent();
            ruta = "";

            analizador = new Analisis();
            erroresLexicos = new List<ErroresLexicos>();
            erroresSintacticos = new List<ErroresSintacticos>();
            calculador = new Calculadora();
            constantes = new List<Constantes>();
            funciones = new List<Funciones>();
            graficas = new List<Graficas>();
            tokens = new List<Token>();

            lienzo = new List<PictureBox>();
            seccion = new List<TabPage>();

            errores = false;
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lenguaje Formales y de Programacción- A \n" +
                "Ruth Nohemy Ardón Lechuga \n" +
                "Carnet: 201602975");
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog cuadroDialogo = new SaveFileDialog();
            cuadroDialogo.Title = "Seleccionar ubicación para guardar archivo";
            cuadroDialogo.Filter = "Documentos de texto(*.draw) | *.draw";

            if (cuadroDialogo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter escritor = new StreamWriter(cuadroDialogo.FileName);
                    ruta = cuadroDialogo.FileName;
                    Consola.Text = ruta;
                    escritor.Write(editor.Text);
                    escritor.Close();

                    MessageBox.Show("Archivo guardado Satisfactoriamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al intentar guardar el archivo" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Error al intentar encontrar la dirección");
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog cuadroDialogo = new OpenFileDialog();
            cuadroDialogo.Title = "Seleccionar archivo";
            cuadroDialogo.Filter = "Documentos de texto (*.draw)|*.draw";

            if ((cuadroDialogo.ShowDialog()) == DialogResult.OK)
            {
                try
                {
                    StreamReader lector = new StreamReader(cuadroDialogo.FileName);
                    ruta = cuadroDialogo.FileName;
                    String texto = lector.ReadToEnd();
                    editor.Text = texto;
                    lector.Close();

                    MessageBox.Show("Archivo abierto Satisfactoriamente");
                    numeroLinea();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("¡Error! Ha habido un problema al intentar abrir el archivo" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Error al intentar encontrar la dirección");
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ruta != "")
            {
                StreamWriter escritor = new StreamWriter(ruta);
                escritor.Write(editor.Text);
                escritor.Close();
                MessageBox.Show("Archivo guardado Satisfactoriamente");
            }
            else
            {
                MessageBox.Show("El archivo no se ha guardado con anterioridad");
                guardarComoToolStripMenuItem.PerformClick();
            }
        }

        private void analizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            analizador = new Analisis();
            tokens = new List<Token>();
            erroresLexicos = new List<ErroresLexicos>();
            erroresSintacticos = new List<ErroresSintacticos>();

            tokens = analizador.analizar(editor.Text);
            erroresLexicos = analizador.obtenerErroresLexicos();
            erroresSintacticos = analizador.obtenerErroresSintacticos();
            this.Cursor = Cursors.Default;
            Consola.Text = "Análisis completado. . .";

            if (erroresLexicos.Count == 0 && erroresSintacticos.Count == 0)
            {
                MessageBox.Show("Análisis realizado correctamente");
                errores = false;
            }
            else
            {
                if (erroresLexicos.Count > 0)
                    MessageBox.Show("¡Hay errores léxicos!");

                if (erroresSintacticos.Count > 0)
                    MessageBox.Show("¡Hay errores sintácticos!");
                errores = true;
            }
        }

        private void reporteTokensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String HTML =
            "<html><head><style> table {width: 60%; border: 1px solid black;}\n" +
            "th, td {text-align: cennter;padding: 8px; border: 1px solid black;}\n" +
            "tr:nth-child(even){background-color: white}\n" +
            "th {background-color: green;color: white; }\n" +
            "</style></head><body><h1>TABLA TOKENS</h1><br><br>"
            + "<center><table>"
            + "<tr><th>#</th><th>Lexema</th><th>Fila</th><th>Columna</th>"
            + "<th>Id Token</th><th>Token</th>";

            for (int i = 0; i < tokens.Count; i++)
                HTML += "<tr>" +
                    "<td>" + (i + 1).ToString() + "</td>" +
                    "<td>" + tokens.ElementAt(i).Lexema + "</td>" +
                    "<td>" + tokens.ElementAt(i).Fila.ToString() + "</td>" +
                    "<td>" + tokens.ElementAt(i).Columna.ToString() + "</td>" +
                    "<td>" + tokens.ElementAt(i).IdToken.ToString() + "</td>" +
                    "<td>" + tokens.ElementAt(i).Tipo.ToString() + "</td>";

            HTML += "</Table></center></body></html>";

            StreamWriter escritor = new StreamWriter("TablaTokens.html");
            escritor.Write(HTML);
            escritor.Close();

            Process.Start("TablaTokens.html");
        }

        private void numeroLinea()
        {
            Point pos = new Point(0, 0);
            int primerIndex = editor.GetCharIndexFromPosition(pos);
            int primeraLinea = editor.GetLineFromCharIndex(primerIndex);

            pos.X = editor.Width - 20;
            pos.Y = editor.Height - 40;
            int ultimoIndex = editor.GetCharIndexFromPosition(pos);
            int ultimaLinea = editor.GetLineFromCharIndex(ultimoIndex);

            pos = editor.GetPositionFromCharIndex(ultimoIndex);

            numeroLabel.Text = "";
            for (int i = primeraLinea; i <= ultimaLinea + 1; i++)
            {
                numeroLabel.Text += i + 1 + "\n";
            }
        }

        private void editor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                numeroLinea();
        }

        private void editor_VScroll(object sender, EventArgs e)
        {
            numeroLinea();
        }

        private void erroresLéxicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String HTML =
            "<html><head><style> table {width: 60%; border: 1px solid black;}\n" +
            "th, td {text-align: cennter;padding: 8px; border: 1px solid black;}\n" +
            "tr:nth-child(even){background-color: white}\n" +
            "th {background-color: blue;color: white; }\n" +
            "</style></head><body><h1>TABLA ERRORES LÉXICOS</h1><br><br>"
            + "<center><table>"
            + "<tr><th>#</th><th>Fila</th><th>Columna</th>"
            + "<th>Caracter</th><th>Descripcion</th>";

            for (int i = 0; i < erroresLexicos.Count; i++)
                HTML += "<tr>" +
                    "<td>" + (i + 1).ToString() + "</td>" +
                    "<td>" + erroresLexicos.ElementAt(i).Fila.ToString() + "</td>" +
                    "<td>" + erroresLexicos.ElementAt(i).Columna.ToString() + "</td>" +
                    "<td>" + erroresLexicos.ElementAt(i).Caracter + "</td>" +
                    "<td>" + erroresLexicos.ElementAt(i).Descripcion + "</td>";

            HTML += "</Table></center></body></html>";

            StreamWriter escritor = new StreamWriter("TablaErroresLexicos.html");
            escritor.Write(HTML);
            escritor.Close();

            Process.Start("TablaErroresLexicos.html");
        }

        private void erroresSintácticosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                String HTML =
                "<html><head><style> table {width: 60%; border: 1px solid black;}\n" +
                "th, td {text-align: cennter;padding: 8px; border: 1px solid black;}\n" +
                "tr:nth-child(even){background-color: white}\n" +
                "th {background-color: blue;color: white; }\n" +
                "</style></head><body><h1>TABLA ERRORES SINTÁCTICOS</h1><br><br>"
                + "<center><table>"
                + "<tr><th>#</th><th>Fila</th><th>Columna</th>"
                + "<th>Descripcion</th>";

                for (int i = 0; i < erroresSintacticos.Count; i++)
                    HTML += "<tr>" +
                        "<td>" + (i + 1).ToString() + "</td>" +
                        "<td>" + erroresSintacticos.ElementAt(i).Fila.ToString() + "</td>" +
                        "<td>" + erroresSintacticos.ElementAt(i).Columna.ToString() + "</td>" +
                        "<td>" + erroresSintacticos.ElementAt(i).Descripcion + "</td>";

                HTML += "</Table></center></body></html>";

                StreamWriter escritor = new StreamWriter("TablaErroresSintacticos.html");
                escritor.Write(HTML);
                escritor.Close();

                Process.Start("TablaErroresSintacticos.html");
            }
        }

        private void salidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!errores)
            {
                graficas = new List<Graficas>();
                constantes = new List<Constantes>();
                funciones = new List<Funciones>();
                String nombre = "";
                List<String> valor = new List<string>();
                String tipo = "";
                String valorVC = "";
                String nombreFuncion = "";
                int x_positivo;
                int x_negativo;
                int y_positivo;
                int y_negativo;
                int ancho;
                int largo;
                String ruta = "";
                Funciones funcion;
                Funciones temporalFuncion;

                for (int i = 0; i < tokens.Count; i++)
                {
                    //ESTABLECIENDO CONSTANTES
                    if (Comparar(tokens.ElementAt(i).Lexema, "constante"))
                    {
                        nombre = "";
                        valor.Clear();
                        tipo = "";
                        valorVC = "";

                        for (int j = i; j < tokens.Count && !Comparar(tokens.ElementAt(j).Lexema, "fin"); j++)
                        {
                            if (Comparar(tokens.ElementAt(j).Lexema, "nombre"))
                            {
                                nombre = tokens.ElementAt(j + 2).Lexema;
                                j = j + 2;
                            }
                            else if (Comparar(tokens.ElementAt(j).Lexema, "tipo"))
                            {
                                tipo = tokens.ElementAt(j + 2).Lexema;
                                j = j + 2;
                            }
                            else if (Comparar(tokens.ElementAt(j).Lexema, "valor"))
                            {
                                for (int k = j; k < tokens.Count() && (!Comparar(tokens.ElementAt(k + 2).Lexema, "nombre") && !Comparar(tokens.ElementAt(k + 2).Lexema, "fin") && !Comparar(tokens.ElementAt(k + 2).Lexema, "tipo")); k++)
                                {
                                    valor.Add(tokens.ElementAt(k + 2).Lexema);
                                    j = k;
                                }
                            }
                            i = j;
                        }
                        i = i + 2;
                        if ((nombre != "") && (valor.Count > 0) && (tipo != ""))
                        {
                            if (Comparar(tipo, "Entero") || Comparar(tipo, ("Decimal")))
                                valorVC = calculador.calcular(valor, constantes);
                            else
                                valorVC = valor.ElementAt(1);
                        }

                        constantes.Add(new Constantes(nombre, tipo, valorVC));
                    }

                    //ESTABLECIENDO FUNCIONES
                    else if (Comparar(tokens.ElementAt(i).Lexema, "funcion"))
                    {
                        nombre = "";
                        valor = new List<String>();
                        tipo = "";

                        for (int j = i; j < tokens.Count && !Comparar(tokens.ElementAt(j).Lexema, "fin"); j++)
                        {
                            if (Comparar(tokens.ElementAt(j).Lexema, "nombre"))
                            {
                                nombre = tokens.ElementAt(j + 2).Lexema;
                                j = j + 2;
                            }
                            else if (Comparar(tokens.ElementAt(j).Lexema, "valor"))
                            {
                                for (int k = j; k < tokens.Count() && (!Comparar(tokens.ElementAt(k + 2).Lexema, "nombre") && !Comparar(tokens.ElementAt(k + 2).Lexema, "fin") && !Comparar(tokens.ElementAt(k + 2).Lexema, "tipo")); k++)
                                {
                                    valor.Add(tokens.ElementAt(k + 2).Lexema);
                                    j = k;
                                }
                                j = j + 2;
                            }
                            i = j;
                        }
                        i = i + 2;
                        if (nombre != "" && valor.Count > 0)
                            funciones.Add(new Funciones(nombre, valor));
                    }

                    //ESTABLECIENDO GRÁFICAS
                    else if (Comparar(tokens.ElementAt(i).Lexema, "grafica"))
                    {
                        nombre = "";
                        x_positivo = 0;
                        x_negativo = 0;
                        y_positivo = 0;
                        y_negativo = 0;
                        ancho = 0;
                        largo = 0;
                        ruta = "";
                        funcion = null;
                        temporalFuncion = null;
                        nombreFuncion = "";

                        for (int j = i; j < tokens.Count && !Comparar(tokens.ElementAt(j).Lexema, "fin"); j++)
                        {
                            if (Comparar(tokens.ElementAt(j).Lexema, "nombre"))
                            {
                                nombre = tokens.ElementAt(j + 2).Lexema;
                                j = j + 2;
                            }
                            else if (Comparar(tokens.ElementAt(j).Lexema, "x_positivo"))
                            {
                                if (tokens.ElementAt(j + 2).IdToken == 8)
                                    x_positivo = valorConstante(tokens.ElementAt(j + 2).Lexema);
                                else
                                    x_positivo = Convert.ToInt32(tokens.ElementAt(j + 2).Lexema);

                                j = j + 2;
                            }
                            else if (Comparar(tokens.ElementAt(j).Lexema, "x_negativo"))
                            {
                                if (tokens.ElementAt(j + 2).IdToken == 8)
                                    x_negativo = valorConstante(tokens.ElementAt(j + 2).Lexema);
                                else
                                    x_negativo = Convert.ToInt32(tokens.ElementAt(j + 2).Lexema);

                                j = j + 2;
                            }
                            else if (Comparar(tokens.ElementAt(j).Lexema, "y_positivo"))
                            {
                                if (tokens.ElementAt(j + 2).IdToken == 8)
                                    y_positivo = valorConstante(tokens.ElementAt(j + 2).Lexema);
                                else
                                    y_positivo = Convert.ToInt32(tokens.ElementAt(j + 2).Lexema);

                                j = j + 2;
                            }
                            else if (Comparar(tokens.ElementAt(j).Lexema, "y_negativo"))
                            {
                                if (tokens.ElementAt(j + 2).IdToken == 8)
                                    y_negativo = valorConstante(tokens.ElementAt(j + 2).Lexema);
                                else
                                    y_negativo = Convert.ToInt32(tokens.ElementAt(j + 2).Lexema);

                                j = j + 2;
                            }
                            else if (Comparar(tokens.ElementAt(j).Lexema, "ancho"))
                            {
                                if (tokens.ElementAt(j + 2).IdToken == 8)
                                    ancho = valorConstante(tokens.ElementAt(j + 2).Lexema);
                                else
                                    ancho = Convert.ToInt32(tokens.ElementAt(j + 2).Lexema);

                                j = j + 2;
                            }
                            else if (Comparar(tokens.ElementAt(j).Lexema, "largo"))
                            {
                                if (tokens.ElementAt(j + 2).IdToken == 8)
                                    largo = valorConstante(tokens.ElementAt(j + 2).Lexema);
                                else
                                    largo = Convert.ToInt32(tokens.ElementAt(j + 2).Lexema);

                                j = j + 2;
                            }
                            else if (Comparar(tokens.ElementAt(j).Lexema, "ruta"))
                            {
                                ruta = tokens.ElementAt(j + 3).Lexema;
                                j = j + 4;
                            }
                            else if (Comparar(tokens.ElementAt(j).Lexema, "funcion"))
                            {
                                nombreFuncion = tokens.ElementAt(j + 2).Lexema;
                                j = j + 2;
                            }
                            i = j;
                        }
                        i = i + 2;

                        foreach (Funciones F in funciones)
                        {
                            if (Comparar(nombreFuncion, F.Nombre))
                                temporalFuncion = F;
                        }

                        if (nombre != "" && ruta != "" && temporalFuncion != null)
                            graficas.Add(new Graficas(nombre, x_positivo, x_negativo, y_positivo, y_negativo, ancho, largo, ruta, temporalFuncion));
                    }
                }

                Consola.Text = "";
                Consola.Text = "------------------------------------------------CONSTANTES------------------------------------------------\n";
                foreach (Constantes C in constantes)
                    Consola.Text += C.Nombre + "=" + C.Valor.ToString() + "\n";

                Consola.Text = "------------------------------------------------FUNCIONES------------------------------------------------\n";
                foreach (Funciones F in funciones)
                {
                    String temporal = "";
                    foreach (String operador in F.Valor)
                        temporal += operador;

                    Consola.Text += F.Nombre + "=" + temporal + "\n";
                }

                if (graficas.Count > 0)
                    graficar(graficas);
            }
            else
            {
                MessageBox.Show("Hay errores léxicos o sintácticos, realice los cambios correspondientes e intente de nuevo");
            }
        }

        public Boolean Comparar(String cadena1, String cadena2)
        {
            if (String.Compare(cadena1, cadena2, true) == 0)
                return true;
            else
                return false;
        }


        //GRAFICA DE FUNCIONES
        public void graficar(List<Graficas> Ggraficas)
        {
            PanelGraficas.TabPages.Clear();
            lienzo = new List<PictureBox>();
            seccion = new List<TabPage>();
            int cont = 1;

            foreach (Graficas grafica in Ggraficas)
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
                seccion.Last().Text = grafica.Nombre;

                PanelGraficas.Controls.Add(seccion.Last());
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
                g.FillRectangle(Brush, 0, 0,grafica.Ancho,grafica.Largo);
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

        public Int32 valorConstante(String palabra)
        {
            Constantes temporalConstante = null;

            foreach (Constantes C in constantes)
                if (Comparar(palabra, C.Nombre))
                    temporalConstante = C;

            return Convert.ToInt32(temporalConstante.Valor);
        }

        private void exportarImágenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap temporalBMP;
            for(int i = 0; i < graficas.Count; i++)
            {
                try
                {
                    temporalBMP = (Bitmap)lienzo.ElementAt(i).Image;
                    temporalBMP.Save(graficas.ElementAt(i).Ruta+"\\"+graficas.ElementAt(i).Nombre+".png");
                    MessageBox.Show("Se guardo exitosamente la gráfica: " + graficas.ElementAt(i).Nombre);
                }
                catch (Exception g)
                {
                    MessageBox.Show("No se ha encontrado la ruta especificado de la" +
                        "gráfica: "+graficas.ElementAt(i).Nombre);
                }
            }
        }

        private void galeríaFuncionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GaleriaFunciones galeria = new GaleriaFunciones(graficas,constantes);
            galeria.Show();
        }

        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("Manual usuario.pdf");
        }

        private void manualTécnicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("Manual técnico.pdf");
        }
    }
}
