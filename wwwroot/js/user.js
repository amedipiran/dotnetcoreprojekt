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
             { "data": "", "width": "10%" },


             { "data": "id",
                "render": function(data){
                    return `<div class="w-75 btn-group">
                    <a href="/admin/company/upsert?id=${data}" class="btn btn-primary btn-sm my-1 mx-md-1 my-gradient-btn">
                    <i class="bi bi-pencil-square"> </i> Ändra
                    </a>
                    </div>`
                }, 
              "width": "35%" }

         ]
    });
 }
 

