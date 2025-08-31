// Tag numbers are as follows: doughIndex, creamIndex, toppingIndex, price
EXTERNAL leaveCounter()

=== Default1 ===
# 2
# 99
# 99
# 10
A chocolate biscuit, please!
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A chocolate biscuit with nothing on it, please.
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
    
=== Default2 ===
# 1
# 99
# 99
# 10
I'd like a strawberry biscuit.
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A strawberry biscuit with nothing on it.
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop

=== Default3 ===
# 0
# 99
# 99
# 10
Hi! A vanilla biscuit.
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
Just a vanilla biscuit with nothing on it.
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop

=== Default4 ===
# 2
# 2
# 3
# 20
All the chocolate you have, please!
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A chocolate biscuit with chocolate whipped cream and a chocolate on top.
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop

=== Default5 ===
# 2
# 0
# 0
# 18.5
Could I have a chocolate biscuit with vanilla whipped cream and a strawberry on top?
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A chocolate biscuit with vanilla whipped cream and a strawberry on top.
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
    
=== Default6 ===
# 1
# 99
# 8
# 15
Hi! A strawberry biscuit with sprinkles!
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A strawberry biscuit with sprinkles on top.
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop

=== Default7 ===
# 0
# 2
# 6
# 17
Hmmm...A white biscuit and brown whipped cream sounds good. Oh, and add some yellow syrup on top!
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A vanilla biscuit with chocolate whipped cream and honey.
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop

=== Default8 ===
# 1
# 0
# 7
# 17
I want the strawberry biscuit with vanilla whipped cream. Drizzle some strawberry jam on it too!
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A strawberry biscuit with sprinkles on top.
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop

=== Default9 ===
# 2
# 99
# 1
# 13.5
Everything's better with a cherry on top! A chocolate biscuit with a cherry, thank you!
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A chocolate biscuit with a cherry on top.
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop

=== Default10 ===
# 2
# 2
# 2
# 18.5
I love banana-flavored chocolate milk, so I'd like a chocolate biscuit with chocolate whipped cream and a banana!
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A chocolate biscuit with chocolate whipped cream and a banana on top.
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop

=== Default11 ===
# 0
# 0
# 4
# 20
A vanilla biscuit with vanilla whipped cream and caramel, please.
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A vanilla biscuit with vanilla whipped cream and a caramel on top.
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop

=== Default12 ===
# 1
# 0
# 5
# 18.5
I'm craving some color today. A strawberry biscuit with vanilla whipped cream and blueberries will do!
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A strawberry biscuit with vanilla whipped cream and blueberries on top.
+ [Okay.]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop