

	$(document).ready(function() {
		
		"use strict";
		
		PageLoad(); 
		SliceTitles();			
		ScrollEffects();		 
		Sliders();
		FirstLoad(); 
		PageLoadActions(); 
		FitThumbScreenGSAP();
		FloatingLists();	
		ShowcaseSlider(); 
		ShowcaseCarousel(); 
		ShowcaseWebglCore(); 
		FitThumbScreenWEBGL();
		Portfolio(); 	
		Shortcodes();
		Core();
		JustifiedGrid();
		Lightbox();
		ContactForm();	
		PlayVideo();
		ContactMap();
	});

/*--------------------------------------------------
Function Page Load
---------------------------------------------------*/

	function PageLoad() {
		
		gsap.set($(".menu-timeline .before-span"), {y: 120, opacity:0});
		
		// Page Navigation Events
		$(".preloader-wrap").on('mouseenter', function() {	
			var $this = $(this);			
			gsap.to('#ball', {duration: 0.3, borderWidth: '2px', scale: 1.2, borderColor:$("body").data('primary-color'), backgroundColor:$("body").data('primary-color')});
			gsap.to('#ball-loader', {duration: 0.2, borderWidth: '2px', top: 2, left: 2});
			$( "#ball" ).append( '<p class="first">' + $this.data("firstline") + '</p>' + '<p>' + $this.data("secondline") + '</p>' );				
		});
							
		$(".preloader-wrap").on('mouseleave', function() {					
			gsap.to('#ball', {duration: 0.2, borderWidth: '4px', scale:0.5, borderColor:'#999999', backgroundColor:'transparent'});
			gsap.to('#ball-loader', {duration: 0.2, borderWidth: '4px', top: 0, left: 0});
			$('#ball p').remove();				
		});		
		
		$('body').removeClass('hidden').removeClass('hidden-ball');
		
		gsap.to($("#header-container"), {duration: 0.5, opacity:1, delay:0.2, ease:Power2.easeOut}); 
		
		
		function initOnFirstLoad() {
		
			$('body').waitForImages({
				finished: function() {
					gsap.to('#ball', {duration: 0.2, borderWidth: '4px', scale:0.5, borderColor:'#999999', backgroundColor:'transparent'});
					gsap.to('#ball-loader', {duration: 0.2, borderWidth: '4px', top: 0, left: 0});
					$('#ball p').remove();
					gsap.to($(" .trackbar, .percentage-intro, .percentage"), {duration: 0.3, force3D:true, opacity:0, y:-10, delay:0, ease:Power2.easeIn});						
					gsap.to($(".preloader-wrap"), {duration: 1, yPercent: -101, delay:0.6, ease:Power2.easeInOut});
					gsap.set($(".preloader-wrap"), {visibility:'hidden', delay:1.7, opacity:0});					
					setTimeout(function(){
						$('body').waitForImages({
							finished: function() {
								gsap.to($(".header-middle, #footer-container, .showcase-counter, .swiper-pagination-bullet-active .counter"), {duration: 1, opacity:1, delay:0, ease:Power2.easeOut}); 										
							},
							waitForAll: true
						});
						
						if( $('.hero-video-wrapper').length > 0 ){
							$('#hero-image-wrapper').find('video').each(function() {
								$(this).get(0).play();
							}); 
						}
						
						gsap.to($("#main"), {duration: 0, opacity:1, delay:0, ease:Power2.easeOut});//modified time
						if( $('#hero').hasClass("has-image")) {	
							if ($('body').hasClass('hero-below-caption')) {
								var heroTranslate = $('.hero-translate').height();
								gsap.set($("#hero-image-wrapper"), {y:heroTranslate});
							}
							gsap.to($("#hero-bg-image"), {duration: 1, force3D:true, scale:1 , opacity:1, delay:0.2, ease:Power2.easeOut});							
							gsap.to($(".hero-title span"), {duration: 1, force3D:true, y: 0, opacity:1, rotation:0, delay:0.6, ease:Power2.easeOut});
							gsap.to($(".hero-subtitle span"), {duration: 1, force3D:true, y:0, opacity:1, rotation:0, delay:0.8, ease:Power2.easeOut});
							gsap.to($(".hero-footer-left"), {duration: 1, force3D:true, y: 0, opacity:1, rotation:0, delay:1.1, ease:Power2.easeOut});
							gsap.to($(".hero-footer-right"), {duration: 1, force3D:true, y:0, opacity:1, rotation:0, delay:1.2, ease:Power2.easeOut});																				
							gsap.to($("#main-page-content"), {duration: 0.4, opacity:1, delay:1.15, ease:Power2.easeOut});
						} else {
							// Fading In Small Carousel elements on Finised
							var tlHerospan = gsap.timeline();
							tlHerospan.set($("#hero .hero-title span"), {y: 120, opacity:0});
							$("#hero .hero-title span").each(function(index, element) {
								tlHerospan.to(element, {duration: 0.7, y:0, opacity:1, delay:0.7, ease:Power3.easeOut}, index * 0.03)
							});
							gsap.to($(".hero-subtitle span"), {duration: 0.4, force3D:true, y: 0, opacity:1, rotation:0, delay:0.5, ease:Power2.easeOut});
							gsap.to($(".hero-footer-left"), {duration: 0.7, force3D:true, y: 0, opacity:1, rotation:0, delay:1, ease:Power2.easeOut});
							gsap.to($(".hero-footer-right"), {duration: 0.7, force3D:true, y:0, opacity:1, rotation:0, delay:1.1, ease:Power2.easeOut});									
							gsap.to($("#main-page-content"), {duration: 0.7, opacity:1, delay:1.1, ease:Power2.easeOut});
							gsap.to($(".error-button"), {duration: 0.4, y: 0, opacity:1, rotation:0, delay:1, ease:Power2.easeOut});				
						}	
						
						
						// Fading In Showcase Slider elements on Finised
						gsap.set($("#showcase-slider-holder"), {opacity:0});															
						gsap.to($("#showcase-slider-holder"), {duration: 0.7, opacity:1, delay:0.6, ease:Power2.easeOut});
						
						gsap.to($("#showcase-slider-holder .swiper-slide .slide-title span"), {duration: 1, force3D:true, y: 0, opacity:1, delay:0.8, ease:Power2.easeOut});
						gsap.to($("#showcase-slider-holder .swiper-slide .subtitle span"), {duration: 0.7, force3D:true, y: 0, opacity:1, delay:1.2, ease:Power2.easeOut});
						gsap.to($(".showcase-pagination"), {duration: 1, opacity:1, delay:0.7, ease:Power2.easeOut});
						gsap.to($(".swiper-pagination-bullet .title div"), {duration: 1, y: 0, opacity:1, delay:0.6, ease:Power2.easeOut});
						gsap.to($(".swiper-pagination-bullet-active .subtitle span"), {duration: 0.7, y: 0, opacity:1, delay:1, ease:Power2.easeOut});
						gsap.to($("#fixed-borders"), {duration: 0.3, opacity:1, delay:1, ease:Power2.easeOut});
						
						// Fading In Showcase Carousel elements on Finised
						gsap.set($("#showcase-carousel-holder"), {opacity:0});															
						gsap.to($("#showcase-carousel-holder"), {duration: 0.7, opacity:1, delay:0.6, ease:Power2.easeOut});
						gsap.set($("#showcase-carousel-holder .swiper-slide-active").prev(), {y:-200, scale:0.8, opacity:0});
						gsap.set($("#showcase-carousel-holder .swiper-slide-active").next(), {y:200, scale:0.8, opacity:0});								
						gsap.to($("#showcase-carousel-holder .swiper-slide-active").prev(), {duration: 1.7, y:0, scale:1, delay:0, opacity:1, ease:Power3.easeInOut});
						gsap.to($("#showcase-carousel-holder .swiper-slide-active").next(), {duration: 1.7, y:0, scale:1, delay:0, opacity:1, ease:Power3.easeInOut});								
						gsap.to($("#showcase-carousel-holder .swiper-slide-active .slide-title span"), {duration: 0.7, force3D:true, y: 0, opacity:1, delay:0.7, ease:Power2.easeOut});
						gsap.to($("#showcase-carousel-holder .swiper-slide-active .subtitle span"), {duration: 0.7, force3D:true, y: 0, opacity:1, delay:0.7, ease:Power2.easeOut});
						gsap.to($("#showcase-carousel-holder .swiper-slide-active .slide-date span"), {duration: 0.7, force3D:true, y: 0, opacity:1, delay:0.6, ease:Power2.easeOut});
						
						
						gsap.set($(".swiper-prev, .swiper-next, .swiper-pagination-bullet"), {opacity:0});	
						gsap.to($(".swiper-prev"), {duration: 0.7, force3D:true, y: 0, opacity:1, rotation:0, delay:1.2, ease:Power2.easeOut});
						gsap.to($(".swiper-pagination-bullet"), {duration: 0.7, force3D:true, y:0, opacity:1, rotation:0, delay:1, ease:Power2.easeOut});
						gsap.to($(".swiper-next"), {duration: 0.7, force3D:true, y: 0, opacity:1, rotation:0, delay:1.2, ease:Power2.easeOut});
						setTimeout( function(){	
							$('#showcase-slider-holder, #showcase-carousel-holder, .showcase-list-holder').addClass("loaded");
						} , 1500 );
						var tlSmallTitles = gsap.timeline();					
						$(".slide-small-title span").each(function(index, element) {
							tlSmallTitles.to(element, {duration: 0.5, force3D:true, y:0, opacity:1, delay:1, ease:Power2.easeOut}, index * 0.05)
						});
						
						gsap.to($(".showcase-list-header"), {duration: 0.5, opacity:0.6, delay:0.2, ease:Power2.easeOut});
						
						var SlideListTitle = gsap.timeline();					
						$(".sl-title span").each(function(index, element) {
							SlideListTitle.to(element, {duration: 0.7, force3D:true, y:0, opacity:1, delay:0.5, ease:Power2.easeOut}, index * 0.05)
						});
						
						var SlideListSubtitle = gsap.timeline();					
						$(".sl-subtitle span").each(function(index, element) {
							SlideListSubtitle.to(element, {duration: 0.7, force3D:true, y:0, opacity:1, delay:0.6, ease:Power2.easeOut}, index * 0.05)
						});
						
						var SlideListDate = gsap.timeline();					
						$(".sl-date span").each(function(index, element) {
							SlideListDate.to(element, {duration: 0.7, force3D:true, y:0, opacity:1, delay:0.7, ease:Power2.easeOut}, index * 0.05)
						});
							
						setTimeout( function(){
							$('.slide-list').addClass('show-borders')
						} ,300 );
							
						setTimeout( function(){	
							$('body').removeClass("load-project-page").removeClass("load-project-page-carousel");
						} , 600 );
						
						setTimeout( function(){	
							$('body').removeClass("load-next-project");
							$('body').addClass("header-visible");
							$('#showcase-holder').removeClass("disabled");
						} , 1600 );
						
						setTimeout( function(){	
							$('body').removeClass("show-loader")
						} , 800 );	
						
					} , 600 );
				},
			waitForAll: true
		});
				
		}
		
		
		if (!$('body').hasClass("disable-ajaxload")) {
			
			var width = 100,
				perfData = window.performance.timing, 
				EstimatedTime = -(perfData.loadEventEnd - perfData.navigationStart),
				time = ((EstimatedTime/100)%500) * 10
				
			// Loadbar Animation
			$(".loadbar").animate({
				width: width + "%"
			}, time  );	
			
			// Percentage Increment Animation
			var PercentageID = $("#precent"),
					start = 0,
					end = 100,
					durataion = time + 0;
					animateValue(PercentageID, start, end, durataion);
					
			function animateValue(id, start, end, duration) {
			  
				var range = end - start,
				  current = start,
				  increment = end > start? 1 : -1,
				  stepTime = Math.abs(Math.floor(duration / range)),
				  obj = $(id);
				
				var timer = setInterval(function() {
					current += increment;
					$(obj).text(current);
				  //obj.innerHTML = current;
					if (current == end) {
						clearInterval(timer);
					}
				}, stepTime);
			}
			
			// Fading Out Loadbar on Finised
			setTimeout(function(){
				$('.loadbar').append('<span class="hold-progress-bar"></span>');
				
				gsap.to($('.hold-progress-bar'), {duration: 0.3, force3D:true,width:'100%', delay:0, ease:Power2.easeOut, onComplete:function(){ 
					initOnFirstLoad();				
				}});
		  
			}, time);
		
		} else {
			
			initOnFirstLoad();
		}
		
		
	}// End Page Load
	
	
