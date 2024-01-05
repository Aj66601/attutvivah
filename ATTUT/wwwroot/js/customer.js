$('.add-billAddress').click(function () {

    var _stateId = $('#stateDdl').val();
    var _stateName = $("#stateDdl option:selected").text();
    var _billAddress = $('#billAddress').val();
    var _pincode = $("#pincode").val();
    var _gstNo = $('#GstNo').val();
    var sts = false;
    debugger;
    if (_stateId == 0 || _stateId == "") {
        $('#stateDdl').css({ border: "1px solid Red" });
        sts = true;
    }
    else {
        $('#stateDdl').css({ border: "1px solid #ccc" });

    }
    if (_billAddress == "") {
        $('#billAddress').css({ border: "1px solid Red" });
        sts = true;
    }
    else {
        $('#billAddress').css({ border: "1px solid #ccc" });

    }
    if (_pincode == "" || _pincode.length != 6) {
        $('#pincode').css({ border: "1px solid Red" });
        sts = true;
    }
    else {
        $('#pincode').css({ border: "1px solid #ccc" });

    }
    if (_gstNo == "") {
        $('#GstNo').css({ border: "1px solid Red" });
        sts = true;
    }
    else {
        $('#GstNo').css({ border: "1px solid #ccc" });
    }
    if (sts) { return false; }
    else {       
    var rowCount = $('#tblBillAddress tr').length;
        if (rowCount > 0)
            rowCount -= 1;
            var row1 = '<tr>';
            row1 += ' <td>';
            row1 += '<input class="BillAddress" data-val="true" id="BillAddresses_' + rowCount + '__BillAddress" name="BillAddresses[' + rowCount + '].BillAddress" type="hidden" value="' + _billAddress + '">';
            row1 += _billAddress;
            row1 += '</td>';
            row1 += '<td>';
            row1 += '<input class="StateId" data-val="true" id="BillAddresses_' + rowCount + '__StateId" name="BillAddresses[' + rowCount + '].StateId" type="hidden" value="' + _stateId + '">';
            row1 += _stateName;
            row1 += '</td>';
            row1 += '<td>';
            row1 += '<input class="Pincode" data-val="true" id="BillAddresses_' + rowCount + '__Pincode" name="BillAddresses[' + rowCount + '].Pincode" type="hidden" value="' + _pincode + '">';
            row1 += _pincode;
            row1 += '</td>';
            row1 += '<td>';
            row1 += '<input class="GstNo" data-val="true" id="BillAddresses_' + rowCount + '__GstNo" name="BillAddresses[' + rowCount + '].GstNo" type="hidden" value="' + _gstNo + '">';
            row1 += _gstNo;
            row1 += '</td>';
        row1 += '<td><input value="0" class="IsHide" id="BillAddresses_' + rowCount + '__IsHide" name="BillAddresses[' + rowCount + '].IsHide" type="hidden"><button type="button" onclick="HideRow(this)"><i class="fa fa-minus-circle text-danger" aria-hidden="true"></i></button></td>';
            row1 += '</tr>';
            $('#tblBillAddress tbody').append(row1);
        
    }
});

$('.add-shipAddress').click(function () {
    var _shipAddress = $('#shipAddress').val();
    var sts1 = false;
    if (_shipAddress == "") {
        $('#shipAddress').css({ border: "1px solid Red" });
        sts1 = true;
    }
    else {
        $('#shipAddress').css({ border: "1px solid #ccc" });

    }
    if (sts1) { return false; }
    else {
        var rowCount = $('#tblShipAddress tr').length;
        if (rowCount > 0)
            rowCount -= 1;
        var row1 = '<tr>';
        row1 += ' <td>';
        row1 += '<input class="ShipAddress" data-val="true" id="ShipAddresses_' + rowCount + '__ShipAddress" name="ShipAddresses[' + rowCount + '].ShipAddress" type="hidden" value="' + _shipAddress + '">';
        row1 += _shipAddress;     
        row1 += '<td><input value="0" class="IsHide" id="ShipAddresses_' + rowCount + '__IsHide" name="ShipAddresses[' + rowCount + '].IsHide" type="hidden"><button type="button" onclick="HideShipRow(this)"><i class="fa fa-minus-circle text-danger" aria-hidden="true"></i></button></td>';
        row1 += '</tr>';
        $('#tblShipAddress tbody').append(row1);

    }
});
function HideRow(evt) {
    $(evt).closest('tr').find('.IsHide').val('1');
    $(evt).closest('tr').hide();
}
function HideShipRow(evt) {
    $(evt).closest('tr').find('.IsHide').val('1');
    $(evt).closest('tr').hide();
}