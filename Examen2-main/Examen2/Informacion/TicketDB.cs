using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Informacion
{
    public class TicketDB
    {
        string cadena = "server=localhost; user=root; database=examen2; password=familia1;";

        public bool Insertar(Ticket ticket)
        {
            bool inserto = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO tickes VALUES ");
                sql.Append(" (@idtickes, @Fecha, @idclientes, @Idusuarios, @TipoSoporte, @DescripcionSolicitud, @DescripcionRespuesta, @Precio, @Impuesto, @Descuento, @Total); ");
                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@idtickes", MySqlDbType.VarChar, 50).Value = ticket.idticket;
                        comando.Parameters.Add("@Fecha", MySqlDbType.DateTime).Value = ticket.Fecha;
                        comando.Parameters.Add("@idclientes", MySqlDbType.Int32).Value = ticket.IdentidadClientes;
                        comando.Parameters.Add("@Idusuarios", MySqlDbType.VarChar, 45).Value = ticket.Idusuarios;
                        comando.Parameters.Add("@TipoSoporte", MySqlDbType.VarChar, 45).Value = ticket.TipoSoporte;
                        comando.Parameters.Add("@DescripcionSolicitud", MySqlDbType.VarChar, 45).Value = ticket.DescripcionSolicitud;
                        comando.Parameters.Add("@DescripcionRespuesta", MySqlDbType.VarChar, 45).Value = ticket.DescripcionRespuesta;
                        comando.Parameters.Add("@Precio", MySqlDbType.Decimal).Value = ticket.Precio;
                        comando.Parameters.Add("@Impuesto", MySqlDbType.Decimal).Value = ticket.Impuesto;
                        comando.Parameters.Add("@Descuento", MySqlDbType.Decimal).Value = ticket.Descuento;
                        comando.Parameters.Add("@Total", MySqlDbType.Decimal).Value = ticket.Total;

                        comando.ExecuteNonQuery();
                        inserto = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return inserto;
        }



    }
}
    

