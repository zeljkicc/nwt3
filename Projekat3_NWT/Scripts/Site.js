
$(document).ready(function () {


    //for passing data to contoller when sorting list of properties

    $("#sortOrder").bind("change", function () {
        
        $(".loader-img").css("display", "block");

            $.ajax({
                url: "/Property/List",
                data: {
                    sortOrder: $("#sortOrder").val(), priceMin: $("#priceMin").val(), priceMax: $("#priceMax").val(),
                    metersMin: $("#metersMin").val(), metersMax: $("#metersMax").val(),
                    roomsMin: $("#roomsMin").val(), roomsMax: $("#roomsMax").val(),
                    type: $("select#type").val(), Furnished: $("input[name='Furnished']:checked").val(), availableFor: $("#availableFor").val()
                },
                type: "POST",
                success: function (data) {
                    $(".loader-img").css("display", "none");
                    $("#list-container").html(data);
                },
                error: function (passParams) {
                    // code here
                }
            });
        });

    

    $(function () {
        $("#priceMax").unbind('keyup mouseup'); 
        $("#priceMax").on("keyup mouseup", function (e) {
            if ($("#priceMax").val() != $("#priceMax").data("value"))
            {
                $("#priceMax").data("value", $("#priceMax").val());

                $.ajax({
                    url: "/Property/List",
                    data: {
                        priceMin: $("#priceMin").val(), priceMax: $("#priceMax").val(), sortOrder: $("#sortOrder").val(),
                        metersMin: $("#metersMin").val(), metersMax: $("#metersMax").val(),
                        roomsMin: $("#roomsMin").val(), roomsMax: $("#roomsMax").val(),
                        type: $("select#type").val(), Furnished: $("input[name='Furnished']:checked").val(), availableFor: $("#availableFor").val()
                    },
                    type: "POST",
                    success: function (data) {
                        $(".loader-img").css("display", "none");
                        $("#list-container").html(data);
                    },
                    error: function (passParams) {
                        // code here
                    }
                });

            }

            
        });

        $("#priceMin").unbind('keyup mouseup');
        $("#priceMin").on("keyup mouseup", function (e) {
            if ($("#priceMin").val() != $("#priceMin").data("value")) {
                $("#priceMin").data("value", $("#priceMin").val());


                $.ajax({
                    url: "/Property/List",
                    data: {
                        priceMin: $("#priceMin").val(), priceMax: $("#priceMax").val(), sortOrder: $("#sortOrder").val(),
                        metersMin: $("#metersMin").val(), metersMax: $("#metersMax").val(),
                        roomsMin: $("#roomsMin").val(), roomsMax: $("#roomsMax").val(),
                        type: $("select#type").val(), Furnished: $("input[name='Furnished']:checked").val(), availableFor: $("#availableFor").val()
                    },
                    type: "POST",
                    success: function (data) {
                        $(".loader-img").css("display", "none");
                        $("#list-container").html(data);
                    },
                    error: function (passParams) {
                        // code here
                    }
                });

            }


        });


        $("#metersMin").on("keyup mouseup", function (e) {
            if ($("#metersMin").val() != $("#metersMin").data("value")) {
                $("#metersMin").data("value", $("#metersMin").val());


                $.ajax({
                    url: "/Property/List",
                    data: {
                        priceMin: $("#priceMin").val(), priceMax: $("#priceMax").val(), sortOrder: $("#sortOrder").val(),
                        metersMin: $("#metersMin").val(), metersMax: $("#metersMax").val(),
                        roomsMin: $("#roomsMin").val(), roomsMax: $("#roomsMax").val(),
                        type: $("select#type").val(), Furnished: $("input[name='Furnished']:checked").val(), availableFor: $("#availableFor").val()
                    },
                    type: "POST",
                    success: function (data) {
                        $(".loader-img").css("display", "none");
                        $("#list-container").html(data);
                    },
                    error: function (passParams) {
                        // code here
                    }
                });

            }


        });

        $("#metersMax").on("keyup mouseup", function (e) {
            if ($("#metersMax").val() != $("#metersMax").data("value")) {
                $("#metersMax").data("value", $("#metersMax").val());


                $.ajax({
                    url: "/Property/List",
                    data: {
                        priceMin: $("#priceMin").val(), priceMax: $("#priceMax").val(), sortOrder: $("#sortOrder").val(),
                        metersMin: $("#metersMin").val(), metersMax: $("#metersMax").val(),
                        roomsMin: $("#roomsMin").val(), roomsMax: $("#roomsMax").val(),
                        type: $("select#type").val(), Furnished: $("input[name='Furnished']:checked").val(), availableFor: $("#availableFor").val()
                    },
                    type: "POST",
                    success: function (data) {
                        $(".loader-img").css("display", "none");
                        $("#list-container").html(data);
                    },
                    error: function (passParams) {
                        // code here
                    }
                });

            }


        });

        $("#roomsMin").on("keyup mouseup", function (e) {
            if ($("#roomsMin").val() != $("#roomsMin").data("value")) {
                $("#roomsMin").data("value", $("#roomsMin").val());


                $.ajax({
                    url: "/Property/List",
                    data: {
                        priceMin: $("#priceMin").val(), priceMax: $("#priceMax").val(), sortOrder: $("#sortOrder").val(),
                        metersMin: $("#metersMin").val(), metersMax: $("#metersMax").val(),
                        roomsMin: $("#roomsMin").val(), roomsMax: $("#roomsMax").val(),
                        type: $("select#type").val(), Furnished: $("input[name='Furnished']:checked").val(), availableFor: $("#availableFor").val()
                    },
                    type: "POST",
                    success: function (data) {
                        $(".loader-img").css("display", "none");
                        $("#list-container").html(data);
                    },
                    error: function (passParams) {
                        // code here
                    }
                });

            }


        });

        $("#roomsMax").on("keyup mouseup", function (e) {
            if ($("#roomsMax").val() != $("#roomsMax").data("value")) {
                $("#roomsMax").data("value", $("#roomsMax").val());


                $.ajax({
                    url: "/Property/List",
                    data: {
                        priceMin: $("#priceMin").val(), priceMax: $("#priceMax").val(), sortOrder: $("#sortOrder").val(),
                        metersMin: $("#metersMin").val(), metersMax: $("#metersMax").val(),
                        roomsMin: $("#roomsMin").val(), roomsMax: $("#roomsMax").val(),
                        type: $("select#type").val(), Furnished: $("input[name='Furnished']:checked").val(), availableFor: $("#availableFor").val()
                    },
                    type: "POST",
                    success: function (data) {
                        $(".loader-img").css("display", "none");
                        $("#list-container").html(data);
                    },
                    error: function (passParams) {
                        // code here
                    }
                });

            }


        });

        $("select#type").bind("change", function (e) {
            if ($("select#type").val() != $("select#type").data("value")) {
                $("select#type").data("value", $("select#type").val());


                $.ajax({
                    url: "/Property/List",
                    data: {
                        priceMin: $("#priceMin").val(), priceMax: $("#priceMax").val(), sortOrder: $("#sortOrder").val(),
                        metersMin: $("#metersMin").val(), metersMax: $("#metersMax").val(),
                        roomsMin: $("#roomsMin").val(), roomsMax: $("#roomsMax").val(),
                        type: $("select#type").val(), Furnished: $("input[name='Furnished']:checked").val(), availableFor: $("#availableFor").val()
                    },
                    type: "POST",
                    success: function (data) {
                        $(".loader-img").css("display", "none");
                        $("#list-container").html(data);
                    },
                    error: function (passParams) {
                        // code here
                    }
                });

            }


        });


        $("input[name='Furnished']").change(function (e) {


                $.ajax({
                    url: "/Property/List",
                    data: {
                        priceMin: $("#priceMin").val(), priceMax: $("#priceMax").val(), sortOrder: $("#sortOrder").val(),
                        metersMin: $("#metersMin").val(), metersMax: $("#metersMax").val(),
                        roomsMin: $("#roomsMin").val(), roomsMax: $("#roomsMax").val(),
                        type: $("select#type").val(), Furnished: $("input[name='Furnished']:checked").val(), availableFor: $("#availableFor").val()
                    },
                    type: "POST",
                    success: function (data) {
                        $(".loader-img").css("display", "none");
                        $("#list-container").html(data);
                    },
                    error: function (passParams) {
                        // code here
                    }
                });



        });

        $("#load-more-properties").on("click", function (e) {
            $.ajax({
                url: "/Property/List",
                data: {
                    priceMin: $("#priceMin").val(), priceMax: $("#priceMax").val(), sortOrder: $("#sortOrder").val(),
                    metersMin: $("#metersMin").val(), metersMax: $("#metersMax").val(),
                    roomsMin: $("#roomsMin").val(), roomsMax: $("#roomsMax").val(),
                    type: $("select#type").val(), Furnished: $("input[name='Furnished']:checked").val(),
                    blocks: $("#load-more-properties").data("value"), availableFor: $("#availableFor").val()
                },
                type: "POST",
                success: function (data) {
                    $(".loader-img").css("display", "none");

 
                    $("#list-container").append(data);

                    $("#load-more-properties").data("value", $("#load-more-properties").data("value") + 1);
                },
                error: function (passParams) {
                    // code here
                }
            });
        });

    });

   
    $("#new-properties").load("/Property/ListPartialHomePage",
   { newer: true }, function () {
       //do other cool client side stuff
   });

    $("#rent-properties").load("/Property/ListPartialHomePage",
   { newer: false, availableFor: "Rent" }, function () {
       //do other cool client side stuff
   });

    $("#sale-properties").load("/Property/ListPartialHomePage",
   { newer: false, availableFor: "Sale" }, function () {
       //do other cool client side stuff
   });


    if ($("#map").length > 0) {
        initializeMap();

        if (typeof propertyLat === 'undefined') {
            

            // Attempt to get the users current location.
            if (navigator.geolocation)
                navigator.geolocation.getCurrentPosition(onGetCurrentPosition, onError);
        }
        else{
            map.addLayer((new L.Marker(new L.LatLng(propertyLat, propertyLon)).bindPopup("Property location")));
            map.setView(new L.LatLng(propertyLat, propertyLon), 17);
            propertyLat = null;
            propertyLon = null;
        }
        
  
    }

    $("body").on("shown.bs.tab", "#pill-address", function () {
        map.invalidateSize(false);
    });

    $("body").on("shown.bs.tab", "#pill-properties-map", function () {
        map.invalidateSize(false);

        var all = $(".property-list-element").map(function () {
            return this;
        }).get();



        var markers = new Array();
        var latlngs = new Array();

        all.forEach(function (item) {
            var lat = parseFloat($(item).data("lat"));
            var lon = parseFloat($(item).data("lon"));

            var availableFor = $(item).data("availablefor");
            var type = $(item).data("type");
            var price = $(item).data("price");
            var meters = $(item).data("meters");
            var rooms = $(item).data("rooms");

            var id = $(item).data("id");

            if (!isNaN(lat) && !isNaN(lon)){
                var marker = L.marker([lat, lon]);
              
                //latlngs.push(new L.LatLng(lon, lat));

                var str = "";

                if (typeof price !== 'undefined' && price != null) {
                    str += "<h3>&euro;" + price + "</h3>";
                }

                if (typeof availableFor !== 'undefined' && availableFor != null) {
                    str += "For " + availableFor + " - ";
                }

                if (typeof type !== 'undefined' && type != null) {
                    str += type + " - ";
                }

                if (typeof meters !== 'undefined' && meters != null) {
                    str += meters + "m2 - ";
                }

                if (typeof rooms !== 'undefined' && rooms != null) {
                    str += rooms + " Rooms(s) ";
                }

                str += "<p><a href='/Property/Details/" + id + "'>See More</a></p>"

                marker.bindPopup(str);

                markers.push(marker);
            }
               
           
        });
        if (typeof properties !== 'undefined')
            map.removeLayer(properties);
        properties = L.layerGroup(markers);
        map.addLayer(properties);

        //var bounds = new L.LatLngBounds(latlngs);
        //map.fitBounds(bounds);

       // var bounds = L.latLngBounds(markers);
        // map.fitBounds(bounds);
        if(markers[0])
        map.setView(markers[0]._latlng, 17);
    });



    $("#send-message-button").on('click', function (event) {
        event.preventDefault();
        $.ajax({
            url: "/Message/Create",
            data: $('#form-message-send').serialize(),
            type: "POST",
            success: function (data) {
                if (data.success) {
                    $("#error-message").css("display", "none");
                    $("#form-message-send").html("<h1>" + data.message + "</h1>");
                }
                else {
                    $("#error-message").html(data.message);
                }
            },
            error: function (passParams) {
                // code here
            }
        });
    });

    if ($("#map-contact").length > 0) {
        var map1 = new L.Map('map-contact');

        // REQUIRED: create the tile layer with correct attribution
        var osmUrl = 'http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png';
        var osmAttrib = 'Map data © <a href="http://openstreetmap.org">OpenStreetMap</a> contributors';
        var osm = new L.TileLayer(osmUrl, { minZoom: 8, maxZoom: 20, attribution: osmAttrib });

        map1.addLayer(osm);
        map1.setView(new L.LatLng(43.318200, 21.890924), 16);

        map1.addLayer(((new L.Marker(new L.LatLng(43.318200, 21.890924)).bindPopup("MVC Realty")).openPopup()));

    }

});



