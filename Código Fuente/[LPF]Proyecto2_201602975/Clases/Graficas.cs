using System;

namespace _LPF_Proyecto2_201602975.Clases
{
    public class Graficas
    {
        String nombre;
        int x_positivo;
        int x_negativo;
        int y_positivo;
        int y_negativo;
        int ancho;
        int largo;
        String ruta;
        Funciones funcion;

        public Graficas(String nombre,int x_positivo, int x_negativo, int y_positivo, int y_negativo, int ancho, int largo, string ruta, Funciones funcion)
        {
            this.Nombre = nombre;
            this.X_positivo = x_positivo;
            this.X_negativo = x_negativo;
            this.Y_positivo = y_positivo;
            this.Y_negativo = y_negativo;
            this.Ancho = ancho;
            this.Largo = largo;
            this.Ruta = ruta;
            this.Funcion = funcion;
        }

        public int X_positivo { get => x_positivo; set => x_positivo = value; }
        public int X_negativo { get => x_negativo; set => x_negativo = value; }
        public int Y_positivo { get => y_positivo; set => y_positivo = value; }
        public int Y_negativo { get => y_negativo; set => y_negativo = value; }
        public int Ancho { get => ancho; set => ancho = value; }
        public int Largo { get => largo; set => largo = value; }
        public string Ruta { get => ruta; set => ruta = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        internal Funciones Funcion { get => funcion; set => funcion = value; }
    }
}
