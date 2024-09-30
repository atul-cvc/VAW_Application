/// <reference path="jquery-3.4.1.min.js" />
function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}

$(document).ready(function () {
    // Global DataTable options
    $.extend($.fn.dataTable.defaults, {
        //paging: true,
        //language: {
        //    lengthMenu: "Show _MENU_ entries",
        //    info: "Showing _START_ to _END_ of _TOTAL_ entries",
        //    infoEmpty: "No entries available",
        //    search: "Search:",
        //    zeroRecords: "No matching records found"
        //},
        dom: 'Bfrtlip', // Buttons, filter, table, etc.
        buttons: [
            'copy',
            //'csv',
            'excel',
            'pdf',
            'print'
        ],
        lengthMenu: [5, 10, 25, 50, 100]
    });    
});


function handlePopup(data) {
    alert(data);
}