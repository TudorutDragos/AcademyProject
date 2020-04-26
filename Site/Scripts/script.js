
function buildFootballerForm(){
    var bodyElement = document.body;
    var formElement = document.createElement('form');

    var titleElement = document.createElement('h2');
    titleElement.innerText = 'Add Footballer';
    titleElement.setAttribute('class','formTitle');

    formElement.appendChild(titleElement)
    formElement.append(getFormDivSection('First Name'), getFormDivSection('Last Name'), getFormDivSection('Birth Day'), getFormDivSection('Nationality'),getFormDivSection('Team'));
    formElement.append(getButton('Submit Footballer'));
    bodyElement.appendChild(formElement);
}

function buildTeamForm(){
    var bodyElement = document.body;
    var formElement = document.createElement('form');
    var titleElement = document.createElement('h2');
    titleElement.innerText = 'Add Team';
    titleElement.setAttribute('class','formTitle');

    formElement.appendChild(titleElement)
    formElement.append(getFormDivSection('Name'),getFormDivSection('League'));
    formElement.appendChild(getButton('Submit Team'));
    bodyElement.appendChild(formElement);
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