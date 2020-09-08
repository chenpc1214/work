var colors = [];
colors[0] = 'alert alert-info';
colors[1] = 'alert alert-danger';
colors[2] = 'alert alert-success';
colors[3] = 'alert alert-warning';

function getAlertStyle() {
    var index = Math.floor(Math.random() * 4);

    return colors[index];
}