$(document).ready(function() {
    
});
function LoadCustomerByCode(control) {
    var code = $("#" + control.id).val();
    if (code == "")
        return;
    $.blockUI({ message: '<h3><img src="../Images/loading.gif" height=55px; width=55px; /> Fetching Product...</h2>' });

    if (code != "" && code != "0") {
        $.ajax({
            url: "/Api/Product",
            type: "GET",
            data: { id: code },
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

        //For New Product Page Fields
        $("#Category").val(data.CategoryId);
        $("#MinSalePriceAllowed").val(data.MinSalePriceAllowed);
        $("#ProductModel_ProductId").val(data.ProductId);
        $("#ProductModel_RecCreatedBy").val(data.RecCreatedBy);
        $("#ProductModel_RecCreatedDate").val(data.RecCreatedDate);
        //END For New Product Page Fields
        ShowProfit();
        $("#btnInventoryItemSubmit").attr("disabled", false);
    }
}

function LoadCustomerByEmailOrPhone(control) {
    var code = $("#" + control.id).val();
    $.blockUI({ message: '<h3><img src="../Images/loading.gif" height=55px; width=55px; /> Fetching Product...</h2>' });

    if (code != "" && code != "0") {
        $.ajax({
            url: "/Api/Customer",
            type: "GET",
            data: { id: code },
            dataType: "json",
            success: CustomerLoaded,
            error: function (textStatus, errorThrown) {
                $.unblockUI();
                alert("Status: " + textStatus); alert("Error: " + errorThrown);
            }
        });
    }
}
function CustomerLoaded(data) {
    $.unblockUI();
    if (data==null) {
        toastr.error("No Customer found.");
    } else {
        toastr.success("Customer found successfully");
        var Id = data.Id;
        var Name = data.Name;
        var Phone = data.Phone;
        var Address = data.Address;
        var Email = data.Email;
        var Comments = data.Comments;
        var RecCreatedDate = data.RecCreatedDate;
        var RecLastUpdatedDate = data.RecLastUpdatedDate;
        var RecCreatedBy = data.RecCreatedBy;
        var RecLastUpdatedBy = data.RecLastUpdatedBy;
    }
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