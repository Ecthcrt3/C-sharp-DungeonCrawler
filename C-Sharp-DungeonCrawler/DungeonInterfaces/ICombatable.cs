namespace DungeonInterfaces
{
    public interface ICombatable
    {
        int MakeAttack();
        int DoDamage();
        int GetAC();
        void TakeDamage(int dmg);
    }
}