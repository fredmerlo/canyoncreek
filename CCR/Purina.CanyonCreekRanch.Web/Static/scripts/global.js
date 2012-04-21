/************************************************************************
 * Site: Canyon Creek Ranch
 * Author: Mesh
*************************************************************************/
$(document).ready(function() { /*$('.scroll').click(function(){
		jQuery.scrollTo('.ingredient_dictionary', 800, {offset:-170});
			return false;
	});*/
	$('.faqs h2').click(function() {
		$(this).toggleClass('toggle').next('p').slideToggle(300);
	});
	/*$('ul#dogs').css('display', 'none');
	$('#nav ul li.dogs').mouseenter(function() {
		$('ul#dogs').slideDown('slow');
		$(this).css('display', 'block');
	});
	$('ul#cats').mouseleave(function() {
		$('ul#cats').slideUp('fast');
		$(this).css('display', 'block');
	});

	
	$('ul#cats').css('display', 'none');
	$('#nav ul li.cats').mouseenter(function() {
		$('ul#cats').slideDown('slow');
		$(this).css('display', 'block');
	});
	$('ul#cats').mouseleave(function() {
		$('ul#cats').slideUp('fast');
		$(this).css('display', 'block');
	});

	$('ul#snacks').css('display', 'none');
	$('#nav ul li.snacks').mouseenter(function() {
		$('ul#snacks').slideDown('slow');
		$(this).css('display', 'block');
	});
	$('ul#snacks').mouseleave(function() {
		$('ul#snacks').slideUp('fast');
		$(this).css('display', 'block');
	});

	$('ul#health').css('display', 'none');
	$('#nav ul li.health').mouseenter(function() {
		$('ul#health').slideDown('slow');
		$(this).css('display', 'block');
	});
	$('ul#health').mouseleave(function() {
		$('ul#health').slideUp('fast');
		$(this).css('display', 'block');
	});

	$('ul#story').css('display', 'none');
	$('#nav ul li.story').mouseenter(function() {
		$('ul#story').slideDown('slow');
		$(this).css('display', 'block');
	});
	$('ul#story').mouseleave(function() {
		$('ul#story').slideUp('fast');
		$(this).css('display', 'block');
	});*/
	
	$('.slide').hover(function() {
		$(this).animate({
			'height': '620px'
		}, 'slow'); //$("#our_story_nav").show();
	}, function() {
		$(this).animate({
			'height': '520px'
		}, 'slow'); //$("#our_story_nav").hide();
	});
	clearTextField($(".blur"));
});

function clearTextField(field) {
	field.focus(function() {
		$(this).addClass('active');
		if (this.value == this.defaultValue) {
			this.value = '';
		}
	});
	field.blur(function() {
		$(this).removeClass('active');
		if (this.value == '') {
			this.value = this.defaultValue;
		}
	});
}
$(function() {
	$("ul.tabs").tabs("> .pane");
	$("ul#ingredients").tabs("div.list > div");
	$(".scrollable").scrollable({
		circular: true
	});
	$(".featured").scrollable({
		circular: true,
		items: '#our_story_slider, #home_slider'
	}).navigator();
});



$(document).ready(function() { 
        $('#nav ul').superfish({ 
            delay:       800,   
            animation:   {opacity:'show',height:'show'}, 
            speed:       'slow',                        
            autoArrows:  false,      
            dropShadows: false                          
        }); 
    }); 