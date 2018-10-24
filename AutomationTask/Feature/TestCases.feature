Feature: TestCases


@mytag
Scenario: ExecutionOfAutomationTasks
	Given end user navigates to 'https://www.w3.org/' and click to 'W3C A to Z (site map)' link
	Then store a path of the link in the variable
	And search result by the last part of URL from stored variable
	Then verify that input of the search string begins from 
	| searchResult |
	| site:w3.org  |