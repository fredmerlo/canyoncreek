/************************************************************************
 * Site: Canyon Creek Ranch
 * Author: Mesh
*************************************************************************/

$(document).ready(function(){
	$('.faqs h2').click(function(){
		$(this).toggleClass('toggle').next('p').slideToggle(300);
	});
	clearTextField( $(".blur") );
	});
function clearTextField( field ){
	field.focus( function(){
		$(this).addClass('active');
		if ( this.value == this.defaultValue ){
			this.value = '';
		}
	});
	field.blur( function(){
		$(this).removeClass('active');
		if( this.value == '' ){
			this.value = this.defaultValue;
		}
	});
}
$(function() {
		$("ul.tabs").tabs("> .pane");
		$(".scrollable").scrollable({ circular: true });
		$(".scrollable_products").scrollable({ circular: true });
		$(".scrollable_snacks").scrollable({ circular: true });
	});