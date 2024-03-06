addNewPriceList();

function addNewPriceList() {
    document.getElementById('add')
    .addEventListener('click', () => location = 'https://localhost:7043/api/html/PriceListCreate');
}