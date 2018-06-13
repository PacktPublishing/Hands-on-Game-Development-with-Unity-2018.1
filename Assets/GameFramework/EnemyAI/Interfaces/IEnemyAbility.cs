using System;

namespace MyCompany.GameFramework.EnemyAI.Interfaces
{
    public interface IEnemyAbility
    {

        event Action onBegin;
        event Action onComplete;
        void UseAbility();
    }
}
