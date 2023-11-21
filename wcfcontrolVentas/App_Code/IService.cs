using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{
	//validacion usuario

	[OperationContract]
	DataSet InicioSesion(string nombreUsuario, string clave);

	//crud de tablas

	[OperationContract]
	DataSet agregarUsuario(string nomUsuario, string nomReal, string clave, string tUsuario, string usuario);

	[OperationContract]
	DataSet IngresarFactura(float monto, int cantidad, int id, string usuario);

	[OperationContract]
	DataSet ActualizarFactura(int id, float monto, int cantidad, string usuario);


	[OperationContract]
	DataSet IngresarVenta(int cant, int cantVnta, float precio, string estado, int idproducto, int idFc, int idUser, string usuario);

	[OperationContract]
	DataSet ActualizarVenta(int id, int idproducto, int cantVnta, int cant, float precio, string estado, string usuario);

	[OperationContract]
	DataSet IngresarProducto(int canPant, string estilo, string marca, string talla, float precioU, string estado, int idFac, int idUser, string usuario);

	[OperationContract]
	DataSet ActualizarProducto(int id, int canPant, string estilo, string marca, string talla, float precioU, string estado, string usuario);

	[OperationContract]
	DataSet EliminarProducto(int id);

	[OperationContract]

	DataSet EliminarVenta(int id);


	//mostradores de tablas

	[OperationContract]
	DataSet mostrarFacturaDinamico(DateTime fchInicio, DateTime fchFinal);

	[OperationContract]
	DataSet mostrarFacturaEdit(int id);

	[OperationContract]
	DataSet mostrarProductoDinamico(DateTime fchInicio, DateTime fchFinal);

	[OperationContract]
	DataSet mostrarProductoCRUD(int id);

	[OperationContract]
	DataSet mostrarVentaDinamico(DateTime fchInicio, DateTime fchFinal);

	[OperationContract]
	DataSet mostrarVentaCRUD(int id);

	[OperationContract]

	DataSet mostrarHistorialDinamico(DateTime fchInicio, DateTime fchFinal);

	[OperationContract]
	DataSet mostrarUsuarios();

	//buscadores de datos

	[OperationContract]
	DataSet buscadorFacturas(int num, float mon, string usuario);

	[OperationContract]

	DataSet buscadorProductos(int num, string letra, float dec);

	[OperationContract]

	DataSet buscadorVentas(int num, float dec, string letra);

	//GRAFICOS
	[OperationContract]
	DataSet mostrarInversion(DateTime fchInicio, DateTime fchFinal);
	[OperationContract]
	DataSet mostrarGanancia(DateTime fchInicio, DateTime fchFinal);
}