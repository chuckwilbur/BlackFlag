function Solve() {
    $("#solve").hide('normal');
    $('#solveResult').empty();
    $('#solveResult').append($('<li/>').append("Thinking..."));

    var startWord = jQuery.trim($("#StartWord").val());
    if (startWord.length < 1) return;
    var endWord = jQuery.trim($("#EndWord").val());
    if (endWord.length < 1) return;

    $.post("/WordChange/Solve",
        { startWord: startWord, endWord: endWord },
        function (solution) {
            $('#solveResult').empty();
            $.each(solution, function (i, word) {
                // Skip start and end words (already shown in textboxes)
                if (i == 0) return;
                if (i == solution.length - 1) return;

                //Add a word to the <ul> solveResult on the right
                $('#solveResult').append($('<li/>').append(word));
            });
            $('#solve').show('normal');
        },
        "json");
}
