function GetCityList(cityListAddress) {

    var county = jQuery.trim($("#CountyList").val());
    if (!county) return;

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
    if (!county) return;
    var city = jQuery.trim($("#CityList").val());
    if (!city) return;

    $.post(statsByCityAddress,
        { county: county, city: city },
        function (solution) {
            var resultTable = document.getElementById("resultTable");
            var topRow = resultTable.rows[0], row, cell, newText;
            // Create an array of all the years from the top row
            var yearCountMap = {}, yearCell, year;
            for (var i = 0; i < topRow.cells.length; ++i) {
                yearCell = topRow.cells[i];
                year = parseInt(yearCell.innerText || yearCell.textContent);
                if (year) yearCountMap[year] = 0;
            }

            // Fill out the number of crashes in any years returned from StatsByCity
            $.each(solution, function (i, yearCount) {
                yearCountMap[yearCount.Key] = yearCount.Value;
            });

            // Create a new row and fill it out
            row = resultTable.insertRow(-1);
            cell = row.insertCell(-1);
            newText = document.createTextNode(city);
            // TODO: add an action link to remove the row?
            cell.appendChild(newText);
            for (var year in yearCountMap) {
                if (yearCountMap.hasOwnProperty(year)) {
                    cell = row.insertCell(-1);
                    newText = document.createTextNode(yearCountMap[year]);
                    cell.appendChild(newText);
                }
            }
            chart.RenderGraph(yearCountMap, city + " (" + county + ")");
        },
        "json");
}

var chart = (function () {
    var pub = {};

    var crashChart;
    var data = [];

    pub.RenderGraph = function (yearCountMap, lineTitle) {

        var graphLine = [];
        for (var year in yearCountMap) {
            if (yearCountMap.hasOwnProperty(year)) {
                graphLine.push({ x: year, y: yearCountMap[year] });
            }
        }
        data.push({ name: lineTitle, data: graphLine });

        if (!crashChart) {
            crashChart = new Contour({
                el: '.crashChart',
                xAxis: { title: 'Year', type: 'linear' },
                yAxis: { title: 'Number of Pedcycle crashes' },
                legend: { vAlign: 'top', hAlign: 'right' }
            })
            .cartesian()
            .line()
            .tooltip();
        }
        crashChart.setData(data).legend(data).render();
    }
    return pub;
} ());
