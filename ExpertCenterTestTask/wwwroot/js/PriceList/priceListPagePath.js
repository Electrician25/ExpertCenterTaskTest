addNewPriceList();

function addNewPriceList() {
    document.getElementById('add')
        .addEventListener('click', () => location = 'http://localhost:25545/api/html/PriceListCreate');
}