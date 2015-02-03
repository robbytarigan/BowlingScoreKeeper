var Bowling;
(function (Bowling) {
    angular.module("bowlingApp").config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/players', {
            templateUrl: '/Content/templates/players.html',
            controller: 'playerController'
        }).when('/game', {
            templateUrl: '/Content/templates/game.html',
            controller: 'gameController'
        }).when('/result', {
            templateUrl: '/Content/templates/result.html',
            controller: 'resultController'
        }).otherwise({
            redirectTo: '/players'
        });
    }]);
})(Bowling || (Bowling = {}));
//# sourceMappingURL=bowlingApp.config.js.map