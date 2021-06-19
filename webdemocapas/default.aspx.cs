using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace webdemocapas
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = conexionDB();
            GridView1.DataBind();
        }
        public System.Data.DataTable conexionDB()
        {
            //Modo desconectado
            //Data Table necesario para dejar los datos en memoria.
            DataTable dt = new DataTable();
            //Tomamos el ConnectionsString desde la configuracion del sitio.
            string connectionString = "Server=DESKTOP-OO5G5B1;Database=ConexionDB_ADO;User Id=sa;Password=roxana21;";

            //Generamos una variable de Conexion
            SqlConnection Variable_Connection = new SqlConnection();
            //Le pasamos el connection string al Conection.
            Variable_Connection.ConnectionString = connectionString;

            //Generamos el SQL command que va a ser el commando a ejecutar en la base.
            SqlCommand Variable_Command = new SqlCommand();
            //Seteo el SQL a ejecutar.
            Variable_Command.CommandText = "select * from [Usuarios]";
            //Seteo la conexion al command
            Variable_Command.Connection = Variable_Connection;

            //Puedo hacer todo en una sola linea.
            //SqlCommand Variable_Command = new SqlCommand("select * from [Usuarios]", Variable_Connection);
            //Le explico que tipo es la ejecucion en la base de datos.
            Variable_Command.CommandType = CommandType.Text;

            //Genero un DataAdapter
            SqlDataAdapter sda = new SqlDataAdapter();
            //Seteo al DataAdapter el command.
            sda.SelectCommand = Variable_Command;

            //Lleno el DataTable para trabajar en memoria
            sda.Fill(dt);
            return dt;

        }
    }
}