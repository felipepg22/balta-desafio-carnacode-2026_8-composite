![ES-3](https://github.com/user-attachments/assets/ba89fbdc-3f30-4c35-8358-2990d871ead1)

## 🥁 CarnaCode 2026 - Desafio 08 - Composite

Hi, I'm Felipe Parizzi Galli, and this is the space where I share my learning journey during the **CarnaCode 2026** challenge, hosted by [balta.io](https://balta.io). 👻

Here you'll find projects, exercises, and code that I'm building throughout the challenge. The goal is to get hands-on, test ideas, and document my growth in the tech world.

### About this challenge

In the **Composite** challenge, I had to solve a real-world problem by implementing the required **Design Pattern**.
Throughout this process, I learned:

- ✅ Software Best Practices
- ✅ Clean Code
- ✅ SOLID
- ✅ Design Patterns

## Problem

A content management system needs to build menus with simple items and nested submenus.
The current code handles individual items and groups differently, making recursive operations more complex.

## About CarnaCode 2026

The **CarnaCode 2026** challenge consists of implementing all 23 design patterns in real-world scenarios. Across the 23 challenges in this journey, participants practice identifying non-scalable code and solving problems using industry-standard patterns.

### eBook - Design Pattern Fundamentals

My main source of knowledge during the challenge was the free eBook [Fundamentos dos Design Patterns](https://lp.balta.io/ebook-fundamentos-design-patterns).

## How Composite Was Implemented

The project applies Composite to represent a hierarchical CMS menu as a tree where single links and groups are treated through a common base type.

- `Component`: `MenuSystem` (`DesignPatternChallenge/src/Models/MenuSystem.cs`) defines the shared contract with `Render(int indent = 0)` and `CountItems()`, plus common state like `Title`, `Icon`, and `IsActive`.
- `Leaf`: `MenuItem` (`DesignPatternChallenge/src/Models/MenuItem.cs`) represents a single clickable entry with `Url`, renders itself, and returns `1` in `CountItems()`.
- `Composite`: `MenuGroup` (`DesignPatternChallenge/src/Models/MenuGroup.cs`) stores children as `List<MenuSystem>`, exposes `Add`/`Remove`, renders recursively (`child.Render(indent + 1)`), and aggregates counts recursively (`count += child.CountItems()`).
- `Client`: `MenuManager` (`DesignPatternChallenge/src/Managers/MenuManager.cs`) keeps root nodes as `List<MenuSystem>` and executes tree-wide operations like rendering and total counting without duplicating traversal logic in the client code.

In `Challenge.cs`, the menu is composed with nested groups (for example, `Products` containing `Clothing`) and then processed as one structure via `RenderMenu()` and `GetTotalItems()`, which demonstrates uniform treatment of leaf and composite nodes.
