namespace DungeonInterfaces
{
    public interface ICombatable
    {
        int MakeAttack();
        int DoDamage();
        byte GetAC();
        void TakeDamage(int dmg);
    }
}