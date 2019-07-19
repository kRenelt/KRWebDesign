// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(function () {
   // alert("Hello");

   // $(selector).action();

    // $('#addToCart').hide();

    $("#button").click(function () {
        $("#test").load("FakeData.txt");
    });

    $('#customers .jsDelete').click(function () {
        if (confirm("are you sure you want to delete this Item?")) {
            $.ajax({
                url: "/shoppingCart" + $(this).attr("data-item-id"),
                method: "DELETE",
                success: function () {
                    console.log("Success");
                }
            });
        }
    })

   // $("button").click(function () {
   //     $('#cartCount').
   // });
});
