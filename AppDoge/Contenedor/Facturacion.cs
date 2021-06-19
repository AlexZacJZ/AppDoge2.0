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
                    txtCodProducto.Focus();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error: " + error);
            }
            
        }
    }
}
