$(document).ready(function(){

    var firstName = $('#firstName').val();
    var lastName = $('#lastName').val();
    var department = $('#department').val();
    var semester = $('#semester').val();

    $('#studentCreateSubmit').click(function () {

        if ($('#firstName').val() == "" || $('#lastName').val() == "" || $('#department').val() == "" || $('#semester').val() == "") {

            alert("You can't leave any fields empty !");
            
        }

        else {
            $.ajax({
                type: 'POST',
                data: $('#studentCreateForm').serialize(),
                success: function (response) {
                    alert("SUCCESS");
                },
                error: function (response) {
                    alert("ERROR");
                }
            });
        }

    });

    $('#studentEditSubmit').click(function(){

        if (firstName != "" && lastName != "" && department != "" && semester != "") {

            $.ajax({
                type: 'POST',
                data: $('#studentEditForm').serialize(),
                success: function (response) {
                    alert("SUCCESS");
                },
                error: function (response) {
                    alert("ERROR");
                }
            });
        }

        else {
            alert("You can't leave any fields empty !");
        }
        
    });

    $('#studentDeleteSubmit').click(function(){
        
        if (firstName != "" && lastName != "" && department != "" && semester != "") {

            $.ajax({
                type: 'POST',
                data: $('#studentDeleteForm').serialize(),
                success: function (response) {
                    alert("SUCCESS");
                },
                error: function (response) {
                    alert("ERROR");
                }
            });
        }

        else {
            alert("You can't leave any fields empty !");
        }
        
    });

});