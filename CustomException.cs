
    public class CustomException
    {
        
            public class InvalidDataException : Exception
            {
                public InvalidDataException() : base("Invalid Data")
                { }
                public InvalidDataException(string message) : base(message)
                { }

            }

            public class OverCapacityException : Exception
            {
                public OverCapacityException() : base("Capacity is over limit")
                { }
                public OverCapacityException(string m) : base(m)
                { }
            }
            public class EmptyStructureException : Exception
            {
                public EmptyStructureExceptionException() : base("Structure not defined")
                { }
                public EmptyStructureException(string m) : base(m)
                { }
            }



   }
