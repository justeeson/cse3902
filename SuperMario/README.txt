Suppressed warnings:

1. CA1811	'GoombaSprite.Rows.get()' appears to have no upstream public or protected callers.	

This warning shows up for several different sprite classes. The reason is because the spritesheets being used only
have a single row and thus get Rows.get() function serves no purpose for now. However, if the spritesheet were to be 
changed in the future, then the Rows.get() command would be useful and necessary. Thus, this warning has been suppressed.

2. MSBUILD : warning CA1823: Microsoft.Performance : It appears that field 'Game1.graphics' is never used or is only ever assigned to. Use this field or remove it.

This warning can be ignored because Game1.graphics must be assigned to in order for the game to run, but it is not used after assignment

3. CA1814	'Mario.StateArray' is a multidimensional array. Replace it with a jagged array if possible.

This warning showned up since we used multidimensional array, instead of jagged array. The reason we didnt change the multidimensional array is it store linearly in the memory, 
which allow easier access and easier to modify. Jagged array which is an array of array, which is not easy to modify and take mutli blocks of memory. The Reason Visual Studio
suggest to change to jagged array is it will improve preference.

Keybindings:

up = Chage mario to idle/jumping state.
down = Chage mario to idle/crouching state.
left, right = Change mario between left running, left idle, right idle, and right running state.
y = Change mario to a small state.
u = Change mario to a big state.
i = Change mario to a fire state.
o = Change mario to a dead state. 
z = Question block turns into used block
x = Brick block disappears
c = Hidden block turns into used block
q = Quit program.
R = Reset program.