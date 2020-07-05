using System;

namespace _LPF_Proyecto2_201602975.Clases
{
    class Token
    {
        String lexema;
        int fila;
        int columna;
        int idToken;
        String tipo;

        public Token(String lexema, int fila, int columna, int idToken, String tipo)
        {
            this.Lexema = lexema;
            this.Fila = fila;
            this.Columna = columna;
            this.IdToken = idToken;
            this.Tipo = tipo;
        }

        public string Lexema { get => lexema; set => lexema = value; }
        public int Fila { get => fila; set => fila = value; }
        public int Columna { get => columna; set => columna = value; }
        public int IdToken { get => idToken; set => idToken = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
}
