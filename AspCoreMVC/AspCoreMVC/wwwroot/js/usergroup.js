//$(document).ready(function () {   // енто оригинал
//    loadDataTable();
//});

//function loadDataTable() {
//    dataTable = $('#tabData').DataTable({
//        "ajax": { url: '/admin/usergroup/getall' },
//        "columns": [
//            { data: 'description', "width": "25%" },
//            { data: 'user.login', "width": "25%" },
//            { data: 'createdDate', "width": "25%" },
//            { data: 'code', "width": "25%" }
//        ]
//    });
//}

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tabData').DataTable({
        "ajax": { url: '/admin/usergroup/getall' },
        "columns": [
            { data: 'code', "width": "25%" },
            { data: 'description', "width": "15%" },
            { data: 'createdDate', "width": "10%" },
            { data: 'memberId', "width": "15%" }         
        ]
    });
}