public class SmallHealthCollectable : CollectableDecorator
{
    public int healthAmount = 10;

    public override void Collect(Entity player)
    {
        //player.IncreaseHealth(healthAmount);
    }
}