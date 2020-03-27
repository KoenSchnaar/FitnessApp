// pratice on index page
var theDiv = $("#homeText");
theDiv.hide();

var button = $("#hideButton");
button.on("click", function () {
    theDiv.toggle();
});


// Pop-up Exercise Info
var exerciseInfo = $(".popupExerciseInfo");
exerciseInfo.hide();


var exerciseInfoBtn = $(".exerciseInfoBtn");
exerciseInfoBtn.on("click", function () {
    console.log("You clicked " + $(this).text())
    exerciseInfo.toggle();
});

// image preview onchange
function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}