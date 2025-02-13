﻿var groupview = $.extend({}, $.fn.treegrid.defaults.view, {
    render: function (target, container, frozen) {
        var state = $.data(target, 'treegrid');
        var opts = state.options;
        var rows = state.data.rows;
        var fields = $(target).treegrid('getColumnFields', frozen);
        //var color=stata.options.color;
        var table = [];
        var index = 0;
        var groups = this.groups;
        for (var i = 0; i < groups.length; i++) {
            var group = groups[i];

            //table.push('<div class="treegrid-group" group-index=' + i + ' style="height:25px;overflow:hidden;border-bottom:1px solid #ccc;">');
            table.push('<div group-index=' + i + ' style="height:30px;overflow:hidden;border-bottom:1px solid #ccc; ">');
            table.push('<table cellspacing="0" cellpadding="0" border="0" style="height:100%"><tbody>');
            table.push('<tr>');
            table.push('<td style="border:0;">');
            if (!frozen) {
                table.push('<span style="color:#416aa3;font-weight:bold;margin-left:10px;">');
                table.push(opts.groupFormatter.call(target, group.fvalue, group.rows));
                table.push('</span>');
            }
            table.push('</td>');
            table.push('</tr>');
            table.push('</tbody></table>');
            table.push('</div>');

            table.push('<table class="treegrid-btable" cellspacing="0" cellpadding="0" border="0"><tbody>');
            for (var j = 0; j < group.rows.length; j++) {
                // get the class and style attributes for this row
                var cls = (index % 2 && opts.striped) ? 'class="treegrid-row treegrid-row-alt"' : 'class="treegrid-row"';
                var styleValue = opts.rowStyler ? opts.rowStyler.call(target, index, group.rows[j]) : '';
                var style = styleValue ? 'style="' + styleValue + '"' : '';
                var rowId = state.rowIdPrefix + '-' + (frozen ? 1 : 2) + '-' + index;
                table.push('<tr id="' + rowId + '" treegrid-row-index="' + index + '" ' + cls + ' ' + style + '>');
                table.push(this.renderRow.call(this, target, fields, frozen, index, group.rows[j]));
                table.push('</tr>');
                index++;
            }
            table.push('</tbody></table>');
        }

        $(container).html(table.join(''));
    },

    onAfterRender: function (target) {
        var opts = $.data(target, 'treegrid').options;
        var dc = $.data(target, 'treegrid').dc;
        var view = dc.view;
        var view1 = dc.view1;
        var view2 = dc.view2;

        $.fn.treegrid.defaults.view.onAfterRender.call(this, target);

        if (opts.rownumbers || opts.frozenColumns.length) {
            var group = view1.find('div.treegrid-group');
        } else {
            var group = view2.find('div.treegrid-group');
        }
        $('<td style="border:0"><div class="treegrid-row-expander treegrid-row-collapse" style="width:25px;height:16px;cursor:pointer"></div></td>').insertBefore(group.find('td'));

        view.find('div.treegrid-group').each(function () {
            var groupIndex = $(this).attr('group-index');
            $(this).find('div.treegrid-row-expander').bind('click', { groupIndex: groupIndex }, function (e) {
                if ($(this).hasClass('treegrid-row-collapse')) {
                    $(target).treegrid('collapseGroup', e.data.groupIndex);
                } else {
                    $(target).treegrid('expandGroup', e.data.groupIndex);
                }
            });
        });
    },

    onBeforeRender: function (target, rows) {
        var opts = $.data(target, 'treegrid').options;
        var groups = [];
        for (var i = 0; i < rows.length; i++) {
            var row = rows[i];
            var group = getGroup(row[opts.groupField]);
            if (!group) {
                group = {
                    fvalue: row[opts.groupField],
                    rows: [row],
                    startRow: i
                };
                groups.push(group);
            } else {
                group.rows.push(row);
            }
        }

        function getGroup(fvalue) {
            for (var i = 0; i < groups.length; i++) {
                var group = groups[i];
                if (group.fvalue == fvalue) {
                    return group;
                }
            }
            return null;
        }

        this.groups = groups;

        var newRows = [];
        for (var i = 0; i < groups.length; i++) {
            var group = groups[i];
            for (var j = 0; j < group.rows.length; j++) {
                newRows.push(group.rows[j]);
            }
        }
        $.data(target, 'treegrid').data.rows = newRows;
    }
});


//var groupview = $.extend({}, $.fn.treegrid.defaults.view, {
//    render: function (target, container, frozen) {
//        var state = $.data(target, 'treegrid');
//        var opts = state.options;
//        var rows = state.data.rows;
//        var fields = $(target).treegrid('getColumnFields', frozen);

//        var table = [];
//        var index = 0;
//        var groups = this.groups;
//        for (var i = 0; i < groups.length; i++) {
//            var group = groups[i];

