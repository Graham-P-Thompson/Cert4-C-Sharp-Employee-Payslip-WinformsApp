# Cert4-C-Sharp-Employee-Payslip-WinformsApp

## Description

I completed this project as part of my IT certificate 4 (programming) at Tafe in 2023.

This project is object oriented based. Built using C# and Winforms, it loads in 2 tax scales from .csv files and employee data from another .csv file,
it then allows the user to enter the hours they have worked and displays a payslip for them based on whether or not they are claiming,
the tax free threshold. The user can then save the generated payslip information to a timestamped .csv file.

The project requirements were to:
- Design the application with the use of multiple UML diagrams:
 - Use case diagram
 - Activity diagram
 - Sequence diagram
 - Communication diagram
 - State diagram
 - Class diagram
- Build the application using Winforms
- Research and compare 3rd party libraries that would make working with .csv files easier.
- Create spike tests to compare two chosen csv libraries and make a decision on what one to use and implement into our code
- Research and compare different testing frameworks
- Carry out multiple types of testing:
 - Unit testing
 - Integration testing
 - Functional testing

I have also arranged my file structure to create a more organised workflow into persistence, domain and ui layers.

## Dependencies

- [Winforms](https://github.com/dotnet/winforms)
- [CsvHelper](https://www.nuget.org/packages/CsvHelper) Nuget package
- [Nunit](https://nunit.org) testing framework
