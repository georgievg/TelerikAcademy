
function autoTreeView() {
    var hidden = document.getElementsByClassName('treeView');
    for (var i = 0; i < hidden.length; i++) {
        var lists = hidden[i].getElementsByTagName('a');

        for (var i = 0, j = lists.length; i < j; i++) {
            lists[i].addEventListener('click', expandList, false)
        };
        function expandList() {
            var ul = this.parentNode.getElementsByTagName('ul')[0];
            ul.style.display = "block";
            this.addEventListener('click', shrinkList, false);
        }
        function shrinkList() {
            var uls = this.parentNode.getElementsByTagName('ul');
            for (var i = 0; i < uls.length; i++) {
                uls[i].style.display = 'none';
            };
            this.removeEventListener('click', shrinkList);

        }
    }
};


function controls() {
    
    var TreeView = function (el) {
        this.el = el;
    }

    var AddNode = function (el) {
        this.el = el;
    }

    AddNode.prototype.content = function (content,link) {
        for (var i = 0; i < this.el.length; i++) {
            var lis = this.el[i].getElementsByTagName('li');
            for (var li = 0; li < lis.length; li++) {
                lis[li].innerHTML = "<a href=" + link + ">" + content + "</a>";
            }
        }
    }

    TreeView.prototype.addNode = function () {
        var items = [];
        for (var i = 0; i < this.el.length; i++) {
            var tree = this.el[i].getElementsByTagName('ul')[0];
            tree.innerHTML += '<li></li>';
            items.push(tree);
        }
        
        return new AddNode(items);
    }

    function treeView(selector) {

        var el = document.querySelectorAll(selector);

        for (var i = 0; i < el.length; i++) {
            el[i].innerHTML = '<ul class="treeView"></ul>';
        }
        autoTreeView();
        return new TreeView(el);
    }

    return {
        treeView: treeView
    }
}
  

var cont = new controls();
var treeView = cont.treeView('#container');
var node = treeView.addNode();
var node = treeView.addNode();
var node = treeView.addNode();
var node = treeView.addNode();
var node = treeView.addNode();
var node = treeView.addNode();

node.content('hahaah', 'http://google.bg');