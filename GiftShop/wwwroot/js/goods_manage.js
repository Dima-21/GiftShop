$("#Goods_Group_Id").change(function () {
    updateCharacteristic($(this).val());
});



//$(".btn-del-img").click(function (e) {
//    deletePicture($(this));
//    e.preventDefault();
//});

//$(".image-block").mouseenter(function (elem) {
//    $(this).children(".goods-img").css({ 'opacity': '0.5' });
//    $(this).children(".btn").css("visibility", "visible");

//})

//$(".image-block").mouseleave(function (elem) {
//    $(this).children(".goods-img").css({ 'opacity': '1' });
//    $(this).children(".btn").css("visibility", "hidden");
//})


var files; // переменная. будет содержать данные файлов


//function deletePicture(elem) {
//    var img_name = elem.children("img");
//    var img_name1 = elem.children("img").attr("data-imgname");
//    //TODO: Не работает, доделать!!!
//    var img_input1 = $('#images')[0].files;

//    $.each(img_input1, function (key, value) {
//        if (value.name == img_name1) {
//            files.remove(key);

//        };
//    });

//    elem.remove();

//}


$("#images").change(function () {

    files = this.files;
    // создадим объект данных формы
    var data = new FormData();

    loadPicture(files, data, '#picture-list');
});


$("#groupimage").change(function () {
    files = this.files;
    // создадим объект данных формы
    var data = new FormData();

    loadPicture(files, data, '#group-image-preview');
});

$("#groupicon").change(function () {
    files = this.files;
    // создадим объект данных формы
    var data = new FormData();

    loadPicture(files, data, '#group-icon-preview');
});

$("#btn-add-property").click(function () {
    var propertyName = $(this).parent('#add-property-block').siblings('#input-property-name').val();
    var groupId = $("#groupId").val();

    if (propertyName != null && propertyName != "") {
        $.ajax({
            url: 'AddPropertyToGroup',
            type: 'POST',
            data: {
                groupId: groupId,
                propName: propertyName
            },
            success: function (result) {
                $("#property-partial").empty();
                $("#property-partial").append(result);
            },
            error: function (err) {
                alert("Не удалось добавить свойство. Код ошибки: " + err.status);
            }
        });
    }
});

$(document).on("click", ".btn-delete-property", function () {
    var propertyId = $(this).attr("data-propid");
    var groupId = $("#groupId").val();

    $.ajax({
        url: 'DeletePropertyGroup',
        type: 'POST',
        data: {
            groupId: groupId,
            propId: propertyId
        },
        success: function (result) {
            $("#property-partial").empty();
            $("#property-partial").append(result).parent(".btn-delete-property").click(deleteProperty());
        },
        error: function (err) {
            alert("Не удалось удалить свойство. Код ошибки: " + err.status);
        }
    });
});



$(document).on("change", ".check-isFilter", function () {
    var propertyId = $(this).attr("data-propid");
    var isChecked = this.checked;

    console.log($(this));
    console.log(propertyId);
    console.log(isChecked);

    checkPropertyIsFilter(propertyId, isChecked, $(this));
});

function checkPropertyIsFilter(id, checked, elem) {

    $.ajax({
        url: 'CheckPropertyIsFilter',
        type: 'POST',
        data: {
            propId: id,
            isCheck: checked
        },
        success: function (result) {
        },
        error: function (err) {
            alert("Не удалось обновить запись. Код ошибки: " + err.status);
            elem.checked = !checked;
        }
    });

}

// 
function loadPicture(files, data, elemId) {

    $(elemId).empty()

    // заполняем объект данных файлами в подходящем для отправки формате
    $.each(files, function (key, value) {
        data.append(key, value);
    });

    $.each(files, function (key, value) {
        var reader = new FileReader();

        reader.onload = function (e) {
            var checkImageFormat = checkImage(value, e.target, 500, 500);

            if (checkImageFormat == false) {
                return;
            }


            var newElems = $('<div class="image-block">')
                .append('<img class="goods-img m-1" src="' + e.target.result + '"  data-imgname="' + value.name + '">');

            newElems.last().click(function (e) {
                deletePicture($(this));
                e.preventDefault();
            });

            $(elemId).append(newElems);

        }

        reader.readAsDataURL(value);
    });

}

function checkImage(image, target, checkWidth, checkHeight) {
    // Проверка на формат
    var type = image.type.split('/').pop().toLowerCase();
    if (type != "jpeg" && type != "jpg" && type != "png") {
        alert('Формат файла не поддерживается. Доступные форматы: jpeg, jpg, png');
        return false;
    }

    // Проверка на размер файла
    var filesize = image.size;
    if (filesize > 5242880) {
        alert('Размер файла не должен превышать 5 Мб');
        return false;
    }

    // Проверка на разрешение картинки
    img = new Image();
    img.onload = function () {
        var imageWidth = this.width;
        var imageHeight = this.height;
        console.log(imageHeight + " " + imageWidth);
        if (imageWidth < checkWidth || imageHeight < checkHeight) {
            alert('Минимальное разрешение для картинки 500х500');
            return false;
        }
    };
    img.src = target.result;

    //console.log("filename: " + image.name);
    //console.log(image);

    //var i = new Image();
    ////reader.readAsDataURL(target.result);
    //i.src = target.result;
    //console.log("the width of the image is : " + imageWidth);
    //console.log("the height of the image is : " + imageHeight);

    return true;
}


function updateCharacteristic(groupId) {
    $.ajax({
        url: 'LoadCharacteristic',
        type: 'POST',
        data: { groupId: groupId },
        success: function (result) {
            $("#charact-data").empty();
            $("#charact-data").append(result);
        },
        error: function (err) {
            alert("Не удалось загрузить характеристику для выбранной группы товаров. Код ошибки: " + err.status);
        }
    });

}


// Изменение поля "IsHidden" в товаре
function checkIsHidden(id, checked, elem) {

    $.ajax({
        url: 'Goods/CheckIsHidden',
        type: 'POST',
        data: {
            goodsId: id,
            isChecked: checked
        },
        success: function (result) {

        },
        error: function (err) {
            alert("Не удалось обновить запись. Код ошибки: " + err.status);
            elem.checked = !checked;
        }
    });

}

// Изменение поля "IsHidden" в товаре
$(document).on("change", ".check-isHidden", function () {
    var elem = $(this).closest("td");
    var id = elem.prev(".goods-id");
    checkIsHidden(id[0].textContent, this.checked, this);
});

//$(".check-isHidden").change(function () {
//    var elem = $(this).closest("td");
//    var id = elem.prev(".goods-id");
//    checkIsHidden(id[0].textContent, this.checked, this);
//});


$('#saveCharact').click(function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var property = button.data('whatever') // Extract info from data-* attributes
    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    var modal = $(this)
    modal.find('.modal-title').text(property)
    console.log("click");
})