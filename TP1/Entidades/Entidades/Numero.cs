using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Entidades
{
    public class Numero
    {
        private double _numero;

        public double getNumero()
        {
            return this._numero;
        }        
        public Numero() : this(0)
        {
        }
        public Numero(string cadena)
        {
            setNumero(cadena);
        }
        public Numero(double numero)
        {
            this._numero = numero;
        }

        /// <summary>
        /// Valida si el parametro recibido es un numero
        /// </summary>
        /// <param name="nroCadena">Recibe un string</param>
        /// <returns>Retorna un numero double si es un numero valido o 0 si no lo es</returns>
        private double validarNumero(string nroCadena)
        {
            double aux;
            if(double.TryParse(nroCadena, out aux) == true)
            {
                return aux;
            }
            return 0;
        }

        private void setNumero(string nro)
        {
            double aux = this.validarNumero(nro);
            if(aux != 0)
            {
                this._numero = aux;
            }
        }

        /// <summary>
        /// Convierte un valor binario a valor decimal
        /// </summary>
        /// <param name="cadena">Recibe un string</param>
        /// <returns>Retorna el numero en decimal o sino un mensaje de error</returns>
        public string BinarioDecimal(string cadena)
        {
            string aux = "";
            Regex val = new Regex(@"[0-1]$");

            cadena = cadena.Replace(" ", "");

            if (val.IsMatch(cadena))
            {
                cadena = RevertirString(cadena);
                int digito;
                int i = 0;
                double numDouble = 0;

                while (cadena.Contains("0") || cadena.Contains("1"))
                {
                    digito = (int)Char.GetNumericValue(cadena[i]);
                    numDouble += digito * (Math.Pow(2, i));
                    i++;

                    if (i == cadena.Length)
                    {
                        break;
                    }
                }
                aux = numDouble.ToString();
            }
            else
            {
                aux = "Valor invalido";
            }
            return aux;
        }
        /// <summary>
        /// Invierte los valores de String
        /// </summary>
        /// <param name="cadena">Recibe un string</param>
        /// <returns>Retorna invertido el string</returns>
        public static string RevertirString(string cadena)
        {
            char[] aux = cadena.ToCharArray();
            Array.Reverse(aux);
            return new string(aux);
        }

        /// <summary>
        /// Convierte un valor decimal a valor binario
        /// </summary>
        /// <param name="nro">Recibe un double</param>
        /// <returns>Retorna un numero binario</returns>
        public string DecimalBinario(double nro)
        {
            string cadena = "";
            int aux = Convert.ToInt32(nro);

            if (aux == 0)
            {
                cadena = "0";
            }

            while (aux > 0)
            {
                double operacion = aux % 2;
                aux /= 2;

                if (operacion == 0 || operacion == 1)
                {
                    cadena += Convert.ToString(operacion) + "";
                }
            }

            return RevertirString(cadena);
        }
        /// <summary>
        /// Convierte un valor decimal a valor binario
        /// </summary>
        /// <param name="nro">Recibe un string</param>
        /// <returns>Retorna un numero binario</returns>
        public string DecimalBinario(string nro)
        {
            string aux = "";

            aux = this.DecimalBinario(Convert.ToDouble(nro));

            return aux;
        }

        public static implicit operator double(Numero nro)
        {
            return nro.getNumero();
        }
        public static double operator -(Numero nro1, Numero nro2)
        {
            return nro1._numero - nro2._numero;
        }

        public static double operator +(Numero nro1, Numero nro2)
        {
            return nro1._numero + nro2._numero;
        }

        public static double operator *(Numero nro1, Numero nro2)
        {
            return nro1._numero * nro2._numero;
        }

        public static double operator /(Numero nro1, Numero nro2)
        {
            return nro1._numero / nro2._numero;
        }
    }
}
