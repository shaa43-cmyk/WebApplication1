$(document).ready(function () {

    $("#btnCalculate").click(function () {
        calculatePremium();
    });

    $("#ddlOccupation").change(function () {
        calculatePremium();
    });

});

function calculatePremium() {

    var request = {
        Name: $("#txtName").val(),
        AgeNextBirthday: parseInt($("#txtAge").val()),
        DateOfBirth: $("#txtDob").val(),
        Occupation: $("#ddlOccupation").val(),
        DeathSumInsured: parseFloat($("#txtDeathSum").val())
    };

    if (!request.Name || !request.AgeNextBirthday || !request.DateOfBirth ||
        !request.Occupation || !request.DeathSumInsured) {
        alert("All fields are mandatory.");
        return;
    }

    $.ajax({
        url: "/api/premium/calculate",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(request),
        success: function (response) {
            $("#premiumResult").text(response.MonthlyPremium);
        },
        error: function () {
            alert("Calculation failed.");
        }
    });
}