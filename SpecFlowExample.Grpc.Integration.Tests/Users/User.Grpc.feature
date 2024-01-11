@Grpc
Feature: User Grpc

Scenario: Get User
	Given a user exists with id "123" and name "Daniel"
	When a user is requested for id '123'
	Then a Grpc response is returned with code 'OK'
	And the users name is 'Daniel'
	