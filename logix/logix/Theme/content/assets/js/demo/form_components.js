/*
 * form_components.js
 *
 * Demo JavaScript used on form-pages.
 */

"use strict";

$(document).ready(function(){

	//===== Autocomplete =====//
	// Using typehead.js-library
	$('#autocomplete-example').typeahead({
		name: 'autocomplete-example',
		local: [
			'Alabama','Alaska','Arizona','Arkansas','California','Colorado','Connecticut','Delaware','Florida','Georgia','Hawaii','Idaho','Illinois','Indiana','Iowa','Kansas','Kentucky','Louisiana','Maine','Maryland','Massachusetts','Michigan','Minnesota','Mississippi','Missouri','Montana','Nebraska','Nevada','New Hampshire','New Jersey','New Mexico','New York','North Dakota','North Carolina','Ohio','Oklahoma','Oregon','Pennsylvania','Rhode Island','South Carolina','South Dakota','Tennessee','Texas','Utah','Vermont','Virginia','Washington','West Virginia','Wisconsin','Wyoming'
		]
	});

	//===== Tags =====//
	// @see: for normal tags, see assets/js/plugins.form-components.js (initTags())

	// Custom Tags
	$('.tags-autocomplete').tagsInput({
		width: '100%',
		height: 'auto',
		autocomplete_url: 'assets/js/plugins/tagsinput/tags_autocomplete.html'
	});


	//===== Select2 =====//
	// @see: for default options, see assets/js/plugins.form-components.js (initSelect2())

	// Normal
	$('.select2-select-00').select2({
		allowClear: true
	});

	// Minimal Input Length
	$('.select2-select-01').select2({
		minimumInputLength: 3
	});

	// Tagging Support
	$('.select2-select-02').select2({
	    tags: ['Abdullah', 'Rafeeq', 'Muhammed', 'Razzak', 'Hussain']
	});

    // Tagging Support
	$('.select2-select-03').select2({
	    tags: ['Abu Hali', 'Rasidiya', 'Emirates', 'Union Square']
	});

    // Tagging Support
	$('.select2-select-04').select2({
	    tags: ['Check Point 1', 'Check Point 2', 'Check Point 3', 'Check Point 4', 'Check Point 5']
	});

    // Tagging Support
	$('.select2-select-05').select2({
	    tags: ['Department 1', 'Department 2', 'Department 3', 'Department 4', 'Department 5']
	});

    // Tagging Support
	$('.select2-select-06').select2({
	    tags: ['Employee Type 1', 'Employee Type 2', 'Employee Type 3', 'Employee Type 4', 'Employee Type 5']
	});
    // Tagging Support
	$('.select2-select-07').select2({
	    tags: ['Grade 1', 'Grade 2', 'Grade 3', 'Grade 4', 'Grade 5']
	});
    // Tagging Support
	$('.select2-select-08').select2({
	    tags: ['0', '1', '2', '3', '4', '5']
	});
    // Tagging Support
	$('.select2-select-09').select2({
	    tags: ['Category 1', 'Category 2', 'Category 3', 'Category 4', 'Category 5']
	});
    // Tagging Support
	$('.select2-select-10').select2({
	    tags: ['Group 1', 'Group 2', 'Group 3', 'Group 4', 'Group 5']
	});
    // Tagging Support
	$('.select2-select-11').select2({
	    tags: ['Team 1', 'Team 2', 'Team 3', 'Team 4', 'Team 5']
	});
    // Tagging Support
	$('.select2-select-12').select2({
	    tags: ['Day 1', 'Day 2', 'Day 3', 'Day 4', 'Day 5']
	});
    // Tagging Support
	$('.select2-select-13').select2({
	    tags: ['One Hour', 'Two Hour', 'Three Hour', 'Four Hour']
	});
    // Tagging Support
	$('.select2-select-14').select2({
	    tags: ['Vacation 1', 'Vacation 2', 'Vacation 3', 'Vacation 4']
	});
    // Tagging Support
	$('.select2-select-15').select2({
	    tags: ['Grace 1', 'Grace 2', 'Grace 3', 'Grace 4']
	});
    // Tagging Support
	$('.select2-select-15').select2({
	    tags: ['Action 1', 'Action 2', 'Action 3', 'Action 4']
	});
	//===== Spinner =====//
	if ($.fn.spinner) {
		$( ".spinner-default" ).spinner();

		$( "#spinner-decimal" ).spinner({
			step: 0.01,
			numberFormat: "n"
		});

		$( "#culture" ).change(function() {
			var current = $( "#spinner-decimal" ).spinner( "value" );
			Globalize.culture( $(this).val() );
			$( "#spinner-decimal" ).spinner( "value", current );
		});

		$( "#currency" ).change(function() {
			$( "#spinner-currency" ).spinner( "option", "culture", $( this ).val() );
		});

		$( ".spinner-currency" ).spinner({
			min: 5,
			max: 2500,
			step: 25,
			start: 1000,
			numberFormat: "C"
		});

		$( "#spinner-overflow" ).spinner({
			spin: function( event, ui ) {
				if ( ui.value > 10 ) {
					$( this ).spinner( "value", -10 );
					return false;
				} else if ( ui.value < -10 ) {
					$( this ).spinner( "value", 10 );
					return false;
				}
			}
		});

		$.widget( "ui.timespinner", $.ui.spinner, {
			options: {
				// seconds
				step: 60 * 1000,
				// hours
				page: 60
			},

			_parse: function( value ) {
				if ( typeof value === "string" ) {
					// already a timestamp
					if ( Number( value ) == value ) {
						return Number( value );
					}
					return +Globalize.parseDate( value );
				}
				return value;
			},

			_format: function( value ) {
				return Globalize.format( new Date(value), "t" );
			}
		});

		$( ".spinner-time" ).timespinner();
		$( "#culture-time" ).change(function() {
			var current = $( ".spinner-time" ).timespinner( "value" );
			Globalize.culture( $(this).val() );
			$( ".spinner-time" ).timespinner( "value", current );
		});

		$( "#spinner-validation" ).spinner();
	}
});
