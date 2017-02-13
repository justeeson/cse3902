Suppressed warnings:

1. CA1811	'NormalMonsterSprite.Rows.get()' appears to have no upstream public or protected callers.	

This warning shows up for several different sprite classes. The reason is because the spritesheets being used only
have a single row and thus get Rows.get() function serves no purpose for now. However, if the spritesheet were to be 
changed in the future, then the Rows.get() command would be useful and necessary. Thus, this warning has been suppressed.

2. 


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