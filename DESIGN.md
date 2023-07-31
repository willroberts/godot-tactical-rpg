# Game Design Document

Technical Constraints:
- Compatible with mobile and web platforms
- Touchscreen friendly
- Travel/commute friendly (10-15 minute dungeons)

Core Gameplay Mechanics:
- Turn-based
- Control a single hero character
- Tactical RPG combat: movement, attacks, spells, items
- Camera moves with the player
- Bosses

Depth and Polish:
- Diablo II itemization and character development
- Level Design: Interactions, impediments, etc.

Scene Hierarchy:
- Main
  - Dungeon: Interconnected series of rooms
    - Rooms: 16x10  
		- Tilemap
		  - Floor tiles
		  - Impassable walls
		  - Openable interior doors
		  - Doors/Gateways to previous/next dungeon floor
		- Actors
		  - Player
		  - Enemies
		  - Loot
		  - Bosses
  - UI
