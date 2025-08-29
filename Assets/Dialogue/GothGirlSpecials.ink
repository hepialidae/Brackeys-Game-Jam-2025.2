EXTERNAL endOrder()
EXTERNAL leaveCounter()

=== Good1 ===
Mmm...this makes me melt.
~ endOrder()
-> END

=== Good2 ===
Oh, this is truly one of a kind!
~ endOrder()
-> END

=== Good3 ===
Just as good as retail therapy!
~ endOrder()
-> END

=== Okay ===
Pretty good.
~ endOrder()
-> END

=== Bad ===
Are you sure this is for me?
~ endOrder()
-> END

=== Special1 ===
# 1
# 0
# 8
My girlfriend really likes the color pink...a pink biscuit, white cream, and a crown of rainbow sprinkles would suit her well.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A strawberry biscuit with vanilla whipped cream and rainbow sprinkles.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop

=== Special2 ===
# 0
# 0
# 3
Contrasting colors can really make an accessory stand out, like dark chocolate on top of fluffy white clouds and a white biscuit.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A vanilla biscuit with vanilla whipped cream and a chocolate on top.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop

=== Special3 ===
# 2
# 99
# 5
I found a beautiful ring in a shop once - a gorgeous blue sapphire on top of a black band. Could you make me something similar?
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A chocolate biscuit with blueberries on top.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop