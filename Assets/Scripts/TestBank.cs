using gameSystem.Bank;
using UnityEngine;

public class TestBank : MonoBehaviour
{
    private BankRepository _bankRepository;
    private BankInteractor _bankInteractor;
    void Start()
    {
        _bankRepository = new BankRepository();
        _bankRepository.Initialize();

        _bankInteractor = new BankInteractor(_bankRepository);
        _bankInteractor.Initialize();
        
        Debug.Log(_bankInteractor.Coins);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _bankInteractor.AddCoins(this,10);
            Debug.Log(_bankInteractor.Coins);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _bankInteractor.Spend(this,10);
            Debug.Log(_bankInteractor.Coins);
        }
    }
}
