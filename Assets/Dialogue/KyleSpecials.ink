EXTERNAL endOrder()
EXTERNAL leaveCounter()

=== Good1 ===
This is just as good as the music you play!
~ endOrder()
-> END

=== Good2 ===
Wow! This is delicious!
~ endOrder()
-> END

=== Good3 ===
Couldn't be better!
~ endOrder()
-> END

=== Okay ===
Thank you!
~ endOrder()
-> END

=== Bad ===
I don't think this is what I ordered...
~ endOrder()
-> END

=== Special1 ===
# 0
# 2
# 99
# 15
I'll have a...vanilla biscuit with chocolate cream. Do you mind if I work on my music here? 
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A vanilla biscuit with chocolate cream.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop

=== Special2 ===
# 1
# 1
# 3
# 20
I heard strawberries and chocolate go well together. Coud I get a strawberry biscuit, strawberry whipped cream, and that chocolate topping?
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A strawberry biscuit with strawberry whipped cream and a chocolate on top.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop

=== Special3 ===
# 2
# 99
# 3
# 15
I'm craving chocolate today, but could you leave out the whipped cream?
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A chocolate biscuit with a chocolate on top.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop