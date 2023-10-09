Feature: Checking Range

    Scenario: Checking coordinates within range
        Given the x coordinate is 10
        And the y coordinate is 11
        When I check for coordinates within the range
        Then the coordinates should be out of range