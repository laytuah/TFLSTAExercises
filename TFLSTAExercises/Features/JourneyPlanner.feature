Feature: JourneyPlanner

Background:
		Given that TFL website is loaded
		When a user clicks on the Accept all cookies button
		

Scenario: 01_Verify that a valid journey can be planned using the widget
		When a user fills-in the From text field with 'barnsley'
		And a user clicks on 'barnsley Rail Station' from the list suggested for From field
		And a user fills-in the To text field with 'bolton'
		And a user clicks on 'bolton rail station' from the list suggested for To field
		And a user clicks on plan my journey button
		Then a journey result page showing 'Earlier journey' must be loaded

Scenario: 02_Verify that the widget is unable to provide results when an invalid journey is planned
		When a user fills-in the From text field with 'barnsley'
		And a user clicks on 'barnsley Rail Station' from the list suggested for From field
		And a user fills-in the To text field with 'Umuahia'
		And a user clicks on plan my journey button
		Then the journey result page must load 'We found more than one location matching' input

Scenario: 03_Verify that the widget is unable to plan a journey if no locations are entered into the widget
		When a user clicks on plan my journey button
		Then a user must get an error message stating 'The From field is required'

Scenario: 04_Verify change time link on the journey planner displays “Arriving” option and plan a journey based on arrival time
		When a user fills-in the From text field with 'barnsley'
		And a user clicks on 'barnsley Rail Station' from the list suggested for From field
		And a user fills-in the To text field with 'bolton'
		And a user clicks on 'bolton rail station' from the list suggested for To field
		And a user clicks on Change Time link
		Then a user must see the 'Arriving' option
		When a user clicks on the arriving option button
		And a user selects 'Mon 11 Dec' from the date dropdown
		And a user selects selects '17:30' from the time dropdown
		And a user clicks on plan my journey button
		Then a journey result page showing 'Earlier journey' must be loaded

Scenario: 05_On the Journey results page, verify that a journey can be amended by using the “Edit Journey” button.
		When a user fills-in the From text field with 'barnsley'
		And a user clicks on 'barnsley Rail Station' from the list suggested for From field
		And a user fills-in the To text field with 'bolton'
		And a user clicks on 'bolton rail station' from the list suggested for To field
		And a user clicks on plan my journey button
		And a user clicks the Edit journey link
		And a user clicks the Clear-field icon
		And a user fills-in the To text field with 'ilford'
		And a user clicks on 'ilford rail station' from the list of suggested for edit
		And a user clicks on Update Journey button
		Then a journey result page showing 'Earlier journey' must be loaded

Scenario: 06_Verify that the “Recents” tab on the widget displays a list of recently planned journeys.
		#Pre-requisite: At least one journey must recently be planned.
		When a user fills-in the From text field with 'barnsley'
		And a user clicks on 'barnsley Rail Station' from the list suggested for From field
		And a user fills-in the To text field with 'bolton'
		And a user clicks on 'bolton rail station' from the list suggested for To field
		And a user clicks on plan my journey button
		And a user clicks the Home icon
		And a user clicks on the Recents link
		Then a list of recent journeys must be displayed with 'Turn off / clear' link below the list