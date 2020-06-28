using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    public sealed class Singleton
    {
        private static Singleton instance = null;

        public static Singleton GetSingleton
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }

        private Singleton()
        {

        }
    }
}