/*--------------------------------------------------
Function Slice Titles
---------------------------------------------------*/

	function SliceTitles() {	
		
		$('#main .has-image .hero-title, #main #project-nav .next-hero-title, #main #project-nav .next-temp-hero-title').each(function(){
			var words = $(this).text().split(" ");
			var total = words.length;
			$(this).empty();
			for (index = 0; index < total; index ++){
				$(this).append($("<div /> ").text(words[index]));
			}
		});
		
		$('#main .has-image .hero-title div, #main #project-nav .next-hero-title div, #main #project-nav .next-temp-hero-title div').each(function(){
			var words = $(this).text().slice(" ");
			var total = words.length;
			$(this).empty();
			for (index = 0; index < total; index ++){
				$(this).append($("<span /> ").text(words[index]));
			}
		});
		
	}// End Slice Titles	

	
	
/*--------------------------------------------------
Page Load Actions
---------------------------------------------------*/	
	
	function PageLoadActions() {
		
		
		// Default Page Navigation Load Events
		$(".next-ajax-link-page").on('mouseenter', function() {	
			var $this = $(this);			
			gsap.to('#ball', {duration: 0.3, borderWidth: '2px', scale: 1.2, borderColor:$("body").data('primary-color'), backgroundColor:$("body").data('primary-color')});
			gsap.to('#ball-loader', {duration: 0.2, borderWidth: '2px', top: 2, left: 2});
			$( "#ball" ).append( '<p class="first">' + $this.data("firstline") + '</p>' + '<p>' + $this.data("secondline") + '</p>' );				
		});
							
		$(".next-ajax-link-page").on('mouseleave', function() {					
			gsap.to('#ball', {duration: 0.2, borderWidth: '4px', scale:0.5, borderColor:'#999999', backgroundColor:'transparent'});
			gsap.to('#ball-loader', {duration: 0.2, borderWidth: '4px', top: 0, left: 0});
			$('#ball p').remove();				
		});				
		
		if (!$("body").hasClass("load-no-ajax")) {
			$('.next-ajax-link-page').on('click', function() {					
				$("body").addClass("load-next-page");
				$("body").addClass("show-loader");
				$('header').removeClass('white-header');
				$("#app").remove();
				$(".big-title-caption").remove();	
					
				gsap.to('#ball', {duration: 0.2, borderWidth: '4px', scale:0.5, borderColor:'#999999', backgroundColor:'transparent'});
				gsap.to('#ball-loader', {duration: 0.2, borderWidth: '4px', top: 0, left: 0});
				$("#ball").removeClass("with-icon");
				$('#ball p').remove();
				$('#ball i').remove();
				
				if ($("body").hasClass("smooth-scroll")) {
					var navmove = $("#content-scroll").height() - $("#page-nav").height() - $("footer").height() 			
				} else {
					var navmove = window.innerHeight - $("#page-nav").height() - $("footer").height()	   
				}
				
				gsap.to($("#main-page-content, #hero"), {duration: 0.3, opacity:0});		
				gsap.to($("#page-nav"), {duration: 0.7, y: - navmove, delay:0, ease:Power2.easeInOut});
				gsap.to($("footer"), {duration: 0.3, opacity:0, delay:0, ease:Power2.easeInOut});
			});
		}
		
		
		// Project Page Navigation Load Events
		var TempNextTitle = gsap.timeline({paused:true});
		var NextTitle = gsap.timeline({paused:true});
		
		TempNextTitle.to($(".next-caption").find('.next-temp-hero-title span'), {duration: 0.5, y:-10, rotationX: 78, transformOrigin:"50% 10% 0px", opacity:0, stagger: 0.02, ease:Power2.easeInOut})
		NextTitle.to($(".next-caption").find('.next-hero-title span'), {duration: 0.5, y:0, rotationX: 0, transformOrigin:"50% 10% 0px", opacity:1, stagger: 0.02, ease:Power2.easeInOut})
		
		$("#project-nav .next-ajax-link-project").mouseenter(function(e) {	
			var $this = $(this);		
			$( "#ball" ).append( '<p class="first">' + $this.data("firstline") + '</p>' + '<p>' + $this.data("secondline") + '</p>' );
			gsap.to('#ball', {duration: 0.3, borderWidth: '2px', scale: 1.2, borderColor:$this.data('color'), backgroundColor:$this.data('color')});			
			gsap.to('#ball-loader', {duration: 0.2, borderWidth: '2px', top: 2, left: 2});
			$("#project-nav .next-hero-title").addClass('hover-title');
			TempNextTitle.play();
			NextTitle.play();			
		});
						
		$("#project-nav .next-ajax-link-project").mouseleave(function(e) {
			gsap.to('#ball', {duration: 0.2, borderWidth: '4px', scale:0.5, borderColor:'#999999', backgroundColor:'transparent'});
			gsap.to('#ball-loader', {duration: 0.2, borderWidth: '4px', top: 0, left: 0});
			$('#ball p').remove();
			$("#project-nav .next-hero-title").removeClass('hover-title');
			
			NextTitle.reverse();
			TempNextTitle.reverse();
			
		});	
		
		if (!$("body").hasClass("load-no-ajax")) {
			$('.next-ajax-link-project').on('click', function() {	
				
				gsap.set($(".next-caption").find('.next-temp-hero-title span'), {y:10, rotationX: -78, transformOrigin:"50% 90% 0px", opacity:0});
				gsap.set($(".next-caption").find('.next-hero-title span'), {y:0, rotationX: 0, transformOrigin:"50% 10% 0px", opacity:1});
				
				$("body").addClass("load-project-thumb-with-title").addClass("show-loader");
				$('header').removeClass('white-header');
				$("#app").remove();
				$('.next-project-image-wrapper').addClass("temporary").appendTo('body');
				if ($(this).parents('#project-nav').hasClass("change-header")) {
					$("body").append('<div class="temporary-hero"><div class="outer content-max-width"><div class="inner"></div></div></div>');
				} else {
					$("body").append('<div class="temporary-hero light-content"><div class="outer content-max-width"><div class="inner"></div></div></div>');
				}
				$('.next-caption').appendTo('.temporary-hero .inner');	
					
				gsap.to('#ball', {duration: 0.2, borderWidth: '4px', scale:0.5, borderColor:'#999999', backgroundColor:'transparent'});
				gsap.to('#ball-loader', {duration: 0.2, borderWidth: '4px', top: 0, left: 0});
				$("#ball").removeClass("with-icon");
				$('#ball p').remove();
				$('#ball i').remove();
				
				gsap.to($("#main-page-content"), {duration: 0.3, opacity:0});			
				gsap.to($(".next-project-image"), {duration: 0.6, scale:1, opacity: 1, ease:Power2.easeOut,onComplete: function() {
				  $('.next-project-image').addClass("visible")
				}});
				gsap.to($("footer"), {duration: 0.3, opacity:0, ease:Power2.easeInOut});				
			});
		}
		
	}// Page Load Actions
	
	

	
