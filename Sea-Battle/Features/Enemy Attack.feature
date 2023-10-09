Feature: Enemy Attack

    Scenario: Attempting enemy attack
        Given the number of enemy ships is 5
        And the opponent's game board is not initialized
        When the opponent attempts to attack
        Then the enemy attack should not be successful