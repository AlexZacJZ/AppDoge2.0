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
            try
            {
                string cdm = string.Format("Exec ActualizaCliente '{0}','{1}','{2}','{3}','{4}'", txtId.Text.Trim(), 
                    txtNombre.Text.Trim(),txtApellido.Text.Trim(),txtNit.Text.Trim(),txtTelefono.Text.Trim());
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
    }
}
