var dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
         "ajax": {url:'/admin/order/getall'},
         "columns": [
             { "data": "id" , "width": "25%"},
             { "data": "name", "width": "15%" },
             { "data": "phoneNumber", "width": "15%" },
             { "data": "applicationUser.email", "width": "10%" },
             { "data": "orderStatus", "width": "10%" },
             { "data": "orderTotal", "width": "10%" },

             { "data": "id",
                "render": function(data){
                    return `<div class="w-75 btn-group">
                    <a href="/admin/order/details?orderId=${data}" class="btn btn-primary btn-sm my-1 mx-md-1 my-gradient-btn">
                    <i class="bi bi-pencil-square"> </i>
                    </a>
                    </div>`
                }, 
              "width": "35%" }

         ]
    });
 }
 
