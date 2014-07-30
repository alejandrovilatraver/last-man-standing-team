last-man-standing-team
======================

ICFP contest Last Man Standing Team solution 

It is a team of just one person: Alejandro Vila Traver.

The Lambdaman AI is based on just three items:

	*Lambdaman previous direction.
	*Ghost position.
	*Number of bifurcation present in the alternative paths, only taking into account 
	  those branches within a range of distances from lambdaman position.

The rest of the posible factors are not present because of a lack of time.

The lambdaman solution have been encoded with the help of wisual studio 2010, c# and wpf, the visual studio project is in the present directory. I have used those to build just a bunch of helper functions which let me create my assembler code that is simply generated as the Text property of a textBox that you can copy. 
I have used only the original resources to try out and debug my code.

The ghost AI is based in a very simple strategy:

	*In a first stadium the ghost tries to spread.
	*In a second -and longer- stadium the ghosts try to get lambdaman.
	*Repeat the sequence.

As for lambdaman strategy everything else has been left out because of the lack of time.
Code have been generated directly in ghost assembly.

Those are not exactly the same files that i sent to the contest, I have ordered my code and comments only a little bit, just for legibility purposes, but my code is untouched. I have included the original files in the "originalFiles" directory.


