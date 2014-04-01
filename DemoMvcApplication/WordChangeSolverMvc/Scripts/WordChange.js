function Solve() {
    $("#solve").hide('normal');
    $('#solveResult').empty();
    $('#solveResult').append($('<li/>').append("Thinking..."));

    var startWord = jQuery.trim($("#StartWord").val());
    if (startWord.length < 1) return;
    var endWord = jQuery.trim($("#EndWord").val());
    if (endWord.length < 1) return;
    var depth = jQuery.trim($("#Depth").val());
    depth = parseInt(depth);
    if (isNaN(depth)) depth = 20;

    $.post("/WordChange/Solve",
        { startWord: startWord, endWord: endWord, depth: depth },
        function (solution) {
            $('#solveResult').empty();
            $.each(solution, function (i, word) {
                // Skip start and end words (already shown in textboxes)
                if (i == 0) { alert("solution.ToString = " + solution.toString()); return; }
                if (i == solution.length - 1) return;

                //Add a word to the <ul> solveResult on the right
                $('#solveResult').append($('<li/>').append(word));
            });
            $('#solve').show('normal');
        },
        "json");
}
