var deleteButton = document.querySelector("#delete");

deleteButton.onclick = function () {
    return confirm("Are you sure you want to delete this ticket?");
}