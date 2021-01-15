//Configure the visible toolbar options for the text-editor:
var toolbarOptions = [
    ['bold', 'italic', 'underline', 'strike'],          //text markup like bold, italic.
    ['blockquote', 'code-block'],                       //markup for codesnippets or quotes.
    [{ 'header': 1 }, { 'header': 2 }],                 //text header types.
    [{ 'list': 'ordered' }, { 'list': 'bullet' }],      //list types.
    [{ 'script': 'sub' }, { 'script': 'super' }],       //script options.
    [{ 'indent': '-1' }, { 'indent': '+1' }],           //text identation options.
    [{ 'direction': 'rtl' }],
    [{ 'size': ['small', false, 'large', 'huge'] }],    //text sizes.
    ['link', 'image', 'video', 'formula'],              //embedded data (videos, pictures, etc.)
    [{ 'color': [] }, { 'background': [] }],            //text & background color.
    [{ 'font': [] }],                                   //font types.
    [{ 'align': [] }]                                   //text aligning.
];

//Set options for debugging, text editor themes, etc.
var options = {
    debug: 'info',                                      //set debugging options.
    modules: {                                          //array for modules.
        toolbar: toolbarOptions                         //set the toolbar options.
    },
    readOnly: false,                                    //set readOnly property.
    theme: 'snow'                                       //set theme for text editor.
};

var quill = new Quill('#editor', options);              //instantiate the text editor within the specified div container (#editor) and the options as defined in the above variable.

var form = document.querySelector('#create');           //get form from View.
var editForm = document.querySelector('#editForm');

window.onload = function () {

    if ($("#ticketContent").length) {

        let articleContent = document.getElementById("ticketContent").value;
        quill.root.innerHTML = articleContent;
    }

};

quill.on('text-change',
    function (delta, oldDelta, source) {
        var content = document.querySelector('input[name=content]');
        content.setAttribute("value", quill.root.innerHTML);
    });

//This function gets the content from an input field with the name content from the View, and then calls getQuillText in order to set the value for the hidden input field in the View.
form.onsubmit = function () {
    var content = document.querySelector('input[name=content]');
    content.setAttribute("value", getQuillText());
}

editForm.onsubmit = function () {

    var content = document.querySelector('input[name=content]');
    content.setAttribute("value", getQuillText());
    alert(content.value);
}

//Initialize variables for getQuillText function.
var editors = {};
editors[editor] = quill;

//This function gets the text from the Quill Editor and returns it.
function getQuillText() {
    var quillEditor = editors[editor];
    var text = quillEditor.root.innerHTML;
    return text;
}