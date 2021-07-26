$(document).ready(function () {
    $('#citytbl').dataTable({
        ajax: {
            url: "/Cities/CityAjex",
            dataSrc: ""
        },
        LengthChange: true,
        lengthMenu: [[5, 10, -1], [5, 10, "All"]],
        Paginate: true,
        columns: [
            { 'title': 'ID', 'data': 'Id' },
            { 'title': 'Name', 'data': 'CityName' },
            { 'title': 'Country', 'data': "Country.CountryName" },
            { 'title': 'AddedDate', 'data': 'AddedDate' },
            {
                'data': 'Id', 'width': '50px', 'render': function (data) {
                    return '<a class="btn btn-info" href="/Cities/Details/' + data + '"> Details</a>'
                }
            },
            {
                'data': 'Id', 'width': '50px', 'render': function (data) {
                    return '<a class="btn btn-warning" href="/Cities/Edit/' + data + '"> Edit</a>'
                }
            },
            {
                'data': 'Id', 'width': '50px', 'render': function (data) {
                    return '<a class="btn btn-danger" href="/Cities/Delete/' + data + '"> Delete</a>'
                }
            }
        ]

    });
});


function OnSuccess(response) {
    console.log(response);
    $("#citytbl").DataTable(
        {
            LengthChange: true,
            lengthMenu: [[5, 10, -1], [5, 10, "All"]],
            Filter: true,
            Sort: true,
            Paginate: true,
            data: response,
            columns: [
                { 'title': 'ID', 'data': 'Id' },
                { 'title': 'Name','data': 'CityName' },
                //{ 'title': 'Country', 'data': 'Country.CountryName' },
                //{ 'title': 'Date', 'data': 'AddedDate'},
                {
                    'data': 'Id', 'width': '50px', 'render': function (data) {
                        return '<a class="btn btn-info" href="/Cities/Details/'+data+'"> Details</a>'
                    }
                },
                {
                    'data': 'Id', 'width': '50px', 'render': function (data) {
                        return '<a class="btn btn-warning" href="/Cities/Edit/' + data + '"> Edit</a>'
                    }
                },
                {
                    'data': 'Id', 'width': '50px', 'render': function (data) {
                        return '<a class="btn btn-danger" href="/Cities/Delete/' + data + '"> Delete</a>'
                    }
                }
            ]
        });
}
