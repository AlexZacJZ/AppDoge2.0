using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtileriaDLL;

namespace AppDoge
{
    public partial class MantenimientoCliente : Mantenimiento
    {
        public MantenimientoCliente()
        {
            InitializeComponent();
        }

        public override bool Guardar()
        {
            /*Lo que hace el if con el nuevo procedimiento de ValidarFormulario es, Si no encuentra ningun error 
             procedera a almacenar la informacion en la base de datos, recordando que el unico error que 
            estamos validando es que si el Txt se encuentra nulo/Vacio*/
            if (MiLibreria.ValidarFormulario(this, errorProvider1) == false)
            {
                try
                {
                    string cdm = string.Format("Exec ActualizaCliente '{0}','{1}','{2}','{3}','{4}'", txtId.Text.Trim(),
                        txtNombre.Text.Trim(), txtApellido.Text.Trim(), txtNit.Text.Trim(), txtTelefono.Text.Trim());
                    MiLibreria.Ejecutar(cdm);
                    MessageBox.Show("Se ha guardado correctamente");
                    return true;
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Ha ocurrido un error: " + exp.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public override void Eliminar()
        {
            try
            {
                string cmd = string.Format("Exec EliminarCliente '{0}'", txtId.Text.Trim());
                MiLibreria.Ejecutar(cmd);
                MessageBox.Show("Se ha eliminado con exito");
            }
            catch (Exception exp)
            {
                MessageBox.Show("Ha ocurrido un error" + exp.Message);
            }
        }

        

        private void txtId_TextChanged_1(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
    }
}
