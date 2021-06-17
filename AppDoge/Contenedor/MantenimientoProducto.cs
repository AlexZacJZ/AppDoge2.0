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
    public partial class MantenimientoProducto : Mantenimiento
    {
        public MantenimientoProducto()
        {
            InitializeComponent();
        }
        /*Como en el formulario de Mantenimiento se crearon los botones con los metodos correspondientes, nosotros 
         * utilizaremos el polimorfismo para poder utilizar el método de la forma mas conveniente posible
         */
        public override bool Guardar()
        {
            try
            {
                string cdm = string.Format("Exec ActualizaProducto '{0}','{1}','{2}'", txtId.Text.Trim(), txtNombre.Text.Trim(),
                    txtPrecio.Text.Trim());
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
                string cmd = string.Format("Exec EliminarProducto '{0}'", txtId.Text.Trim());
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
