let producto = {
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

$(document).ready(function () {
    $('#productoTable').DataTable();
    Producto.ObtenerTallas();
    Producto.ObtenerColores();
    Producto.ObtenerDepartamentos();
    Producto.ObtenerProductos();
});

var table = $('#productoTable').DataTable();
$('#productoTable tbody').on('click', 'tr', function () {
    var rowData = table.row(this).data();
    Producto.CargarProducto(rowData);
});

$("#guardaProducto").click(function () {
    if ($("#productoId").val() == "") {
        Producto.AgregarProducto();
    }
    else {
        Producto.ActualizarProducto();
    }
});

$("#eliminarProducto").click(function () {
    if ($("#productoId").val() != "") {
        Producto.EliminarProducto();
    }
});

$("#nuevoProducto").click(function () {
    Producto.LimpiarProducto();
});

class Producto {
    static AgregarProducto() {
        producto.Nombre = $("#productoNombre").val();
        producto.Precio = $("#productoPrecio").val();
        producto.Talla.TallaId = $("#productoTalla").val();
        producto.Color.ColorId = $("#productoColor").val();
        producto.TipoDepartamento.TipoDepartamentoId = $("#productoDepartamento").val();
        ProductoRequest.GuardarProductos(producto).done(function (data) {
            if (data != null) {
                Producto.LimpiarProducto();
                Producto.ObtenerProductos();
            }
        });
    }

    static CargarProducto(rowData) {
        $("#productoNombre").val(rowData[0]);
        $("#productoPrecio").val(rowData[1]);
        $("#productoId").val(rowData[5]);
        $("#productoTalla").val(rowData[6]);
        $("#productoColor").val(rowData[7]);
        $("#productoDepartamento").val(rowData[8]);
    }

    static ActualizarProducto() {
        producto.ProductoId = $("#productoId").val();
        producto.Nombre = $("#productoNombre").val();
        producto.Precio = $("#productoPrecio").val();
        producto.Talla.TallaId = $("#productoTalla").val();
        producto.Color.ColorId = $("#productoColor").val();
        producto.TipoDepartamento.TipoDepartamentoId = $("#productoDepartamento").val();
        ProductoRequest.ActualizarProductos(producto).done(function (data) {
            if (data != null) {
                Producto.LimpiarProducto();
                Producto.ObtenerProductos();
            }
        });
    }

    static EliminarProducto() {
        ProductoRequest.EliminarProductos($("#productoId").val()).done(function (data) {
            if (data != null) {
                Producto.LimpiarProducto();
                Producto.ObtenerProductos();
            }
        });
    }

    static ObtenerProductos() {
        ProductoRequest.ObtenerProductos().done(function (data) {
            let dataProducto = { };
            var dataArray = [];
            if (data != null) {
                $('#productoTable').DataTable().clear().draw();
                $(data).each(function () {
                    dataProducto.ProductoId = this.ProductoId;
                    dataProducto.Nombre = this.Nombre;
                    dataProducto.Precio = this.Precio;
                    dataProducto.TallaId = this.Talla.TallaId;
                    dataProducto.TallaDescripcion = this.Talla.TallaDescripcion;
                    dataProducto.ColorId = this.Color.ColorId;
                    dataProducto.ColorDescripcion = this.Color.ColorDescripcion;
                    dataProducto.TipoDepartamentoId = this.TipoDepartamento.TipoDepartamentoId;
                    dataProducto.TipoDepartamentoDescripcion = this.TipoDepartamento.TipoDepartamentoDescripcion;
                    dataArray.push(dataProducto);
                    var t = $('#productoTable').DataTable();
                    t.row.add([
                        dataProducto.Nombre,
                        dataProducto.Precio,
                        dataProducto.TallaDescripcion,
                        dataProducto.ColorDescripcion,
                        dataProducto.TipoDepartamentoDescripcion,
                        dataProducto.ProductoId,
                        dataProducto.TallaId,
                        dataProducto.ColorId,
                        dataProducto.TipoDepartamentoId
                    ]).draw(false);
                });
            }
        });
    }

    static LimpiarProducto() {
        $("#productoId").val("");
        $("#productoNombre").val("");
        $("#productoPrecio").val("");
        $("#productoTalla").val("");
        $("#productoColor").val("");
        $("#productoDepartamento").val("");
    }

    static ObtenerTallas() {
        ProductoRequest.ObtenerTallas().done(function (data) {
            if (data != null) {
                $(data).each(function () {
                    var option = $(document.createElement('option'));
                    option.text(this.TallaDescripcion);
                    option.val(this.TallaId);
                    $("#productoTalla").append(option);
                });
            }
        });
    }

    static ObtenerColores() {
        ProductoRequest.ObtenerColores().done(function (data) {
            if (data != null) {
                $(data).each(function () {
                    var option = $(document.createElement('option'));
                    option.text(this.ColorDescripcion);
                    option.val(this.ColorId);
                    $("#productoColor").append(option);
                });
            }
        });
    }

    static ObtenerDepartamentos() {
        ProductoRequest.ObtenerDepartamentos().done(function (data) {
            if (data != null) {
                $(data).each(function () {
                    var option = $(document.createElement('option'));
                    option.text(this.TipoDepartamentoDescripcion);
                    option.val(this.TipoDepartamentoId);
                    $("#productoDepartamento").append(option);
                });
            }
        });
    }
}