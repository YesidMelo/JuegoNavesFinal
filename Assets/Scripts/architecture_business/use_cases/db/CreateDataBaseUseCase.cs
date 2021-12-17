using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface CreateDataBaseUseCase {
    Task<bool> invoke(string applicationDataPath);
}
public class CreateDataBaseUseCaseImpl : CreateDataBaseUseCase
{
    private DatabaseRepository databaseRepository = new DatabaseRepositoryImpl();
    public async Task<bool> invoke(string applicationDataPath) => await databaseRepository.createDataBase(applicationDataPath: applicationDataPath);
}