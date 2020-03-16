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
//传参执行存储过程
function fnExecProcedure(pro,code) {
    var data;
    $.ajax({
        url:"../SQLtoDB/FnExecProcedure",
        type: "post",
        async: false,
        data: {
            pro: pro,
            code:code
        },
        success: function (msg) {
            data = msg;
        }
    });
    return data;
}
//根据条件删除的数据，返回True，False,字符串形式
function fnDeleteData(table, code) {
    var table = table;
    var code = code == "" ? "1 = 1" : code;
    var sqlString = "delete from " + table + " where " + code;
    var data;
    $.ajax({
        url: "../SQLtoDB/FindData",
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
//插入数据格式如下
/*var data = {
                factorycode: "6925303730574",
                name: "统一阿萨姆奶茶",
                describe: "原味500ml",
                unit: "瓶",
                supplier: "统一集团",
                place: "广东省惠州市",
                production: "2020-01-06",
                expiration: ""
        }
 */
function fnInsertData(table, json) {
    console.log(table, json)
    var data;
    $.ajax({
        url: "../SQLtoDB/Save",
        type: "post",
        async: false,
        dataType: "json",
        data: {
            tablename: table,
            data: JSON.stringify(json)
        },
        success: function (msg) {
            data = msg
        }
    });
    return data;
}