/*--------------------------------------------------
Function Lazy Load
---------------------------------------------------*/

	function LazyLoad() {	
		
		$('#page-content').removeClass('light-content-slider');
		
		gsap.set($("#show-filters, #counter-wrap"), {opacity:0, delay:0});
		
		$('body').waitForImages({
			finished: function() {
				$('body').removeClass('loading')
				setTimeout( function(){	
					$('body').removeClass('hidden').removeClass('scale-up').removeClass('scale-none');
				} , 1500 );
			},
			waitForAll: true
		});	
		
		$('body').waitForImages({
			finished: function() {
				gsap.to($("#header-container, .header-middle"), {duration: 1, force3D:true, opacity:1, ease:Power2.easeOut});				
			},
			waitForAll: true
		});
		
		if( !$('#canvas-slider').hasClass("active")) {	
			gsap.set($('#canvas-slider'), {opacity:0, scale:1.1});
			gsap.to($('#canvas-slider'), {duration: 1, force3D:true, opacity:1, scale:1, delay:0.3, ease:Power2.easeOut});
		}
		
		gsap.to($("#main"), {duration: 0.3, opacity:1, delay:0.1, ease:Power2.easeOut});
		gsap.to($("#footer-container"), {duration: 1, force3D:true, opacity:1, delay:0.4, ease:Power2.easeOut});		
		
		if( $('#hero').hasClass("has-image")) {	
			if( $('body').hasClass("load-project-thumb-with-title")) {
				if ($('body').hasClass('hero-below-caption')) {
					var heroTranslate = $('.hero-translate').height();
					gsap.set($("#hero-image-wrapper"), {y:heroTranslate});					
				}
				gsap.to($("#hero-bg-image"), {duration: 0, force3D:true, scale:1 , opacity:1, delay:0, ease:Power2.easeOut});				
				gsap.to($(".hero-title span"), {duration: 0, force3D:true, y: 0, opacity:1, delay:0, ease:Power2.easeOut});
				gsap.to($(".hero-subtitle span"), {duration: 0, force3D:true, y:0, opacity:1, delay:0, ease:Power2.easeOut});
				gsap.to($(".hero-footer-left"), {duration: 0.7, force3D:true, y: 0, opacity:1, rotation:0, delay:0.9, ease:Power2.easeOut});
				gsap.to($(".hero-footer-right"), {duration: 0.7, force3D:true, y:0, opacity:1, rotation:0, delay:1, ease:Power2.easeOut});		
			} else if( $('body').hasClass("load-project-thumb-with-title-and-scale")) {
				gsap.to($("#hero-bg-image"), {duration: 0, force3D:true, scale:1.02, opacity:1, delay:0, ease:Power2.easeOut});				
				gsap.to($(".hero-title span"), {duration: 0, force3D:true, y: 0, opacity:1, delay:0, ease:Power2.easeOut});
				gsap.to($(".hero-subtitle span"), {duration: 0, force3D:true, y:0, opacity:1, delay:0, ease:Power2.easeOut});
				gsap.to($(".hero-footer-left"), {duration: 0.7, force3D:true, y: 0, opacity:1, rotation:0, delay:0.9, ease:Power2.easeOut});
				gsap.to($(".hero-footer-right"), {duration: 0.7, force3D:true, y:0, opacity:1, rotation:0, delay:1, ease:Power2.easeOut});		
			} else if( $('body').hasClass("load-project-thumb")) {
				if ($('body').hasClass('hero-below-caption')) {
					var heroTranslate = $('.hero-translate').height();
					gsap.set($("#hero-image-wrapper"), {y:heroTranslate});
					gsap.to($(".hero-title span"), {duration: 0.7, force3D:true, y: 0, opacity:1, rotation:0, delay:0.6, ease:Power2.easeOut});
					gsap.to($(".hero-subtitle span"), {duration: 0.7, force3D:true, y:0, opacity:1, rotation:0, delay:0.9, ease:Power2.easeOut});
				} else {
					gsap.to($(".hero-title span"), {duration: 0.7, force3D:true, y: 0, opacity:1, rotation:0, delay:0.6, ease:Power2.easeOut});
					gsap.to($(".hero-subtitle span"), {duration: 0.7, force3D:true, y:0, opacity:1, rotation:0, delay:0.9, ease:Power2.easeOut});	
				}
				gsap.to($("#hero-bg-image"), {duration: 0, force3D:true, scale:1.02 , opacity:1, delay:0, ease:Power2.easeOut});						
				
				gsap.to($(".hero-footer-left"), {duration: 0.7, force3D:true, y: 0, opacity:1, rotation:0, delay:1.1, ease:Power2.easeOut});
				gsap.to($(".hero-footer-right"), {duration: 0.7, force3D:true, y:0, opacity:1, rotation:0, delay:1.2, ease:Power2.easeOut});			
			} else {
				gsap.to($("#hero-bg-image"), {duration: 0, force3D:true, scale:1 , opacity:1, delay:0, ease:Power2.easeOut});
				gsap.to($(".hero-title span"), {duration: 0.7, force3D:true, y: 0, opacity:1, rotation:0, delay:0.6, ease:Power2.easeOut});
				gsap.to($(".hero-subtitle span"), {duration: 0.7, force3D:true, y:0, opacity:1, rotation:0, delay:0.9, ease:Power2.easeOut});
				gsap.to($(".hero-footer-left"), {duration: 0.7, force3D:true, y: 0, opacity:1, rotation:0, delay:1.1, ease:Power2.easeOut});
				gsap.to($(".hero-footer-right"), {duration: 0.7, force3D:true, y:0, opacity:1, rotation:0, delay:1.2, ease:Power2.easeOut});	
			}
			gsap.to($("#main-page-content"), {duration: 0.4, opacity:1, delay:0.95, ease:Power2.easeOut});
		} else {
			var tlHerospan = gsap.timeline();
			tlHerospan.set($("#hero .hero-title span"), {y: 60, opacity:0});
			$("#hero .hero-title span").each(function(index, element) {
				tlHerospan.to(element, {duration: 0.7, y:0, opacity:1, delay:0.25, ease:Power3.easeOut}, index * 0.05)
			});
			gsap.to($(".hero-subtitle span"), {duration: 0.4, force3D:true, y: 0, opacity:1, rotation:0, delay:0.1, ease:Power2.easeOut});
			gsap.to($(".hero-footer-left"), {duration: 0.7, force3D:true, y: 0, opacity:1, rotation:0, delay:0.5, ease:Power2.easeOut});
			gsap.to($(".hero-footer-right"), {duration: 0.7, force3D:true, y:0, opacity:1, rotation:0, delay:0.6, ease:Power2.easeOut});
			gsap.to($("#main-page-content"), {duration: 0.5, opacity:1, delay:0.15, ease:Power2.easeOut});
			gsap.to($(".post-article-wrap"), {duration: 0.4, force3D:true, y: 0, opacity:1, ease:Power2.easeOut});
			gsap.to($(".error-button"), {duration: 0.4, force3D:true, y: 0, opacity:1, rotation:0, delay:0.2, ease:Power2.easeOut});
		}	
		
		// Fading In Showcase Slider on Finised
		gsap.set($("#showcase-slider-holder"), {opacity:0});
		gsap.to($("#showcase-slider-holder"), {duration: 0.3, opacity:1, delay:0, ease:Power2.easeOut});
		gsap.to($("#showcase-slider-holder .swiper-slide .slide-title span"), {duration: 1, y: 0, opacity:1, delay:0.6, ease:Power2.easeOut});
		gsap.to($("#showcase-slider-holder .swiper-slide .subtitle span"), {duration: 0.7, y: 0, opacity:1, delay:1, ease:Power2.easeOut});
		gsap.to($(".showcase-pagination"), {duration: 1, opacity:1, delay:0.7, ease:Power2.easeOut});
		gsap.to($(".swiper-pagination-bullet .title div"), {duration: 1, y: 0, opacity:1, delay:0.6, ease:Power2.easeOut});
		gsap.to($(".swiper-pagination-bullet-active .subtitle span"), {duration: 0.7, y: 0, opacity:1, delay:1, ease:Power2.easeOut});
		gsap.to($("#fixed-borders"), {duration: 0.3, opacity:1, delay:1, ease:Power2.easeOut});
		
		// Fading In Showcase Carousel on Finised
		gsap.set($("#showcase-carousel-holder"), {opacity:0});
		gsap.to($("#showcase-carousel-holder"), {duration: 0.3, opacity:1, delay:0.3, ease:Power2.easeOut});
		var slideWidth = $("#showcase-carousel-holder .swiper-slide").width();
		gsap.set($("#showcase-carousel-holder .swiper-slide-active").prev(), {y:-slideWidth, scale:0.8, opacity:0});
		gsap.set($("#showcase-carousel-holder .swiper-slide-active").next(), {y:slideWidth, scale:0.8, opacity:0});								
		gsap.to($("#showcase-carousel-holder .swiper-slide-active").prev(), {duration: 2, y:0, scale:1, delay:0.1, opacity:1, ease:Power3.easeInOut});
		gsap.to($("#showcase-carousel-holder .swiper-slide-active").next(), {duration: 2, y:0, scale:1, delay:0.1, opacity:1, ease:Power3.easeInOut});
		gsap.to($("#showcase-carousel-holder .swiper-slide .slide-title span"), {duration: 0.3, force3D:true, y: 0, opacity:1, delay:0, ease:Power2.easeOut});
		gsap.to($("#showcase-carousel-holder .swiper-slide .subtitle span"), {duration: 0.3, force3D:true, y: 0, opacity:1, delay:0, ease:Power2.easeOut});
		
		gsap.set($(".swiper-prev, .swiper-next, #showcase-border"), {opacity:0});		
		gsap.to($(".swiper-prev, .swiper-next, .swiper-pagination-bullet"), {duration: 0.7, y: 0, opacity:1, delay:1.2, ease:Power2.easeOut});
		
		var tlSmallTitles = gsap.timeline();					
		$(".slide-small-title span").each(function(index, element) {
			tlSmallTitles.to(element, {duration: 0.5, force3D:true, y:0, opacity:1, delay:1, ease:Power2.easeOut}, index * 0.05)
		});
		// Fading In Floating Lists 
		gsap.to($(".showcase-list-header"), {duration: 0.5, opacity:0.6, delay:0.6, ease:Power2.easeOut});
		
		var SlideListTitle = gsap.timeline();					
		$(".sl-title span").each(function(index, element) {
			SlideListTitle.to(element, {duration: 0.7, force3D:true, y:0, opacity:1, delay:0.5, ease:Power2.easeOut}, index * 0.05)
		});		
		var SlideListSubtitle = gsap.timeline();					
		$(".sl-subtitle span").each(function(index, element) {
			SlideListSubtitle.to(element, {duration: 0.7, force3D:true, y:0, opacity:1, delay:0.6, ease:Power2.easeOut}, index * 0.05)
		});
		var SlideListDate = gsap.timeline();					
		$(".sl-date span").each(function(index, element) {
			SlideListDate.to(element, {duration: 0.7, force3D:true, y:0, opacity:1, delay:0.7, ease:Power2.easeOut}, index * 0.05)
		});
		
		setTimeout( function(){
			$('.slide-list').addClass('show-borders')
		} ,800 );
		
		
		
		if( $('.load-project-thumb').length > 0 ){
			$('#hero-image-wrapper').waitForImages({
				finished: function() {
					setTimeout( function(){
						$('#hero-image-wrapper').find('video').each(function() {
							$(this).get(0).play();
						});
						$("#app.active").remove();
						$(".big-title-caption").remove();
						$('.thumb-container').remove();				
					} ,250 );
				},
				waitForAll: true
			});
		} else if( $('.load-project-thumb-with-title').length > 0 ){
			$('#hero-image-wrapper').waitForImages({
				finished: function() {
					setTimeout( function(){
						$('#hero-image-wrapper').find('video').each(function() {
							$(this).get(0).play();
						});
						$("#app.active").remove();
						$('.thumb-container').remove();	
						$("#canvas-slider.active").remove();
						$(".temporary-hero").remove();
						$(".next-project-image-wrapper.temporary").remove();
						$('body').removeClass("load-project-thumb-with-title").removeClass("show-loader");	
					} , 500 );
				},
				waitForAll: true
			});			
		} else if( $('.load-project-thumb-with-title-and-scale').length > 0 ){
			$('#hero-image-wrapper').waitForImages({
				finished: function() {
					setTimeout( function(){
						$('#hero-image-wrapper').find('video').each(function() {
							$(this).get(0).play();
						});
						$("#app.active").remove();
						$('.thumb-container').remove();	
						$("#canvas-slider.active").remove();
						$(".temporary-hero").remove();
						$(".next-project-image-wrapper.temporary").remove();
						$('body').removeClass("load-project-thumb-and-title").removeClass("show-loader");	
					} , 500 );
				},
				waitForAll: true
			});	
		} else {
			$('#hero-image-wrapper').waitForImages({
				finished: function() {
					$('#hero-image-wrapper').find('video').each(function() {
						$(this).get(0).play();
					});
					$("#app.active").remove();
					$('.thumb-container').remove();	
					$("#canvas-slider.active").remove();
				},
				waitForAll: true
			});
		}
		
		setTimeout( function(){	
			$('header').removeClass('white-header');
			$('body').removeClass("load-project-page").removeClass("load-project-thumb").removeClass("load-next-project").removeClass("load-next-page");
			setTimeout( function(){	
				$('body').removeClass("load-project-thumb-with-title").removeClass("show-loader");
			} , 300 );			
		} , 800 );
		
	
	}// End Lazy Load		




	
	
	
