window.onload = function(){
    registerPageEvents();
}

function registerPageEvents(){
    $('#getAll').on('click', function(){
        loadPage('footballerGetAll.html');
        populateListFootballers();
    });
    $('#form').on('click', function(){
        $('#divContainer').empty();
        buildFootballerForm();
    });
    $('#delete').on('click', function(){
        loadPage('footballerDelete.html');
    });
    $('#update').on('click', function(){
        $('#divContainer').empty();
        buildFootballerFormUpdate();
    });
    $('#getById').on('click', function(){
        loadPage('footballerGetById.html');
    });
    $('#home').on('click',function(){
        loadHomePage();
    });
}

function populateListFootballers(data){
    $.when(getFootballers()).then(function(data){
        var table = $('<table>');
        var thead = $('<thead>');
        thead.append($('<tr>').append($('<th>').text("First Name"), $('<th>').text("Last Name"),$('<th>').text("Birth Day"),$('<th>').text("Nationality")));
        table.append($(thead));
        data.forEach(function(item){
            var newtr= $('<tr>');
            var tdFirstName = $('<td>');
            var tdLastName = $('<td>');
            var tdBirthDay = $('<td>');
            var tdNationality = $('<td>');
            tdFirstName.text(JSON.stringify(item.firstName));
            tdLastName.text(JSON.stringify(item.lastName));
            tdBirthDay.text(JSON.stringify(item.birthDay));
            tdNationality.text(JSON.stringify(item.nationality));
            $(newtr).append($(tdFirstName),$(tdLastName),$(tdBirthDay),$(tdNationality));
            $(table).append($(newtr));
        })
        var span = $('#listOfFootballer');
        $(span).append($(table));
    }).fail(function(){
        alert("Something failed");
    });
}

function handleInsert(){
    var id = $('#idFootballer').val();
    var firstName = $('#firstName').val();
    var lastName = $('#lastName').val();
    var birthDay = $('#birthDay').val();
    var nationality = $('#nationality').val();
    var team = $('#team').val();

    var footballerData = {
        ID: id,
        FirstName: firstName,
        LastName: lastName,
        BirthDay: birthDay,
        Nationality: nationality,
        Team: team
    }

    $.when(sendFootballerData(footballerData,'http://localhost:33908/api/Footballer/Insert')).then(function(){
        alert("Footballer added");
    }).fail(function(){
        alert('Error, check data');
    })
}


function handleUpdate(){
    var id = $('#idFootballer').val();
    var firstName = $('#firstName').val();
    var lastName = $('#lastName').val();
    var team = $('#team').val();

    var footballerData = {
        ID: id,
        FirstName: firstName,
        LastName: lastName,
        Team: team
    }

    $.when(sendFootballerData(footballerData,'http://localhost:33908/api/Footballer/UpdateByUid')).then(function(){
        alert("Footballer updated");
    }).fail(function(){
        alert('Error, check data');
    })
} 

function handleGetByUid(){
    var id = $('#footballerId').val();

    var footballerData={
        ID:id
    }

    $.when(getFootballerByUid(footballerData)).then(function(item){
        $('footballerById').text(JSON.stringify(item.firstName+" "+item.lastName));
    }).fail(function(){
        alert('Error, check data');
    })
}

function handleDelete(){
    var id = $('#deleteFootballer').val();

    var footballerData={
        ID:id
    }

    $.when(deleteFootballer(footballerData)).then(function(){
        alert("Footballer deleted");
    }).fail(function(){
        alert('Error, check data');
    })
}

function deleteFootballer(data){

    let promise = $.ajax({
        type:"DELETE",
        url: 'http://localhost:33908/api/Footballer/DeleteByUid',
        contentType: 'application/json',
        dataType: 'json',
        accept:'application/json',
        data: JSON.stringify(data)
    });
    return promise;
}

function getFootballers(){

    let promise = $.ajax({
        type:"GET",
        url: 'http://localhost:33908/api/Footballer/GetAll',
        contentType: 'application/json',
        dataType: 'json',
        accept: 'application/json'
    });

    return promise;
}

function getFootballerByUid(data){

    let promise = $.ajax({
        type:"GET",
        url: 'http://localhost:33908/api/Footballer/GetByUid',
        contentType: 'application/json',
        dataType: 'json',
        accept:'application/json',
        data: JSON.stringify(data)
    });
    return promise;
}

function sendFootballerData(data,urlPath){
    let promise = $.ajax({
        type : 'POST',
        url : urlPath,
        contentType : 'application/json',
        dataType : 'json',
        accept: 'application/json',
        data: JSON.stringify(data)
    });

    return promise;
}

function loadPage(htmlView){
    $('#divContainer').load(htmlView);
}

