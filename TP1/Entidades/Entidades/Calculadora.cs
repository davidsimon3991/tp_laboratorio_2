using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida y realiza las operaciones entre 2 numeros en base al operador recibido
        /// </summary>
        /// <param name="nro1">Recibe 1er valor</param>
        /// <param name="nro2">Recibe 2do valorNumero</param>
        /// <param name="operador">Recibe el operador</param>
        /// <returns>Retorna el resultado de las operacion</returns>
        public double Operar(Numero nro1, Numero nro2, string operador)
        {
            operador = this.ValidarOperador(operador);

            if (operador[0] == '+')
            {
                return nro1 + nro2;
            }
            else if (operador[0] == '-')
            {
                return nro1 - nro2;
            }
            else if (operador[0] == '/')
            {
                if (nro2 == 0)
                    return 0;

                return nro1 / nro2;
            }
            else
            {
                return nro1 * nro2;
            }
        }
        /// <summary>
        ///  Valida que el operador sea correcto
        /// </summary>
        /// <param name="operador"> Recibe un string operador</param>
        /// <returns>Retorna el operador y si no es correcto lo determina como "+" </returns>
        private string ValidarOperador(string operador)
        {
            if (operador != "")
            {
                if (operador[0] == '+' || operador[0] == '-' || operador[0] == '/' || operador[0] == '*')
                    return operador;
            }

            return "+";
        }
    }
    
}
