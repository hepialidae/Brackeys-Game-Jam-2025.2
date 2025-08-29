EXTERNAL endOrder()
EXTERNAL leaveCounter()

=== Good1 ===
Only matcha could make this place more perfect. You should make a matcha biscuit!
~ endOrder()
-> END

=== Good2 ===
This is so good. If only the girls were here to taste this...
~ endOrder()
-> END

=== Good3 ===
Heavenly. I would put down my feminist literature for this. Only for a while.
~ endOrder()
-> END

=== Okay ===
Pretty good.
~ endOrder()
-> END

=== Bad ===
Ugh. Not even my cat, Matcha, would eat this.
~ endOrder()
-> END

=== Special1 ===
# 1
# 1
# 7
I want an all-pink biscuit-cream-topping combo, but with no fruit toppings. I'll call this the Feminism Special!
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A strawberry biscuit with strawberry whipped cream and strawberry jam.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
    
=== Special2 ===
# 2
# 0
# 5
My favorite singer, Clairo, loves grapes. ...Since you don't have that, I'll have the closest thing to grapes - blueberries - on top of a chocolate biscuit and vanilla whipped cream!
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A chocolate biscuit with vanilla whipped cream and blueberries.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop

=== Special3 ===
# 1
# 99
# 2
I heard chocolates and bananas are good for period cramps. No whipped cream! I'm doing my part in the fight against period cramps!
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop
= loop
A banana on top of a chocolate biscuit.
+ [Okay]
    ~ leaveCounter()
    -> END
+ [What?]
    -> loop