/*--------------------------------------------------
Function Showcase Slider
---------------------------------------------------*/
	
	function ShowcaseSlider() {
		
	
		if( $('#showcase-slider-holder').length > 0 ){
			
			var myHero = document.getElementById("hero");
			if(!myHero){
				$("footer").addClass("showcase-footer");
			}
			
			
			var titles = [];
			var subtitle = [];
			$('#showcase-slider .swiper-slide').each(function(i) {
			  	titles.push($(this).data('title'))
				subtitle.push($(this).data('subtitle'))
			});
			
			var swiperOptions = {
				direction: "horizontal",
				loop: true,
				grabCursor: false,
				resistance : true,
				resistanceRatio:0.5,
				slidesPerView: 'auto',
				allowTouchMove:true,  
				speed:700,
				autoplay: false,
				mousewheel: true,
				parallax:true,
				navigation: {
					nextEl: '.swiper-next',
					prevEl: '.swiper-prev',
				},
				pagination: {
				  el: '.showcase-pagination',
					clickable: true,
					renderBullet: function (index, className) {
						return '<div class="' + className + '">' + '<div class="caption-wrapper">' + '<div class="title">' + titles[index] + '</div>' + '<div class="subtitle">' + '<span>' + subtitle[index] + '</span>' + '</div>' + '</div>' +'<div class="parallax-wrap">' + '<div class="parallax-element">' + '<svg class="fp-arc-loader disable-drag" width="20" height="20" viewBox="0 0 20 20">'+
								'<circle class="path" cx="10" cy="10" r="5.5" fill="none" transform="rotate(-90 10 10)"'+
								'stroke-opacity="1" stroke-width="2px"></circle>'+
								'<circle class="solid-fill" cx="10" cy="10" r="3"></circle>'+
								'</svg></div></div>' + '</div>';						 
					},
				},						
				on: {
					slidePrevTransitionStart: function () {	
						$('.showcase-pagination').find('.swiper-pagination-bullet').each(function() {
							if (!$(this).hasClass("swiper-pagination-bullet-active")) {															
								gsap.to($(this).find('.title span'), {duration: 0.5, y:10, rotationX: -78, transformOrigin:"50% 90% 0px", opacity:0, stagger: 0.02, ease:Power2.easeInOut})
								gsap.to($(this).find('.subtitle span'), {duration: 0.5, y:30, opacity:0, delay:0.1, ease:Power2.easeInOut})
							} else {
								gsap.set($(this).find('.title span'), {y:-10, rotationX: 78, transformOrigin:"50% 90% 0px", opacity:0, });
								gsap.set($(this).find('.subtitle span'), {y:-30, opacity:0, });
								gsap.to($(this).find('.title span'), {duration: 0.5, y:0, rotationX: 0, transformOrigin:"50% 10% 0px", opacity:1, delay:0.5, stagger: 0.02, ease:Power2.easeOut})
								gsap.to($(this).find('.subtitle span'), {duration: 0.5, y:0, opacity:1, delay:0.5, ease:Power2.easeInOut})									
							}
						});
												
					},
					slideNextTransitionStart: function () {	
			
						$('.showcase-pagination').find('.swiper-pagination-bullet').each(function() {
							if (!$(this).hasClass("swiper-pagination-bullet-active")) {															
								gsap.to($(this).find('.title span'), {duration: 0.5, y:-10, rotationX: 78, transformOrigin:"50% 10% 0px", opacity:0, stagger: 0.02, ease:Power2.easeInOut})
								gsap.to($(this).find('.subtitle span'), {duration: 0.5, y:-30, opacity:0, delay:0.1, ease:Power2.easeInOut})
							} else {
								gsap.set($(this).find('.title span'), {y:10, rotationX: -78, transformOrigin:"50% 10% 0px", opacity:0, });
								gsap.set($(this).find('.subtitle span'), {y:30, opacity:0, });
								gsap.to($(this).find('.title span'), {duration: 0.5, y:0, rotationX: 0, transformOrigin:"50% 90% 0px", opacity:1, delay:0.5, stagger: 0.02, ease:Power2.easeOut})
								gsap.to($(this).find('.subtitle span'), {duration: 0.5, y:0, opacity:1, delay:0.5, ease:Power2.easeInOut})											
							}
						});
												
					},						
					slideChangeTransitionStart: function () {
						
						$('#trigger-slides .swiper-slide-active').find('div').first().each(function() {
							if (!$(this).hasClass("active")) {
								$(this).trigger('click');
							}
							
						});
						
						$('#trigger-slides .swiper-slide-duplicate-active').find('div').first().each(function() {
							if (!$(this).hasClass("active")) {
								$(this).trigger('click');
							}
						}); 
												
						if ($('#page-content').hasClass("dark-content")) {
							if ($('.swiper-slide-active').hasClass("change-header")) {
								$('#page-content').delay(450).queue(function(next){
									$(this).removeClass('light-content-slider');
									$('#magic-cursor').removeClass('light-content-slider');
									next();
								});	
							} else {
								$('#page-content').delay(550).queue(function(next){
									$(this).addClass('light-content-slider');
									$('#magic-cursor').addClass('light-content-slider');
									next();
								});	
							}
							
							if ($('.swiper-slide-duplicate-active').hasClass("change-header")) {
								$('#page-content').delay(450).queue(function(next){
									$(this).removeClass('light-content-slider');
									$('#magic-cursor').removeClass('light-content-slider');
									next();
								});	
							} else {
								$('#page-content').delay(550).queue(function(next){
									$(this).addClass('light-content-slider');
									$('#magic-cursor').addClass('light-content-slider');
									next();
								});	
							}
						}
						
						if ($('#page-content').hasClass("light-content")) {
							if ($('.swiper-slide-active').hasClass("change-header")) {
								$('#page-content').delay(450).queue(function(next){
									$(this).addClass('light-content-slider');
									$('#magic-cursor').addClass('light-content-slider');
									next();
								});	
							} else {
								$('#page-content').delay(550).queue(function(next){
									$(this).removeClass('light-content-slider');
									$('#magic-cursor').removeClass('light-content-slider');
									next();
								});	
							}
							
							if ($('.swiper-slide-duplicate-active').hasClass("change-header")) {
								$('#page-content').delay(450).queue(function(next){
									$(this).addClass('light-content-slider');
									$('#magic-cursor').addClass('light-content-slider');
									next();
								});	
							} else {
								$('#page-content').delay(550).queue(function(next){
									$(this).removeClass('light-content-slider');
									$('#magic-cursor').removeClass('light-content-slider');
									next();
								});	
							}
						}
						
						$('.swiper-slide').find('.slide-title').each(function() {
							$(this).removeClass('active-title');							
						});
						
						LinesWidth();						
						
					},
					slideChangeTransitionEnd: function () {							
						
						$('.swiper-slide-active').find('.slide-title').each(function() {
							$(this).addClass('active-title');							
						});
						
						$('.swiper-slide-duplicate-active').find('.slide-title').each(function() {
							$(this).addClass('active-title');	
						});						
						
					},
  				},
			};
			
			
			var showcaseSwiper = new Swiper("#showcase-slider", swiperOptions);
			
			if( $('#showcase-slider').length > 0 ){
				$('body').waitForImages({
					finished: function() {	
						showcaseSwiper.update();
					},				
					waitForAll: true
				});	
			}	
			
			
			function LinesWidth() {
			
				var sliderWidth = $('#showcase-slider-holder').width();
				var captionWidth = $('.swiper-slide-active .slide-title').width();
				var lineWidth = sliderWidth / 2 - 50
				
				$(".caption-border.left").css({
					'width': lineWidth - captionWidth/2 + 'px',
					'opacity': 1,
				});				
				$(".caption-border.right").css({
					'width': lineWidth - captionWidth/2 + 'px',
					'opacity': 1,
				});
				
			}// End Lines Width
			
			LinesWidth();
			
			
			function BulletsPosition() {
				var bullets_count = $('.swiper-pagination-bullet .parallax-wrap').length;
				var bullets_count_width = $('.swiper-pagination-bullet .parallax-wrap').length * 40 / 2;
				var bullets_height = $('.showcase-pagination-wrap').height()/2;
				var window_width = $(window).width() / 2;
				var window_height = $(window).height() / 2;
				var footer_height = $('footer').height() / 2 ;
				for( i = 0; i < bullets_count; i++ ) { $('.swiper-pagination-bullet .parallax-wrap').eq( i ).css( 'left', (i * 40) - bullets_count_width + window_width).css( 'top', (bullets_height - 20) + window_height - footer_height);	}
			}
			
			BulletsPosition();
			
			var resizeTime;
			$(window).resize(function() {
				clearTimeout(resizeTime);
				resizeTime = setTimeout(doneResizing, 10);
			});
				
			function doneResizing(){
				BulletsPosition();
				LinesWidth();
			}
			
			$('.title').each(function(){
				var words = $(this).text().split(" ");
				var total = words.length;
				$(this).empty();
				for (index = 0; index < total; index ++){
					$(this).append($("<div /> ").text(words[index]));
				}
			});
			
			$('.title div').each(function(){
				var words = $(this).text().slice(" ");
				var total = words.length;
				$(this).empty();
				for (index = 0; index < total; index ++){
					$(this).append($("<span /> ").text(words[index]));
				}
			});
			
			
			
			
			if (!isMobile()) {
				
				// Showcase Slider Trigger Events
				$('#showcase-slider-holder .slide-title').on('mousedown', function(event) {
					return false;
				});				
				
				$('.swiper-container').on('mousedown touchstart', function() {	
					if ($('#magic-cursor').hasClass("light-content")) {
						gsap.to('#ball', {duration: 0.3, borderWidth: '2px', scale: 1.2, borderColor:'#fff', backgroundColor:'#fff'});
					} else {
						gsap.to('#ball', {duration: 0.3, borderWidth: '2px', scale: 1.2, borderColor:'#2b2a35', backgroundColor:'#2b2a35'});
					}
					$("body" ).addClass("scale-drag-x");
				});
					
				$('.swiper-container').on('mouseup touchend', function() {
					gsap.to('#ball', {duration: 0.2, borderWidth: '4px', scale:0.5, borderColor:'#999999', backgroundColor:'transparent'});
					$("body").removeClass("scale-drag-x");
				});
				
				$('body').on('mouseup touchend', function() {				
					$('body').removeClass('scale-drag-x');					
				});
				
				// Showcase Slider Hover Events
				$("#showcase-slider-holder .slide-title").on('mouseenter', function() {	
					var $this = $(this);			
					gsap.to('#ball', {duration: 0.3, borderWidth: '2px', scale: 1.2, borderColor:$this.data('color'), backgroundColor:$this.data('color')});
					gsap.to('#ball-loader', {duration: 0.2, borderWidth: '2px', top: 2, left: 2});
					$( "#ball" ).append( '<p class="first">' + $this.data("firstline") + '</p>' + '<p>' + $this.data("secondline") + '</p>' );	
					$("#showcase-slider-holder .slide-title").addClass('hover-title')			
				});
									
				$("#showcase-slider-holder .slide-title").on('mouseleave', function() {					
					gsap.to('#ball', {duration: 0.2, borderWidth: '4px', scale:0.5, borderColor:'#999999', backgroundColor:'transparent'});
					gsap.to('#ball-loader', {duration: 0.2, borderWidth: '4px', top: 0, left: 0});
					$('#ball p').remove();		
					$("#showcase-slider-holder .slide-title").removeClass('hover-title')		
				});
			
			}
			
			
			// Showcase Slider Project Load Events
			if (!$("body").hasClass("load-no-ajax")) {
				$('#showcase-slider-holder .slide-title').on('click', function() {
					if ($("#hero").hasClass("has-slider")) {
						if( $('#showcase-slider').length > 0 ){						
							var threeSlider = document.getElementById("canvas-slider");
							threeSlider.className += " active"; 
							$("body").append(threeSlider)						
						}
					}
					
					let parent_slide = $(this).closest( '.swiper-slide' );
					parent_slide.addClass('above');
					
					$("body").addClass("show-loader");
					if ($(this).parents('.swiper-slide').hasClass("change-header")) {
						$("body").append('<div class="temporary-hero"><div class="outer content-max-width"><div class="inner"></div></div></div>');
					} else {
						$("body").append('<div class="temporary-hero light-content"><div class="outer content-max-width"><div class="inner"></div></div></div>');
					}
					
					gsap.to('.slide-small-title span', {duration: 0.3, y:-30, opacity:0, delay:0, ease:Power2.easeIn});				
					gsap.to('footer, #hero-footer, .showcase-pagination-wrap .parallax-element, .caption-border', {duration: 0.5, opacity:0, ease:Power4.easeInOut});
					gsap.to('#showcase-border', {duration: 0.5, width:'0', opacity:0, ease:Power4.easeInOut});
					
					$('.swiper-pagination-bullet-active').find('.caption-wrapper').appendTo('.temporary-hero .inner');
					$("body").addClass("load-project-thumb-with-title");
					$(this).delay(100).queue(function() {
						var link = $(".above").find('a');
						link.trigger('click');
					});
					
					gsap.to('#ball', {duration: 0.2, borderWidth: '4px', scale:0.5, borderColor:'#999999', backgroundColor:'transparent'});
					gsap.to('#ball-loader', {duration: 0.2, borderWidth: '4px', top: 0, left: 0});
					$("#ball").removeClass("with-icon");
					$('#ball p').remove();
					$('#ball i').remove();				
				});
			}
			
			
		}
		
			
	}//End Showcase Slider
	
	
	
