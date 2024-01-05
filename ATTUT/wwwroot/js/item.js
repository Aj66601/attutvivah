function GetPricing(ItemId) {
    var cId = $('#CompanyId').val();
  
        $.ajax({
            type: 'GET',
            url: "/Item/GetItemPricing",
            dataType: 'html',
            data: { cid: cId, itemId: ItemId },
            success: function (data) {
                $("#divItemPrice").empty().append(data);

            },
            error: function (ex) {
                $("#divItemPrice").empty().append(ex.responseText);
            }
        }); 
}

