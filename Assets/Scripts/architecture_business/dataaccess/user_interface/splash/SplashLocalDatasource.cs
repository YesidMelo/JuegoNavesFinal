using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface SplashLocalDatasource {
    Task<ResultApisDBs> loadElementsGame();
}

public class SplashLocalDatasourceImpl : SplashLocalDatasource
{
    //static variables
    private static SplashLocalDatasourceImpl instance;

    //static methods
    public static SplashLocalDatasourceImpl getInstance() {
        if (instance == null) {
            instance = new SplashLocalDatasourceImpl();
        }
        return instance;
    }

    public async Task<ResultApisDBs> loadElementsGame()
    {
        return await Task<ResultApisDBs>.Run( async () => {
            await Task.Delay(Constants.timeAwaitSplash);
            Success<bool> currentResult = new Success<bool>();
            currentResult.data = true;
            return currentResult;
        });
    }
}
