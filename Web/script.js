var ViewModel = function ViewModel() {
    
    var me = this;
    me.password = ko.observable();
    me.forecasts = ko.observableArray();
    me.temperatureC = ko.observable();
    me.summary = ko.observable();
    
    me.loadData = function() {
        $.ajax({
            url: "https://localhost:5001/WeatherForecast",
            type: "GET",
            data: {
                databasePassword: me.password()
            },
            success: function(a) {
                me.forecasts.removeAll();
                a.forEach((value) => me.forecasts.push(value));
            }
        });
    }

    me.login = function() {
        me.loadData();
    }
    
    me.save = function() {
        $.ajax({
            url: "https://localhost:5001/WeatherForecast",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({
                databasePassword: me.password(),
                temperatureC: me.temperatureC(),
                summary: me.summary()
            }),
            success: function() {
                me.loadData();
            }
        });
    }

    me.delete = function(forecast) {
        if(confirm("Are you sure you want to delete the forecast?")) {
            $.ajax({
                url: "https://localhost:5001/WeatherForecast",
                type: "DELETE",
                contentType: "application/json",
                data: JSON.stringify({
                    databasePassword: me.password(),
                    id: forecast.id
                }),
                success: function () {
                    me.loadData();
                }
            });
        }
    }
}
ko.applyBindings(new ViewModel());