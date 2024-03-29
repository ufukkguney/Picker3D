﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelGenerator : CustomBehaviour
{
    public Level CurrentLevel;
    [SerializeField] private GameObject[] _avaliableObjects;
    [SerializeField] private LayerMask _groundLayer;

    public GameObject[] AvaliableObjects => _avaliableObjects;
    public LayerMask GroundLayer => _groundLayer;

    private Transform mapHolder;
    private Dictionary<string, GameObject> objToNameMap = new Dictionary<string, GameObject>();

    

    public void GenerateLevel(Level level)
    {
        CurrentLevel = level;
        if (CurrentLevel == null)
            return;

        CreateObjMap();
        CreateParentGameObject();
        SpawnTiles();
    }
    private void CreateObjMap()
    {
        objToNameMap = new Dictionary<string, GameObject>();
        foreach (var obj in _avaliableObjects)
        {
            objToNameMap.Add(obj.name, obj);
        }
    }

    private Transform CreateParentGameObject()
    {
        string holderName = "Generated Map";
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == holderName)
                DestroyImmediate(transform.GetChild(i).gameObject);
        }

        mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;
        mapHolder.transform.localPosition = Vector3.zero;
        return mapHolder;
    }

   
    private void SpawnTiles()
    {
        for (int i = 0; i < CurrentLevel.levelObjects.Count; i++)
        {
            CreateObject(CurrentLevel.levelObjects[i]);
        }
    }

    public GameObject CreateNewObject(Level.LevelObjectData data)
    {
        CurrentLevel.levelObjects.Add(data);
        return CreateObject(data);
    }

    private GameObject CreateObject(Level.LevelObjectData data)
    {
        var prefab = GetPrefab(data.prefebName);
        if (prefab == null)
            return null;
        var instance = Instantiate(GetPrefab(data.prefebName), mapHolder);
        instance.transform.localPosition = data.position;
        instance.transform.rotation = data.rotation;
        instance.transform.localScale = data.scale;

        data.instantiatedObject = instance;
        return instance;
    }


    private GameObject GetPrefab(string prefebName)
    {
        if (objToNameMap.TryGetValue(prefebName, out GameObject prefab))
            return prefab;
        Debug.LogError($"Prefab {prefebName} is not avaliable. Check the level generator inspector");
        return null;
    }
}