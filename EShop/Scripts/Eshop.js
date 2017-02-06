$(document).ready(function () {

    var $newInvoice = $("new-invoice");
    var $addInvoice = $newInvoice.find("add-invoice-item");
    var $invoiceTable = $newInvoice.find("invoice-table");
    

    $addInvoice.click(function (e) {
       
        e.preventDefault();
        debugger;
        var $prodID = $newInvoice.find("invoice-product-id");
        var $prodQty = $newInvoice.find("invoice-product-qty");
        var $prodPrice = $newInvoice.find("invoice-product-price");
        
    });



});

