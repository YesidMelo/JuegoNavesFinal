using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface CreateTablesDBUseCase {
    Task<bool> invoke();
}

public class CreateTablesDBUseCaseImpl : CreateTablesDBUseCase
{
    private DatabaseRepository databaseRepository = new DatabaseRepositoryImpl();
    public async Task<bool> invoke() => await databaseRepository.createTablesDataBase();
}