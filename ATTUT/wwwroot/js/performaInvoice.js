function GetCustomerInfo() {
    var _contact = $('#ContactNo').val();
    if (_contact != null && _contact.length > 0 && _contact.length.trim != 10) {
        $.ajax({
            type: 'GET',
            url: "/General/GetCustomerDetails",
            dataType: 'json',
            data: { contactNo: _contact },
            success: function (data) {                 
                $('#CustomerId').val(data.id);
                $('#Name').val(data.name);
                //$('#ContactNo').val(data.contactNo);
                $('#EmailId').val(data.emailId);
                $('#PanNo').val(data.panNo);
                $('#GSTNo').val(data.gstNo);
                $('#Address').val(data.address);
                $('#StateID').val(data.stateID);
                $('#ShipTo').val(data.shipTo); 
            },
            error: function (ex) {
                alert("Failed- " + ex.responseText);
            }
        });
    }
    else {
        alert("Contact no must be 10 digit");
        $('#ContactNo').focus();
    }
};

$('.add-items').click(function () {

    var _itemId = $('#DdlItem').val();
    var _itemName = $("#DdlItem option:selected").text();
    var _colorId = $('#DdlColor').val();
    var _colorName = $('#DdlColor').val(); //$("#DdlColor option:selected").text();
    var _mrp = $('#mrp').val();
    var _discount = $('#discount').val();
    var _flatDiscount = $('#flatDiscount').val();
    var _qty = $('#qty').val();
    var _total = $('#total').val();
    var sts = false;

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
    if (_discount == "") {
        $('#discount').css({ border: "1px solid Red" });
        sts = true;
    }
    else {
        $('#discount').css({ border: "1px solid #ccc" });

    }
    if (_flatDiscount == "") {
        $('#flatDiscount').css({ border: "1px solid Red" });
        sts = true;
    }
    else {
        $('#flatDiscount').css({ border: "1px solid #ccc" });
    }
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
        var IsHide = $(this).find("input.IsHide").val();
        if (tblItemId > 0  && IsHide == 0) {
            if (tblItemId == _itemId && tblColorId == _colorId) {
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
        row1 += '<input class="ItemId" data-val="true" id="InvoiceItems_' + rowCount + '__ItemId" name="InvoiceItems[' + rowCount + '].ItemId" type="hidden" value="' + _itemId + '">';
        row1 += '<input class="ItemName" data-val="true" id="InvoiceItems_' + rowCount + '__ItemName" name="InvoiceItems[' + rowCount + '].ItemName" type="hidden" value="' + _itemName + '">';
        row1 += _itemName;
        row1 += '</td>';
        row1 += ' <td>';
        row1 += '<input class="ColorId" data-val="true" id="InvoiceItems_' + rowCount + '__ColorId" name="InvoiceItems[' + rowCount + '].ColorId" type="hidden" value="' + _colorId + '">';
         row1 += _colorName;
        row1 += '</td>';
        row1 += '<td>';
        row1 += '<input class="MRP" data-val="true" id="InvoiceItems_' + rowCount + '__MRP" name="InvoiceItems[' + rowCount + '].MRP" type="hidden" value="' + _mrp + '">';
        row1 += _mrp;
        row1 += '</td>';
        row1 += '<td>';
        row1 += '<input class="DiscountPercent" data-val="true" id="InvoiceItems_' + rowCount + '__DiscountPercent" name="InvoiceItems[' + rowCount + '].DiscountPercent" type="hidden" value="' + _discount + '">';
        row1 += _discount;
        row1 += '</td>';
        row1 += '<td>';
        row1 += '<input class="FlatDiscount" data-val="true" id="InvoiceItems_' + rowCount + '__FlatDiscount" name="InvoiceItems[' + rowCount + '].FlatDiscount" type="hidden" value="' + _flatDiscount + '">';
        row1 += _flatDiscount;
        row1 += '</td>';
        row1 += '<td>';
        row1 += '<input class="Qty" data-val="true" id="InvoiceItems_' + rowCount + '__Qty" name="InvoiceItems[' + rowCount + '].Qty" type="hidden" value="' + _qty + '">';
        row1 += _qty;
        row1 += '</td>';
        row1 += '<td>';
        row1 += '<input class="Total" data-val="true" id="InvoiceItems_' + rowCount + '__Total" name="InvoiceItems[' + rowCount + '].Total" type="hidden" value="' + _total + '">';
        row1 += _total;
        row1 += '</td>';
        row1 += '<td><input value="0" class="IsHide" id="InvoiceItems_' + rowCount + '__IsHide" name="InvoiceItems[' + rowCount + '].IsHide" type="hidden"><button type="button" onclick="HideRow(this)"><i class="fa fa-minus-circle text-danger" aria-hidden="true"></i></button></td>';
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
        debugger;
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
    else
    {
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
    $('#DdlItem').val("");
    $('#DdlColor').val("");
    $('#mrp').val("");
    $('#qty').val("1");
    $('#discount').val("");
    $('#total').val("");
    $('#flatDiscount').val("");
}