namespace Outback.Combat
{
    public class CardSelectOption : ICombatOption
    {
        private readonly CardSelector _selector;

        public CardSelectOption(CardSelector selector)
        {
            _selector = selector;
        }

        public void Execute()
        {
            _selector.Open();
        }
    }
}