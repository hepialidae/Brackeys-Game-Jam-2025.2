EXTERNAL endOrder()
EXTERNAL leaveCounter()

=== Good1 ===
I knew coming here wouldn't be a waste of time.
~ endOrder()
-> END

=== Good2 ===
This place is quite the hidden gem.
~ endOrder()
-> END

=== Good3 ===
I'm glad this place isn't filled with other tourists.
~ endOrder()
-> END

=== Okay ===
Mm. Not bad.
~ endOrder()
-> END

=== Bad ===
I've seen better.
~ endOrder()
-> END

=== Special1 ===
# 2
# 2
# 6
On my travels, I once saw a yellow river running down a brown mountain.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
Pile the chocolate up high, then add yellow syrup.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop

=== Special2 ===
# 0
# 99
# 7
When I go hiking, I always pack bread and jam as a snack, but I forgot to this time. Could you make me something similar?
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A vanilla biscuit with jam.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop

=== Special3 ===
# 2
# 99
# 4
When I visited a village up in the snowy North, the villagers and I shared mugs of hot chocolate flavored with caramel. Could you help me relive that warmth?
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A chocolate biscuit with caramel on top.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
