using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoubleBuffer
{
    //Illustrate the Double Buffer game programming pattern by generating a cave pattern and display it on a plane
    //The idea is based on this Unity tutorial https://www.youtube.com/watch?v=v7yyZZjF1z4 
    public class GameController : MonoBehaviour
    {
        public MeshRenderer displayPlaneRenderer;

        [Range(0, 1)]
        public float randomFillPercent;

        //The double buffer
        //Notice that the Unity tutorial is using one buffer, which works but is not entirely correct because it results in a strong diagonal bias
        //Someone in the comment section is also complaining about it, so this is the correct version
        //Is storing int where 1 is wall and 0 is cave
        private int[,] bufferOld;
        private int[,] bufferNew;

        private const int GRID_SIZE = 100;

        private const int SIMULATION_STEPS = 20;

        private float PAUSE_TIME = 1f;

        private void Start()
        {
            bufferOld = new int[GRID_SIZE, GRID_SIZE];
            bufferNew = new int[GRID_SIZE, GRID_SIZE];

            // Initializing the Random libraries state.
            Random.InitState(33);

            for(int x = 0; x < GRID_SIZE; x++)
            {
                for (int y = 0; y < GRID_SIZE; y++)
                {
                    if (x == 0 || x == GRID_SIZE - 1 || y == 0 || y == GRID_SIZE - 1)
                    {
                        bufferOld[x, y] = 1;
                    }
                    else
                    {
                        bufferOld[x, y] = Random.Range(0f, 1f) < randomFillPercent ? 1 : 0;
                    }
                }
            }

            //For testing that init is working
            //GenerateAndDisplayTexture(bufferOld);

            //Start the simulation
            StartCoroutine(SimulateCavePattern());
        }

        private IEnumerator SimulateCavePattern()
        {
            for (int i = 0; i < SIMULATION_STEPS; i++)
            {
                // Calculate new values
                RunCellularAutomataStep();

                // Generate texture and display it on plane
                GenerateAndDisplayTexture(bufferNew);

                // Swap the buffers
                (bufferOld, bufferNew) = (bufferNew, bufferOld);

                yield return new WaitForSeconds(PAUSE_TIME);
            }
            Debug.Log("Simulation completed!");
        }

        //Generate caves by smoothing the data
        //Remember to always put the new results in bufferNew and use bufferOld to do the calculations
        private void RunCellularAutomataStep()
        {
            for (int x = 0; x < GRID_SIZE; x++)
            {
                for (int y = 0; y < GRID_SIZE; y++)
                {
                    if (x == 0 || x == GRID_SIZE - 1 || y == 0 || y == GRID_SIZE - 1)
                    {
                        bufferNew[x, y] = 1;

                        continue;
                    }

                    // Use bufferOld to get wall count
                    int surroundingWalls = GetSurroundingWallCount(x, y);

                    if (surroundingWalls > 4)
                    {
                        bufferNew[x, y] = 1;
                    }
                    else if (surroundingWalls == 4)
                    {
                        bufferNew[x, y] = bufferOld[x, y];
                    }
                    else
                    {
                        bufferNew[x, y] = 0;
                    }
                }
            }
        }

        // Given a cell, how many of surrounding cells are walls?
        private int GetSurroundingWallCount(int cellX, int cellY)
        {
            int wallCounter = 0;

            for(int neighborX = cellX - 1; neighborX <= cellX + 1; neighborX++)
            {
                for (int neighborY = cellY - 1; neighborY <= cellY + 1; neighborY++)
                {
                    // We never look at border cell so no need to check if outside grid

                    // No need to check ourselves
                    if (neighborX == cellX && neighborY == cellY)
                    {
                        continue;
                    }
                    // Check touching wall
                    if(bufferOld[neighborX, neighborY] == 1)
                    {
                        wallCounter++;
                    }
                }
            }
            return wallCounter;
        }

        // Generate a black or white texture depending if pixel is cave or wall
        // Displays the texture on a plane
        private void GenerateAndDisplayTexture(int[,] data)
        {
            // We are constantly creating new textures, so we have to delete old textures or the memory will keep increasing
            // The garbage collector is not collecting unused textures
            Resources.UnloadUnusedAssets();
            // We could also use 
            // Destroy(displayPlaneRenderer.sharedMaterial.mainTexture);
            // Or reuse the same texture

            // These two arrays are always the same so we could init them once at the start
            Texture2D texture = new Texture2D(GRID_SIZE, GRID_SIZE);

            texture.filterMode = FilterMode.Point;

            Color[] textureColors = new Color[GRID_SIZE * GRID_SIZE];

            for (int y = 0; y < GRID_SIZE; y++)
            {
                for(int x = 0; x < GRID_SIZE; x++)
                {
                    textureColors[y * GRID_SIZE + x] = data[x, y] == 1 ? Color.black : Color.white;
                }
            }

            texture.SetPixels(textureColors);

            texture.Apply();

            displayPlaneRenderer.sharedMaterial.mainTexture = texture;
        }
    }
}