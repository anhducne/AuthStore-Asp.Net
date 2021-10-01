$(document).ready(function () {
  var modal = $('.modal');
  var btn = $('.btn');

  btn.click(function () {
    modal.fadeIn();
    return false;
  });

  $(window).on('click', function (a) {
    if ($(a.target).is('.modal')) {
      modal.fadeOut();
    }
  });
});


$(document).ready(function () {
  var modal4 = $('.modal-4');
  var btn4 = $('.btn-4');

  btn4.click(function () {
    modal4.fadeIn();
    return false;
  });

  $(window).on('click', function (d) {
    if ($(d.target).is('.modal-4')) {
      modal4.fadeOut();
    }
  });
});