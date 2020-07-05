using System;
using System.Collections.Generic;
using System.Linq;

namespace _LPF_Proyecto2_201602975.Clases
{
    class Analisis
    {
        List<String> palabrasReservadas;
        List<Token> tokens;
        List<ErroresLexicos> erroresLexicos;
        List<ErroresSintacticos> erroresSintacticos;
        List<int> pila;

        int fila;
        int columna;
        int estado;
        int estadoSintaxis;
        int ayudanteC;
        String auxLexico;
        String texto;
        Char c;
        Token temporal;
        Boolean modoPanico;

        public Analisis()
        {
            tokens = new List<Token>();
            erroresLexicos = new List<ErroresLexicos>();
            erroresSintacticos = new List<ErroresSintacticos>();
            palabrasReservadas = new List<String>();
            pila = new List<int>();
            establecerPalabrasReservadas();

            fila = 1;
            columna = 0;
            estado = 0;
            estadoSintaxis = 0;
            ayudanteC = 0;
            auxLexico = "";
            texto = "";
            c = (char)00;
            modoPanico = false;
        }

        //AFD PARA ANÁLISIS LÉXICO
        public List<Token> analizar(String Texto)
        {
            texto = Texto + " ";
            sintaxis();
            for (int i = 0; i < texto.Length; i++)
            {
                c = texto[i];

                switch (estado)
                {
                    case 0:
                        columna++;
                        if (Char.IsLetter(c))
                        {
                            auxLexico += c;
                            estado = 1;
                        }
                        else if (Char.IsDigit(c))
                        {
                            auxLexico += c;
                            estado = 2;
                        }
                        else if (c == '/' && texto[i + 1] == '/')
                            i = comentarioSimple(i + 2) - 1;
                        else if (c == '/' && texto[i + 1] == '*')
                            i = comentarioCompuesto(i + 2);
                        else if (c == (char)10)
                        {
                            fila++;
                            columna = 0;
                        }
                        else if (c == ' ') ;
                        else
                        {
                            estado = 5;
                            i--;
                            columna--;
                        }
                        break;

                    case 1:
                        columna++;
                        if (Char.IsLetter(c) || Char.IsDigit(c) || c == '_')
                            auxLexico += c;
                        else if (c == '/' && texto[i + 1] == '/')
                            i = comentarioSimple(i + 2) - 1;
                        else if (c == '/' && texto[i + 1] == '*')
                            i = comentarioCompuesto(i + 2);
                        else
                        {
                            if (esReservada(auxLexico))
                                agregarToken(auxLexico, "Palabra Reservada", 1);
                            else
                                agregarToken(auxLexico, "Identificador", 8);

                            estado = 0;
                            i--;
                            columna -= 2;
                            auxLexico = "";
                        }
                        break;

                    case 2:
                        columna++;
                        if (Char.IsDigit(c))
                            auxLexico += c;
                        else if (c == '/' && texto[i + 1] == '/')
                            i = comentarioSimple(i + 2) - 1;
                        else if (c == '/' && texto[i + 1] == '*')
                            i = comentarioCompuesto(i + 2);
                        else if (c == '.')
                        {
                            estado = 3;
                            auxLexico += c;
                        }
                        else
                        {
                            agregarToken(auxLexico, "Número", 9);
                            estado = 0;
                            i--;
                            columna -= 2;
                            auxLexico = "";
                        }
                        break;

                    case 3:
                        columna++;
                        if (Char.IsDigit(c))
                        {
                            estado = 4;
                            auxLexico += c;
                        }
                        else if (c == '/' && texto[i + 1] == '/')
                            i = comentarioSimple(i + 2) - 1;
                        else if (c == '/' && texto[i + 1] == '*')
                            i = comentarioCompuesto(i + 2);
                        else
                        {
                            estado = 0;
                            i--;
                            columna -= 2;
                            auxLexico = "";
                        }
                        break;

                    case 4:
                        columna++;
                        if (Char.IsDigit(c))
                            auxLexico += c;
                        else if (c == '/' && texto[i + 1] == '/')
                            i = comentarioSimple(i + 2) - 1;
                        else if (c == '/' && texto[i + 1] == '*')
                            i = comentarioCompuesto(i + 2);
                        else
                        {
                            agregarToken(auxLexico, "Número", 9);
                            estado = 0;
                            i--;
                            columna -= 2;
                            auxLexico = "";
                        }
                        break;

                    case 5:
                        columna++;
                        if (c == '(')
                            agregarToken("(", "Parentesis Izquierdo", 2);
                        else if (c == ')')
                            agregarToken(")", "Parentesis Derecho", 3);
                        else if (c == '=')
                            agregarToken("=", "Signo igual", 4);
                        else if (c == ',')
                            agregarToken(",", "Coma", 6);
                        else if (c == '"')
                        {
                            agregarToken(c.ToString(), "Comillas", 7);
                            i = Cadena(i + 1);
                            agregarToken(c.ToString(), "Comillas", 7);
                        }
                        else erroresLexicos.Add(new ErroresLexicos(fila, columna, c.ToString(), "Caracter Desconocido"));

                        estado = 0;

                        break;
                }

            }

            return tokens;
        }

