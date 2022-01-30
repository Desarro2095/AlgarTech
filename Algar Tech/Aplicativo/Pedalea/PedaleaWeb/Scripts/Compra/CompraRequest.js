class CompraRequest {
    static ObtenerProductos() {
        return $.ajax({
            type: "POST",
            url: 'https://localhost:44362/Producto/ObtenerProductos',
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        });
    }
    static ObtenerCompras() {
        return $.ajax({
            type: "POST",
            url: 'https://localhost:44362/Compra/ObtenerCompras',
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        });
    }
    static GuardarCompra(cliente) {
        return $.ajax({
            type: "POST",
            url: 'https://localhost:44362/Compra/GuardarCompra',
            data: JSON.stringify({ cliente: cliente }),
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        });
    }
    static ActualizarCompra(cliente) {
        return $.ajax({
            type: "POST",
            url: 'https://localhost:44362/Compra/ActualizarCompra',
            data: JSON.stringify({ cliente: cliente }),
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        });
    }
    static EliminarCompra(id) {
        return $.ajax({
            type: "POST",
            url: 'https://localhost:44362/Compra/EliminarCompra?id=' + id,
            //data: JSON.stringify({ id: id }),
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        });
    }
}