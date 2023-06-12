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
            { data: 'description', "width": "25%" },
            { data: 'user.login', "width": "20%" },    
            { data: 'createdDate', "width": "20%" },
            { data: 'code', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div>
                     <a href="/admin/usergroup/upadd?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil"></i> Edit</a>
                     <a href="/admin/usergroup/delete/${data}" class="btn btn-danger mx-2"><i class="bi bi-trash"></i> Delete</a>
                    </div>`
                },
                "width": "20%"
            }
        ]
    });
}