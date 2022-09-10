public class CollisionException : Exception
{
    public CollisionException(): base("Collision detected, invalid movement") {}
}