        //MÉTODO PARA EL MANEJO DE SINTAXIS
        public void sintaxis()
        {
            switch (estadoSintaxis)
            {
                case 0:
                    push(TNT.FIN_PILA1);
                    estadoSintaxis = 1;
                    sintaxis();
                    break;

                case 1:
                    push(TNT.FIN_MATH1);
                    push(TNT.FIN_GENERACION_GRAFICAS1);
                    push(TNT.CUERPO_GENERACION_GRAFICAS1);
                    push(TNT.INICIO_GENERACION_GRAFICAS1);
                    push(TNT.FIN_DECLARACION_FUNCIONES1);
                    push(TNT.CUERPO_DECLARACION_FUNCIONES1);
                    push(TNT.INICIO_DECLARACION_FUNCIONES1);
                    push(TNT.FIN_DECLARACION_CV1);
                    push(TNT.CUERPO_DECLARACION_CV1);
                    push(TNT.INICIO_DECLARACION_CV1);
                    push(TNT.INICIO_MATH1);
                    estadoSintaxis = 2;
                    break;

                case 2:
                    validarPila();

                    if (top() == obtenerID(temporal.Lexema))
                        pop();
                    else if (top() == 101 && (temporal.IdToken == 8 || temporal.IdToken == 9))
                        pop();
                    else if (top() == 101 && temporal.IdToken == 1)
                    {
                        if (Comparar(temporal.Lexema, "suma") || Comparar(temporal.Lexema, "resta") ||
                           Comparar(temporal.Lexema, "multiplicar") || Comparar(temporal.Lexema, "dividir") ||
                           Comparar(temporal.Lexema, "potencia"))
                        {
                            pop();
                            push(TNT.OPERACIONCOMPUESTA1);
                            validarPila();
                        }
                        else if (Comparar(temporal.Lexema, "coseno") || Comparar(temporal.Lexema, "seno") ||
                                Comparar(temporal.Lexema, "raizCuadrada") || Comparar(temporal.Lexema, "tangente"))
                        {
                            pop();
                            push(TNT.OPERACIONSIMPLE1);
                            validarPila();
                        }
                        else
                        {
                            erroresSintacticos.Add(new ErroresSintacticos(fila, columna, "Se esperaba una operación"));
                            modoPanico = true;
                            gestionErrores();
                        }
                    }
                    else if (top() == 102 && (temporal.IdToken == 8 || temporal.IdToken == 9))
                        pop();
                    else if (top() == 103 && (temporal.IdToken == 10))
                        pop();
                    else if (top() == 104 && (temporal.IdToken == 8))
                        pop();
                    else if (top() == 105 && (Comparar(temporal.Lexema, "entero") || Comparar(temporal.Lexema, "decimal") || Comparar(temporal.Lexema, "cadena")))
                        pop();
                    else
                    {
                        String temporalP = obtenerPalabra(top());
                        if (temporalP != "")
                            erroresSintacticos.Add(new ErroresSintacticos(fila, columna, "Se esperaba " + temporalP));

                        modoPanico = true;
                        gestionErrores();
                    }
                    break;

                case 3:
                        pop();
                        pop();
                    break;
            }
        }


