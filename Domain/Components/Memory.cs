namespace Domain.Components;

public abstract class Memory
{
    public int SizeGb { get; }

    protected Memory(int sizeGb)
    {
        SizeGb = sizeGb;
    }
}

public class Ram : Memory
{
    public Ram(int sizeGb) : base(sizeGb) 
    {
    
    }
}

public class Storage : Memory
{
    public Storage(int sizeGb) : base(sizeGb) 
    { 
    
    }
}