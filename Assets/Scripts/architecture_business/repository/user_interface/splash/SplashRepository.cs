using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface SplashRepository {
    Task<bool> loadElementsGame();
}

public class SplashRepositoryImpl : SplashRepository
{
    private SplashLocalDatasource localDatasource = SplashLocalDatasourceImpl.getInstance();

    public async Task<bool> loadElementsGame() {
        bool response = false;
        ResultApisDBs res = await localDatasource.loadElementsGame();
        res.safeResponse<bool>(
            actionSuccess: (bool output) => {
                response = output;
            },
            actionError: () => {
                response = false;
            }
        );
        return response;
    }
}