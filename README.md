# cyan-tgc

Card Game Master Document

This master document includes details of a TGC that underlines some elements from Hearthstone + Dungeons and Dragons. This clone of the two games will have a PvE style of gameplay in which players will build decks to face off against computer generated enemies. Each card represents unique abilities, spells, or characters that can influence the game in various ways. Players can draw cards from their decks to strategize, using them to cast spells, summon allies, and engage in tactical combat while managing hero health and resources. An HP and Mana system will be implemented for heroes.

Functional Requirements / Major Elements:
•	The max number of players that can play at a time will be four.
•	Players can build and customize decks.
•	Players can hold 10 cards in their deck at a time.
•	Players draw cards at the start of the game and in their turns.
•	Each card has defined abilities (damage, healing, etc.)
•	Abilities directly affect gameplay and require clear definitions.
•	Players will be able to point and click to select a card from their deck to the field.
•	Players will be able to use utility items.
•	Players will be able to restore health with potions.
•	Players will be able to restore mana with potions.
•	Players will be able to choose weapons.
•	Each player will be given the option to pick a hero they would like to play as, which will grant them a special ability that will be implemented separately for each hero. A quick reference to using the ultimate ability in Overwatch games.
•	Heroes’ attributes influence gameplay strategies.
•	The special ability will have a cooldown period enabled with the intention of not making players too overpowered.

 Non-Functional Requirements:
•	GUI – Using Unity
•	All processes executed must be within the 1000ms – 2000ms range.
•	Rest of the requirements…TBD

Technical Considerations:
•	Game will be made using Unity for their use of C# and ability to export to multiple platforms with ease.
•	C# is the language we have decided to work with.
•	We aim to release this as a web application, with plans of releasing it on mobile platforms.
•	The game will be made using MongoDB for a cloud-based NoSQL option.
•	Players will not be able to interact with the databases for the game. 
•	Databases would control what cards exist, the cards in players’ decks, and the players existing within the playerbase.
•	The game will be entirely micro-service and event based.
•	No PVP option is explored during the early stages of the game. We might go down that route and release a PVP update in the future. 
•	As for an API, the ideal potential would be to replicate or use APIs from Hearthstone.
•	Implementation of an abstract system for card effects. Using object-oriented principles for heroes and cards, encapsulating properties and methods.

Instructions: (Jordan, since you’ve made the GUI, you probably have a better idea so feel free to add some bullet points below)





Story:
Set in the early 1400’s, the family of a merchant struggled through poverty. Matthew, Linda, and their son, William built up the courage and decided to speak to the king in efforts to highlight his lack of support for the commonfolk. The smug king, hiding his true intentions, made a false promise to send resources to their village while secretly scheming to eradicate all those who rebel or speak ill of him. A garrison was sent to Matthew’s village with the intention of killing everyone who resided there. Linda watches as her family, friends, and livelihood go up in flames and is the sole survivor of the genocide. Wounded severely with little time to live, her immense pain and sorrow drive her to lay a curse on the king and on the land that was cruel to her and everything she knew. 
A couple decades have passed, and the king has died. But the curse remains on the land which now houses people who were never a part of the mistreatment of the commonfolk. The heir to the throne, Alastair, son of the departed king, now rules the land. Unlike his father, his efforts are to ensure the well-being of the commonfolk and for the kingdom to thrive under him. The curse brings along creatures that run rampant, killing anything that moves. This has affected the agricultural state of the land as well as the population growth. As a last-ditch effort to save his kingdom, the king assembles a highly skilled squadron to eliminate these villainous creatures, locate the source of the curse, and to get rid of it. Our main heroes (yet to be named) embark on a journey through the land on a hunt for Linda’s spirit while eliminating foes on the way. The climatic ending includes the players fighting her spirit, defeating it, and then Linda’s spirit having a moment of clarity. Realizing that what she lived through is now the reality, on a much larger scale for other people, all because of the curse she put on the land. Her spirit finds peace and lifts the curse, our heroes victorious with their task, and the king makes preparations to restore the land to all its glory.
