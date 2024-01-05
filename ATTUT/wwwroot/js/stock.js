function GetWarehouse() {
    var branchId = $('#BranchId').val();
    if (branchId > 0) {
        $.ajax({
            type: "GET",
            url: "/General/DdlWarehouse_Json",
            data: { branchId: branchId },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $("#WarehouseId").empty().append($("<option/>").val('').text("--select--"));
                $.each(data, function () {
                    $("#WarehouseId").append($("<option/>").val(this.value).text(this.text));
                });
            },
            failure: function () {
                alert("Failed!");
            }
        })
    }
    else {
        $('#BranchId').val('');
    }
};

$('.add-items').click(function () {
    var _warehouseId = $('#WarehouseId').val();
    var _warehouseName = $("#WarehouseId option:selected").text();
    var _itemId = $('#DdlItem').val();
    var _itemName = $("#DdlItem option:selected").text();
    var _colorId = $('#DdlColor').val();
    var _colorName = $('#DdlColor').val();// $("#DdlColor option:selected").text();
    var _mrp = $('#mrp').val();
    var _discount = $('#discount').val();
    var _flatDiscount = $('#flatDiscount').val();
    var _qty = $('#qty').val();
    var _total = $('#total').val();
    var sts = false;

    if (_warehouseId == 0 || _warehouseId == "") {
        $('#WarehouseId').css({ border: "1px solid Red" });
        sts = true;
    }
    else {
        $('#WarehouseId').css({ border: "1px solid #ccc" });

    }
    if (_itemId == 0 || _itemId == "") {
        $('#DdlItem').css({ border: "1px solid Red" });
        sts = true;
    }
    else {
        $('#DdlItem').css({ border: "1px solid #ccc" });

    }
    if (_colorId == 0 || _colorId == "") {
        $('#DdlColor').css({ border: "1px solid Red" });
        sts = true;
    }
    else {
        $('#DdlColor').css({ border: "1px solid #ccc" });

    }
    if (_mrp == "" || parseFloat(_mrp) == 0) {
        $('#mrp').css({ border: "1px solid Red" });
        sts = true;
    }
    else {
        $('#mrp').css({ border: "1px solid #ccc" });

    }
    //if (_discount == "") {
    //    $('#discount').css({ border: "1px solid Red" });
    //    sts = true;
    //}
    //else {
    //    $('#discount').css({ border: "1px solid #ccc" });

    //}
    //if (_flatDiscount == "") {
    //    $('#flatDiscount').css({ border: "1px solid Red" });
    //    sts = true;
    //}
    //else {
    //    $('#flatDiscount').css({ border: "1px solid #ccc" });
    //}
    if (_qty == "" || parseInt(_qty) == 0) {
        $('#qty').css({ border: "1px solid Red" });
        sts = true;
    }
    else {
        $('#qty').css({ border: "1px solid #ccc" });
    }
    if (_total == "" || parseInt(_total) == 0) {
        $('#total').css({ border: "1px solid Red" });
        sts = true;
    }
    else {
        $('#total').css({ border: "1px solid #ccc" });
    }
    var sts1 = false;
    $("#tblItems tbody tr").each(function () {
        var tblItemId = $(this).find("input.ItemId").val();
        var tblColorId = $(this).find("input.ColorId").val();
        var tblColorId = $(this).find("input.ColorId").val();
        var IsHide = $(this).find("input.IsHide").val();
        if (tblItemId > 0 && IsHide == 0) {
            if (tblItemId == _itemId && tblColorId == _colorId && WarehouseId==_warehouseId) {
                sts1 = true;
            }
        }

    });
    if (sts1) {
        alert("Item already added. Please choose different item.");
        Reset();
        return false;
    }

    if (sts) { return false; }
    else {
        var rowCount = $('#tblItems tr').length;
        if (rowCount > 0)
            rowCount -= 1;
        var row1 = '<tr>';
        row1 += ' <td>';
        row1 += '<input class="WarehouseId" data-val="true" id="StockItems_' + rowCount + '__WarehouseId" name="StockItems[' + rowCount + '].WarehouseId" type="hidden" value="' + _warehouseId + '">';
        row1 += '<input class="DiscountPercent" data-val="true" id="StockItems_' + rowCount + '__DiscountPercent" name="StockItems[' + rowCount + '].DiscountPercent" type="hidden" value="' + _discount + '">';
        row1 += '<input class="FlatDiscount" data-val="true" id="StockItems_' + rowCount + '__FlatDiscount" name="StockItems[' + rowCount + '].FlatDiscount" type="hidden" value="' + _flatDiscount + '">';
        row1 += '<input class="WarehouseName" data-val="true" id="StockItems_' + rowCount + '__WarehouseName" name="StockItems[' + rowCount + '].WarehouseName" type="hidden" value="' + _warehouseName + '">';
        row1 += _warehouseName;
        row1 += ' <td>';
        row1 += '<input class="ItemId" data-val="true" id="StockItems_' + rowCount + '__ItemId" name="StockItems[' + rowCount + '].ItemId" type="hidden" value="' + _itemId + '">';
        row1 += '<input class="ItemName" data-val="true" id="StockItems_' + rowCount + '__ItemName" name="StockItems[' + rowCount + '].ItemName" type="hidden" value="' + _itemName + '">';
        row1 += _itemName;
        row1 += '</td>';
        row1 += ' <td>';
        row1 += '<input class="ColorId" data-val="true" id="StockItems_' + rowCount + '__ColorId" name="StockItems[' + rowCount + '].ColorId" type="hidden" value="' + _colorId + '">';
        row1 += _colorName;
        row1 += '</td>';
        row1 += '<td>';
        row1 += '<input class="MRP" data-val="true" id="StockItems_' + rowCount + '__MRP" name="StockItems[' + rowCount + '].MRP" type="hidden" value="' + _mrp + '">';
        row1 += _mrp;
        row1 += '</td>'; 
        row1 += '<td>';
        row1 += '<input class="Qty" data-val="true" id="StockItems_' + rowCount + '__Qty" name="StockItems[' + rowCount + '].Qty" type="hidden" value="' + _qty + '">';
        row1 += _qty;
        row1 += '</td>';
        row1 += '<td>';
        row1 += '<input class="Total" data-val="true" id="StockItems_' + rowCount + '__Total" name="StockItems[' + rowCount + '].Total" type="hidden" value="' + _total + '">';
        row1 += _total;
        row1 += '</td>';
        row1 += '<td><input value="0" class="IsHide" id="StockItems_' + rowCount + '__IsHide" name="StockItems[' + rowCount + '].IsHide" type="hidden"><button type="button" onclick="HideRow(this)"><i class="fa fa-minus-circle text-danger" aria-hidden="true"></i></button></td>';
        row1 += '</tr>';
        $('#tblItems tbody').append(row1);

    };
    CalTotal();
    Reset();
});
function HideRow(evt) {
    $(evt).closest('tr').find('.IsHide').val('1');
    $(evt).closest('tr').hide();
    CalTotal();
}
function DdlItems() {
    var branchId = $('#BranchId').val();
    if (branchId > 0) {
        $.ajax({
            type: "GET",
            url: "/General/DdlMstItems_Json",
            data: { branchId: branchId },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $("#DdlItem").empty().append($("<option/>").val('').text("--select--"));
                $.each(data, function () {
                    $("#DdlItem").append($("<option/>").val(this.value).text(this.text));
                });
                $('#DdlItem').selectpicker('refresh');
            },
            failure: function () {
                alert("Failed!");
                return false;
            }
        })
    }
    else {
        alert("Please select branch!");
        return false;
    }
}
function GetItemDetailsByItemAndBranchId() {
    var _branchId = $('#BranchId').val();
    var _itemId = $('#DdlItem').val();
    var sts = false;

    if (_branchId == 0 || _branchId == "") {
        $('#BranchId').css({ border: "1px solid Red" });
        sts = true;
    }
    else {
        $('#BranchId').css({ border: "1px solid #ccc" });

    }
    if (_itemId == "" || _itemId == 0) {
        $('#DdlItem').css({ border: "1px solid Red" });
        sts = true;
    }
    else {
        $('#DdlItem').css({ border: "1px solid #ccc" });
    }
    if (sts) { return false; }
    else {
        $.ajax({
            type: 'GET',
            url: "/General/ItemPriceInfo",
            dataType: 'json',
            data: {
                itemId: _itemId, branchId: _branchId
            },
            success: function (data) {
                $('#mrp').val(data.mrp);
                $('#discount').val(data.discount);
                $('#flatDiscount').val(data.flatDiscount);
                $('#qty').val(data.qty);
                calculate();
            },
            error: function (ex) {
                alert("Failed- " + ex.responseText);
            }
        });
    }
};

