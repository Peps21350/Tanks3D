using System;
using UnityEngine;

public class InterferenceGeneration : MonoBehaviour
{
        [SerializeField] private GameObject _prefabСollapsingWall;
        [SerializeField] private GameObject _prefabNotСollapsingWall;
        private GameObject _createdWalls;
        float xOffset = 0.882f;
        float zOffset = 0.764f;

        private void Start()
        {
                //GenerationInterference();
        }

        private void GenerationInterference()
        {
                //_createdWalls = Instantiate(_prefabNotСollapsingWall, new Vector3(-2.5f, 1.77f, -290 + i * 15), Quaternion.identity) as GameObject;
                
                //стєнки по краях, одна сторона 0.0 \ 1.0 \ 39.0
                // 39.1 \ 39.2 \ 39.39
                // 0.39 \ 1.39 \ 39.38
                // 0.39 \ 0.38\ 0.0
                
                
                for (int x = 0; x < 1; x++) 
                {
                        for (int y = 0; y < 40; y++) 
                        {

                                float xPos = x * xOffset;
                
                                if( y % 2 == 1 ) 
                                {
                                        xPos += xOffset/2f;
                                }

                                _createdWalls = (GameObject)Instantiate(_prefabСollapsingWall, new Vector3( xPos,0, y * zOffset  ), Quaternion.identity  );
                
                                _createdWalls.name = "HexWall_" + x + "_" + y;
                
                                _createdWalls.GetComponent<Hex>().x = x;
                                _createdWalls.GetComponent<Hex>().y = y;
                
                                _createdWalls.transform.SetParent(this.transform);
                
                                _createdWalls.isStatic = true;

                        }
                }
                
                for (int x = 39; x < 40; x++) 
                {
                        for (int y = 0; y < 40; y++) 
                        {

                                float xPos = x * xOffset;
                
                                if( y % 2 == 1 ) 
                                {
                                        xPos += xOffset/2f;
                                }

                                _createdWalls = (GameObject)Instantiate(_prefabСollapsingWall, new Vector3( xPos,0, y * zOffset  ), Quaternion.identity  );
                
                                _createdWalls.name = "HexWall_" + x + "_" + y;
                
                                _createdWalls.GetComponent<Hex>().x = x;
                                _createdWalls.GetComponent<Hex>().y = y;
                
                                _createdWalls.transform.SetParent(this.transform);
                
                                _createdWalls.isStatic = true;

                        }
                }
                
                for (int x = 0; x < 40; x++) 
                {
                        for (int y = 39; y < 40; y++) 
                        {

                                float xPos = x * xOffset;
                
                                if( y % 2 == 1 ) 
                                {
                                        xPos += xOffset/2f;
                                }

                                _createdWalls = (GameObject)Instantiate(_prefabСollapsingWall, new Vector3( xPos,0, y * zOffset  ), Quaternion.identity  );
                
                                _createdWalls.name = "HexWall_" + x + "_" + y;
                
                                _createdWalls.GetComponent<Hex>().x = x;
                                _createdWalls.GetComponent<Hex>().y = y;
                
                                _createdWalls.transform.SetParent(this.transform);
                
                                _createdWalls.isStatic = true;

                        }
                }
                for (int x = 0; x < 40; x++) 
                {
                        for (int y = 0; y < 1; y++) 
                        {

                                float xPos = x * xOffset;
                
                                if( y % 2 == 1 ) 
                                {
                                        xPos += xOffset/2f;
                                }

                                _createdWalls = (GameObject)Instantiate(_prefabСollapsingWall, new Vector3( xPos,0, y * zOffset  ), Quaternion.identity  );
                
                                _createdWalls.name = "HexWall_" + x + "_" + y;
                
                                _createdWalls.GetComponent<Hex>().x = x;
                                _createdWalls.GetComponent<Hex>().y = y;
                
                                _createdWalls.transform.SetParent(this.transform);
                
                                _createdWalls.isStatic = true;

                        }
                }
                
        }

}