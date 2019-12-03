using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Generator3DCourse : EditorWindow
{

    bool terrain = true;
    bool trees = true;
    bool grass = true;
    bool streets = true;    
    bool egoVehicle = true;
    bool sumoIntegration = true;
    bool sumoGUI = true;
    bool buildings = true;
    bool randomBuildings = true;
    bool polyBuildings = false;
    string buildingsCount ="300";

    bool cameraScriptEnable = false;

    static string sumoFilesPath;
    static string sumoIPPort = "127.0.0.1:33102";

    private egoVehicleOptions op;
    
    public enum egoVehicleOptions
    {
        WASD = 0,
        UDP = 1
    }

    [MenuItem("RtM/Straßennetz generieren")]
    public static void ShowWindow()
    {
        sumoFilesPath = Application.dataPath;
        sumoFilesPath = sumoFilesPath.Substring(0, sumoFilesPath.LastIndexOf("/")); // Assets
        sumoFilesPath = sumoFilesPath.Substring(0, sumoFilesPath.LastIndexOf("/")); // Project Folder
        sumoFilesPath += "/GenerateSimulationForUnity3D/output";
        sumoFilesPath.Replace('/', '\\');
        EditorWindow.GetWindow(typeof(Generator3DCourse));
    }

    void OnGUI()
    {
        GUILayout.Label("Terrain + Street Network Generation Settings", EditorStyles.boldLabel);
        terrain = EditorGUILayout.Toggle("Generate Terrain?", terrain);
        trees = EditorGUILayout.Toggle("Generate Trees?", trees);
        grass = EditorGUILayout.Toggle("Generate Grass?", grass);
        streets = EditorGUILayout.Toggle("Generate Streets?", streets);

        buildings = EditorGUILayout.Toggle("Generate Buildings?", buildings);
        polyBuildings = EditorGUILayout.Toggle("| -> PolyBuildings?", !randomBuildings);
        randomBuildings = EditorGUILayout.Toggle("| -> Random Buildings?", !polyBuildings);
        buildingsCount = EditorGUILayout.TextField("Buildings Count?", buildingsCount);
        GUILayout.Space(16);

        GUILayout.Label("Ego Vehicle Generation Settings", EditorStyles.boldLabel);        
        egoVehicle = EditorGUILayout.BeginToggleGroup("Generate ego Vehicle?", egoVehicle);
        op = (egoVehicleOptions)EditorGUILayout.EnumPopup("egoVehicle integration:", op);
        EditorGUILayout.EndToggleGroup();

        cameraScriptEnable = EditorGUILayout.Toggle("Automatic camera script?", !egoVehicle);

        sumoIntegration = EditorGUILayout.BeginToggleGroup("SUMO interface?", sumoIntegration);
        sumoIPPort = EditorGUILayout.TextField("SUMO IP:Port", sumoIPPort);
        sumoGUI = EditorGUILayout.Toggle("SUMO GUI (console if unchecked)", sumoGUI);
        EditorGUILayout.EndToggleGroup();

        GUILayout.Space(16);
        
        sumoFilesPath = EditorGUILayout.TextField("SUMO Files", sumoFilesPath);
        if (GUILayout.Button("Change Folder Location"))
        {
            sumoFilesPath = EditorUtility.OpenFolderPanel("Chose the folder containing the SUMO files (map.edg.xml, map.nod.xml, map.net.xml, map.rou.xml)", Application.dataPath, "");
            EditorGUILayout.TextField("SUMO Files", sumoFilesPath);
        }
        GUILayout.Space(16);

        GUILayout.Label("Processing", EditorStyles.boldLabel);
        if (GUILayout.Button("Start"))
        {
            // Disable main Camera of new scene
            try
            {
                GameObject mainCamera = GameObject.Find("Main Camera");
                mainCamera.SetActive(false);
            }
            catch (Exception ex)
            {
                MonoBehaviour.print(ex.GetBaseException());
            }

            if (streets)
            {
                EditorUtility.DisplayProgressBar("Generation Progress", "Parsing SUMO files", 0.0f);
                ImportAndGenerate.parseXMLfiles(sumoFilesPath);

                EditorUtility.DisplayProgressBar("Generation Progress", "Generating Street Network", 0.2f);
                ImportAndGenerate.drawStreetNetwork();                
            }            

            if (terrain)
            {
                EditorUtility.DisplayProgressBar("Generation Progress", "Generating Terrain, Trees, Grass", 0.3f);
                ImportAndGenerate.generateTerrain(trees, grass);                
            }

            if (buildings)
            {
                EditorUtility.DisplayProgressBar("Generation Progress", "Generating buildings", 0.4f);
                if(randomBuildings)
                    ImportAndGenerate.generatingBuildings(Convert.ToInt32(buildingsCount));
                else if(polyBuildings)
                    ImportAndGenerate.generatingPolyBuildings();
            }

            EditorUtility.DisplayProgressBar("Generation Progress", "Generating Ego Vehicle", 0.8f);
            Boolean udp = (op.Equals(egoVehicleOptions.UDP) ? true : false);
            if (egoVehicle)
                ImportAndGenerate.insertEgoVehicle(udp);

            EditorUtility.DisplayProgressBar("Generation Progress", "Generating SUMO interface", 0.8f);
            ImportAndGenerate.openSUMOFilesAndsaveTotextFile(sumoIntegration, sumoGUI, sumoIPPort, egoVehicle);

            if (cameraScriptEnable)
            {
                EditorUtility.DisplayProgressBar("Generation Progress", "Generating cameras", 1.0f);
                ImportAndGenerate.addCameraScript();
            }
            

            EditorUtility.ClearProgressBar();

            this.Close();
        }

        GUILayout.Space(16);
        
    }

    void OnInspectorUpdate()
    {
        Repaint();
    }
}



