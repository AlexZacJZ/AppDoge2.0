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
    public partial class ConsultarClientes : Consultas
    {
        public ConsultarClientes()
        {
            InitializeComponent();
        }

        private void ConsultarClientes_Load(object sender, EventArgs e)
        {
            /*Mandaremos a llamar al GV de consultas ya que necesitamos que al momento de ingresar a Consultas clientes se
             * cargue la informacion de la consulta clientes, por lo cual usamos el metod DataSource el cual establece
             * el orgiden de la informacion que recibira el GV(data set), entonces llamamos al metodo LLenarData por que
             * este es un metodo que retorna un data set. Colocamos el nombre de la tabla para consultar("").
             */
            dataGridView1.DataSource = LlenarDataGV("Clientes").Tables[0];
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()) == false)
            {
                try
                {
                    DataSet ds;
                    //LIKE instruccion SQL busca coincidencias y no resultados exactos
                    string cmd= "Select * From Clientes Where nombre Like ('%"+txtNombre.Text.Trim()+"%')";
                    ds = MiLibreria.Ejecutar(cmd);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ocurrio un error: " + error);
                }
            }
        }
    }
}
