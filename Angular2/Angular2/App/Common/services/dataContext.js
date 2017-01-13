'use strict';

var serviceId = 'dataContext';
app.factory(serviceId, ['$http', '$q', dataContext]);


function dataContext($http, $q) {
    var deferred = $q.defer();

    return {
        get: _get,
        getById: _getById,
        deleteData: _deleteData,
        add: _add,
        upDate: _upDate,
    };

    function _get(url) {
        var deferred = $q.defer();
        $http({ method: 'GET', url: url }).success(function (data, status, headers, config) {
            deferred.resolve(data);
        }).error(function (data, status, headers, config) {
            error(data, status);
        });
        return deferred.promise;
    }


    function _getById(url) {
        return _get(url);
    }

    function _deleteData(url) {
        var deferred = $q.defer();
        $http({ method: 'Delete', url: url }).success(function (data, status, headers, config) {
            deferred.resolve(data);
        }).error(function (data, status, headers, config) {
            if (data.Message != undefined) {
                error(data.Message + " ,Code:" + status);
            } else {
                error(data, status);
            }
        });
        return deferred.promise;
    }


    function _add(url, model) {
        var deferred = $q.defer();
        
        $http({ method: "Post", url: url, data: model }).success(function (data, status, headers, config) {
            deferred.resolve(data);
        }).error(function (data, status, headers, config) {
             
            error(data, status);
        });
        return deferred.promise;
    }

    function _upDate(url, model) {
        var deferred = $q.defer();
        // , 'Accept': 'application/json;odata=verbose' headers: {'Content-Type': 'application/json'}
        $http({ method: "PUT", url: url, data: model }).success(function (data, status, headers, config) {
            deferred.resolve(data);
        }).error(function (data, status, headers, config) {
            error(data, status);
        });
        return deferred.promise;
    }

    function error(data, status) {
        if (status != 401) {
            alert(data + " ,Code:" + status);
        }
    }
}
