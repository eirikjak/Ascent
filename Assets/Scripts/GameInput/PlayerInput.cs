namespace Assets.Scripts.GameInput
{
    abstract class PlayerInput
    {
        protected readonly IPlayer Player;

        protected PlayerInput(IPlayer player)
        {
            Player = player;
        }
        public abstract void Update();
    }
}
