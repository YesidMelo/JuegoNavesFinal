using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface DatabaseRepository {
    Task<bool> createDataBase(string applicationDataPath);
}
public class DatabaseRepositoryImpl : DatabaseRepository
{
    private DatabaseLocalDatasource database = DatabaseLocalDatasourceImpl.getInstance();

    public async Task<bool> createDataBase(string applicationDataPath) => await database.createDatabase(applicationDataPath: applicationDataPath);
}