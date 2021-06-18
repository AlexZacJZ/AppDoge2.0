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
    public partial class Consultas : FormBase
    {
        public Consultas()
        {
            InitializeComponent();
        }

        public DataSet LlenarDataGV(string tabla)
        {
            /*Tener en cuenta que los GrindView necesitan recibir Dataset para su funcionamiento, lo que haremos es mandar
             a llamar al metodo de ejecutar que realizara la conexion con la base de datos y le mandaremos un consulta general
            para que muestre en el GV todos los datos*/
            DataSet Ds;
            string cmd = string.Format("Select * From "+tabla);
            Ds = MiLibreria.Ejecutar(cmd);

            return Ds;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                return;
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
