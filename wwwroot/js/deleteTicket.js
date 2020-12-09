var deleteButton = document.querySelector("#delete");

deleteButton.onclick = function() {
    if (confirm("Are you sure you want to delete this ticket?")) {
        return true;
    } else {
        return false;
    }
}