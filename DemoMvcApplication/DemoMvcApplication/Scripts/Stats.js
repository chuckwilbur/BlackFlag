function GetCityList(cityListAddress) {

    var county = jQuery.trim($("#CountyList").val());
    if (county.length < 1) return;

    $.post(cityListAddress,
        { county: county },
        function (solution) {
            var cityList = $('#CityList');
            cityList.empty();

            cityList.append("<option>Select city...</option>");
            $.each(solution, function (i, city) {
                //Add an option to the city list
                cityList.append("<option>" + city + "</option>");
            });
        },
        "json");
}

function AddCityStats(statsByCityAddress) {
    var county = jQuery.trim($("#CountyList").val());
    if (county.length < 1) return;
    var city = jQuery.trim($("#CityList").val());
    if (city.length < 1) return;

    $.post(statsByCityAddress,
        { county: county, city: city },
        function (solution) {
            var resultTable = document.getElementById("resultTable");
            var topRow = resultTable.rows[0];
            var yearCountMap = {};
            for (var i = 0; i < topRow.cells.length; ++i) {
                var yearCell = topRow.cells[i];
                var year = parseInt(yearCell.innerText);
                if (!isNaN(year)) yearCountMap[year] = 0;
            }
            $.each(solution, function (i, yearCount) {
                if (typeof yearCountMap[yearCount.Key] !== 'undefined') {
                    yearCountMap[yearCount.Key] = yearCount.Value;
                }
            });

            var row = resultTable.insertRow();
            var cell = row.insertCell();
            var newText = document.createTextNode(city);
            // TODO: add an action link to remove the row?
            cell.appendChild(newText);
            for (var year in yearCountMap) {
                var cell = row.insertCell();
                var newText = document.createTextNode(yearCountMap[year]);
                cell.appendChild(newText);
            }
        },
        "json");
}
