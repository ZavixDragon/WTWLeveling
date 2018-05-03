namespace DesignPatterns
{
    //Signleton pattern is about ensuring there is only one copy of a class around
    public class Singleton
    {
        //There is two different common ways people provide a singleton accessor
        //The first one is through a property
        private static Singleton _instance;
        public static Singleton Instance => _instance ?? (_instance = new Singleton());
        //The second is through a method
        public static Singleton GetInstance()
        {
            return _instance ?? (_instance = new Singleton());
        }

        //So first the reason why you would want to use this, let's imagine you had a logger that for write speed kept a file open. 
        //Because it has the file handle if you tried to use a second logger to log to the same file it would not work
        //Here's where you could use a singleton logger to ensure no file lock would be competed for
        //But there is a cost to these singletons they ensure anyone who uses them has a concrete dependency on it
        //This makes it hard to say give a fake logger to a class for testing.
        //This also makes it hard to add functionality to the singleton without violating the Open/Close Principle.
        //There is 2 ways to mitigate this problem. 
        //One way, you can just require the singleton in the constructor and then only the people who get the instance will know its a singleton
        //Another way is with Monostate Pattern which is in the same family as Singleton Pattern
    }

    //There are two ways to do monostate pattern the first is to keep an instance internally
    public class MonoStateWithInternalInstance
    {
        //Here is the instance that is newed up once
        private static MonoStateWithInternalInstance _instance = new MonoStateWithInternalInstance();

        //What ever properties you would like to expose you would need to make a private copy for
        private string _property;
        //Because the getter and setter of the property will interact with the instance
        public string Property
        {
            get => _instance._property;
            set => _instance._property = value;
        }

        //All your public methods will call the instances equivalent private method
        public void DoIt()
        {
            _instance.DoTheThing();
        }

        //this is only ever called on the single instance and can therefore trust and manipulate the state it contains
        private void DoTheThing()
        {
            //code and such
        }

        //Now this class can be used like any normal class but only internally does it actually reveal he is a singleton
    }

    //When you don't need to worry about timing sush as singleton Queues and you only the data to be shared to act correctly in all instances
    public class MonoStateWithStaticState
    {
        //All you do is keep all the state in private statics
        private static string _property;

        public string Property
        {
            get => _property;
            set => _property = value;
        }
        //And as you can see this ensures only one copy of the data will exist. 
        //This one is simpler to read so it's useful when you are doing Caches as the primarily want singleton cache data for speed
    }

    //there is one danger involved in using Monostate, 
    //programmers who do not know its Monostate do not expect setting a property will affect all other instances of the object.
}
