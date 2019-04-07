﻿(function (app) {
    app.controller('slideAddController', slideAddController)
    slideAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state']
    function slideAddController($scope, apiService, notificationService, $state) {
        $scope.slide = {
            Status: true
        }

        $scope.AddSlide = AddSlide
        function AddSlide() {
            apiService.post('/api/slide/add', $scope.slide, function (result) {
                notificationService.displaySuccess(result.data.Name + ' Đã được thêm thành công')
                $state.go('slide')
            }, function (error) {
                notificationService.displayError('Bạn hãy nhập dữ liệu vào các ô bắt buộc')

                notificationService.displayError('Thêm không thành công')
            })
        }
    }
})(angular.module('smartphone.slide'))