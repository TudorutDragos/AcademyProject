window.onload = function(){
    registerPageEvents();
}

function registerPageEvents(){
    $('#footballer').on('click', function(){
        redirectPage("http://localhost:5500/footballerPage.html");
    });
    $('#team').on('click', function(){
        redirectPage("http://localhost:5500/teamPage.html");
    });
    $('#league').on('click', function(){
        redirectPage("http://localhost:5500/leaguePage.html");
    });
    $('#clasament').on('click', function(){
        redirectPage("http://localhost:5500/clasamentPage.html");
    });
}

function redirectPage(htmlPage){
    window.location.href=htmlPage;
}