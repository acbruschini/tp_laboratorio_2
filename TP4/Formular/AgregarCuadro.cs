using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP4;
using TpExceptions;

namespace Formular
{
    public partial class AgregarCuadro : Form
    {

        private Cuadro cuadro;

        public Cuadro Cuadro
        {
            get { return this.cuadro; }
        }

        public AgregarCuadro()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Valida y agrega el cuadro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                float precio;
                if (float.TryParse(this.txt_Precio.Text.ToString(), out precio))
                {
                    this.cuadro = new Cuadro(this.txt_Sku.Text.ToString(), this.txt_Nombre.Text.ToString(),precio, this.txt_UbicacionArte.Text.ToString(), this.txt_Tamano.Text.ToString());
                    var result = MessageBox.Show("Seguro que desea agregar el cuadro:\n" + this.cuadro.ToString(), "Caption",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
                else
                {
                    throw new ProductoInvalidoException("Por favor coloque todos los datos.");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Cierra el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