/*--------------------------------------------------
Function Showcase Carousel
---------------------------------------------------*/
	
	function ShowcaseCarousel() {
		
	
		if( $('#showcase-carousel-holder').length > 0 ){
			
			$("footer").addClass("showcase-footer")
								
			var interleaveOffset = 0.3;
			
			var swiperOptions = {
				direction: "vertical",
				loop: true,
				grabCursor: false,
				resistance : true,
				resistanceRatio:0.5,
				slidesPerView: 'auto',
				allowTouchMove:true,  
				speed:700,
				autoplay: false,
				mousewheel: true,
				centeredSlides: true,
				spaceBetween: 150,
				breakpoints: {
					320: {
					  spaceBetween: 20
					},
					479: {
					  spaceBetween: 30
					},
					767: {
					  spaceBetween: 60
					},
					1024: {
					  spaceBetween: 80
					}
				},
				parallax:true,
				navigation: {
					nextEl: '.swiper-next',
					prevEl: '.swiper-prev',
				},
				pagination: {
				  el: '.swiper-pagination',
						clickable: true,
						renderBullet: function (index, className) {
					  return '<span class="' + className + '">'+'<div class="parallax-wrap">' + '<div class="parallax-element">' + '<svg class="fp-arc-loader" width="20" height="20" viewBox="0 0 20 20">'+
									'<circle class="path" cx="10" cy="10" r="5.5" fill="none" transform="rotate(-90 10 10)" stroke="#FFF"'+ 'stroke-opacity="1" stroke-width="2px"></circle>' + '<circle class="solid-fill" cx="10" cy="10" r="3" fill="#FFF"></circle>' + '</svg></div></div></span>';
					},
			
				},						
				on: {		
					slideChangeTransitionStart: function () {
						
						$('#showcase-carousel').find('.swiper-slide').each(function() {
							if (!$(this).hasClass("swiper-slide-active")) {
								gsap.to($(this).find('.slide-date span'), {duration:0.5, y:30, opacity:0, ease:Power2.easeInOut})
								gsap.to($(this).find('.slide-title span'), 0.5, {y:120, opacity:0, ease:Power2.easeInOut})
								gsap.to($(this).find('.subtitle span'), 0.5, {y:30, opacity:0,ease:Power2.easeInOut})
							} else {
								gsap.set($(this).find('.slide-date span'), {y:-30, opacity:0, });
								gsap.set($(this).find('.slide-title span'), {y:-120, opacity:0, });
								gsap.set($(this).find('.subtitle span'), {y:-30, opacity:0, });
								gsap.to($(this).find('.slide-date span'), {duration:0.5, y:0, opacity:1, delay:0.2, ease:Power2.easeInOut})
								gsap.to($(this).find('.slide-title span'), {duration:0.5, y:0, opacity:1, delay:0.4, ease:Power2.easeOut})
								gsap.to($(this).find('.subtitle span'), {duration:0.5, y:0, opacity:1, delay:0.3, ease:Power2.easeInOut})
							}
						});
																	
						$('.swiper-slide').find('.slide-title').each(function() {
							$(this).removeClass('active-title');							
						});
						
						$('.swiper-slide-active').find('video').each(function() {
							$(this).get(0).play();
						});						
						
					},
					slideChangeTransitionEnd: function () {	
						
						$('.swiper-slide-active').find('.slide-title').each(function() {
							$(this).addClass('active-title');							
						});
						
						$('.swiper-slide-duplicate-active').find('.slide-title').each(function() {
							$(this).addClass('active-title');	
						});
						
						$('.swiper-slide-prev').find('video').each(function() {
							$(this).get(0).pause();
						});
						
						$('.swiper-slide-next').find('video').each(function() {
							$(this).get(0).pause();
						});
						
					},
  				},
			};
			
			
			var showcaseSwiper = new Swiper("#showcase-carousel", swiperOptions);	
			
			
			if( $('#showcase-carousel').length > 0 ){
				$('body').waitForImages({
					finished: function() {	
						showcaseSwiper.update();
					},				
					waitForAll: true
				});	
			}
			
			
			
			if ($(window).width() >= 1024) {
			
				$('#showcase-carousel-holder .slide-title').on('mousedown', function(event) {
					return false;
				});				
				
				$('.swiper-container').on('mousedown touchstart', function() {	
					if ($('#magic-cursor').hasClass("light-content")) {
						gsap.to('#ball', {duration: 0.3, borderWidth: '2px', scale: 1.2, borderColor:'#fff', backgroundColor:'#fff'});
					} else {
						gsap.to('#ball', {duration: 0.3, borderWidth: '2px', scale: 1.2, borderColor:'#2b2a35', backgroundColor:'#2b2a35'});
					}
					$("body" ).addClass("scale-drag-y");
				});
					
				$('.swiper-container').on('mouseup touchend', function() {
					gsap.to('#ball', {duration: 0.2, borderWidth: '4px', scale:0.5, borderColor:'#999999', backgroundColor:'transparent'});
					$("body").removeClass("scale-drag-y");
				});
				
				$('body').on('mouseup touchend', function() {				
					$('body').removeClass('scale-drag-y');					
				});
				
				$("#showcase-carousel-holder .slide-title").on('mouseenter', function() {	
					var $this = $(this);			
					gsap.to('#ball', {duration: 0.3, borderWidth: '2px', scale: 1.2, borderColor:$this.data('color'), backgroundColor:$this.data('color')});
					gsap.to('#ball-loader', {duration: 0.2, borderWidth: '2px', top: 2, left: 2});
					$( "#ball" ).append( '<p class="first">' + $this.data("firstline") + '</p>' + '<p>' + $this.data("secondline") + '</p>' );	
					$("#showcase-carousel-holder .slide-title").addClass('hover-title')			
				});
									
				$("#showcase-carousel-holder .slide-title").on('mouseleave', function() {					
					gsap.to('#ball', {duration: 0.2, borderWidth: '4px', scale:0.5, borderColor:'#999999', backgroundColor:'transparent'});
					gsap.to('#ball-loader', {duration: 0.2, borderWidth: '4px', top: 0, left: 0});
					$('#ball p').remove();		
					$("#showcase-carousel-holder .slide-title").removeClass('hover-title')		
				});
				
			
			}
			
			
		}	
		
			
	}//End Showcase Carousel		
	
	
	
	
