var geoJson, map, mtsatOverlay;
$(function() {
    $("#datepicker").datepicker();

    $("#id-form-submit").click(function() {
        var formData = $("#id-message-form").serialize();
        $.support.cors = true;
        this.xhr = $.ajax({
            crossDomain: true,
            type: "POST",
            url: "https://readysaster.azurewebsites.net/api/AlertManagementApi?"+formData,
            headers: {
                "content-Type": "application/json",
            },
            data: geoJson
        }).done(success);
    });

    $("#id-toggle-overlay").click(function() {
        var currentMode = $("#id-toggle-overlay").attr("mode");
        if (currentMode == "show") {
            hideOverlay();
            $("#id-toggle-overlay").attr("mode", "hide");
        }
        else {
            showOverlay();
            $("#id-toggle-overlay").attr("mode", "show");
        }
    });
});

function success() {
    $("#id-label").html("Your alerts have been sent.");
}

function initialize() {
    var mapDiv = document.getElementById("map-canvas");
    var mapOptions = {
        center: new google.maps.LatLng(12.375, 121.5),
        zoom: 5,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(mapDiv, mapOptions);

    var drawingManager = new google.maps.drawing.DrawingManager({
        drawingMode: null,
        drawingControl: true,
        drawingControlOptions: {
            position: google.maps.ControlPosition.TOP_CENTER,
            drawingModes: [
                google.maps.drawing.OverlayType.POLYGON,
            ]
        }
    });
    drawingManager.setMap(map);

    google.maps.event.addListener(drawingManager, 'polygoncomplete', function(polygon) {
        var path = polygon.getPath();
        geoJson = convertToGeojson(path);
    });

    getMTSAT(map);
}
google.maps.event.addDomListener(window, 'load', initialize);

function getMTSAT() {
    // Can't access Project NOAH API due to Same Origin Policy
    // this.xhr = $.ajax({
    //     crossDomain: true,
    //     type: "GET",
    //     url: "http://202.90.153.89/api/mtsat",
    //     headers: {
    //         "content-Type": "application/json",
    //     }
    // }).done(getMTSATDone);
    data = [{"url": "http://climatex.dost.gov.ph/img/IR_rbow5.png", "verbose_name": "MTSAT", "extent": [99.6, 2.5, 148.2, 26.9], "size": [674, 337]}, {"url": "http://climatex.dost.gov.ph/img/IRWV5.png", "verbose_name": "Processed MTSAT", "extent": [99.6, 2.5, 148.2, 26.9], "size": [674, 337]}, {"url": "http://climatex.dost.gov.ph/img/VIS5.png", "verbose_name": "MTSAT VIS", "extent": [99.6, 2.5, 148.2, 26.9], "size": [1112, 556]}];
    getMTSATDone(data);
}

function getMTSATDone(data) {
    var mtsatUrl, coords;
    for (var i=0; i<data.length; i++) {
        if (data[i].verbose_name == "MTSAT") {
            mtsatUrl = data[i].url;
            coords = data[i].extent;
        }
    }

    var imageBounds = new google.maps.LatLngBounds(
        new google.maps.LatLng(2.3, 101.0),
        new google.maps.LatLng(27.85, 148.7)
    );

    mtsatOverlay = new google.maps.GroundOverlay(mtsatUrl, imageBounds, {opacity: 0.3});
    showOverlay();
}

function showOverlay() {
    mtsatOverlay.setMap(map);
}

function hideOverlay() {
    mtsatOverlay.setMap(null);
}

function convertToGeojson(path) {
    var coords = [];
    var xy = [];
    for (var i=0; i<path.j.length; i++) {
        xy = [path.j[i]['k'], path.j[i]['A']];
        coords.push(xy);
    }
    coords.push([path.j[0]['k'], path.j[0]['A']]);
    return {
        "type": "Polygon", 
        "coordinates": [coords]
    };
}