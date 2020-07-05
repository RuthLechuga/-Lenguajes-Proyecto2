using System;
using System.Collections.Generic;
using System.Linq;

namespace _LPF_Proyecto2_201602975.Clases
{
    class Calculadora
    {
        List<String> operacionPrefija;
        List<Constantes> constantes;
        String resultado;
        String operando;
        Constantes temporal;
        Boolean bandera;
        Double valor;

        public Calculadora()
        {
            operacionPrefija = new List<String>();
            constantes = new List<Constantes>();
            temporal = null;
            resultado = "";
            operando = "";
            bandera = false;
            valor = 0;
        }

        public void preFija(List<String> operacion)
        {
            for(int i=operacion.Count-1;i>=0;i--)
            {
                operando = operacion.ElementAt(i);
                bandera = false;

                if (Comparar(operando, "multiplicar"))
                    operacionPrefija.Add("*");
                else if (Comparar(operando, "dividir"))
                    operacionPrefija.Add("/");
                else if (Comparar(operando, "suma"))
                    operacionPrefija.Add("+");
                else if (Comparar(operando, "resta"))
                    operacionPrefija.Add("-");
                else if (Comparar(operando, "potencia"))
                    operacionPrefija.Add("^");
                else if (Comparar(operando, "raizCuadrada"))
                    operacionPrefija.Add("sqrt");
                else if (Comparar(operando, "seno"))
                    operacionPrefija.Add("sin");
                else if (Comparar(operando, "coseno"))
                    operacionPrefija.Add("cos");
                else if (Comparar(operando, "tangente"))
                    operacionPrefija.Add("tan");
                else if (operando != "(" && operando != ")" && operando != ",")
                {
                    foreach(Constantes C in constantes)
                    {
                        if (Comparar(C.Nombre, operando))
                        {
                            temporal = C;
                            bandera = true;
                        }
                    }

                    if (bandera)
                        operacionPrefija.Add(temporal.Valor);                 
                    else
                    {
                        if(Comparar(operando,"x"))
                            operacionPrefija.Add(valor.ToString());
                        else
                            operacionPrefija.Add(operando);
                    }
                }
            }
        }

        public String calcular(List<String> operacion, List<Constantes> constantes)
        {
            this.constantes = constantes;
            operacionPrefija.Clear();
            preFija(operacion);
            List<Double> operar = new List<Double>();
            double valor1; double valor2;

            foreach (String elemento in operacionPrefija)
            {
                if (elemento == "*" || elemento == "+" || elemento == "-" || elemento == "/" || elemento == "^")
                {
                    valor1 = operar.ElementAt(operar.Count - 1);
                    valor2 = operar.ElementAt(operar.Count - 2);
                    operar.RemoveAt(operar.Count - 1);
                    operar.RemoveAt(operar.Count - 1);

                    if (elemento == "*") operar.Add(valor1 * valor2);
                    else if (elemento == "+") operar.Add(valor1 + valor2);
                    else if (elemento == "/") operar.Add(valor1 / valor2);
                    else if (elemento == "-") operar.Add(valor1 - valor2);
                    else if (elemento == "^") operar.Add(Math.Pow(valor1, valor2));

                }
                else if(Comparar(elemento,"sin") || Comparar(elemento,"cos") || Comparar(elemento, "tan"))
                {
                    valor1 = operar.ElementAt(operar.Count - 1);
                    operar.RemoveAt(operar.Count - 1);

                    if (Comparar(elemento, "sin")) operar.Add(Math.Sin(valor1));
                    else if(Comparar(elemento, "cos")) operar.Add(Math.Cos(valor1));
                    else if(Comparar(elemento, "tan")) operar.Add(Math.Tan(valor1));
                    else if (Comparar(elemento, "sqrt")) operar.Add(Math.Sqrt(valor1));
                }
                else
                {
                    operar.Add(Convert.ToDouble(elemento));
                }

            }
            resultado = operar.ElementAt(0).ToString();
            return resultado;
        }

        public String calcularFuncion(List<String> operacion, List<Constantes> constantes,Double valor)
        {
            this.valor = valor;
            return calcular(operacion, constantes);
        }

        public Boolean Comparar(String cadena1, String cadena2)
        {
            if (String.Compare(cadena1, cadena2, true) == 0)
                return true;
            else
                return false;
        }
    }
}
