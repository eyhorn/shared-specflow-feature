Feature: HelloWorld
	In to see that a program works
	As programmer
	I want to see hello world

Scenario: Print Hello World
	Given the SharedFeature program
	When SharedFeature program is started
	Then the 'Hello World' should be printed on the screen
