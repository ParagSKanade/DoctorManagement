$(document).ready(function () {
    $("#DoctorPanel").show();
    $("#DoctorRadio").click(function () {
        console.log("click");
        $("#DoctorPanel").show();
        $("#PatientPanel").hide();
    });
    $("#PatientRadio").click(function () {
        $("#DoctorPanel").hide();
        $("#PatientPanel").show();
        });
    });