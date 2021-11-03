function loadBingMap(key, dotnetRef) {
    var map = new Microsoft.Maps.Map('#map', {
        credentials: key,
        mapTypeId: Microsoft.Maps.MapTypeId.aerial,
        zoom: 10
    });
    
    window.map = map;
    window.dotnetRef = dotnetRef;

    Microsoft.Maps.Events.addHandler(map, 'click', function () {
        window.dotnetRef && window.dotnetRef.invokeMethodAsync('HidePopup');
    });

    return "";
}

function addPins(pins) {
    removeAllPins()
    
    for (var i = 0; i < pins.length; i++) {
        var pin = pins[i]
        
        var coordinate = {
            latitude: pin.latitude,
            longitude: pin.longitude
        } 

        var pushpin = new Microsoft.Maps.Pushpin(coordinate, null);
        Microsoft.Maps.Events.addHandler(pushpin, 'click', onClickFactory(pin.id));
        
        window.map.entities.push(pushpin);
    }
    
    return "";
}

function removeAllPins() {
    for (var i = 0; i < window.map.entities.length; i++) {
        window.map.entities.removeAt(0)
    }
}

function onClickFactory(id) {
    return function(e) {
        console.log(e);

        window.dotnetRef && window.dotnetRef.invokeMethodAsync('ClickedOnPin', {
            id: id,
            pageX: e.point.x,
            pageY: e.point.y,
        });
    }
}
