using System;

namespace _LPF_Proyecto2_201602975.Clases
{
    class ErroresLexicos
    {
        int fila;
        int columna;
        String caracter;
        String descripcion;

        public ErroresLexicos(int fila, int columna, String caracter, String descripcion)
        {
            this.Fila = fila;
            this.Columna = columna;
            this.Caracter = caracter;
            this.Descripcion = descripcion;
        }

        public int Fila { get => fila; set => fila = value; }
        public int Columna { get => columna; set => columna = value; }
        public string Caracter { get => caracter; set => caracter = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
