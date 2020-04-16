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
                , { field: 'typename', title: '类别', }
                , { field: 'inprice', title: '进货价', }
                , { field: 'sellprice', title: '售价', }
                , { field: 'vipprice', title: '会员价', }
                , { field: 'varsion', title: '版本', }
            ]];
            break; 
        case "v_OrderformList":
            cols = [[
                {
                    field: 'orderno', title: '单号', sort: true, fixed: 'left' }
                , {
                    field: 'suppliername', title: '供应商' }
                , {
                    field: 'checktime', title: '进货时间', sort: true }
                , {
                    field: 'state', title: '订单类型', }
                , {
                    field: 'factoryname', title: '商品', }
                , { field: 'num', title: '数量', sort: true }
                , { field: 'price', title: '进货价', }
                , { field: 'sumprice', title: '合计', }
                , { field: 'total', title: '订单总额', }
            ]];
            break; 
        case "v_Inventory":
            cols = [[
                {
                    field: 'factorycode', title: '工厂码', sort: true, fixed: 'left'
                }
                , {
                    field: 'name', title: '商品名称'
                }
                , {
                    field: 'describe', title: '描述', sort: true
                }
                , {
                    field: 'suppliername', title: '供应商名称',
                }
                , {
                    field: 'typename', title: '类型',
                }
                , { field: 'num', title: '现有库存', sort: true }
                , {
                    field: 'riskinventory', title: '危险库存', }
            ]];
            break; 
        case "v_InventoryDetail":
            cols = [[
                {
                    field: 'orderno', title: '订单号', sort: true, fixed: 'left'
                }
                , {
                    field: 'factorycode', title: '工厂码'
                }
                , {
                    field: 'name', title: '商品名称', sort: true
                }
                , {
                    field: 'num', title: '数量',
                }
                , {
                    field: 'state', title: '类型',
                }
            ]];
            break; 

    }
    return cols;
}