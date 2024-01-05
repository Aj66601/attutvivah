jQuery(document).ready(function () {
	// 1 Capitalize string - convert textbox user entered text to uppercase
	jQuery('.Capitalize').keyup(function () {
		$(this).val($(this).val().toUpperCase());
	});

	// 2 Capitalize string first character to uppercase
	jQuery('.FirstCapital').keyup(function () {
		var caps = jQuery('.FirstCapital').val();
		caps = caps.charAt(0).toUpperCase() + caps.slice(1);
		jQuery('.FirstCapital').val(caps);
	});

	// 3 Capitalize string every 1st chacter of word to uppercase
	jQuery('#txt_firstCapital').keyup(function () {
		var str = jQuery('#txt_firstCapital').val();


		var spart = str.split(" ");
		for (var i = 0; i < spart.length; i++) {
			var j = spart[i].charAt(0).toUpperCase();
			spart[i] = j + spart[i].substr(1);
		}
		jQuery('#txt_firstCapital').val(spart.join(" "));

    });

    GetState();
});
function GetCompanyBranch() {
    var cId = $('#CompanyId').val();
    if (cId > 0) {
        $.ajax({
            type: "GET",
            url: "/General/DdlCompanyBranch_Json",
            data: { cid: cId },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $("#BranchID").empty().append($("<option/>").val('').text("--select--"));
                $.each(data, function () {
                    console.log('valuesss------ '+ this.value);
                    $("#BranchID").append($("<option/>").val(this.value).text(this.text));
                });
            },
            failure: function () {
                alert("Failed!");
            }
        })
    }
    else {
        $('#BranchID').val('');
    }
} 
function GetHSNDetails() {
    var _id = $('#HSNID').val();
    if (_id > 0) {
        $.ajax({
            type: 'GET',
            url: "/General/GetHSNDetails",
            dataType: 'html',
            data: { id: _id },
            success: function (data) {
                $("#divHsnDetails").empty().append(data);

            },
            error: function (ex) {
                $("#divHsnDetails").empty().append(ex.responseText);
            }
        });
    }
    else {
        $("#divHsnDetails").empty();
    }
}
function GetState() {
    $.ajax({
        type: "GET",
        url: "/General/DdlState_Json",
        data: { cid: 0 },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("#stateDdl").empty().append($("<option/>").val('').text("--select--"));
            $.each(data, function () {
                $("#stateDdl").append($("<option/>").val(this.value).text(this.text));
            });
        },
        failure: function () {
            alert("Failed!");
        }
    })
}