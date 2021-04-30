using UnityEngine;

public class ManaSystem
{
    private int _mana;
    private int _manaMax;
        
    public ManaSystem(int manaMax)
    {
        _manaMax = manaMax;
        _mana = manaMax;
    }

    public int GetMana()
    {
        return _mana;
    }

    public void Damage(int damageAmount)
    {
        _mana -= damageAmount;
        if (_mana<0)
        {
            _mana = 0;
        }
    }
    public void Heal(int healAmount)
    {
        _mana += healAmount;
        if (_mana>_manaMax)
        {
            _mana = _manaMax;
        }
    }

    public float GetManaPercent()
    {
        return (float)_mana / _manaMax;
    }
}
