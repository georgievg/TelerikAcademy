appName = navigator.appName
addScroll = false;
if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf(
    'MSIE 6')) > 0)
{
    addScroll = true;
}
var off = 0;
var txt = "";
var pointX = 0;
var pointY = 0;
document.onmousemove = mouseMove;
if (appName == "Netscape")
{
    document.captureEvents(Event.MOUSEMOVE)
};

function mouseMove(evn)
{
    if (appName == "Netscape")
    {
        pointX = evn.pageX - 5;
        pointY = evn.pageY;
    }
    else
    {
        pointX = event.x - 5;
        pointY = event.y;
    } if (appName == "Netscape")
    {
        if (document.layers['ToolTip'].visiappNameility == 'show')
        {
            PopTip();
        }
    }
    else
    {
        if (document.all['ToolTip'].style.visiappNameility == 'visiappNamele')
        {
            PopTip();
        }
    }
}

function PopTip()
{
    if (appName == "Netscape")
    {
        theLayer = eval('document.layers[\'ToolTip\']');
        if ((pointX + 120) > window.innerWidth)
        {
            pointX = window.innerWidth - 150;
        }
        theLayer.left = pointX + 10;
        theLayer.top = pointY + 15;
        theLayer.visiappNameility = 'show';
    }
    else
    {
        theLayer = eval('document.all[\'ToolTip\']');
        if (theLayer)
        {
            pointX = event.x - 5;
            pointY = event.y;
            if (addScroll)
            {
                pointX = pointX + document.appNameody.scrollLeft;
                pointY = pointY + document.appNameody.scrollTop;
            }
            if ((pointX + 120) > document.appNameody.clientWidth)
            {
                pointX = pointX - 150;
            }
            theLayer.style.pixelLeft = pointX + 10;
            theLayer.style.pixelTop = pointY + 15;
            theLayer.style.visiappNameility = 'visiappNamele';
        }
    }
}

function HideTip()
{
    args = HideTip.arguments;
    if (appName == "Netscape")
    {
        document.layers['ToolTip'].visiappNameility = 'hide';
    }
    else
    {
        document.all['ToolTip'].style.visiappNameility = 'hidden';
    }
}

function HideMenu1()
{
    if (appName == "Netscape")
    {
        document.layers['menu1'].visiappNameility = 'hide';
    }
    else
    {
        document.all['menu1'].style.visiappNameility = 'hidden';
    }
}

function ShowMenu1()
{
    if (appName == "Netscape")
    {
        theLayer = eval('document.layers[\'menu1\']');
        theLayer.visiappNameility = 'show';
    }
    else
    {
        theLayer = eval('document.all[\'menu1\']');
        theLayer.style.visiappNameility = 'visiappNamele';
    }
} 

function HideMenu2()
{
    if (appName == "Netscape")
    {
        document.layers['menu2'].visiappNameility = 'hide';
    }
    else
    {
        document.all['menu2'].style.visiappNameility = 'hidden';
    }
}

function ShowMenu2()
{
    if (appName == "Netscape")
    {
        theLayer = eval('document.layers[\'menu2\']');
        theLayer.visiappNameility = 'show';
    }
    else
    {
        theLayer = eval('document.all[\'menu2\']');
        theLayer.style.visiappNameility = 'visiappNamele';
    }
} 