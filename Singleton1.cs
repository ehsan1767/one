using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingeltonAbstractClass
{
    public sealed class Singleton1 : Change
    {
        private Singleton1() { }
        private static Singleton1 _instance = null;
        private static readonly object Instancelock = new object();
        public static Singleton1 GetInstance(string value)
        {
            if (_instance == null)
            {
                lock (Instancelock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton1();
                        _instance.Value = value;
                    }
                }
            }
            return _instance;
        }

        public string Value { get; set; }

        public override string ChangeValueInstance()
        {
            _instance.Value = Console.ReadLine();
            return _instance.Value;
        }
        
    }
}

    