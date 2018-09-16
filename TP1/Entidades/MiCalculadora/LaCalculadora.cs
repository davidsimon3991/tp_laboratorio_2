using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        private Calculadora _calculadora;
        public LaCalculadora()
        {
            InitializeComponent();
            _calculadora = new Calculadora();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Convierte el valor de resultado a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text != "" || this.lblResultado.Text != "0")
            {
                Numero num = new Numero(this.lblResultado.Text);

                this.lblResultado.Text = num.DecimalBinario(this.lblResultado.Text);
            }
            else
            {
                this.lblResultado.Text = "Valor Invalido";
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.Operar();
        }

        /// <summary>
        /// Deja en blanco los valores, el operador y el resultado por defecto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Limpiar()
        {
            lblResultado.Text = "Resultado";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.SelectedIndex = -1;
        }
        /// <summary>
        /// Realiza determinada operacion con los 2 numeros       
        private void Operar()
        {
            if(cmbOperador.SelectedIndex == -1)
            {
                cmbOperador.Text = "+";
            }
            if(this.txtNumero1.Text != "" && this.txtNumero2.Text != "")
            {
                double aux;
                aux = _calculadora.Operar(new Numero(txtNumero1.Text.ToString()), new Numero(txtNumero2.Text.ToString()), cmbOperador.Text.ToString());                
                lblResultado.Text = aux.ToString();
            }
        }
        /// <summary>
        /// Convierte en decimal un valor binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text != "" || this.lblResultado.Text != "0")
            {
                Numero num = new Numero(this.lblResultado.Text);

                this.lblResultado.Text = num.BinarioDecimal(this.lblResultado.Text);
            }
            else
            {
                this.lblResultado.Text = "Valor Invalido";
            }
        }
    }
}
