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
                var title = result.Title;
                var description = result.description;
                var firstName = result.worker.firstName;
                var lastName = result.worker.lastName;

                $('.job-' + jobId).html('<h2>' + result.Title + '</h2><p>' + description + '</p><p>This job is claimed by ' + firstName + ' ' + lastName + '</p>');

            }
        });
    });
});