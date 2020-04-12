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
        case "v_Commodity":
            cols = [[
                { field: 'factorycode', title: '工厂码', sort: true, fixed: 'left' }
                , { field: 'name', title: '名称' }
                , { field: 'describe', title: '描述', sort: true }
                , { field: 'unit', title: '单位', }
                , { field: 'supplier', title: '供应商', }
                , { field: 'place', title: '产地', sort: true }
                , { field: 'suppliername', title: '供应商名称', }
                , { field: 'typename', title: '供应商名称', }
                , { field: 'inprice', title: '进货价', }
                , { field: 'sellprice', title: '售价', }
                , { field: 'vipprice', title: '会员价', }
                , { field: 'varsion', title: '版本', }
            ]];
            break;

    }
    return cols;
}