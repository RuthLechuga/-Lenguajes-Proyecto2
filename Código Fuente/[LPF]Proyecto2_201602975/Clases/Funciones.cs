using System;
using System.Collections.Generic;

namespace _LPF_Proyecto2_201602975.Clases
{
    public class Funciones
    {
        String nombre;
        List<String> valor;

        public Funciones(String nombre, List<String> valor)
        {
            this.Nombre = nombre;
            this.Valor = valor;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public List<String> Valor { get => valor; set => valor = value; }
    }
}
