namespace CustomException
{
    public class CustomException:Exception
    {
        
            public class InvalidDataException : Exception
            {
                public InvalidDataException() : base("Invalid Data")
                { }
                public InvalidDataException(string message) : base(message)
                { }

            }

            public class OverCapacityExcption : Exception
            {
                public OverCapacityExcption() : base("Capacity is over limit")
                { }
                public OverCapacityExcption(string m) : base(m)
                { }
            }
            public class EmptyStructureExcption : Exception
            {
                public EmptyStructureExcptionExcption() : base("Structure not defined")
                { }
                public EmptyStructureExcption(string m) : base(m)
                { }
            }



   }
}