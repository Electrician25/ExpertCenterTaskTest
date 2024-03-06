renderColumnsPage();

async function renderColumnsPage() {
    let count = window.location.href;
    let parse = count.split('=');
    let current = parse[1].toString();

    let priceLists = await sendGetListsRequest(`https://localhost:7043/api/currentcolumns?count=${current}`);

    for(let i = 0; i < priceLists.length; i++)
    {
        let column = priceLists[i];
        contInput(column);
        console.log(column.kind);
        console.log(column.id);
    }
}

function sendGetListsRequest(uri) {
    const myHeaders = new Headers()
    myHeaders.append('Content-Type', 'application/json')
    const request = new Request(uri, {
        method: 'GET',
        headers: myHeaders
    });
 
    let search_result = fetch(request)
        .then((response) => {
            return response.json();
        })
 
    return search_result;
}

function contInput(column)
{
    var nameElement = document.createElement('a');
    nameElement.append(column.name);

    var input = document.createElement('input');
    input.id = "inputName1";
    input.className = "inputName1";

    let listColumns = document.getElementById("dropdown");
    listColumns.className = "dropdown";
    listColumns.append(nameElement);
    listColumns.append(input);
}