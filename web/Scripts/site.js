var $window, $scrollnavbar, $response, $responsetitle, $responsebody, $wait, $waitbody;

$(function () {
    $window = $(window).bind('scroll', function () { SwitchNavigation(); });
    $scrollnavbar = $("#scrollnavbar");

    $response = $("#response");
    $responsetitle = $(".modal-header > .modal-title", $response);
    $responsebody = $(".modal-body", $response);
    $wait = $("#wait");
    $waitbody = $(".modal-body", $wait);

    SwitchNavigation();
});

function SwitchNavigation() {
    if ($window.scrollTop() > 166) {
        $scrollnavbar.addClass('visible');
    } else {
        $scrollnavbar.removeClass('visible');
    }
}

function ShowWaitModal(body) {
    $waitbody.empty().html(body);
    $wait.modal({ backdrop: 'static' });
}

function ShowResponseModal(title, body) {
    $responsetitle.empty().html(title);
    $responsebody.empty().html(body);
    $response.modal({ backdrop: 'static' });
}

function GetResponse(json)
{
    var ajaxContent = json.AjaxContent;

    if (json.Modal) {
        var modal = json.Modal;
        ShowResponseModal(modal.Title, modal.Message);

        if (json.RedirectUrl) {
            $response.on('hidden', function () { window.location.href = json.RedirectUrl; });
        } else if (ajaxContent) {
            $response.on('hidden', function () { $(ajaxContent.ContainerID).empty().html(ajaxContent.Html); });
        }
    } else if (json.RedirectUrl) {
        window.location.href = json.RedirectUrl;
    } else if (json.AjaxContent) {
        $(ajaxContent.ContainerID).empty().html(ajaxContent.Html);
        $wait.modal('hide');
        $response.modal('hide');
    }
}