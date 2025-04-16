namespace CtFG{
public class Score:Board{

    /*
Hand Sequence
When a hand is played, effects will activate in the following orders. (Some Jokers may have different parts trigger at different stages: for example,  Wee Joker gain chips 'on scored' and adds chips to total 'independently').

Boss blind effects: Boss blinds such as The Flint or The Arm will activate.

'On played' Jokers: Jokers that activate when a hand is played, and before any scoring happens. Examples include  Green Joker's scaling,  DNA, and  To Do List.
Played cards scoring: Cards played and scored activate from left to right. For each card, its effects activate in the following order:
Base effect (Chips): The card activates its base effect, giving the accorded amount of Chips. Bonus chips are included in this value.
Card Modifiers: Card modifiers activate in the following order: enhancements, then seals (currently only gold seal), then editions.

'On scored' Jokers: Jokers that activate on a played and scored card will activate their effects. When multiple Jokers are triggered by the same card, they activate from left to right. Examples include  Wee Joker's scaling,  Smiley Face, and  Triboulet.
Retriggers: Each retrigger repeats the previous activation sequence (from base effects to scored card dependent Jokers) one more time. Multiple retriggers stack additively. Red seal would go first, followed by retriggering Jokers from left to right.
Held in hand abilities: Cards in hand are checked from left to right if they can activate in-hand abilities. The sequence for each card is similar to scored cards.
Enhancement (Steel card): Currently Steel is the only card modifier to activate in-hand for each hand.

'On held' Jokers: Jokers that activate on cards still held in hand will activate their effects. When multiple Jokers are triggered by a single card, they activate from left to right. Examples include  Raised Fist,  Shoot the Moon, and  Baron.
Retriggers: Same as those of scored cards, retriggers of cards in hand stack additively. Red seal will activate first, then  Mime and any other Joker copying its effect from left to right.
Joker Editions and 'Independent' Jokers: Jokers are checked from left to right to score any Edition (foil, holographic and polychrome) and activate Independent abilities:
Foil or holographic bonus.

'Independent' Jokers: Jokers that trigger after all the playing cards are scored will activate their base ability. These do not get affected by retriggers. Examples include  Fortune Teller,  The Duo, and  Blackboard.
Jokers dependent on other Jokers (currently, only  Baseball Card).
Polychrome bonus.

Consumables: When the  Observatory Voucher has been purchased, planet cards give X1.5 Mult, activating from left to right.
Plasma Deck balance: Lastly, if using the  Plasma Deck, Chips and Mult are balanced.
    */

public static int[] score = new int[2];


}
}