/*--------------------------------------------------
Function Showcase Webgl Slider Core
---------------------------------------------------*/
	
	function ShowcaseWebglCore() {
		
	
		if( $('#showcase-slider-holder').length > 0 ){
			
			
			var vertex = 'varying vec2 vUv; void main() {  vUv = uv;  gl_Position = projectionMatrix * modelViewMatrix * vec4( position, 1.0 );	}';
			var fragment = `
				varying vec2 vUv;

				uniform sampler2D currentImage;
				uniform sampler2D nextImage;
				uniform sampler2D disp;
				uniform float dispFactor;
				uniform float effectFactor;
				uniform vec4 resolution;

				void main() {

					vec2 uv = (vUv - vec2(0.5))*resolution.zw + vec2(0.5);

					vec4 disp = texture2D(disp, uv);
					vec2 distortedPosition = vec2(uv.x + dispFactor * (disp.r*effectFactor), uv.y);
					vec2 distortedPosition2 = vec2(uv.x - (1.0 - dispFactor) * (disp.r*effectFactor), uv.y);
					vec4 _currentImage = texture2D(currentImage, distortedPosition);
					vec4 _nextImage = texture2D(nextImage, distortedPosition2);
					vec4 finalTexture = mix(_currentImage, _nextImage, dispFactor);

					gl_FragColor = finalTexture; }

				`;

			var gl_canvas = new ClapatWebGL({
					vertex: vertex,
					fragment: fragment,
			});
			
			if( $('#showcase-slider').length > 0 ){
			
				var addEvents = function(){
	
					var triggerSlide = Array.from(document.getElementById('trigger-slides').querySelectorAll('.slide-wrap'));
					gl_canvas.isRunning = false;
	
					triggerSlide.forEach( (el) => {
	
						el.addEventListener('click', function() {
	
								if( !gl_canvas.isRunning ) {
	
									gl_canvas.isRunning = true;
	
									document.getElementById('trigger-slides').querySelectorAll('.active')[0].className = '';
									this.className = 'active';
	
									var slideId = parseInt( this.dataset.slide, 10 );
	
									gl_canvas.material.uniforms.nextImage.value = gl_canvas.textures[slideId];
									gl_canvas.material.uniforms.nextImage.needsUpdate = true;
	
									gsap.to( gl_canvas.material.uniforms.dispFactor, {
										duration: 0.7,
										value: 1,
										ease: 'Sine.easeInOut',
										onComplete: function () {
											gl_canvas.material.uniforms.currentImage.value = gl_canvas.textures[slideId];
											gl_canvas.material.uniforms.currentImage.needsUpdate = true;
											gl_canvas.material.uniforms.dispFactor.value = 0.0;
											gl_canvas.isRunning = false;
										}
									});
	
								}
	
						});
	
					});
	
				};
	
				addEvents();
				
			}
			
			
		}	
		
			
	}//End Showcase WebGL Core	

	
	
