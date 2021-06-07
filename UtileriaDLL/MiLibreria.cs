using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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
    }
}
