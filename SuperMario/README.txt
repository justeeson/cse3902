

A. 

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

B. Suppressed warnings:

1. CA1811	'NormalMonsterSprite.Rows.get()' appears to have no upstream public or protected callers.	

This warning shows up for several different sprite classes. The reason is because the spritesheets being used only
have a single row and thus get Rows.get() function serves no purpose for now. However, if the spritesheet were to be 
changed in the future, then the Rows.get() command would be useful and necessary. Thus, this warning has been suppressed.

2. CA2111 	
Warning	CA2211	Consider making 'Game1.listOfObjects' non-public or a constant.	SuperMario	C:\Users\son\Source\Repos\cse3902team22\SuperMario\Game1.cs	28	Active

According to Microsoft, this warning can be surpressed when we are developing a application because we have full access to static field. We dont
need to make it to nonpublic and a constant. The reason for this is because Microsoft worries about threadsafe if multiple threads try to access
this field at the same time. However, we are only passing it once at a time to another function. Therefore, we should be ok, at least for now.

3. CA1823
Warning	CA1823	It appears that field 'Game1.graphics' is never used or is only ever assigned to.
 Use this field or remove it.	SuperMario	C:\Users\son\Source\Repos\cse3902team22\SuperMario\Game1.cs	19	Active

This warning is because Visual Studio we didn't use graphics variable at all in our game class. However, we use it in the program
class to call the game to run(). This is a game project, so it requires to draw some graphic designs. However, when we use externally, Visual 
Studio doesn't know that because it's hidden. That's why we can surpress this warning. If we remove it, the game won't run because it can't draw
any thing to the screen.

