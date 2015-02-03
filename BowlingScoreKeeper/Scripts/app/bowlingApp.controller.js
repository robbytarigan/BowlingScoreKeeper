var Bowling;
(function (Bowling) {
    angular.module("bowlingApp").controller("playerController", ["$scope", "$http", "$location", playerController]).controller("gameController", ["$scope", "$http", "$location", gameController]);
    function playerController($scope, $http, $location) {
        $scope.names = [];
        $scope.newPlayerName = "";
        $scope.isDuplicatePlayer = false;
        $scope.addPlayer = function () {
            name = $scope.newPlayerName.trim();
            if (name == "") {
                return;
            }
            if ($scope.names.indexOf(name) > -1) {
                $scope.isDuplicatePlayer = true;
            }
            else {
                $scope.names.push(name);
                $scope.isDuplicatePlayer = false;
                $scope.newPlayerName = "";
            }
        };
        $scope.startGame = function () {
            $http.put("/api/game/players", $scope.names).success(function () {
                $location.url("game");
            });
        };
    }
    function gameController($scope, $http, $location) {
        $scope.scoreCards = [];
        $scope.currentFrameIndex = 0;
        $scope.currentDeliveryIndex = 0;
        $scope.isGameOver = false;
        $scope.updateScore = function () {
            switch ($scope.currentDeliveryIndex) {
                case 0:
                    $scope.currentDeliveryIndex = 1;
                    break;
                case 1:
                    $scope.currentDeliveryIndex = $scope.currentFrameIndex == 10 ? 2 : 0;
                    $scope.currentFrameIndex = $scope.currentFrameIndex == 10 ? 10 : $scope.currentFrameIndex + 1;
                    break;
                case 2:
                    $scope.isGameOver = true;
            }
            var records = [];
            for (var i = 0; i < $scope.scoreCards.length; i++) {
                records.push($scope.scoreCards[i].rollRecords[$scope.currentFrameIndex]);
            }
            $http.put("/api/game/score?frameIndex=" + $scope.currentFrameIndex, records).success(function () {
                if ($scope.isGameOver) {
                    $location.url("result");
                }
            });
        };
        $scope.displayDelivery = function (rollRecords, frameIndex, deliveryIndex) {
            if (frameIndex <= $scope.currentFrameIndex) {
                return "";
            }
            switch (deliveryIndex) {
                case 0:
                    if (rollRecords[frameIndex].delivery1 == null) {
                        return "";
                    }
                    return rollRecords[frameIndex].delivery1 == 10 ? "X" : rollRecords[frameIndex].delivery1.toString();
                case 1:
                    if (rollRecords[frameIndex].delivery2 == null) {
                        return "";
                    }
                    if (frameIndex == 10) {
                        return rollRecords[frameIndex].delivery2 == 10 ? "X" : (rollRecords[frameIndex].delivery1 + rollRecords[frameIndex].delivery2) == 10 ? "/" : rollRecords[frameIndex].delivery2.toString();
                    }
                    return (rollRecords[frameIndex].delivery1 + rollRecords[frameIndex].delivery2) == 10 ? "/" : rollRecords[frameIndex].delivery2.toString();
                case 2:
                    if (rollRecords[frameIndex].delivery3 == null) {
                        return "";
                    }
                    if (frameIndex == 10) {
                        return rollRecords[frameIndex].delivery3 == 10 ? "X" : rollRecords[frameIndex].delivery3.toString();
                    }
                    return "";
                default:
                    return "";
            }
        };
        $http.get("/api/game/players").success(function (data, status) {
            for (var i = 0; i < data.length; i++) {
                $scope.scoreCards.push({ player: data[i], rollRecords: initializeEmptyRollRecords(data[i]) });
            }
        });
        function initializeEmptyRollRecords(player) {
            var records = [];
            for (var i = 0; i < 10; i++) {
                records.push({ player: player });
            }
            return records;
        }
    }
})(Bowling || (Bowling = {}));
//# sourceMappingURL=bowlingApp.controller.js.map