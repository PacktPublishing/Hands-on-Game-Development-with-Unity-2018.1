using MyCompany.GameFramework.ResourceSystem.Interfaces;

public interface IWeapon
{
    IResource Ammo { get; }
    bool Shoot();
    void Reload();
}
