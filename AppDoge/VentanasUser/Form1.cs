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
using System.Threading;

namespace AppDoge
{
    public partial class FormLogin : Form
    {
        public static string codigo = "";
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            imgLogin.ImageLocation = @"C:\\Users\\DELL-PC\\Pictures\\Cheems\\Cheems.jpg";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                //Almacena una consulta en Usuarios donde account y password va a almacenar lo que esta en los textbox
                string cmd = string.Format("Select * From Usuarios Where account= '{0}' AND password= '{1}'", txtUser.Text.Trim(), txtPass.Text.Trim());
                DataSet DS = MiLibreria.Ejecutar(cmd);

                //Codigo servira para capturas el dato de la persona que se logea y pasarlo a su respectiva Ventana
                codigo = DS.Tables[0].Rows[0]["id_user"].ToString().Trim();
                string usuario = DS.Tables[0].Rows[0]["account"].ToString().Trim();
                string pass = DS.Tables[0].Rows[0]["password"].ToString().Trim();

                if (usuario == txtUser.Text && pass == txtPass.Text)
                {
                    //Analizara la columna status de la BD y lo convertira a booleano para tomar la desicion
                    if (Convert.ToBoolean(DS.Tables[0].Rows[0]["status"]))
                    {
                        VentanaAdmin vadm = new VentanaAdmin();
                        this.Hide();
                        vadm.Show();
                    }
                    else
                    {
                        VentanaUsuario vus = new VentanaUsuario();
                        this.Hide();
                        vus.Show();
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Los datos son incorrecto, intente nuevamente");
                txtUser.Clear();
                txtPass.Clear();
                txtUser.Focus();
                imgLogin.ImageLocation = @"C:\\Users\\DELL-PC\\source\\repos\\DogeFact\\DogeFact\\Resources\\Nopuedeser.jpg";
                Application.DoEvents();
                Thread.Sleep(1000);
                imgLogin.ImageLocation = @"C:\\Users\\DELL-PC\\source\\repos\\DogeFact\\DogeFact\\Resources\\Cheems.jpg";

            }
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
