EXTERNAL endOrder()
EXTERNAL leaveCounter()

=== Good1 ===
Wow, this is wonderful! Thank you!
~ endOrder()
-> END

=== Good2 ===
Compliments to the chef! Oh, wait, that's you!
~ endOrder()
-> END

=== Good3 ===
Nom nom nom...thanks!
~ endOrder()
-> END

=== Okay ===
Ummm...thank you!
~ endOrder()
-> END

=== Bad ===
If I were a famous British chef, I'd be screaming at you right now.
~ endOrder()
-> END

=== Special1 ===
# 2
# 0
# 2
# 18.5
I've been loving bananas and vanilla cream recently. Oh, and add a chocolate base!
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A chocolate biscuit with vanilla whipped cream and a banana on top.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop

=== Special2 ===
# 0
# 0
# 0
# 18.5
Do you know about strawberry shortcakes? It's a vanilla base with vanilla whipped cream and a strawberry on top!
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A vanilla biscuit with vanilla whipped cream and a strawberry on top.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop

=== Special3 ===
# 1
# 1
# 5
# 18.5
I'm feeling kind of blue today. But I guess biscuits and whipped cream should be pink.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A strawberry biscuit with strawberry whipped cream and blueberries.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
