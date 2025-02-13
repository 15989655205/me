﻿<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Stage.aspx.cs" Inherits="Maticsoft.Web.Project.Template.Stage" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../../Controls/Toolbar.ascx" %>
<%@ Register TagPrefix="group_IDE" TagName="Group_IDE" Src="../../Controls/Project/Template/Group_IDE.ascx" %>
<%@ Register TagPrefix="imp_IDE" TagName="Imp_IDE" Src="../../Controls/Project/Template/Imp_IDE.ascx" %>
<%@ Register TagPrefix="flow_IDE" TagName="Flow_IDE" Src="../../Controls/Project/Template/Flow_IDE.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    var editIndex = undefined;
    var isEdit = true;
    var status_comb = [{ "sid": "0", "name": "不可用" }, { "sid": "1", "name": "可用"}];
    var stageType_comb = eval('(<%=stageType %>)');

    $(function () {
        InitGrid();
    });

    function InitGrid() {
        $('#tt').datagrid({
            fit: true,
            rownumbers: true, //行号
            nowrap: true, //是否换行，True 就会把数据显示在一行里
            singleSelect: true, //单选
            collapsible: false, //可折叠
            remoteSort: false, //定义是否从服务器给数据排序
            fitColumns: true, //列自适应
            url: '../../Ashx/ProjectStage.ashx', //请求数据的页面
            queryParams: { "action": "template_list" },
            idField: 'sid', //标识字段,主键

            columns: [[
                    { title: '系统编号', field: 'sid', width: 60, sortable: true, halign: 'center', align: 'center', editor: "text", hidden: true
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },

                    { title: '阶段', field: 'stage_name', width: 100, sortable: true, halign: 'center', editor: "text"
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '阶段类型', field: 'is_system', width: 100, sortable: true, halign: 'center', editor: { type: 'combobox', options: { data: stageType_comb, valueField: 'value', editable: false, textField: 'text', panelHeight: "auto", required: true, missingMessage: "必填"} }
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            for (var i = 0; i < stageType_comb.length; i++) {
                                var text = stageType_comb[i].text;
                                if (stageType_comb[i].value == value) return text;
                            }
                            //return '<a class="a_black" title="' + value + '"><span class="mlength">' + rowData.stageType + '</span></a>';
                        }
                    },
                    { title: '状态', field: 'status', width: 50, sortable: true, halign: 'center', align: 'center', editor: { type: 'combobox', options: { valueField: 'sid', textField: 'name', data: status_comb, panelHeight: "auto"} },
                        formatter: function (value, row, index) {
                            for (var i = 0; i < status_comb.length; i++) {
                                var text = status_comb[i].name;
                                if (status_comb[i].sid == value) return text;
                            }
                            return '';
                            //return row.node_type_name;
                        }
                        //                        formatter: function (value, rowData, rowIndex) {
                        //                            if (value == 1) {
                        //                                return "可用";
                        //                            } else {
                        //                                return "不可用";
                        //                            }
                        //                            //return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        //                        }
                    },

                    { title: '小组', field: 'group', width: 50, sortable: true, halign: 'center', align: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            return '<a style="color:red" href="javascript:;" onclick="Group(\'' + rowIndex + '\');"><img src="../../images/user_group.gif" /></a>';
                        }
                    },
                    { title: '工作种类', field: 'worktype', width: 50, sortable: true, halign: 'center', align: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            return '<a style="color:red" href="javascript:;" onclick="Implement(\'' + rowIndex + '\');"><img src="../../images/comm.gif" /></a>';
                        }
                    },
                    { title: '工作流程', field: 'workflow', width: 50, sortable: true, halign: 'center', align: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            if (rowData.is_system == 1) {
                                return '<a style="color:red" href="javascript:;" onclick="Flow(\'' + rowIndex + '\');"><img src="../../images/TreeImages/source.gif" /></a>';
                            } else {
                                return "";
                            }
                        }
                    },
                    { title: '工作内容模版', field: 'work', width: 80, sortable: true, halign: 'center', align: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            if (rowData.is_system != 3 && rowData.is_system != 4) {
                                return '<a style="color:red" href="javascript:;" onclick="Content(\'' + rowData.sid + '\',\'' + rowData.stage_name + '\',' + rowData.is_system + ');"><img src="../../images/edit.gif" /></a>';
                            }
                            else {
                                return "";
                            }
                            //if (rowData.is_system == 1) {
                            //                            switch (rowData.is_system) {
                            //                                case 1:
                            //                                    return '<a style="color:red" href="javascript:;" onclick="Content(\'' + rowData.sid + '\',\'' + rowData.stage_name + '\',1);"><img src="../../images/edit.gif" /></a>';
                            //                                    break;
                            //                                case 0:
                            //                                    return '<a style="color:red" href="javascript:;" onclick="Content(\'' + rowData.sid + '\',\'' + rowData.stage_name + '\',0);"><img src="../../images/edit.gif" /></a>';
                            //                                    break;
                            //                                case 2:
                            //                                    return '<a style="color:red" href="javascript:;" onclick="Content(\'' + rowData.sid + '\',\'' + rowData.stage_name + '\',0);"><img src="../../images/edit.gif" /></a>';
                            //                                    break;
                            //                            }
                        }
                    },
                    { title: '备注', field: 'remark', width: 200, sortable: true, halign: 'center', editor: "text"
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '经办人', field: 'createP', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return value;
                        }
                    },
                    { title: '创建时间', field: 'create_date', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            if (value != undefined) {
                                return value.Format("yyyy-MM-dd hh:mm");
                            }
                            else {
                                return "";
                            }
                        }
                    },
                    { title: '变更人', field: 'updateP', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return value;
                        }
                    },
                    { title: '变更时间', field: 'update_date', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            if (value != undefined) {
                                return value.Format("yyyy-MM-dd hh:mm");
                            }
                            else {
                                return "";
                            }
                        }
                    }
                    ]],
            toolbar: "#tab_toolbar",
            onLoadSuccess: function (data) {
                //btnCancel();
            },
            onClickCell: function (rowIndex, field, value) {
                //                if (field != "ckb") {
                //                    $('#sub_tt').datagrid('clearSelections');
                //                }
            },
            onClickRow: function (rowIndex, rowData) {
                if (isEdit) {
                    //group_isEdit = true;
                    //group_btnSave();
                    EditRow(rowIndex);
                }

            }
        });
    }

    function endEditing() {
        if (editIndex == undefined) { return true }
        if ($('#tt').datagrid('validateRow', editIndex)) {
//            try {
//                var ed = $('#tt').datagrid('getEditor', { index: editIndex, field: 'is_system' });
//                var productname = $(ed.target).combobox('getText');
//                $('#tt').datagrid('getRows')[editIndex]['stageType'] = productname;
//            } catch (e) {
//            }

            $('#tt').datagrid('endEdit', editIndex);
            editIndex = undefined;
            return true;
        } else {
            return false;
        }
    }

    function EditRow(index) {
        if (editIndex != index) {
            if (endEditing()) {
                $('#tt').datagrid('selectRow', index).datagrid('beginEdit', index);
                var editor = $('#tt').datagrid('getEditor', { index: 1, field: 'stage_name' });
                editIndex = index;
                var row = $('#tt').datagrid('getSelected');
                if (row != null) {
                    if (row.number == 1) {
                        $(editor.target).attr('disabled', true);
                    }
                }
            } else {
                $('#tt').datagrid('selectRow', editIndex);
            }
        }
    }

    function EditGrid(row) {
        var index = $('#tt').datagrid('getRowIndex', row);
        $('#tt').datagrid('beginEdit', index);
        var editors = $('#tt').datagrid('getEditors', index);
        editIndex = index;
    }

    function MoveRow(fx) {
        var gd = $('#tt');
        var gdData = gd.datagrid("getData");
        if (gdData.rows.length < 2) return;
        var iMovedRowIndex = -1;
        var FocusRow = gd.datagrid('getSelected');
        if (!FocusRow) {
            alert("没有行被选中,无法执行移动操作");
            return;
        }
        var iCurRowIndex = gd.datagrid('getRowIndex', FocusRow);
        isEdit = true;
        EditRow(iCurRowIndex);
        iMovedRowIndex = iCurRowIndex + fx;
        if (iCurRowIndex === 0 && fx === -1) return; //iMovedRowIndex = gdData.rows.length - 1;
        if (iCurRowIndex === gdData.rows.length - 1 && fx === 1) return; //iMovedRowIndex = 0;
        var RowTemp = { stage_name: "",status:"", remark: "", sequence: "", sid: "" ,is_system:""};
        RowTemp.stage_name = gdData.rows[iMovedRowIndex].stage_name;
        RowTemp.status = gdData.rows[iMovedRowIndex].status;
        RowTemp.remark = gdData.rows[iMovedRowIndex].remark;
        RowTemp.sequence = gdData.rows[iMovedRowIndex].sequence;
        RowTemp.sid = gdData.rows[iMovedRowIndex].sid;
        RowTemp.is_system = gdData.rows[iMovedRowIndex].is_system;

        gdData.rows[iMovedRowIndex].stage_name = gdData.rows[iCurRowIndex].stage_name;
        gdData.rows[iMovedRowIndex].status = gdData.rows[iCurRowIndex].status;
        gdData.rows[iMovedRowIndex].remark = gdData.rows[iCurRowIndex].remark;
        //gdData.rows[iMovedRowIndex].sequence = gdData.rows[iCurRowIndex].sequence;
        gdData.rows[iMovedRowIndex].sid = gdData.rows[iCurRowIndex].sid;
        gdData.rows[iMovedRowIndex].is_system = gdData.rows[iCurRowIndex].is_system;

        //gdData.rows[iMovedRowIndex].sequence = gdData.rows[iCurRowIndex].sequence;
        //gdData.rows[iCurRowIndex].sid = RowTemp.sid;

        var edt = gd.datagrid("getEditors", iCurRowIndex);
        edt[1].target.val(RowTemp.stage_name);
        edt[2].target.combobox('setValue', RowTemp.is_system);
        //edt[2].target.val(RowTemp.is_system);
        //edt[3].target.val(RowTemp.status);
        edt[3].target.combobox('setValue', RowTemp.status);
        edt[4].target.val(RowTemp.remark);
        edt[0].target.val(RowTemp.sid);
//        gd.datagrid('updateRow', {
//            index: iCurRowIndex,
//            row: {
//                sid: RowTemp.sid,
//                stage_name: RowTemp.stage_name,
//                is_system: RowTemp.is_system,
//                status: RowTemp.status,
//                RowTemp: RowTemp.RowTemp
//            }
//        });


        gd.datagrid('endEdit', iCurRowIndex);
        gd.datagrid('unselectRow', iCurRowIndex);
        gd.datagrid('selectRow', iMovedRowIndex);
        gd.datagrid('beginEdit', iMovedRowIndex);
        editIndex = iMovedRowIndex;
        gd = null;
    }

    //快速搜索
    function qsearch(v) {
        $('#tt').datagrid('options').queryParams = { "action": "template_list", "key": v };
        $('#tt').datagrid('reload');
    }

    function Group(index) {
        var rows = $('#tt').datagrid('getRows');
        var row = rows[index];
        if (row.sid == 0 || row.sid == undefined || row.sid == null || row.sid == "") {
            $.messager.show({ title: '提示', msg: "您要编辑的是新增阶段，<br/>必须要先保存才能进行小组编辑" });
        }
        else {
            if (art.dialog.get('group_dialog') != null) {
                art.dialog.get('group_dialog').close();
            }
            group_openDialog(index, "小组管理");
        }
    }

    function Implement(index) {
        var rows = $('#tt').datagrid('getRows');
        var row = rows[index];
        if (row.sid == 0 || row.sid == undefined || row.sid == null || row.sid == "") {
            $.messager.show({ title: '提示', msg: "您要编辑的是新增阶段，<br/>必须要先保存才能进行工作种类编辑" });
        }
        else {
            if (art.dialog.get('imp_dialog') != null) {
                art.dialog.get('imp_dialog').close();
            }
            imp_openDialog(index, "阶段工作种类管理");
        }
    }

    function Flow(index) {
        var rows = $('#tt').datagrid('getRows');
        var row = rows[index];
        if (row.is_system == 1) {
            if (row.sid == 0 || row.sid == undefined || row.sid == null || row.sid == "") {
                $.messager.show({ title: '提示', msg: "您要编辑的是新增阶段，<br/>必须要先保存才能进行工作种类编辑" });
            }
            else {
                if (art.dialog.get('flow_dialog') != null) {
                    art.dialog.get('flow_dialog').close();
                }
                flow_openDialog(index, "阶段工作流程管理");
            }
        } else {
            $.messager.show({ title: '提示', msg: "工作流程只适用于<施工图与方案交接>" });
        }
    }

    function Content(sid, name, flag) {
        var index= $('#tt').datagrid('getRowIndex', sid);
        if (isEdit) {
            //group_isEdit = true;
            //group_btnSave();
            EditRow(index);
        }
        if (sid == 0 || sid == undefined || sid == null || sid == "") {
            $.messager.show({ title: '提示', msg: "您要编辑的是新增阶段，<br/>必须要先保存才能进行小组编辑" });
        }
        else {
            url = "/Project/Template/Content.aspx?ps_sid=" + sid + "&isConstruction=" + flag;
            if (name.length > 4) {
                name = name.substring(0, 4) + "...";
            }
            parent.addTab_Ext("模板【" + name + "】_" + sid, url, true);
            //$('#tt').datagrid('reload');
            //qsearch("");
        }

    }

    function Construction(sid, name) {
        var rows = $('#tt').datagrid('getRows');
        var row = rows[index];
        if (row.sid == 0 || row.sid == undefined || row.sid == null || row.sid == "") {
            $.messager.show({ title: '提示', msg: "您要编辑的是新增阶段，<br/>必须要先保存才能进行小组编辑" });
        }
        else {
            url = "/Project/Template/Construction.aspx?ps_sid=" + sid;
            if (name.length > 4) {
                name = name.substring(0, 4) + "...";
            }
            parent.addTab_Ext('模板【' + name + '】', url, "", true);
        }
    }

    function btnSave() {
        $('#tab_div_06').linkbutton("enable");
        $('#tab_div_05').linkbutton("enable");
    }

    function btnCancel() {
        $('#tab_div_06').linkbutton("disable");
        $('#tab_div_05').linkbutton("disable");
    }

    function add() {
        if (!isEdit) {
            //btnSave();
            isEdit = true;
        }
        if (endEditing()) {
            $('#tt').datagrid('appendRow', { status:1,sequence: $('#tt').datagrid('getRows').length, sid: 0 }); 
            editIndex = $('#tt').datagrid('getRows').length - 1;
            $('#tt').datagrid('selectRow', editIndex).datagrid('beginEdit', editIndex);
        }
    }

    function edit() {
        if (!isEdit) {
            //btnSave();
            var row = $('#tt').datagrid('getSelected');
            if (row != null) {
                var index = $('#tt').datagrid('getRowIndex', $('#tt').datagrid('getSelected'));
                EditRow(index);
            }
            isEdit = true;
        }
    }

    function del() {
//        if (!isEdit) {
//            group_btnSave();
//        }
        //if (editIndex == undefined) { return }
        var row = $('#tt').datagrid('getSelected');
        if (!isEdit) {
            editIndex = $('#tt').datagrid('getRowIndex', row);
            isEdit = true;
        }
        if (row.sid != null && row.sid != 0) {
            $.ajax({
                type: "POST",
                async: false,
                url: '../../Ashx/ProjectStage.ashx',
                data: {
                    'action': 'stage_del_check',
                    'sid': row.sid
                },
                success: function (data) {
//                    if (data == "2") {
//                        $.messager.show({ title: '提示', msg: "此阶段是项目必须的，不能删除！" });
//                        return;
//                    }
//                    else 
                    if (data == "1") {
                        $.messager.show({ title: '提示', msg: "此阶段已添加工作内容,<br/>删除前必须把所有内容清空。" });
                        return;
                    }
                    else {
                        for (var i = (editIndex + 1); i < ($('#tt').datagrid('getRows').length); i++) {
                            $('#tt').datagrid('updateRow', {
                                index: i,
                                row: { sequence: i - 1 }
                            });
                        }

                        $('#tt').datagrid('cancelEdit', group_editIndex).datagrid('deleteRow', editIndex);
                        editIndex = undefined;
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                    return;
                }
            });
        } else {
            for (var i = (editIndex + 1); i < ($('#tt').datagrid('getRows').length); i++) {
                $('#tt').datagrid('updateRow', {
                    index: i,
                    row: { sequence: i - 1 }
                });
            }
            $('#tt').datagrid('cancelEdit', editIndex).datagrid('deleteRow', editIndex);
            editIndex = undefined;
        }
    }

    function save() {
        isEdit = true;

        if (endEditing()) {
            var rows = $('#tt').datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                if (rows[i].stage_name.length <= 0) {
                    $.messager.show({ title: '错误提示', msg: "阶段名称不能为空" });
                    EditGrid(rows[i]);
                    return false;
                }
                if (i < rows.length - 1) {
                    for (var j = i + 1; j < rows.length; j++) {
                        if (rows[i].stage_name == rows[j].stage_name) {
                            $.messager.show({ title: '错误提示', msg: "阶段名称不能重复" });
                            EditRow(j);
                            return false;
                        }
                    }
                }
            }

            var allRows = $('#tt').datagrid('getRows');
            var delstr = "";
            var updatestr = "";
            var addstr = "";
            var allstr = "";

            allstr = JSON.stringify(allRows);
            var delrows = $('#tt').datagrid('getChanges', 'deleted');
            delstr = JSON.stringify(delrows);
            var updaterows = $('#tt').datagrid('getChanges', 'updated');
            updatestr = JSON.stringify(updaterows);
            var addrows = $('#tt').datagrid('getChanges', 'inserted');
            addstr = JSON.stringify(addrows);
            $.ajax({
                type: "POST",
                timeout: 30000, //超时时间：30秒
                url: '../../Ashx/ProjectStage.ashx',
                data: {
                    'action': 'stage_edit',
                    'allstr': allstr,
                    'addstr': addstr,
                    'updatestr': updatestr,
                    'delstr': delstr
                },
                success: function (data) {
                    if (data == "success") {
                        $('#tt').datagrid("reload");
                        //btnCancel();
                        $.messager.show({ title: '提示', msg: "编辑成功！" });
                    }
                    else {
                        $.messager.show({ title: '错误提示', msg: (data=="success"?"保存成功":data) });
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                }
            });
        }
    }

    function cancel() {
        //btnCancel();
        isEdit = true;
        $('#tt').datagrid('rejectChanges');
        editIndex = undefined;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table id="tt"></table>
 <div id="toolbarDIV" style="height:0px;" >
    <toolbar:ToolBar ID="toolbar1" runat="server" ></toolbar:ToolBar>
    </div>

    <div id="group_edit" style="display:none;">
        <group_IDE:Group_IDE ID="group_ide1" runat="server"></group_IDE:Group_IDE>
    </div>

    <div id="imp_edit" style="display:none;">
        <imp_IDE:Imp_IDE ID="imp_ide1" runat="server"></imp_IDE:Imp_IDE>
    </div>

    <div id="flow_edit" style="display:none;">
        <flow_IDE:Flow_IDE ID="flow_ide1" runat="server"></flow_IDE:Flow_IDE>
    </div>

    
</asp:Content>
