# Battleships Game - Programming Project

## Overview
This project is a digital version of the classic "Battleships" game, developed using C# and Windows Forms. The game includes features such as single-player mode against an AI, multiplayer over a network, and a high score tracking system. 

The primary goal is to destroy your opponent's fleet of ships before they destroy yours, with gameplay on a 10x10 grid. The AI has intelligent targeting and there is a simple registration and login system to keep track of scores.

## Features
- **Single-player mode**: Play against an AI opponent.
- **Multiplayer mode**: Play against friends over a network.
- **High score tracking**: The top 10 players are stored and displayed based on game completion times.
- **AI with adaptive difficulty**: The AI improves its accuracy when it detects ships.
- **User Authentication**: Players must register and log in to keep track of their scores.
- **Responsive UI**: Simple and intuitive interface for easy navigation and gameplay.
- **No Internet Required for AI mode**: Play offline against the AI.

## Game Rules
- Players take turns firing at each other’s fleet on a 10x10 grid.
- Each player has 5 ships: Carrier (5 tiles), Battleship (4 tiles), Cruiser (3 tiles), Submarine (3 tiles), Destroyer (2 tiles).
- The first player to sink all of the opponent’s ships wins.

## System Requirements
- **OS**: Windows 10 or later
- **Development Tools**: Visual Studio 2022 with .NET framework 5
- **Hardware**: Quad-core CPU, 4GB RAM, Monitor (minimum resolution 1366x768)


## How to Play
1. **Login**: Register and log in to start playing. 
2. **Main Menu**: Choose to play against the AI, play with friends, view instructions, or view high scores.
3. **Game Play**: Place your ships on the grid, and then take turns with your opponent to fire at each other's ships.
4. **Victory Condition**: Sink all opponent's ships to win. Your score (time taken) will be stored if you win.
5. **Multiplayer Mode**: Requires both players to be on the same network.

