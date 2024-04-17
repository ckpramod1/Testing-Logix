$.widget('customeSlide.SlideLeftMenu', {
    options: {
        ClassNames: ".left-handle,.left-content",
        Speed: 800
    },
    _create: function () {
        $(this.element).find('ol').slideUp(1);
        this._bindEvent(this);
    },
    _bindEvent: function (w) {
        var p = $(this.element),
            c = this.options.ClassNames;
        p.delegate(c, 'click', function () {
            s = $(this).siblings(':last'),
            o = $(this.parentElement).siblings().children('ol:visible');
            o.stop(true, true).slideUp(w.options.Speed);
            s.stop(true, true).slideToggle(w.options.Speed);
        });
    }
});