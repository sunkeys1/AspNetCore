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

var dataTable;

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
                     <a onClick=Delete('/admin/usergroup/delete/${data}') class="btn btn-danger mx-2"><i class="bi bi-trash"></i> Delete</a>
                    </div>`
                },
                "width": "20%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!',
        color: '#ffffff',
        background: '#716add'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}