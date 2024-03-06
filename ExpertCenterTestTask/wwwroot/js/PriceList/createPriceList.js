const createPriceList = async () => {
    let currectDiv = document.getElementById("listInputs").children;
    let len = currectDiv.length + 1;
    var json = "";
    var frist = findKindColumn();
    var second = getColumnName();
    let length = len - 1;
    for(let i =0;i<length;i++)
    {
        json = JSON.stringify({
            name: second.next().value,
            kind: frist.next().value
        }); 
        await sendPostColumnRequest(json,"https://localhost:7043/api/post");
    }

    let listName = document.getElementById("priceListName").value;
    console.log(listName);
    let json1 = JSON.stringify({
        name: listName,
    }); 
    await sendPostColumnRequest1(json1,"https://localhost:7043/api/priceList/add");

    document.getElementById('add')
    addEventListener('click', () => location = `https://localhost:7043/api/html/AddItemPageLast?id=${length}`);
}

function* findKindColumn()
{
    let currectDiv = document.getElementById("listInputs").children;
    let len = currectDiv.length + 1;
    console.log("findcolumn");
    var t = 1;
    for(let i = 0; i < len - 1; i++)
    {
        if(t == len + 1)
        {
            break;
        }
        let listFunc = document.getElementById("listFunc" + (t).toString());
        t++;
        console.log("KIND");
        let num = Number(listFunc.value);
        yield num;
    }
}

function* getColumnName() {
    let currectDiv = document.getElementById("listInputs").children;
    let len = currectDiv.length + 1;
    console.log("columnname");
    var t = 1;
    for(let i = 0; i < len - 1; i++)
    {
        if(t == len + 1)
        {
            break;
        }
        let listFunc = document.getElementById("inputName" + (t).toString());
        t++;
        console.log("NAME");
        let toString1 = String(listFunc.value);
        yield toString1;
    }
}

function sendPostColumnRequest(json, uri) {
    const myHeaders = new Headers()
    myHeaders.append('Content-Type', 'application/json')
    const request = new Request(uri, {
        method: 'POST',
        body: json,
        headers:myHeaders
    });

    console.log(json);
    let search_result = fetch(request)
        .then((response) => {
            return response.json()
        })

    return search_result;
}

function sendPostColumnRequest1(json, uri) {
    const myHeaders = new Headers()
    myHeaders.append('Content-Type', 'application/json')
    const request = new Request(uri, {
        method: 'POST',
        body: json,
        headers:myHeaders
    });

    console.log(json);
    let search_result = fetch(request)
        .then((response) => {
            return response.json()
        })

    return search_result;
}

function addColumn() {
    let currectDiv = document.getElementById("listInputs").children;
    let len = currectDiv.length + 1;

    let countElement = document.createElement('option');
    countElement.value = "1";
    countElement.id = "count";
    countElement.textContent = "Число";

    let stringElement = document.createElement('option');
    stringElement.value = "2";
    countElement.id = "string";
    stringElement.textContent = "Однострочный текст";

    let textElement = document.createElement('option');
    textElement.value = "3";
    countElement.id = "text";
    textElement.textContent = "Многострочный текст";

    let elementSelect = document.createElement('select');
    elementSelect.className = "dropdown-select";
    elementSelect.id = "listFunc" + len.toString();

    elementSelect.append(countElement);
    elementSelect.append(stringElement);
    elementSelect.append(textElement);

    let valueList = document.createElement('div');
    valueList.className = "dropdown";
    valueList.append(elementSelect);

    const coumnNuber = document.createElement('div');
    coumnNuber.className = "defColumn"; 

    let column = document.createElement('a');
    column.append("Колонка " + len.toString());

    let columnName = document.createElement('input');
    columnName.className = "inputName1";
    columnName.id = "inputName" + len.toString();

    let deleteButton = document.createElement('button');
    deleteButton.className = "btn btn-danger";
    deleteButton.textContent = "Удалить";

    coumnNuber.append(column);
    coumnNuber.append(columnName);
    coumnNuber.append(valueList);
    coumnNuber.append(deleteButton);

    document.getElementById("listInputs").append(coumnNuber);
}