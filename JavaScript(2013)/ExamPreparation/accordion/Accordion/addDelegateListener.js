var div = document.createElement("div"),
    prefix = ["moz", "webkit", "ms", "o"].filter(function (prefix) {
        return prefix + "MatchesSelector" in div;
    })[0] + "MatchesSelector";

Element.prototype.addDelegateListener = function (type, selector, fn) {

    this.addEventListener(type, function (e) {
        var target = e.target;

        while (target && target !== this && !target[prefix](selector)) {
            target = target.parentNode;
        }

        if (target && target !== this) {
            return fn.call(target, e);
        }

    }, false);
};

Element.prototype.appendSibling = function appendSibling(child) {
    if (this.nextSibling) {
        this.parentNode.insertBefore(child, this.nextSibling);
    }
    else {
        this.parentNode.appendChild(child);
    }
};

Element.prototype.getFirstLevelChildNodes = function () {
    var children = [];
    var child;
    var current = this;
    while (child = current.nextSibling) {
        if (child.nodeType == 1 && child.outerHTML.indexOf("ul") !== -1) {
            children.push(child);
        }
        current = child;

    }
    return children;
}

function isElement(obj) {
    try {
        //Using W3 DOM2 (works for FF, Opera and Chrom)
        return obj instanceof HTMLElement;
    }
    catch (e) {
        //Browsers not supporting W3 DOM2 don't have HTMLElement and
        //an exception is thrown and we end up here. Testing some
        //properties that all elements have. (works on IE7)
        return (typeof obj === "object") &&
          (obj.nodeType === 1) && (typeof obj.style === "object") &&
          (typeof obj.ownerDocument === "object");
    }
}

Element.prototype.getAllSiblings = function () {
    var siblings = [];
    var current = this;
    var sibl;

    while (sibl = current.previousSibling) {
        if (isElement(sibl)) {
            siblings.push(sibl);
        }
        current = sibl;
    }

    current = this;
    while (sibl = current.nextSibling) {
        if (isElement(sibl)) {
            siblings.push(sibl);
        }
        current = sibl;
    }

    return siblings;
}
