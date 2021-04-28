namespace gameSystem.Bank
{
    public class BankInteractor : Interactor
    {
        private static BankRepository _repository;

        public int Coins => _repository.Coins;

        public BankInteractor(BankRepository repository)
        {
            _repository = repository;
        }

        public bool IsEnougthCoins(int value)
        {
            return Coins >= value;
        }
        
        public void AddCoins(object sender,int value)
        {
            _repository.Coins += value;
            _repository.Save();
        }
        
        public void Spend(object sender,int value)
        {
            _repository.Coins -= value;
            _repository.Save();
        }
        
    }
}