        //MÉTODO RECURSIVO PARA EL MANEJO DE LA PILA EN DEPENDENCIA DE TERMINALES Y NO TERMINALES
        public void validarPila()
        {
            if (top() < 50)
            {
                //ESTRUCTURA GENERAL 
                if (top() == TNT.INICIO_MATH1)
                {
                    pop();
                    push(TNT.MATH1);
                    push(TNT.INICIO1);
                }
                else if (top() == TNT.FIN_MATH1)
                {
                    pop();
                    push(TNT.MATH1);
                    push(TNT.FIN1);
                    validarPila();
                    estadoSintaxis = 3;
                }
                else if (top() == TNT.NTNOMBRE1)
                {
                    pop();
                    push(TNT.Identificador);
                    push(TNT.ASG1);
                    push(TNT.NOMBRE1);
                }
                else if (top() == TNT.NTVALOR1)
                {
                    pop();
                    push(TNT.Identificador);
                    push(TNT.ASG1);
                    push(TNT.VALOR1);
                }
                else if(top() == TNT.OPERACIONCOMPUESTA1)
                {
                    pop();
                    push(TNT.PARENTESISD1);
                    push(TNT.Identificador);
                    push(TNT.COMA1);
                    push(TNT.Identificador);
                    push(TNT.PARENTESISI1);
                }
                else if(top() == TNT.OPERACIONSIMPLE1)
                {
                    pop();
                    push(TNT.PARENTESISD1);
                    push(TNT.Identificador);
                    push(TNT.PARENTESISI1);
                }
                else if(top() == TNT.NTXPOSITIVO1)
                {
                    pop();
                    push(TNT.Identificador);
                    push(TNT.ASG1);
                    push(TNT.XPOSITIVO1);
                }
                else if(top() == TNT.NTXNEGATIVO1)
                {
                    pop();
                    push(TNT.NID1);
                    push(TNT.ASG1);
                    push(TNT.XNEGATIVO1);
                }
                else if(top() == TNT.NTYPOSITIVO1)
                {
                    pop();
                    push(TNT.NID1);
                    push(TNT.ASG1);
                    push(TNT.YPOSITIVO1);
                }
                else if (top() == TNT.NTYNEGATIVO1)
                {
                    pop();
                    push(TNT.NID1);
                    push(TNT.ASG1);
                    push(TNT.YNEGATIVO1);
                }
                else if (top() == TNT.NTLARGO1)
                {
                    pop();
                    push(TNT.NID1);
                    push(TNT.ASG1);
                    push(TNT.LARGO1);
                }
                else if (top() == TNT.NTANCHO1)
                {
                    pop();
                    push(TNT.NID1);
                    push(TNT.ASG1);
                    push(TNT.ANCHO1);
                }
                else if(top() == TNT.NTRUTA1)
                {
                    pop();
                    push(TNT.COMILLAS1);
                    push(TNT.Cadena);
                    push(TNT.COMILLAS1);
                    push(TNT.ASG1);
                    push(TNT.RUTA1);
                }
                else if (top() == TNT.NTFUNCIONG1)
                {
                    pop();
                    push(TNT.Cons);
                    push(TNT.ASG1);
                    push(TNT.FUNCION1);
                }
                else if(top() == TNT.NTTIPO1)
                {
                    pop();
                    push(TNT.Pl);
                    push(TNT.ASG1);
                    push(TNT.TIPO1);
                }
                else if(top() == TNT.AC1)
                {
                    if(ayudanteC == 1)
                    {
                        if (Comparar(temporal.Lexema, "tipo"))
                        {
                            pop();
                            push(TNT.NTVALOR1);
                            push(TNT.COMA1);
                            push(TNT.NTTIPO1);
                            validarPila();
                        }
                        else
                        {
                            pop();
                            push(TNT.NTTIPO1);
                            push(TNT.COMA1);
                            push(TNT.NTVALOR1);
                            validarPila();
                        }
                    }
                    else if(ayudanteC == 2)
                    {
                        if (Comparar(temporal.Lexema, "nombre"))
                        {
                            pop();
                            push(TNT.NTVALOR1);
                            push(TNT.COMA1);
                            push(TNT.NTNOMBRE1);
                            validarPila();
                        }
                        else
                        {
                            pop();
                            push(TNT.NTNOMBRE1);
                            push(TNT.COMA1);
                            push(TNT.NTVALOR1);
                            validarPila();
                        }
                    }
                    else
                    {
                        if (Comparar(temporal.Lexema, "nombre"))
                        {
                            pop();
                            push(TNT.NTTIPO1);
                            push(TNT.COMA1);
                            push(TNT.NTNOMBRE1);
                            validarPila();
                        }
                        else
                        {
                            pop();
                            push(TNT.NTNOMBRE1);
                            push(TNT.COMA1);
                            push(TNT.NTTIPO1);
                            validarPila();
                        }
                    }
                }

                //MANEJO PILA PARA DECLARACIÓN DE VARIABLES Y CONSTANTES
                else if (top() == TNT.INICIO_DECLARACION_CV1)
                {
                    pop();
                    push(TNT.VARIABLES1);
                    push(TNT.Y1);
                    push(TNT.CONSTANTES1);
                    push(TNT.DECLARACION1);
                    push(TNT.INICIO1);
                }
                else if (top() == TNT.CUERPO_DECLARACION_CV1)
                {
                    if (obtenerID(temporal.Lexema) == 53)
                    {
                        pop();
                        validarPila();
                    }
                    else
                    {
                        pop();
                        push(TNT.CUERPO_DECLARACION_CV1);
                        push(TNT.FIN_CONSTANTE1);
                        push(TNT.CUERPO_CONSTANTE1);
                        push(TNT.INICIO_CONSTANTE1);
                        validarPila();
                    }
                }
                else if (top() == TNT.INICIO_CONSTANTE1)
                {
                    pop();
                    push(TNT.CONSTANTE1);
                    push(TNT.INICIO1);
                    ayudanteC = 0;
                }
                else if (top() == TNT.CUERPO_CONSTANTE1)
                {
                    if (obtenerID(temporal.Lexema) == 53)
                    {
                        pop();
                        validarPila();
                    }
                    else
                    {
                        if (Comparar(temporal.Lexema, "nombre"))
                        {
                            pop();
                            push(TNT.CUERPO_DECLARACION_CV1);
                            push(TNT.AC1);
                            push(TNT.COMA1);
                            push(TNT.NTNOMBRE1);
                            ayudanteC = 1;
                            validarPila();
                        } 
                        else if (Comparar(temporal.Lexema, "tipo"))
                        {
                            pop();
                            push(TNT.CUERPO_DECLARACION_CV1);
                            push(TNT.AC1);
                            push(TNT.COMA1);
                            push(TNT.NTTIPO1);
                            ayudanteC = 2;
                            validarPila();
                        }
                        else
                        {
                            pop();
                            push(TNT.CUERPO_DECLARACION_CV1);
                            push(TNT.AC1);
                            push(TNT.COMA1);
                            push(TNT.NTVALOR1);
                            ayudanteC = 3;
                            validarPila();
                        }
                    }
                }
                else if (top() == TNT.FIN_CONSTANTE1)
                {
                    pop();
                    push(TNT.CONSTANTE1);
                    push(TNT.FIN1);
                }
                else if (top() == TNT.FIN_DECLARACION_CV1)
                {
                    pop();
                    push(TNT.VARIABLES1);
                    push(TNT.Y1);
                    push(TNT.CONSTANTES1);
                    push(TNT.DECLARACION1);
                    push(TNT.FIN1);
                }


                //MANEJO PILA PARA DECLARACIÓN DE FUNCIONES
                else if (top() == TNT.INICIO_DECLARACION_FUNCIONES1)
                {
                    pop();
                    push(TNT.FUNCIONES1);
                    push(TNT.DECLARACION1);
                    push(TNT.INICIO1);
                }
                else if (top() == TNT.CUERPO_DECLARACION_FUNCIONES1)
                {
                    if (obtenerID(temporal.Lexema) == 53)
                    {
                        pop();
                        validarPila();
                    }
                    else
                    {
                        pop();
                        push(TNT.CUERPO_DECLARACION_FUNCIONES1);
                        push(TNT.FIN_FUNCION1);
                        push(TNT.CUERPO_FUNCION1);
                        push(TNT.INICIO_FUNCION1);
                        validarPila();
                    }
                }
                else if (top() == TNT.INICIO_FUNCION1)
                {
                    pop();
                    push(TNT.FUNCION1);
                    push(TNT.INICIO1);
                }
                else if (top() == TNT.CUERPO_FUNCION1)
                {
                    if (obtenerID(temporal.Lexema) == 53)
                    {
                        pop();
                        validarPila();
                    }
                    else
                    {
                        if (obtenerID(temporal.Lexema) == TNT.NOMBRE1)
                        {
                            pop();
                            push(TNT.NTVALOR1);
                            push(TNT.COMA1);
                            push(TNT.NTNOMBRE1);
                        }
                        else
                        {
                            pop();
                            push(TNT.NTNOMBRE1);
                            push(TNT.COMA1);
                            push(TNT.NTVALOR1);
                        }
                        validarPila();
                    }
                }
                else if (top() == TNT.FIN_FUNCION1)
                {
                    pop();
                    push(TNT.FUNCION1);
                    push(TNT.FIN1);
                }
                else if (top() == TNT.FIN_DECLARACION_FUNCIONES1)
                {
                    pop();
                    push(TNT.FUNCIONES1);
                    push(TNT.DECLARACION1);
                    push(TNT.FIN1);
                }


                //MANEJO PILA PARA DECLARACIÓN DE GRÁFICAS
                else if (top() == TNT.INICIO_GENERACION_GRAFICAS1)
                {
                    pop();
                    push(TNT.GRAFICAS1);
                    push(TNT.GENERACION1);
                    push(TNT.INICIO1);
                }
                else if (top() == TNT.CUERPO_GENERACION_GRAFICAS1)
                {
                    if (obtenerID(temporal.Lexema) == 53)
                    {
                        pop();
                        validarPila();
                    }
                    else
                    {
                        pop();
                        push(TNT.CUERPO_GENERACION_GRAFICAS1);
                        push(TNT.FIN_GRAFICA1);
                        push(TNT.CUERPO_GRAFICA1);
                        push(TNT.INICIO_GRAFICA1);
                        validarPila();
                    }
                }
                else if (top() == TNT.INICIO_GRAFICA1)
                {
                    pop();
                    push(TNT.GRAFICA1);
                    push(TNT.INICIO1);
                }
                else if (top() == TNT.CUERPO_GRAFICA1)
                {
                    if (obtenerID(temporal.Lexema) == 53)
                    {
                        pop();
                        validarPila();
                    }
                    else
                    {
                        pop();
                        push(TNT.NTFUNCIONG1);
                        push(TNT.COMA1);
                        push(TNT.NTRUTA1);
                        push(TNT.COMA1);
                        push(TNT.NTLARGO1);
                        push(TNT.COMA1);
                        push(TNT.NTANCHO1);
                        push(TNT.COMA1);
                        push(TNT.NTYNEGATIVO1);
                        push(TNT.COMA1);
                        push(TNT.NTYPOSITIVO1);
                        push(TNT.COMA1);
                        push(TNT.NTXNEGATIVO1);
                        push(TNT.COMA1);
                        push(TNT.NTXPOSITIVO1);
                        push(TNT.COMA1);
                        push(TNT.NTNOMBRE1);
                        validarPila();
                    }
                }
                else if (top() == TNT.FIN_GRAFICA1)
                {
                    pop();
                    push(TNT.GRAFICA1);
                    push(TNT.FIN1);
                }
                else if (top() == TNT.FIN_GENERACION_GRAFICAS1)
                {
                    pop();
                    push(TNT.GRAFICAS1);
                    push(TNT.GENERACION1);
                    push(TNT.FIN1);
                }
            }
        }

