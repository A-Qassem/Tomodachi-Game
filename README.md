# Tomodachi Game

## Overview
`Tomodachi Game` is a multiplayer game where players enter a room and are assigned a random order (hidden from them). The objective is to guess a secret word correctly before others do. If a player guesses correctly, they win. If they guess incorrectly, all players see their guess along with how many letters were correct.

Currently, if no one guesses the word, all players lose. A future update will introduce a voting/elimination system where players can vote out one of their own, and a correct guesser will have the sole power to eliminate another player.

## Game Rules
- **Players:** Minimum `3`, Maximum `10`.
- **Gameplay:**
  - Players take turns guessing the hidden word.
  - Incorrect guesses reveal partial correctness to all players.
  - If a player guesses correctly, they win.
  - If no one guesses correctly, everyone loses (for now).
  - Future updates will introduce eliminations and strategic voting.

## Technologies Used
- `C#`
- `WinForms`
- `Sockets`
- `Async Programming`

## How to Run the Game
1. Start the **server code** on your local machine.
2. Once the server is running, launch the game.
3. Players can now register and join a game room.
4. The game currently supports multiplayer within the same machine.

## Future Enhancements
- Implement a player elimination system where:
  - Players vote to eliminate someone if no correct guess is made.
  - A correct guesser can eliminate another player.
- Expand networking to support LAN or online multiplayer.
