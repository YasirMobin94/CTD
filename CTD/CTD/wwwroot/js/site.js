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
let CTDFn = {
    handleITStaffService: function (servicePlan) {
        console.log(servicePlan)
        let spinner = $(".preloader");
        spinner.show();
        let modalbody = $(".services-modal-body")
        let modalDiv = $("#services-modal")
        $.ajax({
            url: '/it-staff-services-contact-form',
            type: "POST",
            data: {
                servicePlan: servicePlan
            },
        }).done(function (html) {
            modalbody.html(html)
            modalDiv.modal('show');
            spinner.hide();
        }).fail(function (error) {
            spinner.hide();
            SweetAlert.Error()
            console.error(error)
        });
    },
    handlePricePlanService: function (servicePlan) {
        console.log(servicePlan)
        let spinner = $(".preloader");
        spinner.show();
        let modalbody = $(".services-modal-body")
        let modalDiv = $("#services-modal")
        $.ajax({
            url: '/services-contact-form',
            type: "POST",
            data: {
                servicePlan: servicePlan
            },
        }).done(function (html) {
            modalbody.html(html)
            modalDiv.modal('show');
            spinner.hide();
        }).fail(function (error) {
            spinner.hide();
            SweetAlert.Error()
            console.error(error)
        });
    },
}
let HttpService = {

    postDataOfEmail: function (url, form) {
        if (form.valid()) {
            let token = '';
            let servicePlan = $(".servicePlan").val();
            let formValue = form.serializeArray();
            let model = {};
            for (let item of formValue) {
                if (item.name === '__RequestVerificationToken') {
                    token = item.value
                } else {
                    model[item.name] = item.value;
                }
            }
            model.ServicePlanName = servicePlan
            let spinner = $(".preloader");
            spinner.show();
            console.log(model)

            $.ajax({
                url: url,
                type: "POST",
                data: {
                    __RequestVerificationToken: token,
                    user: model
                },
                dataType: 'json',
                contentType: 'application/x-www-form-urlencoded; charset=utf-8',
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
}