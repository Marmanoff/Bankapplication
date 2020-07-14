# General description
You must build a banking application. The application uses a database to store accounts.
Each account has: Name, Current balance and a Transaction list. The transaction list is a list of each amount
deposited or withdrawn. The application must be a console application where you interact using keyboard input.

# Tasks
* The application is started. [Ask for account name]

* The application must ask for the name of the bank account.

* You must then enter the name of the account.

* If the account name dont exist. One will be created.

* If an empty account name is entered, the application proceeds to the step [Display bank's total balance]

* The application will ask for an amount to deposit or withdraw. You must now enter an amount that is an integer, positive (deposit) or negative (withdrawal) or zero. 

* If you enter an incorrect amount, ie. a text string that is not an integer as defined above, it must notify you that the amount is incorrect and ask for the amount again.

* The application should now return to [Ask for account name] and the user is given the opportunity to make new deposits in bank accounts.

* [Display of the bank's total balance] The application now shows the sum of all bank accounts' balance. Waiting for the user to press ENTER before finally closing.

## DB related
* After the application runs there should be a database called "Bank", and in the database there should be a collection called "BankAccount".

## Extra task A
* Implement the main task using any dependency injection container

## Extra task B
* Use mongodb's aggregation framework to solve some part of the main task.

## Extra task C
* Write unit tests that exercise and verify the code against the database.