function loadBingMap(key) {
    var map = new Microsoft.Maps.Map('#map', {
        credentials: key,
        mapTypeId: Microsoft.Maps.MapTypeId.aerial,
        zoom: 10
    });
    
    window.map = map;
    
    return "";
}

function addPins(coordinates) {
    window.map.entities.deleteAllShapes()
   
    for (var i = 0; i < coordinates.length; i++) {
        var coordinate = coordinates[i];
        
        var pushpin = new Microsoft.Maps.Pushpin(coordinate, null);
        window.map.entities.push(pushpin);
    }
    
    return "";
}