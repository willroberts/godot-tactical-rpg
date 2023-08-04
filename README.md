# godot-tactical-rpg

Attempting to create a Tactical RPG (e.g. Tactics Ogre, Banner Saga) with Godot 4.

## Godot Naming Conventions

> C#: Classes, export variables and methods use PascalCase, private fields use _camelCase, local variables and parameters use camelCase (See C# style guide). Be careful to type the method names precisely when connecting signals.

## OS X Keyboard Shortcuts

Offline Docs: Option + Space
Find Highlighted Text in Offline Docs: Option + Shift + Space
Show Intellisense for current method: ??? (Ctrl-Space on Windows)

## Z Indices

0. Tilemap Floor
1. Tilemap Props
2. Grid Debug Lines, Cell highlighter
3. Items
4. Player, Enemies
5. UI

## Design Patterns

- Call Down, Signal Up
  - Can use GetNode<Foo>("MyNode").SomeFunc() just fine.
  - Should avoid GetParent(), and instead use signals to avoid circular dependency.
- Custom Resources
  - Scene can have a variable with an empty array (e.g. OnDeathEffects)
  - Custom Resources can be slotted in to modify Scene behavior
  - Can also be data resources (e.g. character stat sheets) or save files
- Prefer composition over inheritance, especially with Scene packaging
