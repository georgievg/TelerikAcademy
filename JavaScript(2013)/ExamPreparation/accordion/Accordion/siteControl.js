(function () {

    var SiteControl = (function () {
        var accordions = {};

        function createAccordion(selector, name) {
            var el = document.querySelector(selector);
            accordions[name] = new Accordion(el,name);
            accordions[name].init();
        }

        function useAccordion(accordionName) {
            return accordions[accordionName];
        }

        return {
            createAccordion: createAccordion,
            useAccordion: useAccordion
        }
    })();

    SiteControl.createAccordion("#accordion", "mainAccordion");
    var currAccordion = SiteControl.useAccordion("mainAccordion");
    currAccordion.addChild("mainAccordion", "Web");
    currAccordion.addChild("Web", "CSS");
    currAccordion.addChild("CSS", "Part 1");
    currAccordion.addChild("mainAccordion", "Desktop");
    currAccordion.addChild("Desktop", "C#");
    currAccordion.addChild("Desktop", "C");
    currAccordion.addChild("Desktop", "Java");
    currAccordion.addChild("C#", "OOP");
    currAccordion.addChild("C#", "HQK");

})();