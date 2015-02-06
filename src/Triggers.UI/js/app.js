window.Triggers = Ember.Application.create();

// Set API namespace to [host]:[port]/api/
Triggers.ApplicationAdapter = DS.RESTAdapter.extend({
    namespace: 'api'
});


// Close Bootstrap Menu on Item-Click
$(document).on('click','.navbar-collapse.in',function(e) {
    if( $(e.target).is('a') ) {
        $(this).collapse('hide');
    }
});