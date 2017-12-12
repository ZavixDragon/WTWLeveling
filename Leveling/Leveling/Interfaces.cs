namespace Leveling
{
    public interface Interfaces
    {
        void ContractMethod();
    }

    public class SimpleInterfaces : Interfaces
    {
        //it is required to implement whatever methods and properties are on the interface 
        public void ContractMethod()
        {
            //do things
        }

        //this is not accessible through the interface
        public void NonContractMethod()
        {
            //do different things
        }
    }

    public class InterfacesConsumer
    {
        private readonly Interfaces _interfaces;

        public InterfacesConsumer(Interfaces interfaces)
        {
            _interfaces = interfaces;
        }

        public void Method()
        {
            //Here any copy of interfaces given will have this method
            _interfaces.ContractMethod();
            
            //where as here even if you got given SimpleInterfaces you can't call anything not on the contract interface as you the class don't know who the implementer is
            //_interfaces.NonContractMethod();
        }
    }
}