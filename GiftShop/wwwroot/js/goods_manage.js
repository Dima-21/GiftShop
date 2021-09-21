
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

    $('#picture-list').empty()

    // заполняем объект данных файлами в подходящем для отправки формате
    $.each(files, function (key, value) {
        data.append(key, value);
    });

    $.each(files, function (key, value) {
        var reader = new FileReader();

        reader.onload = function (e) {
            var newElems = $('<div class="image-block">')
                .append('<img class="goods-img m-1" src="' + e.target.result + '" width=100px  data-imgname="' + value.name + '">');
            //.append('<button class="btn-del-img btn btn-light rounded-circle">X</button>');

            //newElems.mouseenter(function (elem) {
            //    $(this).children(".goods-img").css({ 'opacity': '0.5' });
            //    $(this).children(".btn").css("visibility", "visible");
            //});


            //newElems.mouseleave(function (elem) {
            //    $(this).children(".goods-img").css({ 'opacity': '1' });
            //    $(this).children(".btn").css("visibility", "hidden");
            //});

            newElems.last().click(function (e) {
                deletePicture($(this));
                e.preventDefault();
            });

            $('#picture-list').append(newElems);

            //$('#blah').attr('src', e.target.result);
        }

        reader.readAsDataURL(value);
    });

    //updateCharacteristic($(this).val());
});


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
        error: function(err) {
            alert("Не удалось обновить запись. Код ошибки: " + err.status);
            elem.checked = !checked;
        }
    });

}

$(".check-isHidden").change(function () {
    var elem = $(this).closest("td");
    var id = elem.prev(".goods-id");
    checkIsHidden(id[0].textContent, this.checked, this);
});