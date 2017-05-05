$(document).ready(function () {
    console.log("hey");
    $('.edit-form').click(function (event) {
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: '/Cupcake/Edit/' + this.value,
            success: function (result) {
                $('.return-edit').html(result);
            }
        });
    });

    $('.edit-cupcake').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: 'Cupcake/Edit',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                var editedCupcake = result.name;
                var cupcakeId = result.id.toString();
                $('#' + cupcakeId).text(editedCupcake);
            }
        });
    });
});