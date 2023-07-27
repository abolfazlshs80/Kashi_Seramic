
function showcard() {
    console.log("hello");
    $.get("/Order/ShowCard"
        , function (resualt) {

            $("#cardbody").html(resualt);
            let count = document.querySelector("#countCard").getAttribute("value");
            document.querySelector(".showcountcard").innerText = count;
        });

}

function AddCard(id) {
    console.log("hello");
    $.get("/Order/AddCard?id=" + id, function (resualt) {

        $("#cardbody").html(resualt);
        let count = document.querySelector("#countCard").getAttribute("value");
        document.querySelector(".showcountcard").innerText = count;
        document.querySelector(".modal-backdrop").remove();
    });

}