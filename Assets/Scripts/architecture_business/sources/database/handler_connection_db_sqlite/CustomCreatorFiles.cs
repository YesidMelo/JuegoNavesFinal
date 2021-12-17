using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public interface CustomCreatorFiles {
    Task<bool> createFile(
        string rootDir, 
        string fileName, 
        string extentionFile, 
        string nameDir = ""
    );
}

public class CreatorFilesImpl : CustomCreatorFiles {

    //static variables
    private static CreatorFilesImpl instance;

    //static methods
    public static CreatorFilesImpl getInstance() {
        if (instance == null) {
            instance = new CreatorFilesImpl();
        }
        return instance;
    }

    private const string messageRootDirNotFound = "root directory not found";
    private const string messageNameFileNotFound = "name file not found";
    private const string messageExtentionFileNotFound = "extention file not found";

    private CreatorFilesImpl() { }

    public async Task<bool> createFile(
        string rootDir, 
        string fileName, 
        string extentionFile, 
        string nameDir = ""
    )
    {
        try
        {
            if (!createDir(rootDir: rootDir, nameDir: nameDir)) return false;
            if (!createFileIO(rootDir: rootDir, nameDir: nameDir, fileName: fileName, extentionName: extentionFile)) return false;
            return true;
        }
        catch (Exception e) {
            Debug.LogError(e.Message);
            return false;
        }
    }

    //private methods
    private bool createDir(string rootDir, string nameDir) 
    {
        if (string.IsNullOrEmpty(rootDir)) throw new Exception("root directory not found");
        if (string.IsNullOrEmpty(nameDir)) return true;

        string element = string.Format(
            "{0}/{1}",
            rootDir,
            nameDir
        );

        if (Directory.Exists(element)) return true;

        try
        {
            Directory.CreateDirectory(element);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            return false;
        }
        return true;
    }

    private bool createFileIO(
        string rootDir,
        string nameDir,
        string fileName,
        string extentionName
    )
    {
        if (string.IsNullOrEmpty(rootDir)) throw new Exception(messageRootDirNotFound);
        if (string.IsNullOrEmpty(fileName)) throw new Exception(messageNameFileNotFound);
        if (string.IsNullOrEmpty(extentionName)) throw new Exception(messageExtentionFileNotFound);

        string pathFile = string.Format(
            "{0}/{1}/{2}.{3}",
            rootDir,
            string.IsNullOrEmpty(nameDir)?"":nameDir,
            fileName,
            extentionName
        );

        if (File.Exists(path: pathFile)) return true;

        try
        {
            File.Create(pathFile);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            return false;
        }
    }

}