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

    $('.activate-job').click(function (event) {
        var jobId = this.value;
        console.log(jobId);
        $.ajax({
            url: '/Jobs/Activate/' + jobId,
            type: 'POST',
            dataType: 'json',
            success: function (result) {
                $('.temporary-activated-job').html('<h4>' + result.title + '</h4><button class="complete-job" value="' + jobId + '">Mark job complete</button>');
                
                $('.unstarted-' + jobId).remove();
                console.log(result);
            }
        });
    });

    $('.complete-job').click(function (event) {
        var jobId = this.value;
        console.log(jobId);
        $.ajax({
            url: '/Jobs/Complete/' + jobId,
            type: 'POST',
            dataType: 'json',
            success: function (result) {
                $('.temporary-completed-job').html('<h4>' + result.title + '</h4>');
                $('.activated-' + jobId).remove();
                $('.worker-available').html('<h2>You don\'t have any activated jobs. Please <a href="/Jobs">select a job</a></h2>');
            }
        });
    });

    //$('.activated-' + jobId).remove();
});