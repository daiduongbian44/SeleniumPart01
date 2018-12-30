'use strict';

const testFolder = 'C:/Users/ManhNguyen/Documents/SeleniumPart01/';
const fs = require('fs');

function pad(width, string, padding) {
    return (width <= string.length) ? string : pad(width, padding + string, padding)
}

function isDirectory(path) {
    try {
        var stat = fs.lstatSync(path);
        return stat.isDirectory();
    } catch (e) {
        return false;
    }
}

function readInfoFolder(folderName, levelNumber) {
    fs.readdirSync(folderName).forEach(file => {
        if (levelNumber !== 0) {
            console.log(pad(levelNumber, "+", "+") + " " + file);
        } else {
            console.log(file);
        }
        var pathOfFile = `${folderName}\\${file}`;
        if (isDirectory(pathOfFile)) {
            readInfoFolder(pathOfFile, levelNumber + 1);
        }
    });
}

readInfoFolder(testFolder, 0);