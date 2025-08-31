EXTERNAL finger()
EXTERNAL end()
EXTERNAL hand()
EXTERNAL eye()
EXTERNAL lifeforce()

=== Day1 ===
Oh, hello, friend.
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
    ~ finger()
    -> END
+ [No!]
    You know that's not what you want.
    If you don't get that $400, you'll have to go back to your boring life, staring at a computer screen all day, doing boring work no one cares about.
    Don't you want to live your dream?
    ->stitch1

= stitch1
 + [...I suppose.]
    Don't worry. I'm here to help.
    ~ finger()
    -> END
+ [No.]
    Well, I can't stop you.
    ~ end()
    -> END

=== Day2 ===
Hello again, friend.
You remember me, don't you? I'm sure you don't regret the deal we made.
Oh? I didn't give you the full $400?
Well, you know, I can't just give you such a large sum of money at once.
+ [Really?]
+ [You liar!]
- Come on, don't be like that.
I promise, I'll help you out. I'm your friend, after all!
In return, you just need to...well...
Lend a hand. # red
It won't hurt. Really, you'll see that it's worth it. # normal
Won't you lend me a helping hand?
+ [Fine...]
    Perfect.
    ~ hand()
    -> END
+ [Not this again.]
    You can trust me. It's not like I didn't give you money last time, right?
    Do you really want to go back to your old life? When people yelled at you for things you didn't do, when your stupid boss micromanaged everything you did?
    Don't you want to continue running your lovely biscuit shop?
    -> stitch1

=stitch1
+ [I guess...]
    You won't regret this.
    ~ hand()
    -> END
+ [No.]
    Well, I can't stop you.
    ~ end()
    -> END
-> END

=== Day3 ===
Hello again, friend.
+ [You again!]
- Don't be so mean! Haven't I helped you? 
I'm getting you to your daily goal, don't you see? $100 per day!
Anyway...
Do you believe in the next place? You know, the place you go to after you die?
+ [Yes.]
+ [Not really.]
- Well, it exists, whether you believe it or not.
I was there once, until they took me...elsewhere.
Somewhere...terrible. I shiver at the very thought!
I'm going off track. I shouldn't be telling you this.
Do you want to reach your next daily goal? I'm happy to help.
It's just going to be, as they say...
...an eye for an eye. # red
You don't need a second eye, anyway. You can see very well with just one. # normal
Have you seen a pirate with an eyepatch? Or just...anyone with an eyepatch?
They go about life perfectly fine. They never complain about losing an eye.
What do you say? I'll give you the usual, of course.
+ [Okay.]
    Perfect.
    ~ eye()
    -> END
+ [I'm not sure...]
    Well...you've come so far already. You're halfway to your $400 goal.
    Don't you remember dreaming of your shop as a kid? You knew exactly where you'd place each table, how you'd greet each customer as they came in...
    This is your destiny.
    Really, losing an eye isn't that bad.
    -> stitch1

=stitch1
+ [Okay...]
    You're doing this for yourself.
    ~ eye()
    -> END
+ [No.]
    Well, I can't stop you.
    ~ end()
    -> END
-> END

=== Day4 ===
Hello again, friend.
This is the last time I'll see you.
+ [Good.]
    So cold...even after all we've been through together.
+ [That's too bad.]
    I'll miss you, too.
- Well...I hate to do this, but I have to ask your for a final favor.
I need your lifeforce.
I'm a demon, after all. We thrive on lifeforce.
I was looking to collect yours after a while, maybe after you ran your shop for a few years.
But I have no choice.
+ [...]
- I really liked you, actually.
I wanted to run my own business too when I was a human, a cake shop.
...What am I saying? You're just so comforting to be around.
...I can't steal your entire future.
I'll let you choose.
You can either go free and lose your shop...
Or I'll take your lifeforce, leaving you with 5 more years.
Please. I need this.
+ [Fine.]
    ...
    Wow. # red
    You humans...sure have a lot of empathy.
    I can't believe that worked on you!
    Enjoy your five years!
    ~ lifeforce()
    -> END
+ [No!]
    ...That's completely understandable.
    Then, I'll throw in something extra.
    In your next life, I'll make sure you get a biscuit shop.
    How about that?
    -> stitch1

=stitch1
+ [Okay.]
    ...
    Wow. # red
    I can't believe that worked on you!
    You humans sure are foolish.
    Enjoy your five years!
    ~ lifeforce()
    -> END
+ [Never.]
    You've doomed me.
    ~ end()
    -> END
-> END