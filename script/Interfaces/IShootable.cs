public interface IShootable
{
    /// <summary>
    /// call to shoot the weapon 
    /// </summary>
    public void Shoot(float damage);
}

public interface ITriggerable
{
    /// <summary>
    /// When Trigger starts
    /// </summary>
    public void Trigger();
    
    /// <summary>
    /// When Trigger ends
    /// </summary>
    public void Release();
}

public interface IExploable
{
    /// <summary>
    /// eploxes
    /// </summary>
    public void Explode();
}