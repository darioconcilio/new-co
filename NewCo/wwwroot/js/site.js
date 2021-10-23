// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var originalStep = $.validator.methods.step;
var wrappedStep = function (value, element, param) {
    var fixedValue = parseFloat(value.toString().replace(",", "."));
    return originalStep.call($.validator.prototype, fixedValue, element, param);
};
$.validator.methods.step = wrappedStep;
