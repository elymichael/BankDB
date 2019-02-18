angular
    .module('app')
    .component('aseguradorasCrud', {
        templateUrl: 'scripts/app/Components/cRegister/c-register.html',
        require: {
            form: '^^form'
        },
        controller: function ($http, URI, authService, appService, $state) {
            var self = this;

            self.$onInit = function () {
                if (!self.id)
                    self.id = "0";

                if (!self.isModal)
                    self.isModal = false;

                initilize();
            };

            function initilize() {
                self.message = "";
                self.isLoading = false;
                self.aseguradora = {};
                self.hasData = false;

                self.fillForm(self.id);
            };

            //self.save = function () {
            //    self.isLoading = true;
            //    if (self.hasData && !self.permiso.roles.update) {
            //        self.callbackUnauthorized();
            //        return;
            //    };

            //    if (!self.hasData && !self.permiso.roles.add) {
            //        self.callbackUnauthorized();
            //        return;
            //    };
            //    self.aseguradora.aseguradoraID = self.id;
            //    self.aseguradora.usuarioID = authService.getUserData().entidad.entidadID;
            //    appService.saveData("Aseguradoras", self.aseguradora).then(function (response) {
            //        self.isLoading = false;
            //        self.aseguradora = {};
            //        self.callbackSuccess();
            //    },
            //        function (error) {
            //            self.isLoading = false;
            //            self.message = appService.getError(error);
            //        });
            //};

            //self.fillForm = function (_id) {
            //    appService.getData("Aseguradoras", "Get", _id).then(function (response) {
            //        self.hasData = true;
            //        self.aseguradora = response.data;
            //    },
            //        function (error) {
            //            self.message = appService.getError(error);
            //        });
            //};

            self.cancel = function () {
                self.callbackCancel();
            };
        },
        bindings: {
            id: '<?',
            callbackSuccess: '&callbackSuccess',
            callbackCancel: '&callbackCancel'
        }
    });