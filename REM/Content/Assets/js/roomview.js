//Global Values
var globalValues = new Array;


$('document').ready(function () {
    
    getRecords();
    createTable();

});

//
function getRecords() {

    globalValues = result;
}

function createTable() {
    //Latch onto Headings or table element.
    //1.) Create left heading.
    //2.) if(col1 === col2 === col3 === col4 === col5){ write out the full 5 column width bar.}
    //2.) if(col1 === col2 === col3 === col4){ Do 4, then 5th.}
    //2.) if(col1 === col2 === col3){ Do 3, then 4th then 5th.}
    //2.) if(col1 === col2){ Do 1,2, then 3, then 4, then 5}
    //2.) if(col2 === col3){ Do 1 then 2,3 then 4, then 5}

}
