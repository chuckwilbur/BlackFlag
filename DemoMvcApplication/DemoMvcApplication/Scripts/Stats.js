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
            // Create an array of all the years from the top row
            var yearCountMap = {};
            for (var i = 0; i < topRow.cells.length; ++i) {
                var yearCell = topRow.cells[i];
                var year = parseInt(yearCell.innerText || yearCell.textContent);
                if (!isNaN(year)) yearCountMap[year] = 0;
            }

            // Fill out the number of crashes in any years returned from StatsByCity
            $.each(solution, function (i, yearCount) {
                if (typeof yearCountMap[yearCount.Key] !== 'undefined') {
                    yearCountMap[yearCount.Key] = yearCount.Value;
                }
            });

            // Create a new row and fill it out
            var row = resultTable.insertRow(-1);
            var cell = row.insertCell(-1);
            var newText = document.createTextNode(city);
            // TODO: add an action link to remove the row?
            cell.appendChild(newText);
            for (var year in yearCountMap) {
                var cell = row.insertCell(-1);
                var newText = document.createTextNode(yearCountMap[year]);
                cell.appendChild(newText);
            }
        },
        "json");
}
