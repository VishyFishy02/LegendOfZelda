#Sprint 5

CONTROLS: 
-WASD and arrow keys are used to move, NOTE: When in the inventory, WASD and arrow keys are instead used to move the cursor around the inventory
-B is used to use the item equipped to the B-button in the HUD.
When pulling up the inventory, hovering the selector cursor over one of the projectiles and then exiting the inventory will equip it to link, 
in addition to being able to use the numerical keys to swap the current projectile.
-Clicking on the right half of the room switches to the next room, and clicking on the left half of the room switches to the previous room.
-Keys Z and N are used to attack with the sword.
-H is to pause/unpause
-L is to open the inventory/close the inventory.

NOTE: Using mouse room switching can let you get to a room with all of the items in the game(room 18) to
have all items available. Go here if you ever need more bombs, arrows(rupees), health, or bombs.

BUGS:

- Knockback will sometimes have odd behavior and send Link out of bounds. Also he occasionally can get stuck on a corner.


PERTINENT information about our implementation:
The main things that were added in this sprint was a boss rush mode. There is an entrance to new rooms
at the top of the old man room.  It will  generate a random  graph of 5 random rooms. Defeating all enemies
will make doors to other rooms appear. Stepping in a new room will always lock Link into that room. Defeated
rooms always stay unlocked. Once Link has defeated all 5 rooms, a white puzzle door appears in whatever room
he is in currently. Going through that door leads to a special boss against the Old Man. Defeating the old
man gives Link access to the Master Sword, which grants him the sword beams for his normal attacks.


INFO ON NEW ENEMIES:
DIGDOGGER:Has an implementation to follow Link around. Will be stunned for a bit of time when hit by a
boomerang. Can only be damaged by boomerang.

DODONGO: Can only be damaged by sword/bombs. If a bomb is used, the Dodongo must be facing the direction
of where the bomb is coming from to take damage. Two bomb hits will kill it.

GOHMA: Only takes damage when the eye is open, only takes damage from sword/bows. 
NOTE: Can be kind of hard to defeat, recommend grabbing all of the rupees in room 18 to load up on ammo
if needed to kill it for now.

OLD MAN BOSS: Is simply the old man sprite, but he now moves around and shoots out orb projectiles as 
he moves.

OTHER KEY DETAILS:
Collision detector uses exhaustive checking to compare every object in room with every other object in room, once a collision is detected,
the two objects are passed to the collision delegator.

The delegator utilizes the ISprite sub-interfaces to identify each generic room object and then select the apropriate collsion handler

Collision handling is done with 8 pair-wise handlers

Room bounding is done with invisible blocks

The room class was based on slides from class, and it has Update(),
Draw(), and GetObjects() method. The roomloader parses an xml file and returns an object of type room. Collision detection is 
implemented using the Rectangle intersect method. 

we've also added a space at the top of the game which will display menu information





Intentional omissions:

sliding doors are replaced with locked doors
The room which contains a pushable block to access the old man room has been modified to accomodated for this. The dragon room 
has also been changed to have a key. 

Items that are only displayed once a room has been cleared are now  displayed in the room pre-clear state.