//            table.push('<div class="treegrid-group" group-index=' + i + ' style="height:25px;overflow:hidden;border-bottom:1px solid #ccc;">');
//            table.push('<table cellspacing="0" cellpadding="0" border="0" style="height:100%"><tbody>');
//            table.push('<tr>');
//            table.push('<td style="border:0;">');
//            if (!frozen) {
//                table.push('<span style="color:#666;font-weight:bold;">');
//                table.push(opts.groupFormatter.call(target, group.fvalue, group.rows));
//                table.push('</span>');
//            }
//            table.push('</td>');
//            table.push('</tr>');
//            table.push('</tbody></table>');
//            table.push('</div>');

//            table.push('<table class="treegrid-btable" cellspacing="0" cellpadding="0" border="0"><tbody>');
//            for (var j = 0; j < group.rows.length; j++) {
//                // get the class and style attributes for this row
//                var cls = (index % 2 && opts.striped) ? 'class="treegrid-row treegrid-row-alt"' : 'class="treegrid-row"';
//                var styleValue = opts.rowStyler ? opts.rowStyler.call(target, index, group.rows[j]) : '';
//                var style = styleValue ? 'style="' + styleValue + '"' : '';
//                var rowId = state.rowIdPrefix + '-' + (frozen ? 1 : 2) + '-' + index;
//                table.push('<tr id="' + rowId + '" treegrid-row-index="' + index + '" ' + cls + ' ' + style + '>');
//                table.push(this.renderRow.call(this, target, fields, frozen, index, group.rows[j]));
//                table.push('</tr>');
//                index++;
//            }
//            table.push('</tbody></table>');
//        }

//        $(container).html(table.join(''));
//    },

//    onAfterRender: function (target) {
//        var opts = $.data(target, 'treegrid').options;
//        var dc = $.data(target, 'treegrid').dc;
//        var view = dc.view;
//        var view1 = dc.view1;
//        var view2 = dc.view2;

//        $.fn.treegrid.defaults.view.onAfterRender.call(this, target);

//        if (opts.rownumbers || opts.frozenColumns.length) {
//            var group = view1.find('div.treegrid-group');
//        } else {
//            var group = view2.find('div.treegrid-group');
//        }
//        $('<td style="border:0"><div class="treegrid-row-expander treegrid-row-collapse" style="width:25px;height:16px;cursor:pointer"></div></td>').insertBefore(group.find('td'));

//        view.find('div.treegrid-group').each(function () {
//            var groupIndex = $(this).attr('group-index');
//            $(this).find('div.treegrid-row-expander').bind('click', { groupIndex: groupIndex }, function (e) {
//                if ($(this).hasClass('treegrid-row-collapse')) {
//                    $(target).treegrid('collapseGroup', e.data.groupIndex);
//                } else {
//                    $(target).treegrid('expandGroup', e.data.groupIndex);
//                }
//            });
//        });
//    },

//    onBeforeRender: function (target, rows) {
//        var opts = $.data(target, 'treegrid').options;
//        var groups = [];
//        for (var i = 0; i < rows.length; i++) {
//            var row = rows[i];
//            var group = getGroup(row[opts.groupField]);
//            if (!group) {
//                group = {
//                    fvalue: row[opts.groupField],
//                    rows: [row],
//                    startRow: i
//                };
//                groups.push(group);
//            } else {
//                group.rows.push(row);
//            }
//        }

//        function getGroup(fvalue) {
//            for (var i = 0; i < groups.length; i++) {
//                var group = groups[i];
//                if (group.fvalue == fvalue) {
//                    return group;
//                }
//            }
//            return null;
//        }

//        this.groups = groups;

//        var newRows = [];
//        for (var i = 0; i < groups.length; i++) {
//            var group = groups[i];
//            for (var j = 0; j < group.rows.length; j++) {
//                newRows.push(group.rows[j]);
//            }
//        }
//        $.data(target, 'treegrid').data.rows = newRows;
//    }
//});

//$.extend($.fn.treegrid.methods, {
//    expandGroup: function (jq, groupIndex) {
//        return jq.each(function () {
//            var view = $.data(this, 'treegrid').dc.view;
//            if (groupIndex != undefined) {
//                var group = view.find('div.treegrid-group[group-index="' + groupIndex + '"]');
//            } else {
//                var group = view.find('div.treegrid-group');
//            }
//            var expander = group.find('div.treegrid-row-expander');
//            if (expander.hasClass('treegrid-row-expand')) {
//                expander.removeClass('treegrid-row-expand').addClass('treegrid-row-collapse');
//                group.next('table').show();
//            }
//            $(this).treegrid('fixRowHeight');
//        });
//    },
//    collapseGroup: function (jq, groupIndex) {
//        return jq.each(function () {
//            var view = $.data(this, 'treegrid').dc.view;
//            if (groupIndex != undefined) {
//                var group = view.find('div.treegrid-group[group-index="' + groupIndex + '"]');
//            } else {
//                var group = view.find('div.treegrid-group');
//            }
//            var expander = group.find('div.treegrid-row-expander');
//            if (expander.hasClass('treegrid-row-collapse')) {
//                expander.removeClass('treegrid-row-collapse').addClass('treegrid-row-expand');
//                group.next('table').hide();
//            }
//            $(this).treegrid('fixRowHeight');
//        });
//    }
//});

