$(document).ready(function () {
    $('.claim-job').click(function (event) {
        var jobId = this.value;
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: '/Jobs/Claim/' + jobId,
            success: function (result) {
                $('.job-' + jobId).html(result);
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