using System;

namespace _LPF_Proyecto2_201602975.Clases
{
    public class Constantes
    {
        String nombre;
        String tipo;
        String valor;

        public Constantes(String nombre, String tipo, String valor)
        {
            this.Nombre = nombre;
            this.Tipo = tipo;
            this.Valor = valor;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Valor { get => valor; set => valor = value; }
    }
}
