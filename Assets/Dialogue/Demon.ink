// EXTERNAL finger()
// EXTERNAL end()
// EXTERNAL hand()

-> Day2
=== Day1 ===
Oh, hello.
You seem to be in trouble.
Need help?
+ [Yes!]
+ [I can manage.]
    Hehe, you should hear me out.
- I'll give you all the money you need. All $400 of it.
In return...I just need a little favor.
+ [What is it?]
- It's very little. Something you won't miss.
A finger. # red
+ [What?!]
- Oh, come on. Don't be like that. # normal
It won't hurt at all. 
Besides, you need the money, don't you?
It's just a finger. How often do you use all five of them, anyway?
Really, it'll be fine.
Here, I'll even let you choose which one.
+ [Okay...]
    Perfect.
    //~ finger()
    -> END
+ [No!]
    You know that's not what you want.
    If you don't get that $400, you'll have to go back to your boring life, staring at a computer screen all day, doing boring work no one cares about.
    Don't you want to live your dream?
    ->stitch1

= stitch1
 + [...I suppose.]
    Don't worry. I'm here to help.
    //~ finger()
    -> END
+ [No.]
    Well, I can't stop you.
    //~ end()
    -> END

=== Day2 ===
Hello again, friend.
You remember me, don't you? I'm sure you don't regret the deal we made.
Oh? I didn't give you $400?
Well, you know, I can't just give you such a large sum of money at once.
+ [Really?]
+ [You liar!]
- Come on, don't be like that.
I promise, I'll help you out.
In return, you just need to...well...
Lend a hand. # red
It won't hurt. Really, you'll see that it's worth it. # normal
Won't you lend me a helping hand?
+ [Fine...]
    Perfect.
    //~ hand()
    -> END
+ [Not this again.]
    You can trust me. It's not like I didn't give you money last time, right?
    Do you really want to go back to your old life? When people yelled at you for things you didn't do, when your stupid boss micromanaged everything you did?
    Don't you want to continue running your lovely biscuit shop?
    -> stitch1
=stitch1
+ [I guess...]
    You won't regret this.
    //~ hand()
    -> END
+ [No.]
    Well, I can't stop you.
    //~ end()
    -> END
-> END