$(".left-content").on("mouseenter", handlerInListButtons).on("mouseleave", handlerOutListButtons);
function handlerInListButtons() {
    $(".list-buttons").show();
}
function handlerOutListButtons() {
    $(".list-buttons").hide();
}
function handleEditContent(id) {
    classId = "." + id;
    $(classId).toggle();

}
function handleEdit(id) {
    classId = "." + id;
    $(classId).toggle();

    $('.saveEdit').click(function () {
        POSTEditLeftData(id)
    }
    )
}
$(`.SizeTitleUp`).click(
    function (e) {
        e.preventDefault();

        let itemId = $(this).attr('data-id');
        let url = `/DocumentConstructorLeftDatas/ChangeSizeTitle/` + itemId + `?changeNumber=-1`;
        $.ajax({
            url: url,
            type: 'GET',
            success: function (response) {
                location.reload();
            }
        });

    }
);

$(`.SizeTitleDown`).click(
    function (e) {
        e.preventDefault();

        let itemId = $(this).attr('data-id');
        let url = `/DocumentConstructorLeftDatas/ChangeSizeTitle/` + itemId + `?changeNumber=1`;
        $.ajax({

            url: url,
            type: 'GET',
            success: function (response) {
                location.reload();
            }
        });

    }
);

$('.NppUp').click(function (e) {
    e.preventDefault();
    let itemId = $(this).attr('data-id');
    $.ajax({
        url: '/DocumentConstructorLeftDatas/ChangeNpp/' + itemId + `?changeNumber=-1`,
        type: 'GET',

        success: function (response) {

            location.reload(); // Перезагрузить страницу для обновления порядка

        }
    });
});

$('.NppDown').click(function (e) {
    e.preventDefault();
    let itemId = $(this).attr('data-id');
    $.ajax({
        url: '/DocumentConstructorLeftDatas/ChangeNpp/' + itemId + `?changeNumber=1`,
        type: 'GET',

        success: function (response) {

            location.reload(); // Перезагрузить страницу для обновления порядка

        }
    });

});
function GETLeftData() {
    $.ajax({
        url: '/DocumentConstructorLeftDatas/ChangeNpp/' + itemId,
        type: 'GET',
        success: function (response) {
            console.log('Успех');
            location.reload();
        },
        error: function (xhr, status, error) {
            console.error('Ошибка:', error);
        }

    })
}

function POSTDeleteLeftData(id) {

    if (confirm("Вы действительно хотите удалить?")) {

    }
    else {
        return false;
    }
    $.ajax({
        url: '/DocumentConstructorLeftDatas/Delete/' + id,
        type: 'Post',
        success: function (response) {
            console.log('Успех');

            let urlToRedirect = '/Home/Edit';
            window.location.href = urlToRedirect;
        },
        error: function (xhr, status, error) {
            console.error('Ошибка:', id);
        }
    });
}
function POSTCreateLeftData() {
  
    $.ajax({
        url: '/DocumentConstructorLeftDatas/Create',
        type: 'POST',
        data: {
            "Title": $("#leftContentInput").val(),
            "Npp": 1,
            "SizeTitle": 3,
        },
        success: function (response) {
            console.log('Успех');
            location.reload();
        },
        error: function (xhr, status, error) {
            console.error('Ошибка:', error);
        }

    });
}
function POSTEditLeftData(id) {

    let data = {
        "DocumentConstructorLeftDataId": id,
        "Title": $("#" + id).val(),
    };
    $.ajax({
        url: '/DocumentConstructorLeftDatas/Edit/' + id,
        type: 'Post',
        data: data,
        success: function (response) {
            console.log('Успех');
            console.log(id);
            console.log(data.Title);
            $(`.` + id).text(data.Title);
        },
        error: function (xhr, status, error) {
            console.error('Ошибка:', id);
        }

    });
}
$('.add').click(function () {
    $('.box').css("display", "block");
    $('.list-buttons').css("display", "none");
    $('#saveInput').click(
        POSTCreateLeftData
    );
});

function editContent() {

    

    //let itemId = $(this).attr("data-id");
    //data = #idinput.val();
    //$.ajax({
    //    url: '/DocumentConstructorLeftDatas/Edit/' + id,
    //    type: 'Post',
    //    data: data,
    //    success: function (response) {
    //        $(`.` + id).text(data.Title);
    //    },
    //    error: function (xhr, status, error) {
    //        console.error('Ошибка:', id);
    //    }
    //})
}

function showTextArea(id) {
    let textAreaName = `#textArea` + id;
    let saveButtonName = `#addContent` + id;
    let editContentName = "#editContent" + id;
    $(textAreaName).toggle();
    $(saveButtonName).toggle();
    $(editContentName).toggle();
}
function saveTextAreaValue(id) {
    let textAreaName = `#textArea` + id;
    let textAreaValue = $(textAreaName).val();
}
//$(`.editContent`).click(
   
//    function () {
        
//    }
//)




