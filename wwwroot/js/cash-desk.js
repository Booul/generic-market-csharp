/* ### Declaration of Variables  ### */

var product = null;
var uriRetrieveProduct = "/Product/Retrieve/";

var sales = [];

var totalSum = 0.00;

/* ### Start  ### */

$("#before-sale").show();
$("#after-sale").hide();

UpdateTotalSum();

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

function UpdateTotalSum () {
    $("#total-sum").html(totalSum);
}

function resetModal () {
    $("#before-sale").show();
    $("#after-sale").hide();
    $("#amount-paid").prop("disabled", false);
    $("#change").val("");
    $("#amount-paid").val("");
}

function addProductInTable (newProduct, amount) {
    var productTemp = {};
    Object.assign(productTemp, newProduct);

    var sale = {product: productTemp, amount: amount, subtotal: newProduct.salePrice * amount};

    totalSum += sale.subtotal;
    UpdateTotalSum();

    sales.push(sale);
    
    $("#products-table").append(`
        <tr>
            <td>${newProduct.id}</td>
            <td>${newProduct.name}</td>
            <td>${amount} ${newProduct.measurementType}</td>
            <td>$ ${newProduct.salePrice}</td>
            <td>$ ${newProduct.salePrice * amount}</td>
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
    var amount = $("#product-count").val();

    addProductInTable(product, amount);

    var amount = 0;
    resetForm();
});

$("#checkout").click(function () {
    if (totalSum <= 0) {
        alert("Invalid purchase, no products added.");
        return;
    }

    var amountPaid = $("#amount-paid").val();
    if (!isNaN(amountPaid)) {
        _amountPaid = parseFloat(amountPaid);

        if (_amountPaid >= totalSum) {
            $("#before-sale").hide();
            $("#after-sale").show();
            $("#amount-paid").prop("disabled", true);

            var change = _amountPaid - totalSum;
            $("#change").val(change);
        } else {
            alert ("Valor pago é insuficiente.")
            return;
        }
    } else {
        alert("Valor pago inválido");
        return;
    }
});

$("#modal-close-btn").click(function () {
    resetModal();
});