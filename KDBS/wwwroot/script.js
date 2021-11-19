function loadBingMap(key, dotnetRef) {
    var map = new Microsoft.Maps.Map('#map', {
        credentials: key,
        zoom: 10
    });

    window.map = map;
    window.dotnetRef = dotnetRef;
    window.pins = []

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
        
        window.pins.push(pushpin)
        window.map.entities.push(pushpin);
    }

    return "";
}

function removeAllPins() {
    for (var i = 0; i < window.pins.length; i++) {
        var pin = window.pins[i]
        window.map.entities.remove(pin);
    }
    
    window.pins = []
}

function onClickFactory(id) {
    return function(e) {
        console.log(e);

        window.dotnetRef && window.dotnetRef.invokeMethodAsync('ClickedOnPin', {
            id: id,
            pageX: Math.floor(e.point.x),
            pageY: Math.floor(e.point.y),
            screenHight: window.innerHeight,
            screenWidth: window.innerWidth,
        });
    }
}
