EXTERNAL endOrder()
EXTERNAL leaveCounter()

=== Good1 ===
This looks delicious! Thank you so much!
~ endOrder()
-> END

=== Good2 ===
Mmm...this smells so good! I should bring Gigi here next time!
~ endOrder()
-> END

=== Good3 ===
Good food, good ambience...if you set up a WiFi router, I'd be here 24/7!
~ endOrder()
-> END

=== Okay ===
Ah! Thank you!
~ endOrder()
-> END

=== Bad ===
Ah! Um...thank you...?
~ endOrder()
-> END

=== Special1 ===
# 0
# 99
# 99
People say I'm boring, but even "boring" things can be delicious! One vanilla biscuit, please!
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
Just a simple vanilla biscuit, please!
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop

=== Special2 ===
# 0
# 99
# 0
Berries are the best! I want three of the same berry on my vanilla biscuit.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A vanilla biscuit with blueberries, please!
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop


=== Special3 ===
# 1
# 99
# 6
I've been coding for too long...I need something sweet. How about a strawberry biscuit with honey on top?
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A strawberry biscuit with honey on top.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop