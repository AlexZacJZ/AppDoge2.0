using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDoge
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }

        private void btnExitFormBase_Click(object sender, EventArgs e)
        {
            /*Nos presentara un mensaje el cualpregunte si deseo salir y mostrara un aviso el cual tendra un boton 
             * de SI o NO, Ahora el metodo MessageBoxIcon lo que hara es simplemente mostrarnos un incono de pregunta
             * en la ventana emergente. Si el resultado del boton es = Si 
             */
            if (MessageBox.Show("Desea Salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                this.Close();
        }

        /*Ahora haremos uso de un metodo virtual el cual practicamente es un metodo que permite ser reescrito 
         * desde cualquier parte del codigo o utilizar el original
         */

        public virtual void Eliminar()
        {

        }

        public virtual void Nuevo()
        {

        }

        public virtual void Consultar()
        {

        }

        public virtual bool Guardar()
        {
            return false;
        }
    }
}
