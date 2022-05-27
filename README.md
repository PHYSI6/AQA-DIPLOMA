# AQA Diploma Project

E2E tests for TestLodge application functionality

## Application

* URL: https://www.testlodge.com/
* API URL: https://help.testlodge.com/hc/en-us/categories/203830188-TestLodge-API  

## Task

* Create test cases in TestLodge management systems
* Implement automation framework for testing of TestLodge API and UI. 
* Setup Jenkins job to trigger automation test run at 11 AM each day
* At the end of each run allure report should be generated

## What must be

* At least 7 UI tests
    * positive
    * negative
    * boundary
    * security

* At least 5 API tests
    * positive
    * negative
    * boundary

* At least 2 data-driven tests
* API calls for precondition steps
* Clearing of test data after launching a specific test/suite/test run
* Readable and understandable allure report
* C# code conventions

## Tech stack

*	.NET Core 
*	Nunit
*	Selenium
*	Fluent Assertions
*	RestSharp
*	GIT
*	AllureReports
*	Jenkins


## Patterns to be used

* Factory
* Chain of invocations
* Decorator
* Mediator

## Git strategy 

*	main — main branch 
*	develop — the main development branch. Each commit to the develop branch is a result of a feature development completion. Each commit should be a result of a merge of merge request from a feature branch.
*	feature — each new feature should reside in its own branch, which is created off of the latest develop version. When a feature is complete, it gets merged back into develop via merge request. After the feature branch is deleted.


## Naming convention 

* branches: *feature/case—id-new-awesome-feature*
* commits: *CASE-ID: Title starting with a capital letter*