/*--------------------------------------------------
Function Floating Lists
---------------------------------------------------*/

	function FloatingLists() {
	
		if( $('.showcase-list-holder').length > 0 ){	
			
			if ($(window).width() < 1024) {
				$('.hover-reveal').addClass('trigger-item-link');
				$('.sl-title').addClass('trigger-item-link');
			}
			
			if ($(window).width() >= 1024) {
			
				if ($("body").hasClass("smooth-scroll")) {
					var elem = document.querySelector("#content-scroll");
					var scrollbar = Scrollbar.init(elem,
					{
						renderByPixels: true,
						damping:0.1
					});
				}
				
				const getMousePos = (e) => {
					let posx = 0;
					let posy = 0;
					if (!e) e = window.event;
					if (e.pageX || e.pageY) {
						posx = e.pageX;
						posy = e.pageY;
					}
					else if (e.clientX || e.clientY) 	{
						posx = e.clientX + document.body.scrollLeft + document.documentElement.scrollLeft;
						posy = e.clientY + document.body.scrollTop + document.documentElement.scrollTop;
					}
					return { x : posx, y : posy }
				}
			
				// Effect 1
				class HoverImgFx1 {
					constructor(el) {
						this.DOM = {el: el};
						this.DOM.reveal = this.DOM.el.querySelector('.hover-reveal');				
						this.DOM.revealInner = this.DOM.reveal.querySelector('.hover-reveal__inner');
						this.DOM.revealInner.style.overflow = 'hidden';
						this.DOM.revealImg = this.DOM.revealInner.querySelector('.hover-reveal__img');
						this.initEvents();
					}
					initEvents() {				
						
						this.positionElement = (ev) => {
							const mousePos = getMousePos(ev);
							if ($("body").hasClass("smooth-scroll")) {
								const docScrolls = {
									left : document.body.scrollLeft + document.documentElement.scrollLeft, 
									top : - scrollbar.scrollTop
								};
								if ($(".showcase-list-holder").hasClass("vertical-list")) {
									gsap.to($('.hover-reveal'), { duration: 0.7, top: `${mousePos.y-150-docScrolls.top}px`, left: `${mousePos.x-250-docScrolls.left}px`, ease:Power4.easeOut });
								} else {
									gsap.to($('.hover-reveal'), { duration: 1, top: `${mousePos.y+40-docScrolls.top}px`, left: `${mousePos.x+10-docScrolls.left}px`, ease:Power4.easeOut });
								}
							} else {
								const docScrolls = {
									left : document.body.scrollLeft + document.documentElement.scrollLeft, 
									top : document.body.scrollTop + document.documentElement.scrollTop
								};
								if ($(".showcase-list-holder").hasClass("vertical-list")) {
									gsap.to($('.hover-reveal'), { duration: 0.7, top: `${mousePos.y-150-docScrolls.top}px`, left: `${mousePos.x-250-docScrolls.left}px`, ease:Power4.easeOut });
								} else {
									gsap.to($('.hover-reveal'), { duration: 1, top: `${mousePos.y+40-docScrolls.top}px`, left: `${mousePos.x+10-docScrolls.left}px`, ease:Power4.easeOut });
								}
							}
							
						};
						this.mouseenterFn = (ev) => {
							this.positionElement(ev);
							this.showImage();
						};
						this.mousemoveFn = ev => requestAnimationFrame(() => {
							this.positionElement(ev);
						});
						this.mouseleaveFn = () => {
							this.hideImage();
						};
						
						this.DOM.el.addEventListener('mouseenter', this.mouseenterFn);
						this.DOM.el.addEventListener('mousemove', this.mousemoveFn);
						this.DOM.el.addEventListener('mouseleave', this.mouseleaveFn);
					}
					showImage() {
						gsap.killTweensOf(this.DOM.revealInner);
						gsap.killTweensOf(this.DOM.revealImg);
			
						this.tl = gsap.timeline({
							onStart: () => {
								this.DOM.reveal.style.opacity = 1;
								gsap.set(this.DOM.el, {zIndex: 1000});
							}
						})
						.add('begin')
						.add(gsap.to(this.DOM.revealInner, {
							duration: 0.4,
							ease: Sine.easeOut,
							startAt: {x: '-100%'},
							x: '0%'
						}), 'begin')
						.add(gsap.to(this.DOM.revealImg, {
							duration: 0.4,
							ease: Sine.easeOut,
							startAt: {x: '100%'},
							x: '0%'
						}), 'begin');
					}
					hideImage() {
						gsap.killTweensOf(this.DOM.revealInner);
						gsap.killTweensOf(this.DOM.revealImg);
			
						this.tl = gsap.timeline({
							onStart: () => {
								gsap.set(this.DOM.el, {zIndex: 999});
							},
							onComplete: () => {
								gsap.set(this.DOM.el, {zIndex: ''});
								gsap.set(this.DOM.reveal, {opacity: 0});
							}
						})
						.add('begin')
						.add(gsap.to(this.DOM.revealInner, {
							duration: 0.4,
							ease: Sine.easeOut,
							x: '100%'
						}), 'begin')
						
						.add(gsap.to(this.DOM.revealImg, {
							duration: 0.4,
							ease: Sine.easeOut,
							x: '-100%'
						}), 'begin');
					}
				}
				
				Array.from(document.querySelectorAll('.slide-list')).forEach(link => new HoverImgFx1(link));
				
				
				$('.slide-list').on('mouseenter', function() {
					$('.slide-list').addClass('disable');
					$(this).removeClass('disable');
					$(this).find('video').each(function() {
						$(this).get(0).play();
					});
				}).on('mouseleave', function() {
					$('.slide-list').removeClass('disable');
					$(this).find('video').each(function() {
						$(this).get(0).pause();
					});
				});
			}
			
		}
		
		
	}// End Floating Lists
	


