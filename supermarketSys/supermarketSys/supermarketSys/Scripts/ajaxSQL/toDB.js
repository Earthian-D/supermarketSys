//根据条件查找对应的数据，返回True，False,字符串形式
function fnFindData(table, code) {
    var table = table;
    var code = code == "" ? "1 = 1" : code;
    var sqlString = "select * from " + table + " where " + code;
    var data;
    $.ajax({
        url: "../SQLtoDB/FindData",
        type: "post",
        async:false,
        data: {
            sql: sqlString.toString()
        },
        success: function (msg) {
            data = msg;
        }
    });
    return data;
}
//根据条件查找对应的数据，返回数组对象形式
function fnGetDataArryObj(table, code) {
    var table = table;
    var code = code == "" ? "1 = 1" : code;
    var sqlString = "select * from " + table + " where " + code;
    var data;
    $.ajax({
        url: "../SQLtoDB/GetJson",
        type: "post",
        async: false,
        data: {
            sql: sqlString.toString()
        },
        success: function (msg) {
            data = msg;
        }
    });
    return data;
}