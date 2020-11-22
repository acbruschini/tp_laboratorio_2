using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAOs;
using TP4;
using TpExceptions;
using System.Threading;

namespace Formular
{
    public partial class FormPrincipal : Form
    {

        private List<Producto> cuadros;
        private CuadrosDAO cuadrosDAO;

        public List<Producto> Cuadros
        {
            get { return this.cuadros; }
            set { this.cuadros = value; }
        }

        public delegate void Callback();
        public delegate void DelegadoActualizar();
        public event DelegadoActualizar TerminoActualizarCuadrosDB;
        public event DelegadoActualizar ComenzoActualizarCuadrosDB;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void formPrincipalOnLoad(object sender, EventArgs e)
        {
            /* Inicializo una lista de productos que son los que existen en el catalogo.
             * Y una instancia de cuadros DAO para generar el admin. 
             * 
             * */
            this.cuadros = new List<Producto>();

            this.cuadrosDAO = new CuadrosDAO();

            /* En un hilo diferente al principal voy realizar el proceso de la importacion de los datos de la db.
             * Obviamente aca solo va a hacerse eso, pero lo hago en un hilo porque en un producto final podria
             * importarse la base mientras yo puedo interactuar con la otra tabla de las remeras.   * */

            Thread cuadrosCargarDB = new Thread(ActualizarListBoxCuadros);

            this.TerminoActualizarCuadrosDB += ActualizarBox;
            this.TerminoActualizarCuadrosDB += HabilitarBotones;
            this.ComenzoActualizarCuadrosDB += DeshabilitarBotones;


            cuadrosCargarDB.Start();

        }

        /// <summary>
        /// Deshabilita los botones que no puden usarse mietras viva el hilo
        /// </summary>
        private void DeshabilitarBotones()
        {
            this.btn_QuitarCuadro.Enabled = false;
            this.btnAgregarCuadro.Enabled = false;
            this.btnActualizarDbCuadros.Enabled = false;
            this.listBox_Cuadros.Enabled = false;
        }

        /// <summary>
        /// Habilito los botones
        /// </summary>
        private void HabilitarBotones()
        {
            this.btn_QuitarCuadro.Enabled = true;
            this.btnAgregarCuadro.Enabled = true;
            this.btnActualizarDbCuadros.Enabled = true;
            this.listBox_Cuadros.Enabled = true;
        }

        /// <summary>
        /// Conexion a la db
        /// </summary>
        private void ActualizarListBoxCuadros()
        {
            if (!(this.ComenzoActualizarCuadrosDB is null))
            {
                this.Invoke(this.ComenzoActualizarCuadrosDB);
            }
           
            this.cuadrosDAO.TraerDatosDeDB(Cuadros);
            Thread.Sleep(3000); // SIMULO UN RETRASO EN CONEXION DE BASE ETC...
            if (!(this.TerminoActualizarCuadrosDB is null))
            {
                this.Invoke(this.TerminoActualizarCuadrosDB);
            }

        }

        /// <summary>
        /// Manejador del evento que termina de actualizar la db
        /// </summary>
        private void ActualizarBox()
        {
            if (this.listBox_Cuadros.InvokeRequired)
            {
                Callback d = new Callback(this.ActualizarBox);
                this.Invoke(d);
            }
            else
            {
                this.listBox_Cuadros.Items.Clear();
                foreach (Cuadro cuadro in this.Cuadros)
                {
                    this.listBox_Cuadros.Items.Add(cuadro);
                }
            }
        }

        /// <summary>
        /// Quita el cuadro seleccionado de la lista y actualiza la db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_QuitarCuadro_Click(object sender, EventArgs e)
        {
            
            if(this.listBox_Cuadros.SelectedItem != null)
            {
                Cuadro aBorrar = (Cuadro)this.listBox_Cuadros.SelectedItem;
                var result = MessageBox.Show("Desea borrar el Cuadro:\n" + aBorrar.ToString(),"Caption",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.cuadrosDAO.BorrarRowPorCuadro(aBorrar);
                    ActualizarListBoxCuadros();
                }
            }
            
        }

        /// <summary>
        /// Actualiza manualmente la db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualizarDbCuadros_Click(object sender, EventArgs e)
        {
            this.ActualizarListBoxCuadros();
        }

        /// <summary>
        /// Agrega un cuadro a la base.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarCuadro_Click(object sender, EventArgs e)
        {
            AgregarCuadro ac = new AgregarCuadro();
            ac.ShowDialog();
            if(!(ac.Cuadro is null))
            {
                this.cuadrosDAO.AgregarCuadro(ac.Cuadro);
                ActualizarListBoxCuadros();
            }
        }
    }
}
