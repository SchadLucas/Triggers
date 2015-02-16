Triggers.NotificationsController = Ember.Controller.extend({

});

Triggers.LogController = Ember.Controller.extend({
    processedData: function (){
        result = [];
        this.model.forEach(function(e){
            var x = e;
            x.set('level', 'loglevel loglevel-' + e.get('level').toLowerCase());
            result.push(x);
        });
        return result;
    }.property('model')
});