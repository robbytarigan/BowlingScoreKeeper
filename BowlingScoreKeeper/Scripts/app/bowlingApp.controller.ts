module Bowling {
    angular.module("bowlingApp")
        .controller("playerController", ["$scope", "$http", "$location", playerController])
        .controller("gameController", ["$scope", "$http", "$location", gameController]);

    function playerController($scope: IPlayerScope, $http: ng.IHttpService, $location : ng.ILocationService) {
        $scope.names = [];
        $scope.newPlayerName = "";
        $scope.isDuplicatePlayer = false;

        $scope.addPlayer = (): void => {
            name = $scope.newPlayerName.trim();

            if (name == "") {
                return;
            }

            if ($scope.names.indexOf(name) > -1) {
                $scope.isDuplicatePlayer = true;                                
            } else {
                $scope.names.push(name);
                $scope.isDuplicatePlayer = false;
                $scope.newPlayerName = "";
            }
        };        

        $scope.startGame = (): void => {
            $http.put("/api/game/players", $scope.names).success(() => {
                $location.url("game");
            });            
        };
    }

    function gameController($scope: IGameScope, $http: ng.IHttpService, $location: ng.ILocationService) {
        $scope.scoreCards = [];
        $scope.currentFrameIndex = 0;
        $scope.currentDeliveryIndex = 0;
        $scope.isGameOver = false;

        $scope.updateScore = (): void => {
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

            $http.put("/api/game/score?frameIndex=" + $scope.currentFrameIndex, records)
                .success(() => {
                if ($scope.isGameOver) {
                    $location.url("result");
                }
            });
        };

        $http.get("/api/game/players").success((data: string[], status) => {
            for (var i = 0; i < data.length; i++) {
                $scope.scoreCards.push({ player: data[i], rollRecords: initializeEmptyRollRecords(data[i]) });
            }
        });

        function initializeEmptyRollRecords(player: string): IRollRecord[] {
            var records = [];
            for (var i = 0; i < 10; i++) {
                records.push({ player: player });
            }

            return records;
        }
    }

    interface IPlayerScope {
        names: string[];
        newPlayerName: string;
        isDuplicatePlayer: boolean;
        addPlayer(name: string);
        startGame();
    }

    interface IGameScope {
        scoreCards: IScoreCard[];
        currentFrameIndex: number;
        currentDeliveryIndex: number;
        isGameOver: boolean;
        updateScore(): void;        
    }

    interface IScoreCard {
        player: string;        
        rollRecords: IRollRecord[];
    }    
}