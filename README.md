# InfinityScroll
Example for an infinity scrolling data table in asp.net core


1. Create a normal view that contains the html-table eg. via scaffolding
2. Create a new Partial View and move all the logic that creates the table rows in this view.
3. Add a reference to InfinityScroll.js to the view and create a variable with the constructor of InfinityScroll
4. Create an action in the controller, that delivers the data for the partial view and add a few additional lines of code.


