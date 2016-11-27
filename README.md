# SavingsTargetManager
An application that helps you manage your savings goals easily!

A C#/.NET MVC5 Web application that provides an interfaces to collect savings goals for a range of different items a person would like to purchase. 

To access the savings target interface a login is provided an email address(username in the database) and a password. 
Additional functionality can also be added to provide login through Gmail/Facebook/Twitter.
Each savings goal has a title, a date, a money value and a description. 
When created, the interface lists the items created and provides the following additional functionalities:

>The list can be sorted based on Title, Date, Value or Description

>Provides pagination

>Search box to search for items based on  Title, Date, Value or Description

>There is an option to create a new item, at the top of the page.

>The Home page also displays the current Balance in the user’s savings account.

>A progress graph shows how much the user should deposit to meet his wish-list expenses.

>A link is also provided to add money to the User’s savings account

The Savings Account tab, shows the history of amount deposited in the user’s account along with the date and closing balance. 
>User has the option to add to the account from this page as well.
>The contents are displayed specific to every single login, ie, a user can only see/modify the Wishlist he/she has created and his own Savings account.
A daily email reminder can also be set up to run periodically if the user has not deposited enough money to meet his needs, once the application is hosted.
Validations are performed on User inputs along with Unit tests.

