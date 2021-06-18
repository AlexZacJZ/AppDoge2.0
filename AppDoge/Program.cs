using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDoge
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());//ESTE ES EL METODO QUE INICIALIZA LA VENTANA A UTILIZAR

            /*Si Queremos correr una ventana especifica sin pasar por todo el programa solo modificamos la referencia
             * del cual se iniciara el .Run
             */
            //Application.Run(new ConsultarClientes());
        }
    }
}
