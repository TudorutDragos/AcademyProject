window.onload = function(){
    registerPageEvents();
}

function registerPageEvents(){
    $('#getAll').on('click', function(){
        
    });
    $('#form').on('click', function(){
        buildLeagueForm();
    });
    $('#delete').on('click', function(){
        
    });
    $('#update').on('click', function(){

    });
    $('#getById').on('click', function(){
   
    });
    $('#home').on('click',function(){
        loadHomePage();
    });
}

function buildLeagueForm(){
    var bodyElement = document.body;
    var formElement = document.createElement('form');
    var titleElement = document.createElement('h2');
    titleElement.innerText = 'Add League';
    titleElement.setAttribute('class','formTitle');

    formElement.appendChild(titleElement)
    formElement.appendChild(getFormDivSection('Name'));
    formElement.appendChild(getButton('Submit League'));
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