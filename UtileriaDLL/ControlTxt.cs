using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtileriaDLL
{
    public partial class ControlTxt : TextBox
    {
        public ControlTxt()
        {
            InitializeComponent();
        }
        //METODO PARA VALIDAR QUE EL TXT NO SE ENCUENTRE VACIO
        public Boolean Validar
        {
            set;
            get;
        }
        //METODO PARA VALIDAR QUE SOLO ACEPTE NUMEROS
        public Boolean SoloNumeros
        {
            set;
            get;
        }
    }
}
