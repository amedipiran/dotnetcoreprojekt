var dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
         "ajax": {url:'/admin/company/getall'},
         "columns": [
             { "data": "name" , "width": "25%"},
             { "data": "streetAddress", "width": "15%" },
             { "data": "city", "width": "15%" },
             { "data": "state", "width": "10%" },
             { "data": "postalCode", "width": "10%" },
             { "data": "phoneNumber", "width": "10%" },


             { "data": "id",
                "render": function(data){
                    return `<div class="w-75 btn-group">
                    <a href="/admin/product/upsert?id=${data}" class="btn btn-primary btn-sm my-1 mx-md-1 my-gradient-btn">
                    <i class="bi bi-pencil-square"> </i> Ändra
                    </a>
                    <a onClick="Delete('/admin/product/delete/${data}')" class="btn btn-danger btn-sm my-1 mx-md-1">
                    <i class="bi bi-trash-fill"> </i> Radera
                    </a>
                    </div>`
                }, 
              "width": "35%" }

         ]
    });
 }
 

function Delete(url) {
    Swal.fire({
        title: "Är du säker?",
        text: "Denna åtgärd går inte att ångra!",
        icon: "warning",
        showCancelButton: true,
        cancelButtonText: "Avbryt",
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Ja, radera det!"
      }).then((result) => {
        if (result.isConfirmed) {
       $.ajax({
        url: url,
        type:'DELETE',
        success: function(data) {
            dataTable.ajax.reload();
            toastr.success(data.message);
        }
       })
        }
      });
}