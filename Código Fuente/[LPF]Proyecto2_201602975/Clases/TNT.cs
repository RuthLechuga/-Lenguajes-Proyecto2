namespace _LPF_Proyecto2_201602975.Clases
{
    /// <summary>
    /// Clase estática que especifica el identificador 
    /// constante de los terminales y no terminales
    /// </summary>
    static class TNT
    {
        private const int FIN_PILA = 99;

        //NO TERMINALES
        private const int INICIO_MATH = 1;
        private const int INICIO_DECLARACION_CV = 2;
        private const int CUERPO_DECLARACION_CV = 3;
        private const int FIN_DECLARACION_CV = 4;
        private const int INICIO_DECLARACION_FUNCIONES = 5;
        private const int CUERPO_DECLARACION_FUNCIONES = 6;
        private const int FIN_DECLARACION_FUNCIONES = 7;
        private const int INICIO_GENERACION_GRAFICAS = 8;
        private const int CUERPO_GENERACION_GRAFICAS = 9;
        private const int FIN_GENERACION_GRAFICAS = 10;
        private const int FIN_MATH = 11;
        private const int INICIO_CONSTANTE = 12;
        private const int CUERPO_CONSTANTE = 13;
        private const int FIN_CONSTANTE = 14;
        private const int INICIO_FUNCION = 15;
        private const int CUERPO_FUNCION = 16;
        private const int FIN_FUNCION = 17;
        private const int INICIO_GRAFICA = 18;
        private const int CUERPO_GRAFICA = 19;
        private const int FIN_GRAFICA = 20;
        private const int NTNOMBRE = 22;
        private const int NTTIPO = 23;
        private const int NTVALOR = 24;
        private const int OPERACIONCOMPUESTA = 26;
        private const int OPERACIONSIMPLE = 27;
        private const int NTXPOSITIVO = 28;
        private const int NTXNEGATIVO = 29;
        private const int NTYPOSITIVO = 30;
        private const int NTYNEGATIVO = 31;
        private const int NTANCHO = 32;
        private const int NTLARGO = 33;
        private const int NTRUTA = 34;
        private const int NTFUNCIONG = 35;
        private const int AC = 36;

        //TERMINALES
        private const int INICIO = 51;
        private const int MATH = 52;
        private const int FIN = 53;
        private const int DECLARACION = 54;
        private const int CONSTANTES = 55;
        private const int Y = 56;
        private const int VARIABLES = 57;
        private const int FUNCIONES = 58;
        private const int GENERACION = 59;
        private const int GRAFICAS = 60;
        private const int CONSTANTE = 61;
        private const int FUNCION = 62;
        private const int GRAFICA = 63;
        private const int NOMBRE = 64;
        private const int TIPO = 65;
        private const int VALOR = 66;
        private const int COMA = 67;
        private const int ASG = 68;
        private const int PARENTESISD = 69;
        private const int PARENTESISI = 70;
        private const int SUMA = 71;
        private const int RESTA = 71;
        private const int DIVIDIR = 71;
        private const int MULTIPLICAR = 71;
        private const int POTENCIA = 71;
        private const int RAIZ = 72;
        private const int SENO = 72;
        private const int COSENO = 72;
        private const int TANGENTE = 72;
        private const int XPOSITIVO = 73;
        private const int XNEGATIVO = 74;
        private const int YPOSITIVO = 75;
        private const int YNEGATIVO = 76;
        private const int ANCHO = 77;
        private const int LARGO = 78;
        private const int RUTA = 79;
        private const int COMILLAS = 81;
        private const int ENTERO = 82;
        private const int DECIMAL = 82;
        private const int CADENA = 82;

        //OTROS
        private const int identificador = 101; //identificador de constantes, numeros, operaciones 
        private const int NID = 102; //identificador de número y constantes
        private const int cadena = 103; //identificador de cadenas
        private const int cons = 104; //identificador de constantes
        private const int pl = 105; //identificador pare Entero|decimal|cadena

        public static int FIN_PILA1 => FIN_PILA;
        public static int INICIO_MATH1 => INICIO_MATH;
        public static int INICIO_DECLARACION_CV1 => INICIO_DECLARACION_CV;
        public static int CUERPO_DECLARACION_CV1 => CUERPO_DECLARACION_CV;
        public static int INICIO_DECLARACION_FUNCIONES1 => INICIO_DECLARACION_FUNCIONES;
        public static int CUERPO_DECLARACION_FUNCIONES1 => CUERPO_DECLARACION_FUNCIONES;
        public static int FIN_DECLARACION_FUNCIONES1 => FIN_DECLARACION_FUNCIONES;
        public static int INICIO_GENERACION_GRAFICAS1 => INICIO_GENERACION_GRAFICAS;
        public static int CUERPO_GENERACION_GRAFICAS1 => CUERPO_GENERACION_GRAFICAS;
        public static int FIN_GENERACION_GRAFICAS1 => FIN_GENERACION_GRAFICAS;
        public static int FIN_MATH1 => FIN_MATH;
        public static int INICIO1 => INICIO;
        public static int MATH1 => MATH;
        public static int FIN1 => FIN;
        public static int DECLARACION1 => DECLARACION;
        public static int CONSTANTES1 => CONSTANTES;
        public static int Y1 => Y;
        public static int VARIABLES1 => VARIABLES;
        public static int FIN_DECLARACION_CV1 => FIN_DECLARACION_CV;
        public static int FUNCIONES1 => FUNCIONES;
        public static int GRAFICAS1 => GRAFICAS;
        public static int GENERACION1 => GENERACION;
        public static int INICIO_CONSTANTE1 => INICIO_CONSTANTE;
        public static int CUERPO_CONSTANTE1 => CUERPO_CONSTANTE;
        public static int FIN_CONSTANTE1 => FIN_CONSTANTE;
        public static int CONSTANTE1 => CONSTANTE;
        public static int INICIO_FUNCION1 => INICIO_FUNCION;
        public static int CUERPO_FUNCION1 => CUERPO_FUNCION;
        public static int FIN_FUNCION1 => FIN_FUNCION;
        public static int FUNCION1 => FUNCION;
        public static int INICIO_GRAFICA1 => INICIO_GRAFICA;
        public static int CUERPO_GRAFICA1 => CUERPO_GRAFICA;
        public static int FIN_GRAFICA1 => FIN_GRAFICA;
        public static int GRAFICA1 => GRAFICA;
        public static int NTNOMBRE1 => NTNOMBRE;
        public static int NTTIPO1 => NTTIPO;
        public static int NTVALOR1 => NTVALOR;
        public static int NOMBRE1 => NOMBRE;
        public static int TIPO1 => TIPO;
        public static int VALOR1 => VALOR;
        public static int COMA1 => COMA;
        public static int ASG1 => ASG;
        public static int Identificador => identificador;
        public static int PARENTESISD1 => PARENTESISD;
        public static int PARENTESISI1 => PARENTESISI;
        public static int SUMA1 => SUMA;
        public static int RESTA1 => RESTA;
        public static int DIVIDIR1 => DIVIDIR;
        public static int MULTIPLICAR1 => MULTIPLICAR;
        public static int POTENCIA1 => POTENCIA;
        public static int RAIZ1 => RAIZ;
        public static int SENO1 => SENO;
        public static int COSENO1 => COSENO;
        public static int TANGENTE1 => TANGENTE;
        public static int OPERACIONCOMPUESTA1 => OPERACIONCOMPUESTA;
        public static int OPERACIONSIMPLE1 => OPERACIONSIMPLE;
        public static int NTXPOSITIVO1 => NTXPOSITIVO;
        public static int NTXNEGATIVO1 => NTXNEGATIVO;
        public static int NTYPOSITIVO1 => NTYPOSITIVO;
        public static int NTYNEGATIVO1 => NTYNEGATIVO;
        public static int NTANCHO1 => NTANCHO;
        public static int NTLARGO1 => NTLARGO;
        public static int NTRUTA1 => NTRUTA;
        public static int NTFUNCIONG1 => NTFUNCIONG;
        public static int XPOSITIVO1 => XPOSITIVO;
        public static int XNEGATIVO1 => XNEGATIVO;
        public static int YPOSITIVO1 => YPOSITIVO;
        public static int YNEGATIVO1 => YNEGATIVO;
        public static int ANCHO1 => ANCHO;
        public static int LARGO1 => LARGO;
        public static int RUTA1 => RUTA;
        public static int NID1 => NID;
        public static int Cadena => cadena;
        public static int Cons => cons;
        public static int COMILLAS1 => COMILLAS;
        public static int Pl => pl;
        public static int AC1 => AC;
    }
}
