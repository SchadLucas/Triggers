window.Triggers = Ember.Application.create();

// Set API namespace to [host]:[port]/api/
Triggers.ApplicationAdapter = DS.RESTAdapter.extend({
    namespace: 'api'
});


// Close Bootstrap Menu on Item-Click
$(document).on('click', '.navbar-collapse.in', function (e) {
    if ($(e.target).is('a')) {
        $(this).collapse('hide');
    }
});


// Beautify Timestamps
Triggers.DateTransform = DS.Transform.extend({
    deserialize: function (serialized) {
        var m = moment(serialized);
        if (!m.isValid()) {
            return ' ';
        }

        var format = 'hh:mm A';
        var isCurrentDate = m.isSame(new Date(), "day");
        if (!isCurrentDate) {
            format += ' YY/M/D';
        }

        return m.format(format);
    }
});
Triggers.register('transform:date', Triggers.DateTransform);