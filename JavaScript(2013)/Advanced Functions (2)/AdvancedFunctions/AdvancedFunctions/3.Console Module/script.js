var advancedConsole = (function () {
    
    this.format = function (message,args) {
        for (var i = 0; i < args.length; i++) {
            message = message.replace('{' + i + '}', args[i].toString());
        }

        return message;
    }

    this.writeLine = function (write, formatArgs) {
        if (formatArgs !== undefined) {
            write = format(write, formatArgs);
        }
        console.log(write);
    };

    this.writeError = function (write,formatArgs) {
        if (formatArgs !== undefined) {
            write = format(write, formatArgs);
        }
        console.error(write);
    };

    this.writeWarning = function (write, formatArgs) {
        if (formatArgs !== undefined) {
            write = format(write, formatArgs);
        }
        console.warn(write);
    };
    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    }
})();

advancedConsole.writeLine('{0} {1}', ['pesho', 'gosho']);
advancedConsole.writeError(' sucks {0}', [document.body]);
advancedConsole.writeWarning('yay {0}', ['you']);