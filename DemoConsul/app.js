var app = angular.module('consulDemoApp', ['ngAnimate']);

app.controller('consulCtrl', function ($scope, $http, $interval) {
    
    getConfigsFunc = function() {

        $http.get("api/configs").success(
            function(response) {

                $scope.configs = response;
            }
        );
    };

    getFeaturesFunc = function () {

        $http.get("api/features").success(
            function(response) {

                $scope.features = response;

                $scope.enabledFeatures = [];

                $scope.features.forEach(function(feature) {

                    if (feature.value == "True") {

                        feature.checked = true;

                        $scope.enabledFeatures.push(feature.key);

                    } else {

                        feature.checked = false;
                    }
                });
            }
        );
    };
    
    getConfigsFunc();

    getFeaturesFunc();


    $interval(getConfigsFunc, 3000);

    $interval(getFeaturesFunc, 3000);

});