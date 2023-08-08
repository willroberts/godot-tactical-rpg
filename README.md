# godot-tactical-rpg

Attempting to create a Tactical RPG (e.g. Tactics Ogre, Banner Saga) with Godot 4.

## Game Design

Characters:
- Paladin, Knight, Warrior, etc.
- Ranger, Amazon, etc.
- Wizard, Witch, Sorceror, etc.
- Necromancer
- Rogue, Assassin, etc.
- Barbarian
- Druid

## Choosing a Sprite Resolution

Characters:
- Final Fantasy 1 (NES): 17x26
- Final Fantasy 2 (SNES): 16x24
- Advance Wars (GBA): 14x16
- Fire Emblem (GBA): 16x20
- Tactics Ogre (GBA): 16x32

Tiles:
- Tiny Dungeon: 16x16

## Godot Naming Conventions

From Godot docs:

> C#: Classes, export variables and methods use PascalCase, private fields use `_camelCase`, local variables and parameters use camelCase (See C# style guide).

## OS X Keyboard Shortcuts

Offline Docs: Option + Space
Find Highlighted Text in Offline Docs: Option + Shift + Space
Show Intellisense for current method: ??? (Ctrl-Space on Windows)

## Design Patterns

- Call Down, Signal Up
  - Can use GetNode<Foo>("MyNode").SomeFunc() just fine.
  - Should avoid GetParent(), and instead use signals to avoid circular dependency.
- Custom Resources
  - Scene can have a variable with an empty array (e.g. OnDeathEffects)
  - Custom Resources can be slotted in to modify Scene behavior
  - Can also be data resources (e.g. character stat sheets) or save files
  - Can also import data from spreadsheets as CSV into Tables
- Prefer composition over inheritance, especially with Scene packaging
- Use static Option/Param classes to avoid long method signatures
  - Copy before writing to avoid side effects
- When to use `Godot.Collections.Array<T>` vs `T[]`
  - C# `T[]` arrays have fixed length.
  - Godot `Array<T>` arrays are actually lists, with `Add()` and `Remove()` methods.
  - Some Godot functions (e.g. `AStar.CalculatePointPath()` return packed arrays, i.e. `Vector2[]`.
- Finite State Machine
  - Use FSM node script with Ready/Process/UnhandledInput authortiy
  - Has a method to transition state to new state (idle, walk, run, etc.)
  - FSM runs the Ready/Process/UnhandledINput code for that state only
- Async: Use `Callable` and `FuncRef` types for callbacks on signals
- Signal Bus
  - Create node script with signal registrations
  - Use Project Settings > Autoload to register on startup
- Object Pool
  - Dictionary of instantiated scenes, using the scene type as a key
  - Can be performant/efficient when using GC and not just RefCounted types
- Debug Component Nodes
  - Component node that draws something when attached to a parent
  - GetParent(), or use Owner property to get root node of scene
