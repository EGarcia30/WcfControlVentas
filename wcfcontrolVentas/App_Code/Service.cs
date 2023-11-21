using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
	DataSet ds = new DataSet();//es el repositorio universal de datos en memoria
	SqlDataAdapter da;//sirve para ejecutar cualquier proceso en bd
	private string strConexion = "server=DESKTOP-DARCKLB\\SQLEXPRESS; database=Control Ventas; Integrated Security=true;";
	string patron = "Pr0y3ct0";

	//METODOS PARA USUARIOS

	public DataSet InicioSesion(string nombreUsuario, string clave)
    {
		da = new SqlDataAdapter("Sp_inicioSesion", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
		da.SelectCommand.Parameters.AddWithValue("@claveUsuario", clave);
		da.SelectCommand.Parameters.AddWithValue("@patron", patron);
		da.Fill(ds);

		return ds;
    }

	public DataSet agregarUsuario(string nomUsuario, string nomReal, string clave, string tUsuario, string usuario)
    {
		da = new SqlDataAdapter("Sp_agregarUsuario", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@nomUsuario", nomUsuario);
		da.SelectCommand.Parameters.AddWithValue("@nomReal", nomReal);
		da.SelectCommand.Parameters.AddWithValue("@clave", clave);
		da.SelectCommand.Parameters.AddWithValue("@tipoUsuario", tUsuario);
		da.SelectCommand.Parameters.AddWithValue("@usuario", usuario);
		da.SelectCommand.Parameters.AddWithValue("@patron", patron);
		da.Fill(ds);

		return ds;
	}

	//METODOS PARA FACTURA(INVERSION/GASTOS)

	public DataSet IngresarFactura(float monto, int cantidad, int id, string usuario)
    {
		da = new SqlDataAdapter("Sp_IngresarFactura", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@mon", monto);
		da.SelectCommand.Parameters.AddWithValue("@cant", cantidad);
		da.SelectCommand.Parameters.AddWithValue("@idUsuario", id);
		da.SelectCommand.Parameters.AddWithValue("@nom", usuario);
		da.Fill(ds);

		return ds;
    }

	public DataSet ActualizarFactura(int id, float monto, int cantidad, string usuario)
	{
		da = new SqlDataAdapter("Sp_ActualizarFactura", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@id", id);
		da.SelectCommand.Parameters.AddWithValue("@mon", monto);
		da.SelectCommand.Parameters.AddWithValue("@cant", cantidad);		
		da.SelectCommand.Parameters.AddWithValue("@nom", usuario);
		da.Fill(ds);

		return ds;
	}

	//METODOS PARA PRODUCTOS(STOCK/VENTAS)
	public DataSet IngresarVenta(int cant, int cantVnta, float precio, string estado, int idproducto, int idFc, int idUser, string usuario)
    {
		da = new SqlDataAdapter("Sp_IngresarVenta", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@cantPant", cant);
		da.SelectCommand.Parameters.AddWithValue("@cantVenta", cantVnta);
		da.SelectCommand.Parameters.AddWithValue("@precioUnitario", precio);
		da.SelectCommand.Parameters.AddWithValue("@estadoProducto", estado);
		da.SelectCommand.Parameters.AddWithValue("@idproducto", idproducto);
		da.SelectCommand.Parameters.AddWithValue("@idfactura", idFc);
		da.SelectCommand.Parameters.AddWithValue("@idUsuario", idUser);
		da.SelectCommand.Parameters.AddWithValue("@nombreUsuario", usuario);
		da.Fill(ds);

		return ds;
    }

	public DataSet ActualizarVenta(int id, int idproducto, int cantVnta, int cant, float precio, string estado, string usuario)
    {
		da = new SqlDataAdapter("Sp_ActualizarVenta", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@idventa", id);
		da.SelectCommand.Parameters.AddWithValue("@idproducto", idproducto);
		da.SelectCommand.Parameters.AddWithValue("@cantVenta", cantVnta);
		da.SelectCommand.Parameters.AddWithValue("@cantPantalon", cant);
		da.SelectCommand.Parameters.AddWithValue("@precioUnitario", precio);
		da.SelectCommand.Parameters.AddWithValue("@estado", estado);
		da.SelectCommand.Parameters.AddWithValue("@nombreUsuario", usuario);
		da.Fill(ds);

		return ds;
	}

	public DataSet IngresarProducto(int canPant,string estilo, string marca, string talla, float precioU, string estado, int idFac, int idUser, string usuario)
    {
		da = new SqlDataAdapter("Sp_IngresarProducto", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@cantPantalon", canPant);
		da.SelectCommand.Parameters.AddWithValue("@colorEstilo", estilo);
		da.SelectCommand.Parameters.AddWithValue("@marca", marca);
		da.SelectCommand.Parameters.AddWithValue("@tallaReal", talla);
		da.SelectCommand.Parameters.AddWithValue("@precio", precioU);
		da.SelectCommand.Parameters.AddWithValue("@estadoProducto", estado);
		da.SelectCommand.Parameters.AddWithValue("@idfactura", idFac);
		da.SelectCommand.Parameters.AddWithValue("@idUsuario", idUser);
		da.SelectCommand.Parameters.AddWithValue("@nombreUsuario", usuario);
		da.Fill(ds);

		return ds;
	}

	public DataSet ActualizarProducto(int id, int canPant, string estilo, string marca, string talla, float precioU, string estado, string usuario)
	{
		da = new SqlDataAdapter("Sp_ActualizarProducto", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@id", id);
		da.SelectCommand.Parameters.AddWithValue("@cantPantalon", canPant);
		da.SelectCommand.Parameters.AddWithValue("@colorEstilo", estilo);
		da.SelectCommand.Parameters.AddWithValue("@marca", marca);
		da.SelectCommand.Parameters.AddWithValue("@tallaReal", talla);
		da.SelectCommand.Parameters.AddWithValue("@precio", precioU);
		da.SelectCommand.Parameters.AddWithValue("@estadoProducto", estado);
		da.SelectCommand.Parameters.AddWithValue("@nombreUsuario", usuario);
		da.Fill(ds);

		return ds;
	}

	public DataSet EliminarProducto(int id)
	{
		da = new SqlDataAdapter("Sp_eliminarProducto", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@id", id);
		da.Fill(ds);

		return ds;
	}

	public DataSet EliminarVenta(int id)
	{
		da = new SqlDataAdapter("Sp_eliminarVenta", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@id", id);
		da.Fill(ds);

		return ds;
	}

	//MOSTRAR TABLAS

	public DataSet mostrarFacturaDinamico(DateTime fchInicio, DateTime fchFinal)
	{

		da = new SqlDataAdapter("Sp_mostrarFacturaDin", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@fchInicio", fchInicio);
		da.SelectCommand.Parameters.AddWithValue("@fchFinal", fchFinal);
		da.Fill(ds);
		return ds;
	}

	public DataSet mostrarFacturaEdit(int id)
    {
		da = new SqlDataAdapter("Sp_mostrarFacturaEdit", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@id", id);
		da.Fill(ds);
		return ds;
	}

	public DataSet mostrarProductoDinamico(DateTime fchInicio, DateTime fchFinal)
    {
		da = new SqlDataAdapter("Sp_mostrarProductoDin", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@fchInicio", fchInicio);
		da.SelectCommand.Parameters.AddWithValue("@fchFinal", fchFinal);
		da.Fill(ds);
		return ds;
	}

	public DataSet mostrarProductoCRUD(int id)
    {
		da = new SqlDataAdapter("Sp_mostrarProductoCRUD", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@id", id);
		da.Fill(ds);
		return ds;
	}

	public DataSet mostrarVentaDinamico(DateTime fchInicio, DateTime fchFinal)
    {
		da = new SqlDataAdapter("Sp_mostrarVentaDin", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@fchInicio", fchInicio);
		da.SelectCommand.Parameters.AddWithValue("@fchFinal", fchFinal);
		da.Fill(ds);
		return ds;
	}

	public DataSet mostrarVentaCRUD(int id)
	{
		da = new SqlDataAdapter("Sp_mostrarVentaCRUD", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@id", id);
		da.Fill(ds);
		return ds;
	}

	public DataSet mostrarHistorialDinamico(DateTime fchInicio, DateTime fchFinal)
    {
		da = new SqlDataAdapter("Sp_mostrarHistorial", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@fchInicio", fchInicio);
		da.SelectCommand.Parameters.AddWithValue("@fchFinal", fchFinal);
		da.Fill(ds);
		return ds;
	}

	public DataSet mostrarUsuarios()
    {
		da = new SqlDataAdapter("Sp_mostrarUsuario", strConexion);
		da.Fill(ds);

		return ds;
    }

	//Buscadores de nuestro web forms
	
	public DataSet buscadorFacturas(int num, float mon, string usuario)
    {
		da = new SqlDataAdapter("Sp_BuscarFactura", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@num", num);
		da.SelectCommand.Parameters.AddWithValue("@mon", mon);
		da.SelectCommand.Parameters.AddWithValue("@objeto", usuario);
		da.Fill(ds);

		return ds;
	}

	public DataSet buscadorProductos(int num, string letra, float dec )
	{
		da = new SqlDataAdapter("Sp_buscarProducto", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@num", num);
		da.SelectCommand.Parameters.AddWithValue("@dec", dec);
		da.SelectCommand.Parameters.AddWithValue("@letra", letra);
		da.Fill(ds);

		return ds;
	}

	public DataSet buscadorVentas(int num, float dec, string letra)
	{
		da = new SqlDataAdapter("Sp_buscarVenta", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@num", num);
		da.SelectCommand.Parameters.AddWithValue("@dec", dec);
		da.SelectCommand.Parameters.AddWithValue("@letra", letra);
		da.Fill(ds);

		return ds;
	}

	public DataSet MostrarTopVenta()
    {
		da = new SqlDataAdapter("sp_mostrarMejorVenta", strConexion);
		da.Fill(ds);

		return ds;
    }

	//graficos
	public DataSet mostrarInversion(DateTime fchInicio, DateTime fchFinal)
    {
		da = new SqlDataAdapter("sp_totalInversion", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@fchInicio", fchInicio);
		da.SelectCommand.Parameters.AddWithValue("@fchFinal", fchFinal);
		da.Fill(ds);

		return ds;
	}

	public DataSet mostrarGanancia(DateTime fchInicio, DateTime fchFinal)
	{
		da = new SqlDataAdapter("sp_totalGanado", strConexion);
		da.SelectCommand.CommandType = CommandType.StoredProcedure;
		da.SelectCommand.Parameters.AddWithValue("@fchInicio", fchInicio);
		da.SelectCommand.Parameters.AddWithValue("@fchFinal", fchFinal);
		da.Fill(ds);

		return ds;
	}
}