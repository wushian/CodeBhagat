/// <reference path="admin/user/edit.html" />
(function () {
    'use strict';

    var app = angular.module('app');

    // Collect the routes
    app.constant('routes', getRoutes());

    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);

    function routeConfigurator($routeProvider, routes) {
        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });
        //$routeProvider.otherwise({ redirectTo: '/' });
    }

    // Define the routes
    function getRoutes() {
        return [
            {
                url: '/',
                config: {
                    templateUrl: '/App/views/Layout/Home.html'
                }
            }, {
                url: '/User/Detail/:UserId',
                config: {
                    templateUrl: '/App/views/UsersAdmin/UserDetail.html'
                }
            },
            {
                url: '/UserAdmin',
                config: {
                    templateUrl: '/App/views/UsersAdmin/List.html'
                }
            }, {
                url: '/UserAdmin/UserAddEdit',
                config: {
                    templateUrl: '/App/views/UsersAdmin/UserAddEdit.html'
                }
            },  {
                url: '/User/Edit/:UserId',
                config: {
                    templateUrl: '/App/views/UsersAdmin/UserAddEdit.html'
                }
            }, {
                url: '/RolesAdmin',
                config: {
                    templateUrl: '/App/views/RolesAdmin/List.html'
                }
            }, {
                url: '/Profile',
                config: {
                    templateUrl: '/App/views/Account/Profile.html'
                }
            },
            {
                url: '/Calendar',
                config: {
                    templateUrl: '/App/views/Layout/Calendar.html'
                }
            },
            {
                url: '/Contact',
                config: {
                    templateUrl: '/App/views/Layout/Contact.html'
                }
            },
            {
                url: '/About',
                config: {
                    templateUrl: '/App/views/Layout/About.html'
                }
            },
            {
                url: '/Account/Profile',
                config: {
                    templateUrl: '/App/views/Account/Profile.html'
                }
            },
            {
                url: '/Account/MyAccount',
                config: {
                    templateUrl: '/App/views/Account/MyAccount.html'
                }
            },
            {
                url: '/Account/EditProfile',
                config: {
                    templateUrl: '/App/views/Account/EditProfile.html'
                }
            },
            {
                url: '/Account/ChangePassword',
                config: {
                    templateUrl: '/App/views/Account/ChangePassword.html'
                }
            },
            {
                url: '/Account/ForgotPassword',
                config: {
                    templateUrl: '/App/views/Account/ForgotPassword.html',
                    title: 'Forgot Password'
                }
            },
            {
                url: '/Account/ForgotPasswordConfirmation',
                config: {
                    templateUrl: '/App/views/Account/ForgotPasswordConfirmation.html'
                }
            },
            {
                url: '/Account/ResetPassword',
                config: {
                    templateUrl: '/App/views/Account/ResetPassword.html'
                }
            },
            {
                url: '/Account/ResetPasswordConfirmation',
                config: {
                    templateUrl: '/App/views/Account/ResetPasswordConfirmation.html'
                }
            },
            {
                url: '/Account/SetPassword',
                config: {
                    templateUrl: '/App/views/Account/SetPassword.html'
                }
            },
            {
                url: '/Account/SendCode',
                config: {
                    templateUrl: '/App/views/Account/SendCode.html'
                }
            },
            {
                url: '/Account/VerifyCode',
                config: {
                    templateUrl: '/App/views/Account/VerifyCode.html'
                }
            },
            {
                url: '/Graphs',
                config: {
                    templateUrl: '/App/views/Layout/Graphs.html'
                }
            },
            {
                url: '/Calendar',
                config: {
                    templateUrl: '/App/views/Layout/Calendar.html'
                }
            },
            {
                url: '/Settings',
                config: {
                    templateUrl: '/App/views/Layout/Settings.html'
                }
            },
            {
                url: '/Inbox',
                config: {
                    templateUrl: '/App/views/Layout/Inbox.html'
                }
            },
            {
                url: '/login',
                config: {
                    templateUrl: '/App/views/Account/Login.html'
                }
            },
            {
                url: '/register',
                config: {
                    templateUrl: '/App/views/Account/Register.html'
                }
            },
            {
                url: '/UnauthorisedAccess',
                config: {
                    templateUrl: '/App/views/Account/UnauthorisedAccess.html',
                }
            },
            { url: '/ab041', config: { templateUrl: '/App/Views/ab041/ab041List.html' }},
{ url: '/ab041/Add', config: { templateUrl: '/App/Views/ab041/ab041AddEdit.html' }},
{ url: '/ab041/Edit/:gkey', config: { templateUrl: '/App/Views/ab041/ab041AddEdit.html' }},
{ url: '/ab041/Detail/:gkey', config: { templateUrl: '/App/Views/ab041/ab041Detail.html' }},
{ url: '/ab062sg', config: { templateUrl: '/App/Views/ab062sg/ab062sgList.html' }},
{ url: '/ab062sg/Add', config: { templateUrl: '/App/Views/ab062sg/ab062sgAddEdit.html' }},
{ url: '/ab062sg/Edit/:gkey', config: { templateUrl: '/App/Views/ab062sg/ab062sgAddEdit.html' }},
{ url: '/ab062sg/Detail/:gkey', config: { templateUrl: '/App/Views/ab062sg/ab062sgDetail.html' }},
{ url: '/ab110', config: { templateUrl: '/App/Views/ab110/ab110List.html' }},
{ url: '/ab110/Add', config: { templateUrl: '/App/Views/ab110/ab110AddEdit.html' }},
{ url: '/ab110/Edit/:gkey', config: { templateUrl: '/App/Views/ab110/ab110AddEdit.html' }},
{ url: '/ab110/Detail/:gkey', config: { templateUrl: '/App/Views/ab110/ab110Detail.html' }},
{ url: '/ab120', config: { templateUrl: '/App/Views/ab120/ab120List.html' }},
{ url: '/ab120/Add', config: { templateUrl: '/App/Views/ab120/ab120AddEdit.html' }},
{ url: '/ab120/Edit/:gkey', config: { templateUrl: '/App/Views/ab120/ab120AddEdit.html' }},
{ url: '/ab120/Detail/:gkey', config: { templateUrl: '/App/Views/ab120/ab120Detail.html' }},
{ url: '/ab121sg', config: { templateUrl: '/App/Views/ab121sg/ab121sgList.html' }},
{ url: '/ab121sg/Add', config: { templateUrl: '/App/Views/ab121sg/ab121sgAddEdit.html' }},
{ url: '/ab121sg/Edit/:gkey', config: { templateUrl: '/App/Views/ab121sg/ab121sgAddEdit.html' }},
{ url: '/ab121sg/Detail/:gkey', config: { templateUrl: '/App/Views/ab121sg/ab121sgDetail.html' }},

        ];
    }
})();
