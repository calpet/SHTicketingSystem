//var content = document.querySelector(".ticketContent");

let editorForm = document.querySelector('#edit');



window.onload = function () {
    let content = document.getElementById("ticketContent").value;
    let qEditor = quill;
    render(content, qEditor.root);
    //qEditor.root.innerHTML = content;
};

function getQuillContent() {
    let qEditor = editors[editor];
    let text = qEditor.root.textContent;
    return text;
}

editorForm.onsubmit = function () {
    var content = document.querySelector('input[name=content]');
    content.value = getQuillContent();
}

var render = function (template, node) {
    if (!node) return;
    node.innerHTML = template;
}