# cyan-tgc
<<<<<<< HEAD

This master document includes details of a Trading Card Game that underlines some elements from Hearthstone + Dungeons & Dragons. Players will build decks to face off against generated enemies. Each card represents unique abilities that can influence the game in various ways. Players can draw cards from their decks to strategize, using them to cast spells, and engage in tactical combat.
=======
Card Game Master Document
>>>>>>> c250668083fdad612f0a052196c0510c2917d89f

### 1. Functional Requirements / Major Elements
- Players can build and customize decks.
- Players can hold a maximum of 10 cards in their hand.
- The deck holds a maximum of 50 cards.
- Each card has defined abilities (damage, healing, etc.).
- Players will be able to point and click to select a card from their deck to the field.

### 2. Non-Functional Requirements
- GUI - Using Unity
- All processes executed must be within the 1000ms - 2000ms range.

### Technical Considerations
- Game will be made using Unity for their use of C# and ability to export to multiple platforms with ease.
- C# is the language we have decided to work with.
- The game will be made using MongoDB for a cloud-based NoSQL option.
- Players will not be able to interact with the database for the game.
- Database would control what cards exist.
- The game will be entirely micro-service and event based.

### Console App
Run Instructions
1. Install .NET SDK
2. Navigate to Project Directory `cd <project-folder>`
3. Restore Dependencies `dotnet restore`
4. Build the Project `dotnet build`
5. Run the Application `dotnet run`

### Unit Testing
Test Instructions
1. Install Python
1. Navigate to Tests Directory `cd app/tests`
2. Run `python -m unittest tests.py`