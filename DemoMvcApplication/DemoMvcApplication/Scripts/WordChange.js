function Solve(solveAddress) {
    var solveResultDiv = $('#solveResult');
    solveResultDiv.empty();
    solveResultDiv.append($('<li/>').append("Thinking..."));

    var startWord = jQuery.trim($("#StartWord").val());
    if (startWord.length < 1) return;
    var endWord = jQuery.trim($("#EndWord").val());
    if (endWord.length < 1) return;

    $.post(solveAddress,
        { startWord: startWord, endWord: endWord },
        function (solution) {
            solveResultDiv.empty();
            if (solution.length == 0) {
                solveResultDiv.append($('<li/>').append("No solution found."));
            }
            $.each(solution, function (i, word) {
                // Skip start and end words (already shown in textboxes)
                if (i == 0) return;
                if (i == solution.length - 1) return;

                //Add a word to the <ul> solveResult on the right
                solveResultDiv.append($('<li/>').append(word));
            });
        },
        "json");
}
