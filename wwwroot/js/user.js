var dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
         "ajax": {url:'/admin/user/getall'},
         "columns": [
             { "data": "name" , "width": "25%"},
             { "data": "email", "width": "15%" },
             { "data": "phoneNumber", "width": "15%" },
             { "data": "company.name", "width": "10%" },
             { "data": "role", "width": "10%" },


             { "data": {id: "id", lockoutEnd: "lockoutEnd"},
                "render": function(data){
                    let today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();

                    if(lockout > today) {
                        return `<div class="text-center">
                        <a onClick=LockUnlock('${data.id}') class="btn btn-danger fs-6 mb-2 text-white" style="cursor:pointer; width:150px;">
                        <em class="bi bi-lock-fill"></em>Lås</a>

                            <a href="/admin/user/RoleManagement?userId=${data.id}" class="btn btn-danger fs-6  text-white" style="cursor:pointer; width:150px;">
                            <em class="bi bi-pencil-square"></em>Behörighet</a>
                        </div>`
                    } else {
                        return `<div class="text-center">
                        <a onClick=LockUnlock('${data.id}') class="btn btn-success fs-6 mb-2 text-white" style="cursor:pointer; width:150px;">
                        <em class="bi bi-unlock-fill"></em>Lås upp</a>

                        <a href="/admin/user/RoleManagement?userId=${data.id}" class="btn btn-danger fs-6  text-white" style="cursor:pointer; width:150px;">
                        <em class="bi bi-pencil-square"></em>Behörighet</a>
                    </div>`
                    }


               
                }, 
              "width": "35%" }

         ]
    });
 }
 



 function LockUnlock(id) {
    $.ajax({
        type: "POST",
        url: "/Admin/User/LockUnlock",
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            toastr.success(data.message);
            dataTable.ajax.reload();
        }
    })
 }