        public void gestionErrores()
        {
            modoPanico = true;
            while (!top().Equals(TNT.INICIO1) && !top().Equals(TNT.FIN1) && !top().Equals(TNT.INICIO_DECLARACION_CV1)
                    && !top().Equals(TNT.INICIO_DECLARACION_FUNCIONES1) && !top().Equals(TNT.INICIO_GENERACION_GRAFICAS1)
                    && top() != 99)
            {
                pop();
            }
        }

        public Boolean Comparar(String cadena1, String cadena2)
        {
            if (String.Compare(cadena1, cadena2, true) == 0)
                return true;
            else
                return false;
        }

        public Boolean esReservada(String palabra)
        {
            foreach (String elemento in palabrasReservadas)
            {
                if (Comparar(elemento, palabra))
                    return true;
            }
            return false;
        }

        public void agregarToken(String lexema, String tipo, int id_tipo)
        {
            temporal = new Token(lexema, fila, columna, id_tipo, tipo);
            if (Comparar(lexema, "inicio"))
                modoPanico = false;

            if (!modoPanico)
                sintaxis();

            tokens.Add(temporal);
        }

        public int comentarioSimple(int pos)
        {
            while (pos < texto.Length && texto[pos] != (char)10)
                pos++;
            return pos;
        }

        public int comentarioCompuesto(int pos)
        {
            while (pos < texto.Length && !(texto[pos] == '*' && texto[pos + 1] == '/'))
            {
                if (texto[pos] == (char)10)
                {
                    fila += 1;
                    columna = 0;
                }
                else
                {
                    columna += 1;
                }
                pos++;
            }

            if (pos == texto.Length && !(texto[pos - 1] == '*' && texto[pos] == '/'))
                erroresSintacticos.Add(new ErroresSintacticos(fila, columna, "Falta un */"));

            return pos + 1;
        }

