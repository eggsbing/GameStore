////var myModal = new bootstrap.Modal(document.getElementById('modal_box'));

function LoadDetail(gameId) {    
    $.get("/GameGroup/GameDetail/" + gameId,
        function (res) {
            $("#modal_box .modal_body").html(res);
            myModal.show();
        });
}

//function AddToCart(productId) {
//    $.get("/ProductGroups/AddToCart/" + productId,
//        function (res) {
//            $(".mini_cart_wrapper").html(res);            
//        });
//}

