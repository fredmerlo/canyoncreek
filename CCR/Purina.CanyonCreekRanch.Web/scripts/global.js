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
	$('.slide').hover(function() {
		$(this).stop(true, true).animate({
			'height': '620px'
		}, 'slow'); //$("#our_story_nav").show();
	}, function() {
		$(this).stop(true, true).animate({
			'height': '530px'
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
	$("ul.tabs, ul.tabs_snack").tabs("> .pane");
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
            delay:       0,   
            animation:   {opacity:'show',height:'show'}, 
            speed:       'slow',                        
            autoArrows:  false,      
            dropShadows: false                         
        }); 
        $('.enlargable').click(function() {
          var markup = "";
          var path = $(this).attr('src').split('/')
          path.pop();
          path.push('product-lg.png');
          //console.log(path.join('/'));
          markup += '<div id="overlay">';
          markup += '<div id="lightbox">';
          markup += '<img class="close" src="/img/shared/close.png" />';
          markup += '<img class="product_lg" src="' + path.join('/')  + '" />';
          markup += '</div></div>';
          $('body').append(markup);
        });

        $('#overlay').live('click', function() {
          //console.log('clicked');
          $('#overlay').remove();
        })
}); 


