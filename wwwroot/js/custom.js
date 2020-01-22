$(function () {
    //$('#datepicker').datetimepicker({ format: 'DD/MM/YYYY' });
    $('#datepicker').datepicker({
        uiLibrary: 'bootstrap4',
        disableDates: function (date) {
            const currentDate = new Date();
            return date > currentDate ? false : true;
        }
    });
    $("#dialog-1").dialog({
        autoOpen: false,
        width: 400,
        height: 150,
        buttons: {
            "OK": function () { $(this).dialog("close"); },
            "Cancel": function () { $(this).dialog("close"); }
        }
    });
    
    var separator = '-';
    $('.class-name').on('keypress', function (e) {
        var key = e.charCode || e.keyCode || 0;
        var phone = $(this);
        if (phone.val().length === 0) {
            phone.val(phone.val() + '(');
        }
            if (key !== 8 && key !== 9) {
                if (phone.val().length === 4) {
                    phone.val(phone.val() + ')');
                }
                if (phone.val().length === 5) {
                    phone.val(phone.val() + ' ');
                }
                if (phone.val().length === 9) {
                    phone.val(phone.val() + '-');
                }
                if (phone.val().length >= 14) {
                    phone.val(phone.val().slice(0, 13));
                }
            }
        // Auto-format- do not expose the mask as the user begins to type
        

        // Allow numeric (and tab, backspace, delete) keys only
        return (key == 8 ||
            key == 9 ||
            key == 46 ||
            (key >= 48 && key <= 57) ||
            (key >= 96 && key <= 105));
    })

        .on('focus', function () {
            phone = $(this);

            if (phone.val().length === 0) {
                phone.val('(');
            } else {
                var val = phone.val();
                phone.val('').val(val); // Ensure cursor remains at the end
            }
        })

        .on('blur', function () {
            $phone = $(this);

            if ($phone.val() === '(') {
                $phone.val('');
            }
        });

    $(".ui-datepicker-trigger").css('cursor', 'pointer');


    $('.class-name').keypress(function (e) {
        var txt = String.fromCharCode(e.which);
        console.log(txt + ' : ' + e.which);
        if (txt.match(/[A-Za-z+#.]/)) {
            return false;
        }
    });
    $('#configreset').click(function () {
        $('#configform')[0].reset();
    });
    $(document).ready(function () {
        $('#myTable').DataTable();
    });
});