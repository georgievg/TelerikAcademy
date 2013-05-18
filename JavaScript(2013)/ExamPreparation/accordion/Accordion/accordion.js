(function () {

    Accordion = function (element, name) {
        this.elements = {};
        this.name = name;
        this.mainElement = element;


        this.initializeEvents = function () {
            this.mainElement.addDelegateListener('click', 'ul', function (e) {
                e.stopPropagation();
                e.preventDefault();
                
                var siblings = this.getAllSiblings();
                for (var i = 0; i < siblings.length; i++) {
                    if (siblings[i].parentNode !== element) {
                        if (siblings[i] instanceof HTMLUListElement) {
                            siblings[i].style.display = "none";
                        }
                    }
                }

                var firstLiChilds = this.childNodes;
                var firstUlChilds;
                for (var i = 0; i < firstLiChilds.length; i++) {
                    firstUlChilds = firstLiChilds[i].childNodes;
                    for (var j = 0; j < firstUlChilds.length; j++) {
                        firstUlChilds[j].style.display = "";
                    }
                }

            });

        }
    }

    Accordion.prototype = {
        init: function () {
            //var newMainElement = document.createElement("ul");
            //this.mainElement.appendChild(newMainElement);
            this.elements[this.name] = this.mainElement;
        },
        addChild: function (toElementName, newElementName) {
            var currEl = this.elements[toElementName];
            var newUl = document.createElement("ul");
            currEl.appendChild(newUl);
            newUl.id = newElementName;
            if (newUl.parentElement !== this.mainElement) {
                newUl.style.display = 'none';
            }
            currEl = newUl;

            var newLi = document.createElement("li");
            newLi.className = "hidden";
            var newA = document.createElement("a");
            newA.href = "#";
            newA.innerHTML = newElementName;
            newLi.appendChild(newA);
            currEl.appendChild(newLi);
            this.elements[newElementName] = newLi;
            this.initializeEvents();
        }
    };

    
})();