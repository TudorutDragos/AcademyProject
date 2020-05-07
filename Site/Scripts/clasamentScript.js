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

function buildClasamentForm(){
    var bodyElement = document.body;
    var formElement = document.createElement('form');
    var titleElement = document.createElement('h2');
    titleElement.innerText = 'Add Clasament';
    titleElement.setAttribute('class','formTitle');

    formElement.appendChild(titleElement)
    formElement.append(getFormDivSection('League'),getFormDivSection('Position'), getFormDivSection('Team'),getFormDivSection('Team Wins'), getFormDivSection('Team Defeats'), getFormDivSection('Team Draws'), getFormDivSection('Team Points'));
    formElement.appendChild(getButton('Submit Clasament'));
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
        alert("Date trimise");
    }
    divElement.appendChild(button);
    return divElement;
}

function loadHomePage(){
    window.location.href="http://localhost:5500/index.html"
}