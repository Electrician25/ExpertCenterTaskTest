const createList = async () => {
    json = JSON.stringify({
        name: document.getElementById("inputName1").value,
        vendorCode: document.getElementById("inputName2").value
    }); 
    await sendPostColumnRequest(json,"https://localhost:7043/api/item/additem");
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