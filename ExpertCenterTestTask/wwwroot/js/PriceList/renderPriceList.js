renderPriceListsPage();

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

async function renderPriceListsPage() {
    let priceLists = await sendGetListsRequest("https://localhost:7043/api/priceList/getall");

    for(let i = 0; i < priceLists.length; i++)
    {
        let list = priceLists[i];
        renderPriceListIdFunction(list);
        renderPriceListNameFunction(list);
    }
}

function renderPriceListIdFunction(list)
{
    const newList = document.createElement("p");
    newList.className = "IdColumnTable";

    const newListId = list.id + "";
    
    newList.append(newListId);

    document.getElementById("ColumnsId").append(newList);

    return newList;
}

function renderPriceListNameFunction(list)
{
    const newList = document.createElement("p");
    newList.className = "NameColumnTable";
    
    const newListName = list.name + "";
    console.log(list.name);

    newList.append(newListName);

    document.getElementById("ColmnsName").append(newList);

    return newList;
}