        public int Cadena(int pos)
        {
            String cadena = "";

            while (pos < texto.Length && texto[pos] != '"' && texto[pos] != (char)10)
            {
                cadena += texto[pos];
                columna += 1;
                pos++;
            }

            if (texto[pos] == (char)10 && texto[pos] != '"')
                erroresSintacticos.Add(new ErroresSintacticos(fila, columna, "Faltan comillas de cierre"));
            else
            {
                agregarToken(cadena, "Cadena", 10);
                validarPila();
            }

            return pos;
        }

        public void push(int c)
        {
            pila.Add(c);
        }

        public void pop()
        {
            if (pila.Count > 0)
                pila.RemoveAt(pila.Count - 1);
        }

        public int top()
        {
            if (pila.Count > 0)
                return pila.ElementAt(pila.Count - 1);
            else
                return 0;
        }

        public List<ErroresLexicos> obtenerErroresLexicos()
        {
            return erroresLexicos;
        }

        public List<ErroresSintacticos> obtenerErroresSintacticos()
        {
            return erroresSintacticos;
        }

        private void establecerPalabrasReservadas()
        {
            palabrasReservadas.Add("inicio");
            palabrasReservadas.Add("math");
            palabrasReservadas.Add("declaracion");
            palabrasReservadas.Add("constantes");
            palabrasReservadas.Add("y");
            palabrasReservadas.Add("constante");
            palabrasReservadas.Add("variables");
            palabrasReservadas.Add("fin");
            palabrasReservadas.Add("nombre");
            palabrasReservadas.Add("tipo");
            palabrasReservadas.Add("valor");
            palabrasReservadas.Add("funciones");
            palabrasReservadas.Add("funcion");
            palabrasReservadas.Add("generacion");
            palabrasReservadas.Add("graficas");
            palabrasReservadas.Add("x_positivo");
            palabrasReservadas.Add("y_positivo");
            palabrasReservadas.Add("x_negativo");
            palabrasReservadas.Add("y_negativo");
            palabrasReservadas.Add("ancho");
            palabrasReservadas.Add("largo");
            palabrasReservadas.Add("ruta");
            palabrasReservadas.Add("funcion");
            palabrasReservadas.Add("suma");
            palabrasReservadas.Add("resta");
            palabrasReservadas.Add("multiplicar");
            palabrasReservadas.Add("dividir");
            palabrasReservadas.Add("potencia");
            palabrasReservadas.Add("raizCuadrada");
            palabrasReservadas.Add("seno");
            palabrasReservadas.Add("coseno");
            palabrasReservadas.Add("tangente");
            palabrasReservadas.Add("entero");
            palabrasReservadas.Add("decimal");
            palabrasReservadas.Add("cadena");
        }

