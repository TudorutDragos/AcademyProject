window.onload = function(){
    registerPageEvents();
}

function registerPageEvents(){
    $('#getAll').on('click', function(){
        loadPage();
    });
    $('#form').on('click', function(){
        buildClasamentForm();
    });
    $('#delete').on('click', function(){
        loadPage();
    });
    $('#update').on('click', function(){
        loadPage();
    });
    $('#getById').on('click', function(){
        loadPage();
    });
    $('#home').on('click',function(){
        loadHomePage();
    });
}


function loadPage(htmlView){
    $('#divContainer').load(htmlView);
}
