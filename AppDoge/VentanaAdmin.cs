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
    public partial class VentanaAdmin : Form
    {
        public VentanaAdmin()
        {
            InitializeComponent();
        }

        private void VentanaAdmin_Load(object sender, EventArgs e)
        {
            //Cmd creara una consulta a la base de datos con la informacion de LoginForm.Codigo
            string cmd = "Select * From Usuarios Where id_user=" + FormLogin.codigo;
            DataSet DS = MiLibreria.Ejecutar(cmd);
            lblNombre.Text = DS.Tables[0].Rows[0]["name_user"].ToString();
            lblCuenta.Text = DS.Tables[0].Rows[0]["id_user"].ToString();
            lblCodigo.Text = DS.Tables[0].Rows[0]["account"].ToString();

            string url = DS.Tables[0].Rows[0]["foto"].ToString();
            pictureBox1.Image = Image.FromFile(url);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void VentanaAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
