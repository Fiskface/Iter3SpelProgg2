using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectScripts
{
    [CreateAssetMenu(fileName = "MoneyChange", menuName = "ScriptableObjects/Money Gain")]
    public class MoneyChangeObject : ScriptableObject
    {
        public UnityAction<MoneyChangeObject, int> onMoneyChange = delegate {};

        public void MoneyChange(int money)
        {
            onMoneyChange(this, money);
        }
    }
}
