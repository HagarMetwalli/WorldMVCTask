$(document).ready(function () {
    $("#countrytbl").DataTable(
        {
            ajax: {
                url: "/Countries/CountryAjex",
                dataSrc: ""
            },
            LengthChange: true,
            lengthMenu: [[5, 10, -1], [5, 10, "All"]],
            Paginate: true,
            columns: [
                { 'title': 'ID', 'data': 'Id' },
                { 'title': 'Name', 'data': 'CountryName' },
                {
                    'title': 'Added Date', 'data': 'AddedDateTime'

                },
                {
                    'data': 'Id', 'width': '50px', 'render': function (data) {
                        return '<a class="btn btn-info" href="/Countries/Details/' + data + '"> Details</a>'
                    }
                },
                {
                    'data': 'Id', 'width': '50px', 'render': function (data) {
                        return '<a class="btn btn-warning" href="/Countries/Edit/' + data + '"> Edit</a>'
                    }
                },
                {
                    'data': 'Id', 'width': '50px', 'render': function (data) {
                        return '<a class="btn btn-danger" href="/Countries/Delete/' + data + '"> Delete</a>'
                    }
                }
            ]
        });
})