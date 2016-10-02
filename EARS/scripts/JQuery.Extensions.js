jQuery.fn.el = function() {
	return this.get(0);
}
jQuery.fn.alignTo = function(el, anchor) {
	var pos = el.offset();
	var width = el.outerWidth();
	//show the menu directly over the placeholder
	if (!anchor) // Align source's top left to the top right of the target by default.
		this.css({ "left": (pos.left + width) + "px", "top": pos.top + "px" });
	if (anchor == 'tr-br') // Align the source's top right to the bottom right of the target.
		this.css({ "left": (pos.left - this.outerWidth(true) + width) + "px", "top": (pos.top + el.outerHeight()) + "px" });
	if (anchor == 'tl-bl') // Align the source's top left to the bottom left of the target.
		this.css({ "left": (pos.left) + "px", "top": (pos.top + el.outerHeight()) + "px" });
	if (anchor == 't-t') // Align the middle of source's top to the middle top of the target.
		this.css({ "left": (pos.left - (this.outerWidth(true) / 2) + (width / 2)) + "px", "top": pos.top + "px" });
	if (anchor == 'b-t') // Align the middle of source's bottom to the middle top of the target.
		this.css({ "left": (pos.left - (this.outerWidth(true) / 2) + (width / 2)) + "px", "top": (pos.top + el.outerHeight()) + "px" });
	return this;
}
jQuery.fn.moveTo = function(pos) {
	this.css({ "left": pos.left + "px", "top": pos.top + "px" });
	return this;
}