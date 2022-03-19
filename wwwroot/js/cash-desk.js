/* ### Declaration of Variables  ### */

var product = null;
var uriRetrieveProduct = "/Product/Retrieve/";

var sales = [];

/* ### Functions  ### */

function fillForm (productData) {
    $("#product-name").val(productData.name);
    $("#product-category").val(productData.category.name);
    $("#product-supplier").val(productData.supplier.name);
    $("#product-sale-price").val(productData.salePrice);
}

function resetForm () {
    $("#product-name").val("");
    $("#product-category").val("");
    $("#product-supplier").val("");
    $("#product-sale-price").val("");
    $("#product-count").val("");
}

function addProductInTable (newProduct, count) {
    var productTemp = {};
    Object.assign(productTemp, newProduct);
    sales.push(productTemp);
    
    $("#products-table").append(`
        <tr>
            <td>${newProduct.id}</td>
            <td>${newProduct.name}</td>
            <td>${count} ${newProduct.measurementType}</td>
            <td>$ ${newProduct.salePrice}</td>
            <td>$ ${newProduct.salePrice * count}</td>
            <td><button class='btn btn-danger'>Remove</button></td>
        </tr>
    `);
}

function getMeasurementType (measurementType) {
    switch (measurementType) {
        case 0:
            return "liter(s)";

        case 1:
            return "kilo(s)";

        case 2:
            return "unit(s)";

        default:
            return "unit(s)";
    }
}

/* ### Ajax  ### */

$("#search-product-btn").click(function () {
    var productCode = $("#search-product-ipt").val();
    $("#search-product-ipt").val("");

    $.post(uriRetrieveProduct + productCode, function (data, status) {
        product = data;
        product.measurementType = getMeasurementType(product.measurementType);
        fillForm(product);
    }).fail(function () {
        product = null;
        alert("An error has occurred. Please contact support.");
    });
});

$("#product-form").on("submit", function (event) {
    event.preventDefault();
    var count = $("#product-count").val();

    addProductInTable(product, count);

    var count = 0;
    resetForm();
});