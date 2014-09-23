$(function () {

    /*  Search Icons Function  */
    if ($('input#member-finder').length) {
        $('input#member-finder').val('').quicksearch('.member-entry');
    }
    if ($('input#member-finderI').length) {
        $('input#member-finderI').val('').quicksearch('.memberadd');
    }
});