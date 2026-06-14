# SOLID Principles

## Overview

SOLID is a set of five object-oriented design principles that help developers build maintainable, scalable, and loosely coupled software applications.

## Principles Implemented

### Single Responsibility Principle (SRP)

A class should have only one responsibility and one reason to change.

**Implementation:** Student Management System

* Student → Stores student information.
* StudentRepository → Handles saving student data.
* StudentReportGenerator → Generates student reports.

### Open/Closed Principle (OCP)

Software entities should be open for extension but closed for modification.

**Implementation:** Calculator Application

* CalculatorOperation → Common interface.
* Addition, Subtraction, Multiplication → Extend functionality without modifying existing code.
* Calculator → Executes operations.

### Liskov Substitution Principle (LSP)

Objects of a subclass should be replaceable with objects of their superclass without affecting program behavior.

**Implementation:** Banking Application

* WithdrawableAccount → Base class.
* SavingsAccount and CurrentAccount → Subclasses.
* BankingService → Works with both subclasses without modification.

### Interface Segregation Principle (ISP)

Clients should not be forced to depend on methods they do not use.

**Implementation:** Bear Keeper System

* BearCleaner
* BearFeeder
* BearPetter

Separated responsibilities into smaller interfaces.

### Dependency Inversion Principle (DIP)

High-level modules should depend on abstractions rather than concrete implementations.

**Implementation:** 

* Keyboard → Abstraction
* StandardKeyboard → Implementation
* Windows98Machine → Depends on abstraction instead of concrete class.

## Learning Outcome

Implemented and executed practical Java programs for all five SOLID principles and understood how they improve code quality, maintainability, flexibility, and scalability.

## Conclusion

SOLID principles help create clean, reusable, and maintainable software by reducing coupling and improving the overall design of applications.

