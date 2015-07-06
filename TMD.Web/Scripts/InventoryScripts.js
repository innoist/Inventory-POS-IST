$(document).ready(function() {
    
});
function LoadProductByProductCode(control) {
    var productCode = $("#" + control.id).val();
    $.blockUI({ message: '<h3><img src="../Images/loading.gif" height=55px; width=55px; /> Fetching Product...</h2>' });

    if (productCode != "" && productCode != "0") {
        $.ajax({
            url: "/Api/Product",
            type: "GET",
            data: { id: productCode },
            dataType: "json",
            success: ProductLoaded,
            error: function (textStatus, errorThrown) {
                $.unblockUI();
                alert("Status: " + textStatus); alert("Error: " + errorThrown);
            }
        });
    }
}
function ProductLoaded(data) {
    $.unblockUI();
    if (data.ProductId <= 0) {
        toastr.error("No Product found with given Code");

        $("#btnInventoryItemSubmit").attr("disabled", true);
    } else {
        toastr.success("Product found successfully");
        $("#Barcode").val(data.ProductBarCode);
        $("#ProductName").val(data.Name);
        $("#SalePrice").val(data.SalePrice);
        $("#PurchasePrice").val(data.PurchasePrice);
        $("#ProductDescription").val(data.Comments);
        $("#ProductId").val(data.ProductId);
        $("#AvailableItems").val(data.AvailableItems);

        ShowProfit();
        $("#btnInventoryItemSubmit").attr("disabled", false);
    }
}
function LoadProductByBarCode() {
    alert("product loaded");
}
function CalculateProfit(from, to) {
    if (from > 0) {
        var profit = ((to - from) / from) * 100;
        return profit > 0 ? profit.toFixed(2) : 0;
    } else {
        return 0;
    }
}
function ShowProfit() {
    var fromValue = parseInt($("#PurchasePrice").val());
    var toValue = parseInt($("#SalePrice").val());
    var profit = CalculateProfit(isNaN(fromValue) ? 0 : fromValue, isNaN(toValue) ? 0 : toValue);
    $("#Profit").val(profit);
}