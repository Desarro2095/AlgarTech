class ProductoRequest {
    static ObtenerProductos() {
        return $.ajax({
            type: "POST",
            url: 'https://localhost:44362/Producto/ObtenerProductos',
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        });
    }
    static GuardarProductos(producto) {
        return $.ajax({
            type: "POST",
            url: 'https://localhost:44362/Producto/GuardarProductos',
            data: JSON.stringify({ producto: producto }),
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        });
    }
    static ActualizarProductos(producto) {
        return $.ajax({
            type: "POST",
            url: 'https://localhost:44362/Producto/ActualizarProductos',
            data: JSON.stringify({ producto: producto }),
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        });
    }
    static EliminarProductos(id) {
        return $.ajax({
            type: "POST",
            url: 'https://localhost:44362/Producto/EliminarProductos?id=' + id,
            //data: JSON.stringify({ id: id }),
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        });
    }
    static ObtenerProducto(id) {
        return $.ajax({
            type: "POST",
            url: 'https://localhost:44362/Producto/ObtenerProducto',
            data: JSON.stringify({ id: id }),
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        });
    }

    static ObtenerTallas() {
        return $.ajax({
            type: "POST",
            url: 'https://localhost:44362/Producto/ObtenerTallas',
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        });
    }
    static ObtenerColores() {
        return $.ajax({
            type: "POST",
            url: 'https://localhost:44362/Producto/ObtenerColores',
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        });
    }
    static ObtenerDepartamentos() {
        return $.ajax({
            type: "POST",
            url: 'https://localhost:44362/Producto/ObtenerDepartamentos',
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        });
    }
}