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
    public partial class Facturacion : Procesos
    {
        public Facturacion()
        {
            InitializeComponent();
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            //Tener presente que FormLogin.Codigo tomara el dato del Id segun los usuarios autorizados por la base de datos
            string cmd = "Select * From Usuarios Where id_user=" + FormLogin.codigo;
            DataSet ds = MiLibreria.Ejecutar(cmd);
            lblAtiende.Text = ds.Tables[0].Rows[0]["name_user"].ToString().Trim();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodUsuario.Text.Trim()) == false)
                {
                    string cmd = string.Format("Select * From Clientes where id_clientes= '{0}'", txtCodUsuario.Text.Trim());
                    DataSet ds = MiLibreria.Ejecutar(cmd);

                    txtCliente.Text = ds.Tables[0].Rows[0]["nombre"].ToString().Trim();
                    txtNit.Text = ds.Tables[0].Rows[0]["nit"].ToString().Trim();
                    txtCodProducto.Focus();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error: " + error);
            }
            
        }

        public static int contfilas = 0;
        private void btnColocar_Click(object sender, EventArgs e)
        {
            if (MiLibreria.ValidarFormulario(this,errorProvider1)==false)
            {
                bool existe = false;
                int num_fila = 0;
                if (contfilas == 0)
                {
                    dataGridView1.Rows.Add(txtCodProducto.Text,txtDescripcion.Text,txtPrecio.Text,txtCantidad.Text);
                    /*Procedemos a crear una variable double la cual obtendra el valor del DV1 de las celdas 2 y 3
                     * que corresponden a cantidad y precio, tener en cuenta que contfilas es un comodin para saber
                     * en que fila estoy ubicado
                     */
                    double iva = Convert.ToDouble(dataGridView1.Rows[contfilas].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[contfilas].Cells[3].Value)*0.12;
                    dataGridView1.Rows[contfilas].Cells[4].Value = iva;
                    contfilas++;
                }
                else
                {
                    /*El uso de este foreach es encontrar coincidencias, es decir si quiero agregar un producto
                     * repetido, en vez de hacer una fila extra se sumara al que ya se habia ingresado anteriormente
                     */
                    foreach (DataGridViewRow fila in dataGridView1.Rows)
                    {
                        if (fila.Cells[0].Value.ToString() == txtCodProducto.Text)
                        {
                            existe = true;
                            num_fila = fila.Index; //Encuentra la posicion de la fila en que estamos trabajando
                        }
                    }
                    if (existe == true)
                    {
                        //ACTUALIZA LA CANTIDAD DE LA FILA DONDE HAY COINCIDENCIA
                        dataGridView1.Rows[num_fila].Cells[3].Value=(Convert.ToDouble(txtCantidad.Text)+Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[3].Value)).ToString();
                        //ACTUALIZA IMPORTE TOTAL
                        double iva= Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[contfilas].Cells[3].Value) * 0.12;
                        dataGridView1.Rows[num_fila].Cells[4].Value = iva;
                    }
                    else
                    {
                        dataGridView1.Rows.Add(txtCodProducto.Text, txtDescripcion.Text, txtPrecio.Text, txtCantidad.Text);
                        double iva = Convert.ToDouble(dataGridView1.Rows[contfilas].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[contfilas].Cells[3].Value) * 0.12;
                        dataGridView1.Rows[contfilas].Cells[4].Value = iva;
                        contfilas++;
                    }
                }
            }
        }
    }
}
