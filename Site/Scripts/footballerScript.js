window.onload = function(){
    registerPageEvents();
    populateListFootballers();
}

function registerPageEvents(){
    $('#getAll').on('click', function(){
        loadPage('footballerGetAll.html');
    });
    $('#form').on('click', function(){
        buildFootballerForm();
    });
    $('#delete').on('click', function(){
        loadPage('footballerDelete.html');
    });
    $('#update').on('click', function(){
        buildFootballerForm();
    });
    $('#getById').on('click', function(){
        loadPage('footballerDelete.html');
    });
    $('#home').on('click',function(){
        loadHomePage();
    });
}

function populateListFootballers(data){
    var spanToPopulate = $('#listOfFootballers');
    
    $.when(getFootballers()).then(function(data){
        //spanToPopulate.text(data);
        data.forEach(function(item){
            var span = $('#listOfFootballers').append($('<span>'));
            $(span).text(JSON.stringify(item));
        })
    }).fail(function(){
        alert("Something failed");
    });
}

function getFootballers(){
    let promise = $.ajax({
        type:"GET",
        url: 'http://localhost:5500/footballerPage.html/api/Footballer/GetAll',
        contentType: 'application/json',
        dataType: 'json',
    });

    return promise;
}

function handleInsert(){
    var firstName = $('#firstName').val();
    var lastName = $('#lastName').val();
    var birthDay = $('#birthDay').val();
    var nationality = $('#nationality').val();
    var team = $('#team').val();

    var footballerData = {
        FirstName = firstName,
        LastName = lastName,
        BirthDay = birthDay,
        Nationality = nationality,
        Team = team
    }

    $.when(sendFootballerData(footballerData)).then(function(){
        alert("Footballer added");
    }).fail(function(){
        alert('Error, check data');
    })
}

function sendFootballerData(data){
    let promise = $.ajax({
        type : 'POST',
        url : 'http://localhost:5500/footballerPage.html/api/Footballer/Insert',
        contentType : 'application/json',
        dataType : 'json',
        accept: 'application/json',
        data:JSON.stringify(data)
    });

    return promise;
}

function loadPage(htmlView){
    $('#divContainer').load(htmlView);
}

function buildFootballerForm(){
    var bodyElement = document.getElementById('divContainer');
    var formElement = document.createElement('form');

    var titleElement = document.createElement('h2');
    titleElement.innerText = 'Add Footballer';
    titleElement.setAttribute('class','formTitle');

    formElement.appendChild(titleElement)
    formElement.append(getFormDivSection('First Name'), getFormDivSection('Last Name'), getFormDivSection('Birth Day'), getFormDivSection('Nationality'),getFormDivSection('Team'));
    formElement.append(getButton('Submit Footballer'));
    bodyElement.appendChild(formElement);
}

function getFormDivSection(labelText){
    var divElement = document.createElement('div');
    
    var spanElement = document.createElement('span');
    spanElement.innerText = labelText;
    
    var input = document.createElement('input');
    input.setAttribute('type','text');
    input.setAttribute('class', 'inputForms');
    
    divElement.append(spanElement,input);

    return divElement;
}

function getButton(labelText){
    var divElement = document.createElement('div');
    
    var button = document.createElement('input');
    button.setAttribute('type','button');
    button.setAttribute('value',labelText);
    button.setAttribute('id','submitButton');

    button.onclick = function(){
        handleInsert();
    }
    divElement.appendChild(button);
    return divElement;
}

function loadHomePage(){
    window.location.href="http://localhost:5500/index.html"
}