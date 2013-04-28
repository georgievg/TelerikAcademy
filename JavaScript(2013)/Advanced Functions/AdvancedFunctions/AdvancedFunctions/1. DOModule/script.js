var domModule = (function () {

    this.buffer = {};
    this.MAX_BUFFER_SIZE = 100;
    this.selectElement = function (sel) {
        var splittedEls = sel.split(' ');
        var foundEl = [];
        if (splittedEls[splittedEls.length-1].charAt(0) === '#') {
            foundEl.push(document.querySelector(sel));
        }
        else {
            foundEl = (document.querySelectorAll(sel));
        }
        return (function () {
            var els = document.getElementsByTagName('*');
            var newEls = [];
            for (var i = 0; i < els.length; i++) {
                for (var innerEl = 0; innerEl < foundEl.length; innerEl++) {
                    if (foundEl[innerEl] === els[i]) {
                        newEls.push(els[i]);
                    }
                }

            }

            return newEls;
        }());
    }    
    return {
        appendChild: function (el, selector) {
            var selectedEl = selectElement(selector);
            var newEl = document.createElement(el);

            for (var i = 0; i < selectedEl.length; i++) {
                selectedEl[i].appendChild(newEl.cloneNode(true));
            }
        },
        removeChildMod: function (el,selector) {
            var selectedEl = selectElement(selector + ' '+ el);

            for (var i = 0; i < selectedEl.length; i++) {
                var asd = selectedEl[i].parentNode.removeChild(selectedEl[i]);
            }
        },
        addHandler: function (el,event,func) {
            var selectedEl = selectElement(el);
            for (var i = 0; i < selectedEl.length; i++) {
                selectedEl[i].addEventListener(event, func,false);
            }
        },
        appendToBuffer: function (selector, el) {
            var newEl;
            if (el instanceof HTMLElement) {
                newEl = el;
            }
            else {
                newEl = document.createElement(el);
            }

            if (!buffer[selector]) {
                buffer[selector] = [newEl.cloneNode(true)];
            }
            else {
                if (buffer[selector].length >= MAX_BUFFER_SIZE) {
                    for (var key in buffer) {                        
                        for (var i = 0; i < buffer[key].length; i++) {
                            var element = selectElement(selector);
                            for (var elsToAppend = 0; elsToAppend < element.length; elsToAppend++) {
                                element[elsToAppend].appendChild(buffer[key][i])
                            }
                        }
                    }
                }
                else {
                    buffer[selector].push(newEl.cloneNode(true));
                }
                
            }
        }
        
    }
})();


domModule.appendChild('div', '#main ul li');
domModule.removeChildMod('div', '#main ul li');
domModule.addHandler('body', 'click', function () {
    alert('yay you clicked the body !!');
})

var testLi = document.createElement('li');
for (var i = 0; i < 99; i++) {
    domModule.appendToBuffer('#main', testLi.cloneNode(true));
}
domModule.appendToBuffer('#main', testLi.cloneNode(true));
domModule.appendToBuffer('#main', 'div');
