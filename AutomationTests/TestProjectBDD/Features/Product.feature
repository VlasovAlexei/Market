Feature: Product
	Test the product page functionalities 

Background: 
	Given I cleanup following data
		| Name       | Description        | Price | ProductType |
		| Monitor    | HD monitor         | 400   | MONITOR     |
		| Headphones | Noise cancellation | 300   | PERIPHARALS |

@mytag
Scenario: Create product and verify the details
Given I click the Product menu
	And I click the "Create" link
When I create product with following details
	| Name       | Description        | Price | ProductType |
	| Headphones | Noise cancellation | 300   | PERIPHARALS |
When I click the Details link of the newly created product
Then I see all the product details are created as expected
When I delete product Headphones for cleanup

@mytag
Scenario: Edit product and verify the details
Given I ensure the following product is created
	| Name    | Description | Price | ProductType |
	| Monitor | HD monitor  | 400   | MONITOR     |
Given I click the Product menu
When I click the Edit link of the newly created product
When I Edit the product details with following
	| Name    | Description           | Price | ProductType |
	| Monitor | HD Resolution monitor | 500   | MONITOR     |
When I click the Details link of the newly created product
Then I see all the product details are created as expected
When I delete product Monitor for cleanup