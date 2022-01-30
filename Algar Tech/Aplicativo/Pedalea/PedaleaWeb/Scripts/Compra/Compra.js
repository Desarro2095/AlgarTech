let cliente = {
    ClienteId: 0,
    Cedula: '',
    Nombre: '',
    Direccion: '',
    Compra: {
        CompraId: 0,
        Fecha: '',
        Valor: 0,
        PlanSepare: {
            PlanSepareId: 0,
            PlanSepareDescripcion: ''
        },
        Promocion: {
            PromocionId: 0,
            Porcentaje: 0
        },
        DetalleCompra: {
            DetalleCompraId: 0,
            Cantidad: 0,
            Producto: {
                ProductoId: 0,
                Nombre: '',
                Precio: 0,
                Talla: {
                    TallaId: 0,
                    TallaDescripcion: '',
                },
                Color: {
                    ColorId: 0,
                    ColorDescripcion: ''
                },
                TipoDepartamento: {
                    TipoDepartamentoId: 0,
                    TipoDepartamentoDescripcion: ''
                }
            }
        }
    }
}

$(document).ready(function () {
    $('#compraTable').DataTable();
    Compra.ObtenerProductos();
    Compra.ObtenerCompras();
});

var table = $('#compraTable').DataTable();
$('#compraTable tbody').on('click', 'tr', function () {
    var rowData = table.row(this).data();
    Compra.CargarCompra(rowData);
});

$("#guardaCliente").click(function () {
    if ($("#clienteId").val() == "") {
        Compra.AgregarCompra();
    }
    else {
        Compra.ActualizarCompra();
    }
});

$("#eliminarCliente").click(function () {
    if ($("#clienteId").val() != "") {
        Compra.EliminarCompra();
    }
});

$("#nuevoCliente").click(function () {
    Compra.LimpiarCompra();
});

class Compra {
    static AgregarCompra() {
        cliente.Cedula = $("#clienteCedula").val();
        cliente.Nombre = $("#clienteNombre").val();
        cliente.Direccion = $("#clienteDireccion").val();
        cliente.Compra.DetalleCompra.Cantidad = $("#clienteCantidad").val();
        cliente.Compra.DetalleCompra.Producto.ProductoId = $("#clienteProducto").val();
        CompraRequest.GuardarCompra(cliente).done(function (data) {
            if (data != null) {
                Compra.LimpiarCompra();
                Compra.ObtenerCompras();
            }
        });
    }

    static CargarCompra(rowData) {
        $("#clienteId").val(rowData[6]);
        $("#clienteCompraId").val(rowData[7]);
        $("#clienteCedula").val(rowData[1]);
        $("#clienteNombre").val(rowData[0]);
        $("#clienteDireccion").val(rowData[5]);
        $("#clienteCantidad").val(rowData[4]);
        $("#clienteProducto").val(rowData[14]);
    }

    static ActualizarCompra() {
        cliente.ClienteId = $("#clienteId").val();
        cliente.Compra.CompraId = $("#clienteCompraId").val();
        cliente.Cedula = $("#clienteCedula").val();
        cliente.Nombre = $("#clienteNombre").val();
        cliente.Direccion = $("#clienteDireccion").val();
        cliente.Compra.DetalleCompra.Cantidad = $("#clienteCantidad").val();
        cliente.Compra.DetalleCompra.Producto.ProductoId = $("#clienteProducto").val();
        CompraRequest.ActualizarCompra(cliente).done(function (data) {
            if (data != null) {
                Compra.LimpiarCompra();
                Compra.ObtenerCompras();
            }
        });
    }

    static EliminarCompra() {
        CompraRequest.EliminarCompra($("#clienteId").val()).done(function (data) {
            if (data != null) {
                Compra.LimpiarCompra();
                Compra.ObtenerCompras();
            }
        });
    }

    static ObtenerCompras() {
        CompraRequest.ObtenerCompras().done(function (data) {
            let dataCompra = {};
            var dataArray = [];
            if (data != null) {
                $('#compraTable').DataTable().clear().draw();
                $(data).each(function () {

                    cliente.ClienteId = this.ClienteId;
                    cliente.Nombre = this.Nombre;
                    cliente.Cedula = this.Cedula;
                    cliente.Direccion = this.Direccion;
                    cliente.Compra.CompraId = this.Compra.CompraId;
                    cliente.Compra.Fecha = this.Compra.Fecha;
                    cliente.Compra.Valor = this.Compra.Valor;
                    cliente.Compra.PlanSepare.PlanSepareId = this.Compra.PlanSepare.PlanSepareId;
                    cliente.Compra.PlanSepare.PlanSepareDescripcion = this.Compra.PlanSepare.PlanSepareDescripcion;
                    cliente.Compra.Promocion.PromocionId = this.Compra.Promocion.PromocionId;
                    cliente.Compra.Promocion.Porcentaje = this.Compra.Promocion.Porcentaje;
                    cliente.Compra.DetalleCompra.DetalleCompraId = this.Compra.DetalleCompra.DetalleCompraId;
                    cliente.Compra.DetalleCompra.Cantidad = this.Compra.DetalleCompra.Cantidad;
                    cliente.Compra.DetalleCompra.Producto.ProductoId = this.Compra.DetalleCompra.Producto.ProductoId;
                    cliente.Compra.DetalleCompra.Producto.Nombre = this.Compra.DetalleCompra.Producto.Nombre;
                    var t = $('#compraTable').DataTable();
                    t.row.add([
                        cliente.Nombre,
                        cliente.Cedula,
                        cliente.Compra.DetalleCompra.Producto.Nombre,
                        cliente.Compra.Valor,
                        cliente.Compra.DetalleCompra.Cantidad,
                        cliente.Direccion,
                        cliente.ClienteId,
                        cliente.Compra.CompraId,
                        cliente.Compra.Fecha,
                        cliente.Compra.PlanSepare.PlanSepareId,
                        cliente.Compra.PlanSepare.PlanSepareDescripcion,
                        cliente.Compra.Promocion.PromocionId,
                        cliente.Compra.Promocion.Porcentaje,
                        cliente.Compra.DetalleCompra.DetalleCompraId,
                        cliente.Compra.DetalleCompra.Producto.ProductoId
                    ]).draw(false);
                });
            }
        });
    }

    static LimpiarCompra() {
        $("#clienteId").val("");
        $("#clienteCompraId").val("");
        $("#clienteCedula").val("");
        $("#clienteNombre").val("");
        $("#clienteDireccion").val("");
        $("#clienteCantidad").val("");
        $("#clienteProducto").val("");
    }

    static ObtenerProductos() {
        CompraRequest.ObtenerProductos().done(function (data) {
            if (data != null) {
                $(data).each(function () {
                    var option = $(document.createElement('option'));
                    option.text(this.Nombre);
                    option.val(this.ProductoId);
                    $("#clienteProducto").append(option);
                });
            }
        });
    }

}