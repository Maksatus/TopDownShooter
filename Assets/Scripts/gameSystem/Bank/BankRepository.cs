using UnityEngine;

namespace gameSystem.Bank
{
    public class BankRepository : Repository
    {
        private const string KEY = "BANK_KEY";
        
        public int Coins { get; set; }
        
        public override void Initialize()
        {
            this.Coins = PlayerPrefs.GetInt(KEY, 0);
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(KEY,this.Coins);
        }
    }
}   