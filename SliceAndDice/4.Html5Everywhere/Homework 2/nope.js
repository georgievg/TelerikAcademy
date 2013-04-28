$.webshims.polyfill('geolocation');

function requestPosition()
{
    navigator.geolocation.getCurrentPosition(successCallback, errorCallback);
}

function successCallback(position)
{
    document.getElementById("locationResult").innerHTML =
    "Latitude: " + position.coords.latitude + "<br/>Longitude:" + position.coords.longitude;
}

function errorCallback(error)
{
    switch (error.code)
    {
        case error.PERMISSION_DENIED:
            strMessage = "Access to your location is turned off. " +
                         "Change your settings to turn it back on.";
            break;

        case error.POSITION_UNAVAILABLE:
            strMessage = "Data from location services is " +
                         "currently unavailable.";
            break;

        case error.TIMEOUT:
            strMessage = "Location could not be determined " +
                         "within a specified timeout period.";
            break;

        default:
            break;
    }
}