Triggers.Notification = DS.Model.extend({
    caption: DS.attr('string'),
    message: DS.attr('string')
});

Triggers.Log = DS.Model.extend({
    component: DS.attr('string'),
    caption: DS.attr('string'),
    message: DS.attr('string'),
    level: DS.attr('string'),
    timestamp: DS.attr('date')
});