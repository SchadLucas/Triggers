Triggers.Router.map(function () {
    this.resource('triggers', {path: '/'});
    this.resource('notifications');
    this.resource('applications');
    this.resource('settings');
    this.resource('system',  function () {
        // child routes
        this.resource('log');
        this.resource('agents');
        this.resource('update');
        this.resource('backup');
    });
    this.resource('donate', {path: '/donate'});
});

Triggers.IndexRoute = Em.Route.extend({
    afterModel: function () {
        $(document).attr('title', 'Triggers');
    }
});

Triggers.SystemRoute = Em.Route.extend({
    activate: function () {
        window.document.title = 'System - Triggers';
    }
});

Triggers.NotificationsRoute = Em.Route.extend({
    model: function () {
        return this.store.find('notification');
    },
    activate: function () {
        window.document.title = 'Notifications - Triggers';
    }
});

Triggers.ApplicationsRoute = Em.Route.extend({
    activate: function () {
        window.document.title = 'Applications - Triggers';
    }
});

Triggers.SettingsRoute = Em.Route.extend({
    activate: function () {
        window.document.title = 'Settings - Triggers';
    }
});

Triggers.DonateRoute = Em.Route.extend({
    activate: function () {
        window.document.title = 'Donate - Triggers';
    }
});

// todo: Fix routing => [host]/system will return a 404 since Nancy won't know what to do
// Use Browser History API to remove unfancy hash URL's
//Triggers.Router.reopen({
//    location: 'history'
//});