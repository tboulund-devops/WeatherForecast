var ViewModel = function ViewModel() {
    
    var me = this;
    me.api = ko.observable();
    me.forecasts = ko.observableArray();
    me.temperatureC = ko.observable();
    me.summary = ko.observable();

    me.loadData = function() {
        $.ajax({
            url: me.api,
            type: "GET",
            success: function(a) {
                me.forecasts.removeAll();
                a.forEach((value) => me.forecasts.push(value));
            }
        });
    }

    $.ajax({
        url: "/config/api-url.txt",
        type: "GET",
        success: function(url) {
            console.log(url);
            me.api(url);
            me.loadData();
        }
    });
    
    me.save = function() {
        $.ajax({
            url: me.api,
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({
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
                url: me.api,
                type: "DELETE",
                contentType: "application/json",
                data: JSON.stringify({
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