Feature: HelloWorld
	In to see that a program works
	As programmer
	I want to see hello world

@mytag
Scenario: Print hellow world
	Given the SharedFeature program
	When SharedFeature program is started
	Then the Hello world should be printed on the screen
