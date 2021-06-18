using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UtileriaDLL
{
    public class MiLibreria
    {
        public static DataSet Ejecutar(String cmd)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=administra;Integrated Security=True");
            conn.Open();

            DataSet DS = new DataSet();
            SqlDataAdapter DA = new SqlDataAdapter(cmd, conn);

            DA.Fill(DS);
            conn.Close();

            return DS;
        }

        public static Boolean ValidarFormulario(Control Objeto, ErrorProvider error)
        {
            //Al momento de encontrar un error esta variable sera un comodin que retornara True
            Boolean HayErrores = false;

            foreach (Control item in Objeto.Controls)
            {
                if(item is ControlTxt)//Donde ControlTxt es el ControlUsuario que validara los cambos de los txt
                {
                    ControlTxt Obj = (ControlTxt)item;
                    if (Obj.Validar == true)
                    {
                        //Validaremos si el txt esta vacio o nulo el Error pasara a nulo y lo detectara
                        if (string.IsNullOrEmpty(Obj.Text.Trim())){
                            error.SetError(Obj, "No puede dejar el campo vacio");
                            HayErrores = true;
                        }
                    }
                    if (Obj.SoloNumeros == true)
                    {
                        int cont = 0, letrasencontradas = 0;

                        foreach(char letra in Obj.Text.Trim())
                        {
                            if (char.IsLetter(Obj.Text.Trim(), cont))
                            {
                                letrasencontradas++;
                            }
                            cont++;
                        }
                        if (letrasencontradas != 0)
                        {
                            HayErrores = true;
                            error.SetError(Obj, "Solo puede ingresar numeros");
                        }
                    }
                }
            }
            return HayErrores;
        }
    }
}
