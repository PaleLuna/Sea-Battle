Feature: Parsing Shot Coordinates

    Scenario: Entering correct shot coordinates
        Given I enter the string "9,0"
        When I try to parse shot coordinates
        Then the x and y coordinates should be valid