var map, marker;

$(function() {
    $('#id-form-submit').click(function() {
        var userData = {};
        userData["currentLocation"] = {
            "latitude": $("#id-latitude-field"),
            "longitude": $("#id-longitude-field")
        };
        userData["addressString"] = $("#id-address-field");
        userData["phoneNumber"] = $("#id-phone-number-field");

        $.support.cors = true;
        this.xhr = $.ajax({
            crossDomain: true,
            type: "POST",
            url: "https://readysaster.azurewebsites.net/api/AlertSubscriptionApi",
            headers: {
                "content-Type": "application/json",
            },
            data: userData
        }).done(success);
    });
});

function success() {
    $("#id-label").html("Registration successful!");
}

function initialize() {
    var mapOptions = {
        zoom: 13
    };

    map = new google.maps.Map(document.getElementById('map-canvas'),
        mapOptions);

    // Try HTML5 geolocation
    if(navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function(position) {
            var pos = new google.maps.LatLng(position.coords.latitude,
                                               position.coords.longitude);

            map.setCenter(pos);

            initializeMarker(pos);
            setLatLng(pos);
        }, function() {
            handleNoGeolocation(true);
        });
    } else {
        // Browser doesn't support Geolocation
        handleNoGeolocation(false);
    }
}

function setLatLng(pos) {
    $('#id-latitude-field').val(pos.lat());
    $('#id-longitude-field').val(pos.lng());
}

function initializeMarker(pos) {
    marker = new google.maps.Marker({
        position: pos,
        map: map,
        draggable:true,
        title:"Place the marker on your location"
    });

    google.maps.event.addListener(marker, 'dragend', function() {
       setLatLng(marker.getPosition());
    });
}

function handleNoGeolocation(errorFlag) {
    if (errorFlag) {
      var content = 'Error: The Geolocation service failed.';
    } else {
        var content = 'Error: Your browser doesn\'t support geolocation.';
    }

    var options = {
        map: map,
        position: new google.maps.LatLng(12.375, 121.5),
    };

    map.setCenter(options.position);
    initializeMarker(options.position);
}

google.maps.event.addDomListener(window, 'load', initialize);