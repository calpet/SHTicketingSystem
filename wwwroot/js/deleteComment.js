var deleteButton = document.querySelector("#delete-btn");

deleteButton.onclick = function () {
    return confirm("Are you sure you want to delete this comment?");
}