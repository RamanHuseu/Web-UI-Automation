Steps to Complete the Task:

1. Project Setup
Set up a new .NET project in Visual Studio for Web UI automation:
Create a Class Library project using .NET 8.0.
Install the necessary NuGet packages:
Selenium.WebDriver
Selenium.WebDriver.ChromeDriver
NUnit
NUnit3TestAdapter (for running tests in Visual Studio)

2. Writing the Tests
Automate a simple scenarios listed below using Selenium and NUnit.

Test Case 1: Verify Navigation to 'About EHU' Page
Scenario: Verify that the "About EHU" page loads correctly.
URL: https://en.ehu.lt/
Steps:
Navigate to https://en.ehu.lt/.
Click on the "About EHU" link in the main navigation menu.
Expected Result: The user is redirected to https://en.ehu.lt/about/. The page title is "About EHU", and the content header displays "About European Humanities University".



Test Case 2: Verify Search Functionality
Scenario: Verify that the search bar returns results for a valid search term.
URL: https://en.ehu.lt/
Test Data:
Search Term: study programs
Steps:
Navigate to https://en.ehu.lt/.
Enter study programs into the search bar.
Click the "Search" button or press "Enter".
Expected Result: A search results page is displayed, and the page URL includes /?s=study+programs. The search results include links to pages related to study programs at EHU.

Test Case 3: Verify Language Change Functionality
Scenario: Verify that the website language can be changed from English to Lithuanian.
URL: https://en.ehu.lt/
Steps:
Navigate to https://en.ehu.lt/.
Click on the language switcher and select "Lietuvių" (Lithuanian).
Expected Result: The user is redirected to the Lithuanian version of the site (https://lt.ehu.lt/), and the page content appears in Lithuanian.

Test Case 4: Verify Contact Form Submission
Scenario: Verify that the contact form can be submitted successfully with valid input.
URL: https://en.ehu.lt/contact/
Steps:
Navigate to https://en.ehu.lt/contact/.
Verify the list of contacts is available:
E-mail: franciskscarynacr@gmail.com
Phone (LT): +370 68 771365
Phone (BY): +375 29 5781488
Join us in the social networks: Facebook Telegram VK

Expected Result: All fields are displayed and contact info is visible for the user.

