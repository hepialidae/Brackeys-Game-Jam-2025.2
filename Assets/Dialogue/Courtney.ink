// Tag numbers are as follows: doughIndex, creamIndex, toppingIndex
-> Default1

=== Default1 ===
# 2
# 99
# 99
A chocolate biscuit, please!
+ [Okay.]
    -> DONE
+ [What?]
    -> loop
= loop
A chocolate biscuit with nothing on it, please.
+ [Okay.]
    -> DONE
+ [What?]
    -> loop
    
=== Default2 ===
# 1
# 99
# 99
I'd like a strawberry biscuit.
+ [Okay.]
    -> DONE
+ [What?]
    -> loop
= loop
A strawberry biscuit with nothing on it.
+ [Okay.]
    -> DONE
+ [What?]
    -> loop

=== Default3 ===
# 0
# 99
# 99
Hi! A vanilla biscuit.
+ [Okay.]
    -> DONE
+ [What?]
    -> loop
= loop
Just a vanilla biscuit with nothing on it.
+ [Okay.]
    -> DONE
+ [What?]
    -> loop

=== Default4 ===
# 0
# 99
# 99
I need sugar to work! All the chocolate you have, please!
+ [Okay.]
    -> DONE
+ [What?]
    -> loop
= loop
A chocolate biscuit with chocolate whipped cream and a chocolate on top.
+ [Okay.]
    -> DONE
+ [What?]
    -> loop