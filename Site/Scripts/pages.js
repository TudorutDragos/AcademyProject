window.onload = function(){
    registerPageEvents();
}

function registerPageEvents(){
    $('#footballer').on('click', function(){
        loadFootballerPage();
    });
    $('#team').on('click', function(){
        loadTeamPage();
    });
    $('#league').on('click', function(){
        loadLeaguePage();
    });
    $('#clasament').on('click', function(){
        loadClasamentPage();
    });
}

function loadFootballerPage(){
    window.location.href="http://localhost:5500/footballerPage.html"
}

function loadTeamPage(){
    window.location.href="http://localhost:5500/teamPage.html"
}

function loadLeaguePage(){
    window.location.href="http://localhost:5500/leaguePage.html"
}

function loadClasamentPage(){
    window.location.href="http://localhost:5500/clasamentPage.html"
}
