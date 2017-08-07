﻿var selectedProject = 0;
$(function () {
    $("#btnAdd").click(function () { add(); });
    $("#btnDelete").click(function () { deleteMulti(); });
    $("#btnSave").click(function () { save(); });
    $("#btnSavePermission").click(function () { savePermission(); });
    $("#checkAll").click(function () { checkAll(this) });
    loadTables(1, 10);
});

//加载列表数据
function loadTables(startPage, pageSize) {
    $("#tableBody").html("");
    $("#checkAll").prop("checked", false);
    $.ajax({
        type: "GET",
        url: "/Project/GetAllPageList?startPage=" + startPage + "&pageSize=" + pageSize + "&_t=" + new Date().getTime(),
        success: function (data) {
            $.each(data.rows, function (i, item) {
                var tr = "<tr>";
                tr += "<td align='center'><input type='checkbox' class='checkboxs' value='" + item.id + "'/></td>";
                tr += "<td>" + (item.code == null ? "" : item.code) + "</td>";
                tr += "<td>" + item.name + "</td>";
                tr += "<td>" + (item.developmentOrganization == null ? "" : item.developmentOrganization) + "</td>";
                tr += "<td>" + (item.agentOrganization == null ? "" : item.agentOrganization) + "</td>";
                tr += "<td>" + (item.bidType == null ? "" : item.bidType) + "</td>";
                tr += "<td>" + (item.bidTime == null ? "" : item.bidTime) + "</td>";
                tr += "<td>" + (item.remarks == null ? "" : item.remarks) + "</td>";
                tr += "<td><button class='btn btn-info btn-xs' href='javascript:;' onclick='edit(\"" + item.id + "\")'><i class='fa fa-edit'></i> 编辑 </button> <button class='btn btn-danger btn-xs' href='javascript:;' onclick='deleteSingle(\"" + item.id + "\")'><i class='fa fa-trash-o'></i> 删除 </button> </td>"
                tr += "</tr>";
                $("#tableBody").append(tr);
            })
            var elment = $("#grid_paging_part"); //分页插件的容器id
            if (data.rowCount > 0) {
                var options = { //分页插件配置项
                    bootstrapMajorVersion: 3,
                    currentPage: startPage, //当前页
                    numberOfPages: data.rowsCount, //总数
                    totalPages: data.pageCount, //总页数
                    onPageChanged: function (event, oldPage, newPage) { //页面切换事件
                        loadTables(newPage, pageSize);
                    }
                }
                elment.bootstrapPaginator(options); //分页插件初始化
            }
            $("table > tbody > tr").click(function () {
                $("table > tbody > tr").removeAttr("style")
                $(this).attr("style", "background-color:#beebff");
                selectedProject = $(this).find("input").val();
            });
        }
    })
}
//全选
function checkAll(obj) {
    $(".checkboxs").each(function () {
        if (obj.checked == true) {
            $(this).prop("checked", true)

        }
        if (obj.checked == false) {
            $(this).prop("checked", false)
        }
    });
};
//新增
function add() {
    $("#projectForm")[0].reset();
    $("#title").text("新增角色");
    //弹出新增窗体
    $("#editModal").modal("show");
};
//编辑
function edit(id) {
    $.ajax({
        type: "Get",
        url: "/Project/Get?id=" + id + "&_t=" + new Date().getTime(),
        success: function (data) {
            $("#code").val(data.code);
            $("#id").val(data.id);
            $("#name").val(data.name);
            $("#developmentOrganization").val(data.developmentOrganization);
            $("#agentOrganization").val(data.agentOrganization);
            $("#bidType").val(data.bidType);
            $("#bidTime").val(data.bidTime);
            $("#bidSecurityFees").val(data.bidSecurityFees);
            $("#bidSecurityReceiveAccount").val(data.bidSecurityReceiveAccount);
            $("#agentFees").val(data.agentFees);
            $("#refund").val(data.refund);
            $("#bidSecurityReturnTime").val(data.bidSecurityReturnTime);
            $("#unionOrganization").val(data.unionOrganization);
            $("#constructionSubcontractor").val(data.constructionSubcontractor);
            $("#bidPrice").val(data.bidPrice);
            $("#competitor").val(data.competitor);
            $("#remark").val(data.remark);
            $("#title").text("编辑投标项目")
            $("#editModal").modal("show");
        }
    })
};
//保存
function save() {
    var postData = {
        "dto": {
            "Id": $("#id").val(),
            "Name": $("#name").val(),
            "Code": $("#code").val(),
            "DevelopmentOrganization": $("#developmentOrganization").val(),
            "AgentOrganization": $("#agentOrganization").val(),
            "BidType": $("#bidType").val(),
            "BidTime": $("#bidTime").val(),
            "BidSecurityFees": $("#bidSecurityFees").val(),
            "BidSecurityReceiveAccount": $("#bidSecurityReceiveAccount").val(),
            "AgentFees": $("#agentFees").val(),
            "Refund": $("#refund").val(),
            "BidSecurityReturnTime": $("#bidSecurityReturnTime").val(),
            "UnionOrganization": $("#unionOrganization").val(),
            "ConstructionSubcontractor": $("#constructionSubcontractor").val(),
            "BidPrice": $("#bidPrice").val(),
            "Remark": $("#remark").val(),

        }
    };
    $.ajax({
        type: "Post",
        url: "/Project/Edit",
        data: postData,
        success: function (data) {
            if (data.result == "Success") {
                loadTables(1, 10)
                $("#editModal").modal("hide");
            } else {
                layer.tips(data.message, "#btnSave");
            };
        }
    });
};
//批量删除
function deleteMulti() {
    var ids = "";
    $(".checkboxs").each(function () {
        if ($(this).prop("checked") == true) {
            ids += $(this).val() + ","
        }
    });
    ids = ids.substring(0, ids.length - 1);
    if (ids.length == 0) {
        layer.alert("请选择要删除的记录。");
        return;
    };
    //询问框
    layer.confirm("您确认删除选定的记录吗？", {
        btn: ["确定", "取消"]
    }, function () {
        var sendData = { "ids": ids };
        $.ajax({
            type: "Post",
            url: "/Project/DeleteMuti",
            data: sendData,
            success: function (data) {
                if (data.result == "Success") {
                    loadTables(1, 10)
                    layer.closeAll();
                }
                else {
                    layer.alert("删除失败！");
                }
            }
        });
    });
};
//删除单条数据
function deleteSingle(id) {
    layer.confirm("您确认删除选定的记录吗？", {
        btn: ["确定", "取消"]
    }, function () {
        $.ajax({
            type: "POST",
            url: "/Project/Delete",
            data: { "id": id },
            success: function (data) {
                if (data.result == "Success") {
                    loadTables(1, 10)
                    layer.closeAll();
                }
                else {
                    layer.alert("删除失败！");
                }
            }
        })
    });
};

