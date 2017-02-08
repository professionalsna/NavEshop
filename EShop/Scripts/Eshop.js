$(document).ready(function () {
    //debugger;
    var $newInvoice = $(".new-invoice");
    var $addInvoice = $newInvoice.find(".add-invoice-item");
    var $invoiceTable = $(".invoice-table");
    

    $addInvoice.click(function (e) {
        debugger;
        e.preventDefault();
       
      
        var $prodID = $newInvoice.find(".invoice-product-id").val();
        var $prodQty = $newInvoice.find(".invoice-product-qty").val();
        var $prodPrice = $newInvoice.find(".invoice-product-price").val();
        var msg = "ProductID:" + $prodID + " Price:" + $prodPrice + " Qty:" + $prodQty;
       // alert(msg)
        

        var newIndex = $invoiceTable.find("tr").size() - 2;


        $invoiceTable.find("tr.InvoiceTemplate")
            .clone()
            .removeClass("InvoiceTemplate")
            //.addClass("selected")
            //.find("td.prod").text($prodID).end()
            //.find("td.price").text($prodPrice).end()
            //.find("td.qty").text($prodQty).end()
            .find(".inv-productid").val($prodID).attr("name","InvoiceDetail["+newIndex+"].ProductID").end()
            .find(".inv-price").val($prodPrice).attr("name","InvoiceDetail["+newIndex+"].Price").end()
            .find(".inv-qty").val($prodQty).attr("name","InvoiceDetail["+newIndex+"].Qty").end()
            //.find(".name").text(name).end()
            //.find(".name-input").val(name).attr("name", "Tags[" + newIndex + "].Name").end()
            //.find(".selected-input").attr("name", "Tags[" + newIndex + "].IsChecked").val(true).end()
        .appendTo($invoiceTable);

        //create a dynamic text input


        //var prodcutText = "<input type='text' name='InvoiceDetail["+newIndex+"].ProductID' value='"+$prodID+"' />";
        //$invoiceTable.find("td.prod").append(prodcutText);

        //var prodcutPrice = "<input type='text' name='InvoiceDetail[" + newIndex + "].Price' value='" + $prodPrice + "' />";
        //$invoiceTable.find("td.price").append(prodcutPrice);

        //var prodcutQty = "<input type='text' name='InvoiceDetail[" + newIndex + "].Qty' value='" + $prodQty + "' />";
        //$invoiceTable.find("td.qty").append(prodcutQty);

        //$newTagName.val("");
        //$addTagButton.prop("disabled", true);
        
    });



});

