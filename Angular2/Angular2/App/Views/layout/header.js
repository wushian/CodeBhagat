(function () {
    'use strict';

    var controllerId = 'header';
    app.controller(controllerId, ['$route', 'routes', header]);

    function header($route, routes) {
        var vm = this;
         getNavRoutes(); 


         function getNavRoutes() {
             vm.navRoutes = routes.filter(function (r) {
                return r.config.settings && r.config.settings.nav;
            }).sort(function (r1, r2) {
                return r1.config.settings.nav > r2.config.settings.nav;
            });
        }

    };
})();