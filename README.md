# Conway's Game of Life (Forth)
## Description

John Conway's legendary cellular automaton implemented in Forth.

Tested to work with Gforth 0.7.9_20200709. Get it from [here](https://www.complang.tuwien.ac.at/forth/gforth/Snapshots/0.7.9_20200709/ "Gforth 0.7.9_20200709 from Vienna University of Technology's Complang institute").

## Usage
To start simply run ``gforth .\game_of_life.fs``.

## Features
- Completely controllable via Forth CLI
  - Short, speaking commands	
- Menus for easier operation
  - Help menu, pattern overview
- Addressing of every single cell possible
  - Set state to alive/dead
  - Selection verifiable (printing ? at selected cell)
- User-defined world size
  - Resizing possible
- All user inputs are validated
  - "wrap-around" if accessing cell out of world boundaries
- Create and restore backup of world & parameters
  - Backup can be viewed separately
  - Automatic resize if sizes differ
  - "Overwrite" warning if backup already exists
- Evolution 
  - Evolutionary speed adjustable
  - Pause & resume, reset
  - Change cell states at any time
  - Fast-forward/Advance evolution
- Statistics
- Direct execution after call (autostart) 
- Various patterns already predefined

## Screenshots
### Start screen
<img src="https://user-images.githubusercontent.com/52766087/151211244-7c5745c0-ea52-4b9f-8957-487a016abb8f.png" width=75% height=75%>

### Evolving life
<img src="https://user-images.githubusercontent.com/52766087/151211962-ec8c5197-04c8-41f3-b8ec-6972ef2c6537.png" width=70% height=70%>

### Further evolved life
<img src="https://user-images.githubusercontent.com/52766087/151212341-db2358b4-758b-4b69-b05e-035bb31cbf40.png" width=70% height=70%>

### Special pattern
<img src="https://user-images.githubusercontent.com/52766087/151212664-2f775403-8e71-4522-a5b2-c5d3e282e4ba.png" width=70% height=70%>


