namespace KORM.Interfaces;

public interface IKustoDatabase
{
    List<T> Fetch<T>(string query) where T : IKustoEntity, new();
}