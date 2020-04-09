function GetCols(tablename) {
    switch (tablename) {
        case "Commodity":
            cols = [[
                { field: 'factorycode', title: '工厂码', sort: true, fixed: 'left' }
                , { field: 'name', title: '名称' }
                , { field: 'describe', title: '描述', sort: true }
                , { field: 'unit', title: '单位', }
                , { field: 'supplier', title: '供应商号', }
                , { field: 'place', title: '产地', sort: true }
                , { fixed: 'right', title: '操作', align: 'center', toolbar: '#barDemo' }
            ]];
            break;
    }
    return cols;
}