        public int obtenerID(String palabra)
        {
            if (Comparar(palabra, ","))
                return 67;
            else if (Comparar(palabra, "="))
                return 68;
            else if (Comparar(palabra, ")"))
                return 69;
            else if (Comparar(palabra, "("))
                return 70;
            else if (Comparar(palabra, "inicio"))
                return 51;
            else if (Comparar(palabra, "math"))
                return 52;
            else if (Comparar(palabra, "fin"))
                return 53;
            else if (Comparar(palabra, "declaracion"))
                return 54;
            else if (Comparar(palabra, "constantes"))
                return 55;
            else if (Comparar(palabra, "y"))
                return 56;
            else if (Comparar(palabra, "variables"))
                return 57;
            else if (Comparar(palabra, "funciones"))
                return 58;
            else if (Comparar(palabra, "generacion"))
                return 59;
            else if (Comparar(palabra, "graficas"))
                return 60;
            else if (Comparar(palabra, "constante"))
                return 61;
            else if (Comparar(palabra, "funcion"))
                return 62;
            else if (Comparar(palabra, "grafica"))
                return 63;
            else if (Comparar(palabra, "nombre"))
                return 64;
            else if (Comparar(palabra, "tipo"))
                return 65;
            else if (Comparar(palabra, "valor"))
                return 66;
            else if (Comparar(palabra, "suma"))
                return 71;
            else if (Comparar(palabra, "resta"))
                return 71;
            else if (Comparar(palabra, "multiplicar"))
                return 71;
            else if (Comparar(palabra, "dividir"))
                return 71;
            else if (Comparar(palabra, "potencia"))
                return 71;
            else if (Comparar(palabra, "raizCuadrada"))
                return 72;
            else if (Comparar(palabra, "seno"))
                return 72;
            else if (Comparar(palabra, "coseno"))
                return 72;
            else if (Comparar(palabra, "tangente"))
                return 72;
            else if (Comparar(palabra, "x_positivo"))
                return 73;
            else if (Comparar(palabra, "x_negativo"))
                return 74;
            else if (Comparar(palabra, "y_positivo"))
                return 75;
            else if (Comparar(palabra, "y_negativo"))
                return 76;
            else if (Comparar(palabra, "ancho"))
                return 77;
            else if (Comparar(palabra, "largo"))
                return 78;
            else if (Comparar(palabra, "ruta"))
                return 79;
            else if (Comparar(palabra, ('"').ToString()))
                return 81;
            else if (Comparar(palabra,"Entero"))
                return 82;
            else if (Comparar(palabra, "Decimal"))
                return 83;
            else if (Comparar(palabra, "Cadena"))
                return 84;
            else
                return 100;
        }

        public String obtenerPalabra(int id)
        {
            switch (id)
            {
                case 3: return "fin";
                case 6: return "fin";
                case 9: return "fin";
                case 13: return "fin";
                case 51: return "inicio";
                case 52: return "math";
                case 53: return "fin";
                case 54: return "declaracion";
                case 55: return "constantes";
                case 56: return "y";
                case 57: return "variables";
                case 58: return "funciones";
                case 59: return "generacion";
                case 60: return "graficas";
                case 61: return "constante";
                case 62: return "funcion";
                case 63: return "grafica";
                case 64: return "nombre";
                case 65: return "tipo";
                case 66: return "valor";
                case 67: return "una coma";
                case 68: return "una igualación";
                case 69: return "un parentesis derecho";
                case 70: return "un parentesis izquierdo";
                case 71: return "una operación";
                case 72: return "una operación";
                case 73: return "x_positivo";
                case 74: return "x_negativo";
                case 75: return "y_positivo";
                case 76: return "y_negativo";
                case 77: return "ancho";
                case 78: return "largo";
                case 79: return "ruta";
                case 81: return ('"').ToString();
                case 82: return "el tipo de dato: Entero|Decimal|Cadena";
                default: return "";
            }
        }
    }
}