function calculate() {
    var Price = $('#mrp').val();
    var Qty = $('#qty').val();
    var DiscountPercentage = $('#discount').val();
    var DiscountAmount = $('#flatDiscount').val();
    var Amount = 0.00;
    var discVal = 0;
    if (parseFloat(Qty) > 0 && Price > 0) {

        var Total = (Price * Qty);
        if (DiscountPercentage > 0) {
            $('#flatDiscount').val(0);
            DiscountAmount = 0;
            discVal = ((Total * DiscountPercentage) / 100);
        }
        if (DiscountAmount > 0) {
            $('#discount').val(0);
            DiscountPercentage = 0;
            discVal = DiscountAmount;
        }
        Amount = Total - discVal;
        $('#total').val(Amount);
    }
    else {
        $('#qty').focus();
        return false;
    }
}
function CalTotal() {
    var total = 0.00;
    $("#tblItems tbody tr").each(function () {
        if (parseInt($(this).find('.IsHide').val()) != 1) {
            total = total + parseFloat($(this).find("input.Total").val());
        }
    });
    var discount = parseFloat($('#Discount').val());
    var Paidtotal = total - discount;
    $('#TotalBillAmount').val(total);
    $('#PaidAmount').val(Paidtotal);
}
function Reset() {
    //$("#WarehouseId").val("");
    $("#DdlColor").val("");
    $('#mrp').val("");
    $('#qty').val("1");
    $('#discount').val("");
    $('#total').val("");
    $('#flatDiscount').val("");
}
function GetPriceInfo() {
    var _branchId = $('#BranchId').val();
    var _itemId = $('#DdlItem').val();
    var sts = false;

    if (_branchId == 0 || _branchId == "") {
        $('#BranchId').css({ border: "1px solid Red" });
        sts = true;
    }
    else {
        $('#BranchId').css({ border: "1px solid #ccc" });

    }
    if (_itemId == "" || _itemId == 0) {
        $('#DdlItem').css({ border: "1px solid Red" });
        sts = true;
    }
    else {
        $('#DdlItem').css({ border: "1px solid #ccc" });
    }
    if (sts) { return false; }
    else {
        $.ajax({
            type: 'GET',
            url: "/General/ItemPriceInfo",
            dataType: 'json',
            data: {
                itemId: _itemId, branchId: _branchId
            },
            success: function (data) {
                $('#discount').val(0);
                $('#flatDiscount').val(0);
                $('#mrp').val(data.ctc);
                $('#qty').val(data.qty);
                calculate();
            },
            error: function (ex) {
                alert("Failed- " + ex.responseText);
            }
        });
    }
};