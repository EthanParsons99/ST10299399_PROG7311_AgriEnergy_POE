document.addEventListener("DOMContentLoaded", function () {
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl)
    });

    var startDateInput = document.querySelector('input[name="startDate"]');
    var endDateInput = document.querySelector('input[name="endDate"]');

    if (startDateInput && !startDateInput.value) {
        var thirtyDaysAgo = new Date();
        thirtyDaysAgo.setDate(thirtyDaysAgo.getDate() - 30);
        startDateInput, valueAsDate = thirtyDaysAgo;
    }

    if (endDateInput && !endDateInput.value) {
        var today = new Date();
        endDateInput.valueAsDate = today;
    }

    var confrimButtons = document.querySelector('.confirm-action');
    confrimButtons.foreach(function (button) {
        button.addEventListener('click', function (e) {
            if (!confirm('Are you sure you want to proceed?')) {
                e.preventDefault();
            }
        });
    });
});
