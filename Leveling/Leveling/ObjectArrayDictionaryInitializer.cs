using System.Collections.Generic;

namespace Leveling
{
    public class ObjectArrayDictionaryInitializer
    {
        public void InitializeAllTheThings()
        {
            var initializedObject = new ObjectToBeInitialized { Property = "this is how you initialize properties on an object upon construction" };
            var initializedArray = new string[] {"this", "is", "how", "you", "do", "for", "an", "array"};
            var initializedDictionary = new Dictionary<int, string>
            {
                { 1, "this has a key of 1" },
                { 2, "this be 2" }
            };
        }
    }

    public class ObjectToBeInitialized
    {
        public string Property { get; set; }
    }
}
