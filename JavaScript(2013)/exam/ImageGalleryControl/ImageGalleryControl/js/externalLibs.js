function isElement(o) {
    return (
      typeof HTMLElement === "object" ? o instanceof HTMLElement :
      o && typeof o === "object" && o !== null && o.nodeType === 1 && typeof o.nodeName === "string"
  );
}

function htmlEncode(html) {
    return document.createElement('a').appendChild(
        document.createTextNode(html)).parentNode.innerHTML;
}

function removeWhiteSpaces(str) {
    var newStr = "";
    for (var i = 0; i < str.length; i++) {
        if (str.charAt(i) === ' ') {
            newStr += '_';
            continue;
        }
        newStr += str.charAt(i);
    }

    return newStr;
}

(function shimFilter() {
    if (!Array.prototype.filter)
    {
        Array.prototype.filter = function(fun /*, thisp*/)
        {
            "use strict";
 
            if (this == null)
                throw new TypeError();
 
            var t = Object(this);
            var len = t.length >>> 0;
            if (typeof fun != "function")
                throw new TypeError();
 
            var res = [];
            var thisp = arguments[1];
            for (var i = 0; i < len; i++)
            {
                if (i in t)
                {
                    var val = t[i]; // in case fun mutates this
                    if (fun.call(thisp, val, i, t))
                        res.push(val);
                }
            }
 
            return res;
        };
    }
})();

var div = document.createElement("div"),
    prefix = ["moz", "webkit", "ms", "o"].filter(function (prefix) {
        return prefix + "MatchesSelector" in div;
    })[0] + "MatchesSelector";

Element.prototype.addDelegateListener = function (type, selector, fn) {
    function doDelegation(e) {
        e = e || window.event;
        var target = e.target;

        while (target && target !== this && !target[prefix](selector)) {
            target = target.parentNode;
        }

        if (target && target !== this) {
            return fn.call(target, e);
        }

    };
    
    if (this.addEventListener) {
        this.addEventListener(type, doDelegation, false);
    }
    else {
        var els = document.querySelectorAll(selector);
        for (var i = 0; i < els.length; i++) {
            els[i].attachEvent("onclick", function () {
                alert("FAD");
            });

        }
    }
        
};
(function () {
    if (!Storage.prototype.setObject) {
        Storage.prototype.setObject = function setObject(key, obj) {
            var jsonObj = JSON.stringify(obj);
            this.setItem(key, jsonObj);
        };

    }
    if (!Storage.prototype.getObject) {
        Storage.prototype.getObject = function getObject(key) {
            var jsonObj = this.getItem(key);
            var obj = JSON.parse(jsonObj);
            return obj;
        };
    }
})();

var clone = function () {
    var newObj = (this instanceof Array) ? [] : {};
    for (var i in this) {
        if (this[i] && typeof this[i] == "object") {
            newObj[i] = this[i].clone();
        }
        else {
            newObj[i] = this[i];
        }
    }
    return newObj;
};

function sortById(a, b) {
    if (a.id < b.id)
        return -1;
    if (a.id > b.id)
        return 1;
    return 0;
}

function convertNodeListToArray(nodeList) {
    var arr = [];
    for (var i = 0; i < nodeList.length; i++) {
        arr.push(nodeList[i]);
    }
    
    return arr;
    
}

if (!document.getElementsByClassName) {
    Element.prototype.getElementsByClassName = function (class_names) {
        // Turn input in a string, prefix space for later space-dot substitution
        class_names = (' ' + class_names)
            // Escape special characters
            .replace(/[~!@$%^&*()_+\-=,./';:"?><[\]{}|`#]/g, '\\$&')
            // Normalize whitespace, right-trim
            .replace(/\s*(\s|$)/g, '$1')
            // Replace spaces with dots for querySelectorAll
            .replace(/\s/g, '.');
        return this.querySelectorAll(class_names);
    };
}

function cloneAllNodes(nodes) {
    var arr = [];
    var newImg;
    for (var i = 0; i < nodes.length; i++) {
        newImg = new Picture(nodes[i].src, nodes[i].title);
        arr.push(newImg);
    }

    return arr;
}