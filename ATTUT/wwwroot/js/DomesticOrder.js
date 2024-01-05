$('#add-items').click(function () {
    var isValid = true;
    $('#DdlItem,#Remarks').each(function () {
        if ($.trim($(this).val()) == '') {
            isValid = false;
            $(this).css({
                "border": "1px solid red"
            });
        }
        else {
            $(this).css({
                "border": "1px solid #cccccc"
            });
            isValid == true;
        }
    });
    if (isValid == true) {

        var ItemId = $('#DdlItem').val();
        var ItemName = $('#DdlItem option:selected').text();
        var Remarks = $('#Remarks').val();

        var sts = false;
        $("#tblItems tbody tr").each(function () {
            var _ItemId = $(this).find("input.ItemId").val();
            var IsHide = $(this).find("input.IsHide").val();
            if (_ItemId >0 && IsHide == 0) {
                if (_ItemId == ItemId) {
                    sts = true;
                }
            }
        });
        if (sts) {
            alert("Item already added. Please choose different Item.");
            return false;
        }
        var rowCount = $('#tblItems tr').length;
        if (rowCount > 0)
            rowCount -= 1;
        var row1 = '<tr>'
        row1 += ' <td>';
        row1 += '<input class="ItemId" data-val="true" data-val-number="The field ItemId must be a number." data-val-required="The ItemId field is required." id="domesticOrderItems_' + rowCount + '__ItemId" name="domesticOrderItems[' + rowCount + '].ItemId" type="hidden" value=' + ItemId + '>';
        row1 += '<input class="ItemName" data-val="true" id="domesticOrderItems_' + rowCount + '__Gender" name="domesticOrderItems[' + rowCount + '].Gender" type="hidden" value="' + ItemName + '">';
        row1 += ItemName;
        row1 += '</td>';
        row1 += '<td>';
        row1 += '<input class="form-control Remarks" id="domesticOrderItems_' + rowCount + '__Remarks" name="domesticOrderItems[' + rowCount + '].Remarks" type="text" value="' + Remarks + '">';
        row1 += '</td>';
        row1 += '<td>';
        row1 += '<input class="IsHide" data-val="true" data-val-number="The field IsHide must be a number." data-val-required="The IsHide field is required." id="domesticOrderItems_' + rowCount + '__IsHide" name="domesticOrderItems[' + rowCount + '].IsHide" type="hidden" value="0">';
        row1 += '<button type = "button" onclick = "HideRow(this);" > <i class="fa fa-trash" aria-hidden="true"></i></button>';
        row1 += '</td>';
        row1 += '</tr>';
        $('#tblItems tbody').append(row1);
    }
});
function HideRow(evt) {
    $(evt).closest('tr').find('.IsHide').val('1');
    $(evt).closest('tr').hide();
}

function GetDomesticetail() {
    var _DdlItem = $('#DdlItem').val()
    if (_DdlItem > 0) {
        $.ajax({
            type: "GET",
            url: "../Master/DomesticProductListbyID",
            data: { PId: _DdlItem },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var imageurl = (data[0]['imageURL']);
                frame.src = imageurl;
            },
            failure: function () {
                alert("Failed!");
            }
        })
    }
}