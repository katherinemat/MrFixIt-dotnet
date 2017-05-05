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

    $('.confirm-claim-job').click(function (event) {
        var jobId = this.value;
        console.log(jobId);
        $.ajax({
            url: '/Jobs/ClaimConfirmed/' + jobId,
            type: 'POST',
            dataType: 'json',
            success: function (result) {
                var editedCupcake = result.name;
                console.log(result);
            }
        });
    });
});