function initializeMap() {
    map = new L.Map('map');
    newPropertyMarker = null;

    // REQUIRED: create the tile layer with correct attribution
    var osmUrl = 'http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png';
    var osmAttrib = 'Map data © <a href="http://openstreetmap.org">OpenStreetMap</a> contributors';
    var osm = new L.TileLayer(osmUrl, { minZoom: 8, maxZoom: 20, attribution: osmAttrib });

    // Set default center (Hartford, CT in this case - with a zoom level of 17)
    map.setView(new L.LatLng(41.7656874, -72.680087), 17);
    map.addLayer(osm);

    if (typeof noclick === 'undefined') {
        map.on('click', onMapClick);
    }
}


function onGetCurrentPosition(location) {
    var latitude = location.coords.latitude;
    var longitude = location.coords.longitude;
    var zoomLevel = 17;

    map.setView(new L.LatLng(latitude, longitude), zoomLevel);

    map.addLayer((new L.Marker(new L.LatLng(latitude, longitude)).bindPopup("You are here")));
}
function onError() {
    // Do nothing
}



function onMapClick(e) {
    if (newPropertyMarker!=null)
        map.removeLayer(newPropertyMarker);

    newPropertyMarker = new L.Marker();
    newPropertyMarker.bindPopup("Property location")
    newPropertyMarker.setLatLng(e.latlng);
    map.addLayer(newPropertyMarker);

    $("#Address_Lat").val(e.latlng.lat);
    $("#Address_Lon").val(e.latlng.lng);

}





