## Refactoring a complex conditional logic using the Chain of Responsibility pattern.
This sample is about a refactoring I did in a "real life work" project. The original code has been simplified a little bit and distorted so I don't risk leaking any business secrets.

So let's pretend that this code is used to calculate a value that will be used to make further decisions in a clinical decision support system used by medical doctors.
To figure out this value (called Decision Support Factor, DSF) the code goes through a series of conditionals checking if certain rules are met or not.
The original implementation is found in the <b><i>Before</i> folder</b> and the refactored implementation in the folder called <b><i>After</i></b>.

My implementation of the <i>Chain Of Responsibility</i>, in it's simplicity, consists of an interface that declares what is common for a set of concrete handlers (aka rules). These rules are different classes that hold the logic for the different conditionals needed to calculate the DSF.

At first glance this refactoring might look like a lot more code to write for the same result. Which it is. So why do we choose to refactor something like this?

One of the reasons I refactored this code was that it quite often was subject to change because stakeholders changed the formula for different reasons. Everytime it changed the code got more complex, cyclomatic complexity in the conditionals increased and the whole method got harder to overview. In other words, it started to "smell".

So, the refactoring (even though it adds more code) gives us cleaner code that is very easy to change or extend without having to violate SRP or Open/Close principles.

Some might argue that the method was much easier to interpret and understand when you could look at it in its entirety in the original solution. This might be partly true in this simplified version. But, if you have a look at how I construct the chain of rules/handlers it really gives a good overview which simplifies understanding of the code for any potential other programmers not familiar with it.
