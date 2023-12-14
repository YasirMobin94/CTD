// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


let CTDNav = {
    AddCurrentActiveClass: function (className = null) {
        $(`.${className}`).addClass('current')
    }
}

let SweetAlert = {
    Error: function (message = "Something went wrong! Please try later.") {
        Swal.fire({
            icon: "error",
            title: "Oops...",
            text: message,
        });
    },
    Success: function (message) {
        Swal.fire({
            icon: "success",
            title: "Thank you!",
            text: message,
        });
    }
}

let HttpService = {
    postDataOfEmail: function (url, form) {
        debugger
        let formValue = form.serializeArray();
        let model = {};
        for (let item of formValue) {
            model[item.name] = item.value;
        }
        let spinner = $(".preloader");
        spinner.show();
        console.log(model)

        $.ajax({
            url: url,
            type: "POST",
            data: { user: model },
        }).done(function (data) {
            spinner.hide();
            console.log(data)
            if (data.success) {
                form[0].reset();
                SweetAlert.Success("Request has been sent successfully!");
            }
            else {
                SweetAlert.Error(data.message);
            }
        }).fail(function (error) {
            spinner.hide();
            SweetAlert.Error()
            console.error(error)
        });
    }
}