/*--------------------------------------------------
Function Portfolio
---------------------------------------------------*/	
		
	function Portfolio() {	
	
			
		if( $('.portfolio-wrap').length > 0 ){			
			
			
			if ($("body").hasClass("smooth-scroll")) {
				var elem = document.querySelector("#content-scroll");
				var scrollbar = Scrollbar.init(elem,
				{renderByPixels: true,damping:0.1});
			}
			
			var $container = $('.portfolio');
		
			$container.isotope({
			  layoutMode: 'packery',
			  itemSelector: '.item',
			  gutter:0,
			  transitionDuration: "0.5s"
			});
			
			$('#filters a').on('click', function() {
				$('#filters a').removeClass('active');
				$(this).addClass('active');
				$('.item').addClass('item-margins');
				var selector = $(this).attr('data-filter');
				$container.isotope({ filter: selector }, function( $changedItems, instance ) {
				  instance.$allAtoms.filter('.isotope-hidden').removeClass('is-filtered');
				  instance.$filteredAtoms.addClass('is-filtered');
				});		
				return false;
			});
			
			$("#all").trigger('click');
			
			
				
			
			
			//Show Filters On overlay
			$('#show-filters, #close-filters').on('click', function() {			
				$('#filters-overlay').toggleClass('active');
				var navtitleheight = $(".hero-title").height()
				var navsubtitleheight = $(".hero-subtitle").height()
				
				setTimeout( function(){			
					if ($('#filters-overlay').hasClass("active")) {
						
						gsap.to($(".item-parallax"), {duration: 0.6, force3D:true, scale:0.9, opacity:0.3, delay:1.1, ease:Power2.easeInOut});					
						gsap.to($(".active .item-caption"), {duration: 0.3, opacity:0, ease:Power2.easeOut});
						gsap.to($("#show-filters, #counter-wrap"), {duration: 0.3, opacity:0, delay:0, ease:Power2.easeOut});
						gsap.to($("#show-filters, #counter-wrap"), {duration: 0, visibility:'hidden', delay:0.35, ease:Power2.easeOut}); 
						
						//Fade In Navigation Lists
						gsap.set($(".filters-info"), {y:30, opacity:0});
						gsap.to($(".filters-info"), {duration: 0.4, force3D:true, y:0, opacity:1, delay:0.7, ease:Power2.easeOut});
						var tlMenu = gsap.timeline();
						tlMenu.set($(".filters-timeline"), {y:60, opacity:0});
						$(".filters-timeline").each(function(index, element) {
							tlMenu.to(element, {duration: 0.5, y:0, opacity:1, delay:1.2, ease:Power3.easeOut}, index * 0.1)
						});
						
						var heroheight = $("#hero").height();			
						if ($("body").hasClass("smooth-scroll")) {
							gsap.to(scrollbar, {duration: 1.5, scrollTop:heroheight, ease:Power4.easeInOut});
						} else {
							$("html,body").animate({scrollTop: heroheight}, 800);
						}
							
					} else {					
						
						
						gsap.to($(".item-parallax"), {duration: 0.6, force3D:true, scale: 1, opacity:1, delay:0.3, ease:Power2.easeInOut});					
						gsap.to($(".active .item-caption"), {duration: 0.5, opacity:1, delay:0.5, ease:Power2.easeOut});
						gsap.set($("#show-filters, #counter-wrap"), {visibility:'visible', opacity:0});
						gsap.to($("#show-filters, #counter-wrap"), {duration: 0.3, opacity:1, delay:0.7, ease:Power2.easeOut});
						
						//Fade Out Navigation Lists
						gsap.to($(".filters-info"), {duration: 0.2, force3D:true, y:-30, opacity:0, delay:0, ease:Power1.easeIn});					
						var tlMenu = gsap.timeline();
						$(".filters-timeline, .jssocials-share").each(function(index, element) {
							tlMenu.to(element, {duration: 0.25, opacity:0, y:-60, delay:0.1, ease:Power1.easeIn }, index * 0.1)
						});	
						gsap.to('#ball', {duration: 0.1, borderWidth: '4px', scale:0.5,});
						$("#ball").removeClass("close-icon");
						$('#ball i').remove();
						
					}							
				} , 20 );
			});
			
			if (!isMobile()) {
				$(".item-wrap-image").mouseenter(function(e) {	
					var $this = $(this);
					if ($('#page-content').hasClass("light-content")) {
						gsap.to('#ball', {duration: 0.3, borderWidth: '2px', scale: 1.2, borderColor:$this.data('color'), backgroundColor:$this.data('color')});
						$( "#ball" ).addClass("with-icon").append( '<i class="arrow-icon white"></i>' );
					} else {
						gsap.to('#ball', {duration: 0.3, borderWidth: '2px', scale: 1.2, borderColor:$this.data('color'), backgroundColor:$this.data('color')});
						$( "#ball" ).addClass("with-icon").append( '<i class="arrow-icon white"></i>' );
					}
					gsap.to('#ball-loader', {duration: 0.2, borderWidth: '2px', top: 2, left: 2});					
					$(this).parent().find('video').each(function() {
						$(this).get(0).play();
					});
				});
								
				$(".item-wrap-image").mouseleave(function(e) {
					gsap.to('#ball', {duration: 0.2, borderWidth: '4px', scale:0.5, borderColor:'#999999', backgroundColor:'transparent'});
					gsap.to('#ball-loader', {duration: 0.2, borderWidth: '4px', top: 0, left: 0});
					$("#ball").removeClass("with-icon");
					$('#ball i').remove();
					$(this).parent().find('video').each(function() {
						$(this).get(0).pause();
					});
				});
				
				$("#close-filters").mouseenter(function(e) {	
					$( "#ball" ).addClass("close-icon").append( '<i class="fa fa-times"></i>' );
					if ($('#page-content').hasClass("light-content")) {
						gsap.to('#ball', {duration: 0.2, borderWidth: '2px', scale: 1, borderColor:'#fff',});
						gsap.to('#ball i', {duration: 0.2, css:{color:"#fff"}});
					} else {
						gsap.to('#ball', {duration: 0.2, borderWidth: '2px', scale: 1, borderColor:'#000',});
						gsap.to('#ball i', {duration: 0.2, css:{color:"#000"}});
					}
					gsap.to('#ball-loader', {duration: 0.2, borderWidth: '2px', top: 2, left: 2});
				});
					
				$("#close-filters").mouseleave(function(e) {
					gsap.to('#ball', {duration: 0.2, borderWidth: '4px', scale:0.5, borderColor:'#999999',});
					gsap.to('#ball-loader', {duration: 0.2,borderWidth: '4px', top: 0, left: 0});
					$("#ball").removeClass("close-icon");
					$('#ball i').remove();
				});
					
				$("#close-filters").mouseleave(function(e) {
					gsap.to('#ball', {duration: 0.2, borderWidth: '4px', scale:0.5, borderColor:'#999999',});
					gsap.to('#ball-loader', {duration: 0.2,borderWidth: '4px', top: 0, left: 0});
					$("#ball").removeClass("close-icon");
					$('#ball i').remove();
				});
			}
			
			setTimeout( function(){
				var controller = new ScrollMagic.Controller();
				$('.portfolio').each(function(){
					var $this = $(this);
					var $thisHeightFilters = $(this).outerHeight();
					var $thisHeightCaptions = $(this).outerHeight() - window.innerHeight * 0.1;
					
					var sceneFilters = new ScrollMagic.Scene({triggerElement:$this[0],duration: $thisHeightFilters})
						.addTo(controller)
						
					
					sceneFilters.triggerHook(1)
					
					sceneFilters.on('enter', function(){				
						gsap.to($("#show-filters"), {duration: 0.3, opacity:1, delay:0, ease:Power2.easeOut});
						$("#show-filters").addClass('enabled')
					});
					
					sceneFilters.on('leave', function(){				
						gsap.to($("#show-filters"), {duration: 0.15, opacity:0, delay:0, ease:Power2.easeOut});
						$("#show-filters").removeClass('enabled')
					});
					
					var sceneCaptions = new ScrollMagic.Scene({triggerElement:$this[0],duration: $thisHeightCaptions})
						.addTo(controller)
						
					
					sceneCaptions.triggerHook(0.5)
					
					sceneCaptions.on('enter', function(){
						$(".portfolio-captions").addClass('enabled')
					});
					
					sceneCaptions.on('leave', function(){
						$(".portfolio-captions").removeClass('enabled')
					});
					
					
					
					if ($("body").hasClass("smooth-scroll")) {
						scrollbar.addListener(() => {
							sceneFilters.refresh()
							sceneCaptions.refresh()
						});
					}
				})
			} , 2000 );
			
			gsap.to($("#show-filters"), {duration: 0, opacity:0, delay:0.05, ease:Power2.easeOut});			
			
			
		}
	
	}//End Portfolio
	
	
	
	



function LoadViaAjax() {		
		
	FirstLoad();
	SliceTitles();
	ScrollEffects();
	Sliders();
	PageLoadActions();		
	FloatingLists();
	FitThumbScreenGSAP();
	ShowcaseSlider();
	ShowcaseCarousel();
	ShowcaseWebglCore();
	FitThumbScreenWEBGL();		
	LazyLoad();				
	Portfolio();			
	Shortcodes();
	JustifiedGrid();
	Lightbox();
	PlayVideo();
	ContactForm();
	ContactMap();
	
}//End Load Via Ajax
	
	
