$(document).ready(function () {
    loadMatches();
});

function loadMatches() {
    $.get("/api/Matches", null, function (response) {
        bindMatches(response);
    });
}

function bindMatches(matches) {
    var html = "";
    $("#listMatches").html("");
    $.each(matches,
        function (index, match) {
            html += "<tr data-match-id='" + match.id + "'>";

            html += "<td>";
            html += "<img class='team-logo' src='/images/" + match.team1Logo + "'/>";
            html += "<span class='team-name'>" + match.team1Name + "</span>";
            html += "</td>";

            html += "<td>";
            html += "<span data-team-id='" + match.team1Id + "' class='team-goals'>" + match.team1Goals + "</span>";
            html += "</td>";

            html += "<td>";
            html += "<span class='team-separator'> � </span>";
            html += "</td>";

            html += "<td>";
            html += "<span data-team-id='" + match.team2Id + "' class='team-goals'>" + match.team2Goals + "</span>";
            html += "</td>";

            html += "<td>";
            html += "<img class='team-logo' src='/images/" + match.team2Logo + "'/>";
            html += "<span class='team-name'>" + match.team2Name + "</span>";
            html += "</td>";

            html += "</tr>";
        });
    $("#listMatches").append(html);
}